using Common.Network;
using System;
using System.Collections.Generic;
using System.Net.Security;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace localhostUI.Backend
{
    class ChatManager
    {
        private int eventId;
        private ListView chat;

        private TCPClient client;
        private Thread receiverThread;
        private bool connected;

        public ChatManager()
        {
            client = new TCPClient();
            connected = false;
        }

        public void Connect(int eventId, ListView chat)
        {
            this.eventId = eventId;
            this.chat = chat;

            receiverThread = new Thread(new ThreadStart(MessageReceiver));
            receiverThread.Start();
        }

        public bool Connected()
        {
            return connected;
        }

        public void SendMessage(string message)
        {
            Program.Client.SendMessage(message, eventId);
        }

        private void MessageReceiver()
        {
            //string ip = "193.219.91.103";
            //string ip = "doesntexist";
            string ip = "127.0.0.1";
            //ushort port = 2776;
            ushort port = 54000;

            if (client.Connect(ip, port))
            {
                // Wait for packet
                while (client.PacketCount() == 0)
                {
                    Thread.Sleep(10);
                }

                // Confirm connection
                Packet result = client.GetPacket();
                if (Encoding.ASCII.GetString(result.Data) == "Connected.")
                {
                    connected = true;
                }
                else
                {
                    connected = false;
                    return;
                }
            }
            else
            {
                connected = false;
                return;
            }

            // Send request to open chat
            client.Send(new Packet
            {
                PacketId = (uint)PacketType.OPEN_CHAT,
                Data = Encoding.ASCII.GetBytes(eventId.ToString())
            });

            // Wait for packet
            while (client.PacketCount() == 0)
            {
                Thread.Sleep(10);
            }

            // Load previous messages
            List<string> messages = new List<string>();
            while (client.PacketCount() > 0)
            {
                Packet message = client.GetPacket();
                string msgString = Encoding.ASCII.GetString(message.Data);
                messages.Add(msgString);
                Console.WriteLine(msgString);
            }

            // Listen for new messages
            while (true)
            {
                while (client.PacketCount() > 0)
                {
                    Packet packetMessage = client.GetPacket();
                    Packet packetEventId = client.GetPacket();

                    string eventId = Encoding.ASCII.GetString(packetEventId.Data);
                    if (this.eventId.ToString() == eventId)
                    {
                        string message = Encoding.ASCII.GetString(packetMessage.Data);
                        Console.WriteLine(message);
                    }
                }

                Thread.Sleep(10);
            }
        }

        private void AddMessage()
        {

        }
    }
}
