using Common.Network;
using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Network
{
    class ChatMessageSender
    {
        private readonly TCPServer server;

        private List<uint> clients;

        public ChatMessageSender(TCPServer server)
        {
            this.server = server;
        }

        public void AddClient(uint client)
        {
            clients.Add(client);
        }

        public void EchoMessage(string message, string eventId)
        {
            RemoveDisconnectedClients();

            foreach (uint client in clients)
            {
                // Create and send packets
                Packet packInfo = new Packet
                {
                    PacketId = (uint)PacketType.MULTIPLE_PACKETS,
                    SenderId = client,
                    Data = BitConverter.GetBytes(2u)
                };

                Packet pack1 = new Packet
                {
                    PacketId = (uint)PacketType.SEND_MESSAGE_TEXT,
                    SenderId = client,
                    Data = Encoding.ASCII.GetBytes(message)
                };

                Packet pack2 = new Packet
                {
                    PacketId = (uint)PacketType.SEND_MESSAGE_EVENT_ID,
                    SenderId = client,
                    Data = Encoding.ASCII.GetBytes(eventId)
                };

                server.Send(packInfo);
                server.Send(pack1);
                server.Send(pack2);
            }
        }

        private void RemoveDisconnectedClients()
        {
            List<uint> connectedClients = new List<uint>(server.GetClientIds());

            foreach (uint id in clients)
            {
                if (!connectedClients.Contains(id))
                {
                    clients.Remove(id);
                }
            }
        }
    }
}
