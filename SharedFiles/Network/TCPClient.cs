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

        public const uint MaxPacketSize = 1024;

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
            //IPHostEntry ipHost = Dns.GetHostEntry(ip);
            //IPAddress ipAddr = ipHost.AddressList.Length == 1 ? ipHost.AddressList[0] : ipHost.AddressList[1];

            try
            {
                IPAddress ipAddr = IPAddress.Parse(ip);
                IPEndPoint localEndPoint = new IPEndPoint(ipAddr, port);

                // Create socket which listens for new connections
                thisClient = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                thisClient.Connect(localEndPoint);
                if (!thisClient.Connected)
                    return false;
            }
            catch
            {
                return false;
            }

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

        private int Send(Socket sock, byte[] buffer, int id = -1)
        {
            int prefixSent = sock.Send(BitConverter.GetBytes(buffer.Length));
            int messageSent = sock.Send(buffer);

            // Change color to red if something is wrong
            if (prefixSent != 4)
                Console.ForegroundColor = ConsoleColor.Red;
            if (buffer.Length != messageSent)
                Console.ForegroundColor = ConsoleColor.Red;

            Console.Write($"[User {id}] ");
            Console.Write($"|Prefix size: {prefixSent}| ");
            Console.WriteLine($"Sending {buffer.Length} bytes ({messageSent} sent)");

            // Reset color back to white
            Console.ForegroundColor = ConsoleColor.Gray;
            return prefixSent + messageSent;
        }

        public bool Send(Packet packet)
        {
            // Inform server about packet count
            uint packetCount = (uint)Math.Ceiling((uint)packet.Data.Length / (double)(MaxPacketSize - 4));
            byte[] buffer;
            if (packetCount > 1)
            {
                buffer = new byte[8];
                byte[] packTypeBuffer = BitConverter.GetBytes((uint)PacketType.SPLIT_PACKETS);
                byte[] packCountBuffer = BitConverter.GetBytes(packetCount);
                Buffer.BlockCopy(packTypeBuffer, 0, buffer, 0, 4);
                Buffer.BlockCopy(packCountBuffer, 0, buffer, 4, 4);
                if (Send(thisClient, buffer) == 0) return false;
            }

            byte[] packetId = BitConverter.GetBytes(packet.PacketId);

            // Send in parts
            int bytesLeft = packet.Data.Length;
            while (bytesLeft > 0)
            {
                if (bytesLeft + 4 > MaxPacketSize)
                {
                    buffer = new byte[MaxPacketSize];
                    Buffer.BlockCopy(packetId, 0, buffer, 0, 4);
                    Buffer.BlockCopy(packet.Data, packet.Data.Length - bytesLeft, buffer, 4, (int)MaxPacketSize - 4);
                    bytesLeft -= (int)MaxPacketSize - 4;
                }
                else
                {
                    buffer = new byte[packet.Data.Length + 4];
                    Buffer.BlockCopy(packetId, 0, buffer, 0, 4);
                    Buffer.BlockCopy(packet.Data, packet.Data.Length - bytesLeft, buffer, 4, bytesLeft);
                    bytesLeft = 0;
                }
                if (Send(thisClient, buffer) == 0) return false;
            }

            return true;
        }

        public bool Connected()
        {
            if (thisClient == null) return false;
            if (packetHandler == null) return false;

            return thisClient.Connected && packetHandler.IsAlive;
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
            byte[] buffer = new byte[MaxPacketSize];

            List<Packet> packetBuffer = new List<Packet>();
            PacketType bufferUsage = PacketType.NONE;
            uint bufferSize = 0;

            while (true)
            {
                try
                {
                    // Read length of message
                    byte[] msgLengthBuffer = new byte[4];
                    thisClient.Receive(msgLengthBuffer, 4, SocketFlags.None);
                    int msgLength = BitConverter.ToInt32(msgLengthBuffer);

                    // Read message
                    int byteNum;
                    while (true)
                    {
                        // Only receive full messages
                        byteNum = thisClient.Receive(buffer, msgLength, SocketFlags.Peek);
                        if (byteNum == msgLength)
                        {
                            break;
                        }
                        Thread.Sleep(1);
                    }
                    byteNum = thisClient.Receive(buffer, msgLength, SocketFlags.None);
                    if (byteNum < 4) continue;

                    Console.WriteLine($"Receiving {byteNum} bytes (Expected {msgLength})");

                    uint packetId = BitConverter.ToUInt32(buffer, 0);

                    Packet packet = new Packet();
                    packet.PacketId = packetId;
                    packet.SenderId = 0;
                    packet.Data = new byte[byteNum - 4];
                    Buffer.BlockCopy(buffer, 4, packet.Data, 0, byteNum - 4);

                    // Check for special types
                    if (packetId == (uint)PacketType.SPLIT_PACKETS)
                    {
                        bufferUsage = PacketType.SPLIT_PACKETS;
                        bufferSize = BitConverter.ToUInt32(packet.Data, 0);
                        continue;
                    }
                    else if (packetId == (uint)PacketType.MULTIPLE_PACKETS)
                    {
                        bufferUsage = PacketType.MULTIPLE_PACKETS;
                        bufferSize = BitConverter.ToUInt32(packet.Data, 0);
                        continue;
                    }

                    if (bufferSize > 0)
                    {
                        bufferSize--;
                        packetBuffer.Add(packet);

                        // Deposit buffer to packet queue
                        if (bufferSize == 0)
                        {
                            DepositPacketBuffer(packetBuffer, bufferUsage);
                            packetBuffer.Clear();
                        }
                    }
                    else
                    {
                        lock (mPak)
                        {
                            incomingPackets.Enqueue(packet);
                        }
                    }
                }
                // Client disconnected
                catch (ObjectDisposedException)
                {
                    return;
                }
                catch (SocketException)
                {
                    return;
                }
                finally
                {
                    thisClient.Close();
                }
            }
        }

        private void DepositPacketBuffer(List<Packet> buffer, PacketType bufferUsage)
        {
            if (buffer.Count == 0) return;

            switch (bufferUsage)
            {
                case PacketType.MULTIPLE_PACKETS:
                    // Push all packets to the main queue
                    lock (mPak)
                    {
                        foreach (Packet pack in buffer)
                        {
                            incomingPackets.Enqueue(pack);
                        }
                    }
                    break;

                case PacketType.SPLIT_PACKETS:
                    // Combine all packets into 1 and push to the main queue
                    Packet combinedPacket = new Packet()
                    {
                        PacketId = buffer[0].PacketId,
                        SenderId = buffer[0].SenderId
                    };

                    // Calculate total size
                    uint combinedSize = 0;
                    foreach (Packet packet in buffer)
                    {
                        combinedSize += (uint)packet.Data.Length;
                    }

                    // Merge data
                    combinedPacket.Data = new byte[combinedSize];
                    int currentByte = 0;
                    foreach (Packet packet in buffer)
                    {
                        Buffer.BlockCopy(packet.Data, 0, combinedPacket.Data, currentByte, packet.Data.Length);
                        currentByte += packet.Data.Length;
                    }

                    // Push to main queue
                    lock (mPak)
                    {
                        incomingPackets.Enqueue(combinedPacket);
                    }
                    break;

                default:
                    break;
            }
        }
    }
}
