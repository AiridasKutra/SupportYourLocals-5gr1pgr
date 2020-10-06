using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Common.Network
{
    class TCPServer
    {
        class Client
        {
            public Socket sock;
            public uint id;

            public Client(Socket sock)
            {
                this.sock = sock;
                id = GenerateId();
            }

            // Code for uniquely generating ids
            private static uint ID_COUNTER = 0;
            private uint GenerateId()
            {
                return ID_COUNTER++;
            }
        }

        public ushort Port { get { return port; } }
        public int MaxClients { get { return maxClients; } }
        public bool Running { get { return running; } }

        private ushort port;
        private int maxClients;
        private bool running;

        private List<Client> clients;
        private List<Thread> clientThreads;
        private Queue<Packet> incomingPackets;

        //private Socket listenerSocket;
        private TcpListener listener;
        private Thread listenerThread;

        // Mutexes
        Mutex mCon;
        Mutex mPak;

        public TCPServer(ushort port, int maxClients = 64)
        {
            this.port = port;
            this.maxClients = maxClients;
            running = false;

            clients = new List<Client>();
            clientThreads = new List<Thread>();
            incomingPackets = new Queue<Packet>();

            mCon = new Mutex();
            mPak = new Mutex();
        }

        public bool Start()
        {
            // Clear state
            clients.Clear();
            clientThreads.Clear();
            incomingPackets.Clear();

            // Create listener class
            listener = new TcpListener(IPAddress.Any, port);
            listener.Start(10);

            // Start thread which accepts and handles new connections
            listenerThread = new Thread(new ThreadStart(ConnectionHandler));
            listenerThread.Start();

            return true;
        }

        public bool Stop()
        {
            // Stop threads
            foreach (var thread in clientThreads)
            {
                thread.Abort();
            }
            listenerThread.Abort();

            // Disconnect clients
            foreach (var client in clients)
            {
                client.sock.Shutdown(SocketShutdown.Both);
                client.sock.Close();
            }

            return true;
        }

        public bool Send(Packet packet)
        {
            lock (mCon)
            {
                for (int i = 0; i < clients.Count; i++)
                {
                    if (clients[i].id == packet.SenderId)
                    {
                        byte[] packetId = BitConverter.GetBytes(packet.PacketId);
                        byte[] buffer = new byte[packet.Data.Length + 4];
                        Buffer.BlockCopy(packetId, 0, buffer, 0, 4);
                        Buffer.BlockCopy(packet.Data, 0, buffer, 4, packet.Data.Length);
                        clients[i].sock.Send(buffer);
                        return true;
                    }
                }
            }
            return false;
        }

        public int PacketCount()
        {
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

        // Goes through all clients and removes closed sockets from array
        public void Cleanup()
        {
            lock (mCon)
            {
                for (int i = 0; i < clients.Count; i++)
                {
                    if (!clients[i].sock.Connected)
                    {
                        clients.RemoveAt(i);
                        clientThreads[i].Abort();
                        clientThreads.RemoveAt(i);
                    }
                }
            }
        }

        private void ConnectionHandler()
        {
            while (true)
            {
                Socket clientSocket = listener.AcceptSocket();

                lock (mCon)
                {
                    if (clients.Count < maxClients)
                    {
                        int index = clients.Count;
                        clients.Add(new Client(clientSocket));
                        clients[index].sock.Send(Encoding.ASCII.GetBytes("\0\0\0\0Connected."));
                        clientThreads.Add(new Thread(new ParameterizedThreadStart(PacketHandler)));
                        clientThreads[index].Start(clients[index]);
                    }
                    else
                    {
                        clientSocket.Send(Encoding.ASCII.GetBytes("\0\0\0\0Server full."));
                        clientSocket.Close();
                    }
                }
            }
        }

        private void PacketHandler(object clientObj)
        {
            Client client = (Client)clientObj;
            byte[] buffer = new byte[8096];

            while (true)
            {
                try
                {
                    int byteNum = client.sock.Receive(buffer);
                    if (byteNum < 4) continue;

                    uint packetId = BitConverter.ToUInt32(buffer, 0);

                    Packet packet = new Packet();
                    packet.PacketId = packetId;
                    packet.SenderId = client.id;
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
                    client.sock.Close();
                    return;
                }
                catch (SocketException)
                {
                    client.sock.Close();
                    return;
                }
            }
        }
    }
}