using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Linq;

namespace Common.Network
{
    class TCPServer
    {
        public class Client
        {
            public Socket sock;
            public uint id;
            public int accountId;
            public ulong vfid;

            public Client() { }

            public Client(Socket sock)
            {
                this.sock = sock;
                id = GenerateId();
                accountId = -1;
                vfid = 0;
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
        public const uint MaxPacketSize = 1024;

        private List<Client> clients;
        private List<Thread> clientThreads;
        private Queue<Packet> incomingPackets;
        private Queue<Packet> outgoingPackets;

        //private Socket listenerSocket;
        private TcpListener listener;
        private Thread listenerThread;

        // Mutexes
        private Mutex mCon;
        private Mutex mPak;

        // Random number generator for id's
        private Random vfidGen;

        public TCPServer(ushort port, int maxClients = 64)
        {
            this.port = port;
            this.maxClients = maxClients;
            running = false;

            clients = new List<Client>();
            clientThreads = new List<Thread>();
            incomingPackets = new Queue<Packet>();
            outgoingPackets = new Queue<Packet>();

            mCon = new Mutex();
            mPak = new Mutex();

            vfidGen = new Random(DateTime.Now.Ticks.GetHashCode());
        }

        private ulong RandomUlong()
        {
            byte[] bytes = new byte[8];
            vfidGen.NextBytes(bytes);
            return BitConverter.ToUInt64(bytes);
        }

        public ulong GenerateVfid()
        {
            int attempt = 0;
            do
            {
                ulong vfid = RandomUlong();
                if (vfid == 0) continue;

                if (clients.FindIndex(c => c.vfid == vfid) == -1)
                {
                    return vfid;
                }
            }
            while (++attempt < 10);
            return 0;
        }

        public ulong GenerateVfid(uint id)
        {
            lock (mCon)
            {
                foreach (var client in clients)
                {
                    if (client.id == id)
                    {
                        client.vfid = GenerateVfid();
                        return client.vfid;
                    }
                }
                return 0;
            }
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

        private int Send(Socket sock, byte[] buffer, int id = -1)
        {
            if (!sock.Connected)
            {
                Console.WriteLine($"Send failed: user {id} socket closed");
                return 0;
            }

            int prefixSent = -1;
            int messageSent = -1;

            try
            {
                prefixSent = sock.Send(BitConverter.GetBytes(buffer.Length));
                messageSent = sock.Send(buffer);
            }
            catch { }

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
            lock (mCon)
            {
                for (int i = 0; i < clients.Count; i++)
                {
                    if (clients[i].id == packet.SenderId)
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
                            if (Send(clients[i].sock, buffer) < 1) return false;
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
                                buffer = new byte[bytesLeft + 4];
                                Buffer.BlockCopy(packetId, 0, buffer, 0, 4);
                                Buffer.BlockCopy(packet.Data, packet.Data.Length - bytesLeft, buffer, 4, bytesLeft);
                                bytesLeft = 0;
                            }
                            if (Send(clients[i].sock, buffer) < 1) return false;
                        }

                        return true;
                    }
                }
            }
            return false;
        }

        public void AddToSendQueue(Packet packet)
        {
            outgoingPackets.Enqueue(packet);
        }

