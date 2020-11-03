using Common;
using Common.Formatting;
using Common.Network;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;

namespace Database.Network
{
    class RequestHandler
    {
        private readonly Database database;
        private readonly TCPServer server;
        private Thread handler;
        private bool threadStop;

        private ChatMessageSender chatMessageSender;

        public RequestHandler(Database database, TCPServer server)
        {
            this.database = database;
            this.server = server;

            this.chatMessageSender = new ChatMessageSender(server);
        }

        public void Start()
        {
            threadStop = false;
            handler = new Thread(new ThreadStart(HandlerThread));
            handler.Start();
        }

        public void Stop()
        {
            threadStop = true;
        }

        private void HandlerThread()
        {
            if (!server.Start())
            {
                Console.WriteLine("Server start failed");
                return;
            }

            while (true)
            {
                if (threadStop) return;

                while (server.PacketCount() > 0)
                {
                    Packet packet = server.GetPacket();

                    switch (packet.PacketId)
                    {
                        case (uint)PacketType.EXECUTE_COMMAND:
                        {
                            ExecuteCommand(packet);
                            break;
                        }
                        case (uint)PacketType.ADD_ENTRY_TABLENAME:
                        {
                            Packet[] packets = new Packet[2];
                            packets[0] = packet;
                            packets[1] = server.GetPacket();
                            AddEntry(packets);
                            break;
                        }
                        case (uint)PacketType.EDIT_ENTRY_TABLENAME:
                        {
                            Packet[] packets = new Packet[3];
                            packets[0] = packet;
                            packets[1] = server.GetPacket();
                            packets[2] = server.GetPacket();
                            EditEntry(packets);
                            break;
                        }
                        case (uint)PacketType.REMOVE_ENTRY_TABLENAME:
                        {
                            Packet[] packets = new Packet[2];
                            packets[0] = packet;
                            packets[1] = server.GetPacket();
                            RemoveEntry(packets);
                            break;
                        }
                        case (uint)PacketType.SEND_MESSAGE_TEXT:
                        {
                            Packet[] packets = new Packet[2];
                            packets[0] = packet;
                            packets[1] = server.GetPacket();
                            SendMessage(packets);
                            break;
                        }
                        case (uint)PacketType.OPEN_CHAT:
                        {
                            Packet[] packets = new Packet[1];
                            packets[0] = packet;
                            OpenChat(packets);
                            break;
                        }
                        default:
                        {
                            break;
                        }
                    }
                }
                Thread.Sleep(10);
            }
        }

        // //////////////// //
        // GENERIC HANDLING //
        // //////////////// //
        private void ExecuteCommand(Packet packet)
        {
            string command = Encoding.ASCII.GetString(packet.Data);
            DataList result = database.Execute(command);
            if (result != null)
            {
                string jsonStr = Json.FromList(DataList.ToList(result));
                server.Send(new Packet
                {
                    Data = Encoding.ASCII.GetBytes(jsonStr),
                    PacketId = (uint)PacketType.DATA,
                    SenderId = packet.SenderId
                });
            }
            else
            {
                server.Send(new Packet
                {
                    Data = Encoding.ASCII.GetBytes("null"),
                    PacketId = (uint)PacketType.TEXT,
                    SenderId = packet.SenderId
                });
            }
        }

        private void AddEntry(Packet[] data)
        {
            string tableName = Encoding.ASCII.GetString(data[0].Data);
            string jsonStr = Encoding.ASCII.GetString(data[1].Data);
            DataList entry = DataList.FromList(Json.ToList(jsonStr));

            if (tableName == "events_full")
            {
                AddEvent(tableName, entry);
            }
        }

        private void EditEntry(Packet[] data)
        {
            string tableName = Encoding.ASCII.GetString(data[0].Data);
            string rowName = Encoding.ASCII.GetString(data[1].Data);
            string jsonStr = Encoding.ASCII.GetString(data[2].Data);
            DataList entry = DataList.FromList(Json.ToList(jsonStr));

            if (tableName == "events_full")
            {
                EditEvent(tableName, rowName, entry);
            }
        }

        private void RemoveEntry(Packet[] data)
        {
            string tableName = Encoding.ASCII.GetString(data[0].Data);
            string rowName = Encoding.ASCII.GetString(data[1].Data);

            if (tableName == "events_full")
            {
                RemoveEvent(tableName, rowName);
            }
        }

        private void SendMessage(Packet[] data)
        {
            string message = Encoding.ASCII.GetString(data[0].Data);
            string eventId = Encoding.ASCII.GetString(data[1].Data);

            SendChatMessage(message, eventId);
        }

        private void OpenChat(Packet[] data)
        {
            chatMessageSender.AddClient(data[0].SenderId);

            // Get messages
            string eventId = Encoding.ASCII.GetString(data[0].Data);
            DataList chatroom = database.Execute($"select from event_chatrooms id {eventId}");
            if (chatroom == null)
            {
                return;
            }

            DataList messages = (DataList)chatroom.items[0];
            messages.Remove("id");

            // Send message count (+1 for a confirmation packet)
            server.Send(new Packet
            {
                PacketId = (uint)PacketType.MULTIPLE_PACKETS,
                SenderId = data[0].SenderId,
                Data = BitConverter.GetBytes((uint)messages.Size() + 1)
            });

            // Send confirmation packet
            server.Send(new Packet
            {
                PacketId = (uint)PacketType.NONE,
                SenderId = data[0].SenderId,
                Data = new byte[1]
            });

            // Send messages
            foreach (var msg in messages)
            {
                server.Send(new Packet
                {
                    PacketId = (uint)PacketType.SEND_MESSAGE_TEXT,
                    SenderId = data[0].SenderId,
                    Data = Encoding.ASCII.GetBytes((string)msg.item)
                });
            }
        }

        // ///////////////////// //
        // SPECIALIZED FUNCTIONS //
        // ///////////////////// //
        private void AddEvent(string tableName, DataList entry)
        {
            entry.Remove("id");

            // Create brief copy
            DataList brief = new DataList(entry);
            brief.Remove("address");
            brief.Remove("description");
            brief.Remove("links");

            database.AddEntry(brief, "events_brief");
            database.AddEntry(entry, "events_full");

            // Create chatroom
        }

        private void EditEvent(string tableName, string rowName, DataList entry)
        {
            entry.Remove("id");

            // Create brief copy
            DataList brief = new DataList(entry);
            brief.Remove("address");
            brief.Remove("description");
            brief.Remove("links");

            database.EditEntry(brief, "events_brief", rowName);
            database.EditEntry(entry, "events_full", rowName);
        }

        private void RemoveEvent(string tableName, string rowName)
        {
            database.RemoveEntry("events_brief", rowName);
            database.RemoveEntry("events_full", rowName);

            // Delete chatroom
        }

        private void SendChatMessage(string message, string eventId)
        {
            if (message.Length == 0) return;

            string timestamp = DateTime.Now.ToString("yyyy-MM-dd|HH:mm:ss");

            DataList messageData = new DataList();
            messageData.Add($"{message}", timestamp);

            // Add message to database
            database.AppendEntry(messageData, "event_chatrooms", eventId);

            // Echo incoming message to all connected users
            chatMessageSender.EchoMessage($"{message}", eventId);
        }
    }
}
