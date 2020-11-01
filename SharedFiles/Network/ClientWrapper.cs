using Common;
using Common.Formatting;
using Common.Network;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Common.Network
{
    class ClientWrapper
    {
        private TCPClient client;
        private bool connected;
        
        public ClientWrapper()
        {
            client = new TCPClient();
            connected = false;
        }

        public bool Connect(string ip, ushort port)
        {
            if (client.Connect(ip, port))
            {
                WaitForPacket();
                Packet result = client.GetPacket();
                if (Encoding.ASCII.GetString(result.Data) == "Connected.")
                {
                    connected = true;
                    return true;
                }
                else
                {
                    connected = false;
                    return false;
                }
            }
            else
            {
                connected = false;
                return false;
            }
        }

        public void Disconnect()
        {
            if (Connected())
            {
                client.Disconnect();
            }
        }

        public bool Connected()
        {
            connected = client.Connected();
            return connected;
        }

        public void WaitForPacket()
        {
            if (Connected())
            {
                while (client.PacketCount() == 0)
                {
                    Thread.Sleep(10);
                }
            }
        }

        public DataList ExecuteCommand(string command)
        {
            if (command.Length > 512) return null;
            if (!client.Connected()) return null;

            Packet pack = new Packet
            {
                PacketId = (uint)PacketType.EXECUTE_COMMAND,
                Data = Encoding.ASCII.GetBytes(command)
            };

            client.Send(pack);
            while (client.PacketCount() < 1)
            {
                Thread.Sleep(1);
            }

            Packet packet = client.GetPacket();
            string jsonStr = Encoding.ASCII.GetString(packet.Data);
            return DataList.FromList(Json.ToList(jsonStr));
        }

        public bool AddEntry(DataList entry, string tableName)
        {
            if (!client.Connected()) return false;

            // Remove id attribute
            entry.Remove("id");

            Packet packInfo = new Packet
            {
                PacketId = (uint)PacketType.MULTIPLE_PACKETS,
                Data = BitConverter.GetBytes(2u)
            };

            Packet pack1 = new Packet
            {
                PacketId = (uint)PacketType.ADD_ENTRY_TABLENAME,
                Data = Encoding.ASCII.GetBytes(tableName)
            };

            Packet pack2 = new Packet
            {
                PacketId = (uint)PacketType.ADD_ENTRY_DATA,
                Data = Encoding.ASCII.GetBytes(Json.FromList(DataList.ToList(entry)))
            };

            client.Send(packInfo);
            client.Send(pack1);
            client.Send(pack2);

            return true;
        }

        public bool ModifyEntry(DataList entry, string tableName, int id)
        {
            if (!client.Connected()) return false;

            // Remove id attribute
            entry.Remove("id");

            string rowName = id.ToString();

            Packet packInfo = new Packet
            {
                PacketId = (uint)PacketType.MULTIPLE_PACKETS,
                Data = BitConverter.GetBytes(3u)
            };

            Packet pack1 = new Packet
            {
                PacketId = (uint)PacketType.EDIT_ENTRY_TABLENAME,
                Data = Encoding.ASCII.GetBytes(tableName)
            };

            Packet pack2 = new Packet
            {
                PacketId = (uint)PacketType.EDIT_ENTRY_ROWNAME,
                Data = Encoding.ASCII.GetBytes(rowName)
            };

            Packet pack3 = new Packet
            {
                PacketId = (uint)PacketType.EDIT_ENTRY_DATA,
                Data = Encoding.ASCII.GetBytes(Json.FromList(DataList.ToList(entry)))
            };

            client.Send(packInfo);
            client.Send(pack1);
            client.Send(pack2);
            client.Send(pack3);

            return true;
        }

        public bool RemoveEntry(string tableName, int id)
        {
            if (!client.Connected()) return false;

            string rowName = id.ToString();

            Packet packInfo = new Packet
            {
                PacketId = (uint)PacketType.MULTIPLE_PACKETS,
                Data = BitConverter.GetBytes(2u)
            };

            Packet pack1 = new Packet
            {
                PacketId = (uint)PacketType.REMOVE_ENTRY_TABLENAME,
                Data = Encoding.ASCII.GetBytes(tableName)
            };

            Packet pack2 = new Packet
            {
                PacketId = (uint)PacketType.REMOVE_ENTRY_ROWNAME,
                Data = Encoding.ASCII.GetBytes(rowName)
            };

            client.Send(packInfo);
            client.Send(pack1);
            client.Send(pack2);

            return true;
        }

        public bool SendMessage(string message, int eventId)
        {
            if (!client.Connected()) return false;

            string idString = eventId.ToString();

            Packet packInfo = new Packet
            {
                PacketId = (uint)PacketType.MULTIPLE_PACKETS,
                Data = BitConverter.GetBytes(2u)
            };

            Packet pack1 = new Packet
            {
                PacketId = (uint)PacketType.SEND_MESSAGE_TEXT,
                Data = Encoding.ASCII.GetBytes(message)
            };

            Packet pack2 = new Packet
            {
                PacketId = (uint)PacketType.SEND_MESSAGE_EVENT_ID,
                Data = Encoding.ASCII.GetBytes(idString)
            };

            client.Send(packInfo);
            client.Send(pack1);
            client.Send(pack2);

            return true;
        }
    }
}
