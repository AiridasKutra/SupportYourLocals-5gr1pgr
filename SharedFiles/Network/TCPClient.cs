using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Common.Network
{
    class TCPClient
    {
        private Socket thisClient;
        private Thread packetHandler;

        private Queue<Packet> incomingPackets;

        // Mutexes
        Mutex mPak;

        public TCPClient()
        {
            incomingPackets = new Queue<Packet>();

            mPak = new Mutex();
        }

        public bool Connect(string ip, ushort port)
        {
            // Set up address information
            IPHostEntry ipHost = Dns.GetHostEntry(ip);
            IPAddress ipAddr = ipHost.AddressList[1];
            IPEndPoint localEndPoint = new IPEndPoint(ipAddr, port);

            // Create socket which listens for new connections
            thisClient = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            // Start thread which accepts and handles new connections
            packetHandler = new Thread(new ThreadStart(PacketHandler));
            packetHandler.Start();

            return true;
        }

        public bool Disconnect()
        {
            thisClient.Close();
            return true;
        }

        public bool Send(Packet packet)
        {
            byte[] packetId = BitConverter.GetBytes(packet.PacketId);
            byte[] buffer = new byte[packet.Data.Length + 4];
            Buffer.BlockCopy(packetId, 0, buffer, 0, 4);
            Buffer.BlockCopy(packet.Data, 0, buffer, 4, packet.Data.Length);
            thisClient.Send(buffer);
            return true;
        }

        public int PacketCount()
        {
            if (!packetHandler.IsAlive) return -1;

            lock (mPak)
            {
                return incomingPackets.Count;
            }
        }

        public Packet GetPacket()
        {
            lock (mPak)
            {
                return incomingPackets.Dequeue();
            }
        }

        private void PacketHandler()
        {
            byte[] buffer = new byte[8096];

            while (true)
            {
                try
                {
                    int byteNum = thisClient.Receive(buffer);
                    if (byteNum < 4) continue;

                    uint packetId = BitConverter.ToUInt32(buffer, 0);

                    Packet packet = new Packet();
                    packet.PacketId = packetId;
                    packet.SenderId = 0;
                    packet.Data = new byte[byteNum - 4];
                    Buffer.BlockCopy(buffer, 4, packet.Data, 0, byteNum - 4);

                    lock (mPak)
                    {
                        incomingPackets.Enqueue(packet);
                    }
                }
                // Client disconnected
                catch (ObjectDisposedException)
                {
                    thisClient.Close();
                    Thread.CurrentThread.Abort();
                }
            }
        }
    }
}
