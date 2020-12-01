using Common;
using Common.Formatting;
using Common.Network;
using Database.TableClasses;
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
            this.clients = new List<uint>();
        }

        public void AddClient(uint client)
        {
            clients.Add(client);
        }

        public void EchoMessage(Message message, int eventId)
        {
            string messageJsonStr = Json.FromList(DataList.ToList(message.ToDataList()));
            string eventIdStr = eventId.ToString();

            // Create packets
            Packet packInfo = new Packet
            {
                PacketId = (uint)PacketType.MULTIPLE_PACKETS,
                Data = BitConverter.GetBytes(2u)
            };

            Packet pack1 = new Packet
            {
                PacketId = (uint)PacketType.SEND_MESSAGE_DATA,
                Data = Encoding.ASCII.GetBytes(messageJsonStr)
            };

            Packet pack2 = new Packet
            {
                PacketId = (uint)PacketType.SEND_MESSAGE_EVENT_ID,
                Data = Encoding.ASCII.GetBytes(eventIdStr)
            };

            RemoveDisconnectedClients();

            // Send packets
            foreach (uint client in clients)
            {
                packInfo.SenderId = client;
                pack1.SenderId = client;
                pack2.SenderId = client;

                server.Send(packInfo);
                server.Send(pack1);
                server.Send(pack2);
            }
        }

        private void RemoveDisconnectedClients()
        {
            List<uint> connectedClients = new List<uint>(server.GetClientIds());

            clients.RemoveAll((id) => !connectedClients.Contains(id));

            /*
            foreach (uint id in clients)
            {
                if (!connectedClients.Contains(id))
                {
                    clients.Remove(id);
                }
            }
            */
        }
    }
}