        public bool SendQueue()
        {
            if (outgoingPackets.Count == 0) return false;

            uint clientId = outgoingPackets.Peek().SenderId;
            if (!Send(new Packet
            {
                PacketId = (uint)PacketType.MULTIPLE_PACKETS,
                SenderId = clientId,
                Data = BitConverter.GetBytes((uint)outgoingPackets.Count)
            }))
            {
                outgoingPackets.Clear();
                return false;
            }

            foreach (var packet in outgoingPackets)
            {
                packet.SenderId = clientId;
                if (!Send(packet))
                {
                    outgoingPackets.Clear();
                    return false;
                }
            }

            outgoingPackets.Clear();
            return true;
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

        public int ClientCount()
        {
            return clients.Count;
        }

        public List<Client> GetClients()
        {
            lock (mCon)
            {
                return clients.Select(item => new Client()
                {
                    id = item.id,
                    vfid = item.vfid,
                    accountId = item.accountId
                }).ToList();
            }
        }

        public uint[] GetClientIds()
        {
            lock (mCon)
            {
                uint[] ids = new uint[ClientCount()];
                for (int i = 0; i < clients.Count; i++)
                {
                    ids[i] = clients[i].id;
                }
                return ids;
            }
        }

        public ulong[] GetClientVfids()
        {
            lock (mCon)
            {
                ulong[] vfids = new ulong[ClientCount()];
                for (int i = 0; i < clients.Count; i++)
                {
                    vfids[i] = clients[i].vfid;
                }
                return vfids;
            }
        }

        public void LinkAccount(uint clientId, int accountId)
        {
            lock (mCon)
            {
                foreach (var client in clients)
                {
                    if (client.id == clientId)
                    {
                        client.accountId = accountId;
                        return;
                    }
                }
            }
        }

        public void UnlinkAccount(uint clientId)
        {
            lock (mCon)
            {
                foreach (var client in clients)
                {
                    if (client.id == clientId)
                    {
                        client.accountId = -1;
                        return;
                    }
                }
            }
        }

        public int ThreadCount()
        {
            return clientThreads.Count;
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
                        clientThreads.RemoveAt(i);
                        i--;
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
                        Cleanup();

                        int index = clients.Count;
                        clients.Add(new Client(clientSocket));

                        string message = "\0\0\0\0Connected.";
                        clients[index].sock.Send(BitConverter.GetBytes(message.Length));
                        clients[index].sock.Send(Encoding.ASCII.GetBytes(message));

                        clientThreads.Add(new Thread(new ParameterizedThreadStart(PacketHandler)));
                        clientThreads[index].Start(clients[index]);

                        Console.WriteLine($"New connection: {clientSocket.LocalEndPoint}");
                    }
                    else
                    {
                        string message = "\0\0\0\0Server is full.";
                        clientSocket.Send(BitConverter.GetBytes(message.Length));
                        clientSocket.Send(Encoding.ASCII.GetBytes(message));

                        clientSocket.Close();
                    }
                }
            }
        }

        private void PacketHandler(object clientObj)
        {
            Client client = (Client)clientObj;
            byte[] buffer = new byte[MaxPacketSize];

            List<Packet> packetBufferSplit = new List<Packet>();
            List<Packet> packetBufferMultiple = new List<Packet>();
            uint bufferSizeSplit = 0;
            uint bufferSizeMultiple = 0;

            while (true)
            {
                try
                {
                    // Read length of message
                    byte[] msgLengthBuffer = new byte[4];
                    client.sock.Receive(msgLengthBuffer, 4, SocketFlags.None);
                    int msgLength = BitConverter.ToInt32(msgLengthBuffer);

                    // Read message
                    int byteNum;
                    while (true)
                    {
                        // Only receive full messages
                        byteNum = client.sock.Receive(buffer, msgLength, SocketFlags.Peek);
                        if (byteNum == msgLength)
                        {
                            break;
                        }
                        Thread.Sleep(1);
                    }
                    byteNum = client.sock.Receive(buffer, msgLength, SocketFlags.None);
                    if (byteNum < 4) continue;

                    uint packetId = BitConverter.ToUInt32(buffer, 0);

                    Packet packet = new Packet();
                    packet.PacketId = packetId;
                    packet.SenderId = client.id;
                    packet.Data = new byte[byteNum - 4];
                    Buffer.BlockCopy(buffer, 4, packet.Data, 0, byteNum - 4);

                    // Check for special types
                    if (packetId == (uint)PacketType.SPLIT_PACKETS)
                    {
                        bufferSizeSplit = BitConverter.ToUInt32(packet.Data, 0);
                        continue;
                    }
                    else if (packetId == (uint)PacketType.MULTIPLE_PACKETS)
                    {
                        if (bufferSizeSplit == 0)
                        {
                            bufferSizeMultiple = BitConverter.ToUInt32(packet.Data, 0);
                            continue;
                        }
                    }

                    // Handle split packets
                    if (bufferSizeSplit > 0)
                    {
                        bufferSizeSplit--;
                        packetBufferSplit.Add(packet);

                        // Combine packets
                        if (bufferSizeSplit == 0)
                        {
                            packet = CombinePackets(packetBufferSplit);
                            packetBufferSplit.Clear();
                        }
                        else
                        {
                            continue;
                        }
                    }

                    // Handle multiple packets
                    if (bufferSizeMultiple > 0)
                    {
                        bufferSizeMultiple--;
                        packetBufferMultiple.Add(packet);

                        // Deposit buffer to packet queue
                        if (bufferSizeMultiple == 0)
                        {
                            DepositPacketBuffer(packetBufferMultiple);
                            packetBufferMultiple.Clear();
                        }
                        continue;
                    }

                    // Handle regular packets
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
                // Client sent invalid data
                catch (ArgumentOutOfRangeException)
                {
                    client.sock.Close();
                    return;
                }
                catch
                {
                    client.sock.Close();
                    return;
                }
            }
        }

        private Packet CombinePackets(List<Packet> splitBuffer)
        {
            if (splitBuffer.Count == 0) return null;

            // Combine all packets into 1 and push to the main queue
            Packet combinedPacket = new Packet()
            {
                PacketId = splitBuffer[0].PacketId,
                SenderId = splitBuffer[0].SenderId
            };

            // Calculate total size
            uint combinedSize = 0;
            foreach (Packet packet in splitBuffer)
            {
                combinedSize += (uint)packet.Data.Length;
            }

            // Merge data
            combinedPacket.Data = new byte[combinedSize];
            int currentByte = 0;
            foreach (Packet packet in splitBuffer)
            {
                Buffer.BlockCopy(packet.Data, 0, combinedPacket.Data, currentByte, packet.Data.Length);
                currentByte += packet.Data.Length;
            }

            return combinedPacket;
        }

        private void DepositPacketBuffer(List<Packet> buffer)
        {
            if (buffer.Count == 0) return;

            // Push all packets to the main queue
            lock (mPak)
            {
                foreach (Packet pack in buffer)
                {
                    incomingPackets.Enqueue(pack);
                }
            }
        }
    }
}