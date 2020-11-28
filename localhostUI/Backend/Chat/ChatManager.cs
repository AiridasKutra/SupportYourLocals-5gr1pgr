using Common;
using Common.Formatting;
using Common.Network;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace localhostUI.Backend
{
    class ChatManager
    {
        private int eventId;
        private Panel chat;

        private TCPClient client;
        private Thread receiverThread;
        private bool connected;

        private List<Message> messages;
        private int currentHeight;
        private int currentMessage;

        public ChatManager()
        {
            client = new TCPClient();
            messages = new List<Message>();
            currentHeight = 0;
            currentMessage = 0;
            connected = false;
        }

        public void Connect(int eventId, Panel chat)
        {
            this.eventId = eventId;
            this.chat = chat;

            receiverThread = new Thread(new ThreadStart(MessageReceiver));
            receiverThread.Start();

            connected = true;
        }

        public void Disconnect()
        {
            client.Disconnect();
            connected = false;
        }

        public bool Connected()
        {
            return connected;
        }

        public void SendMessage(Message message)
        {
            Program.Client.SendMessage(message, eventId);
        }

        private void MessageReceiver()
        {
            try
            {
                string ip = "193.219.91.103";
                //string ip = "doesntexist";
                //string ip = "127.0.0.1";
                ushort port = 7099;
                //ushort port = 54000;

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

                // Read confirmation packet
                client.GetPacket();

                // Load previous messages
                while (client.PacketCount() > 0)
                {
                    Packet message = client.GetPacket();
                    string msgString = Encoding.ASCII.GetString(message.Data);
                    messages.Add(new Message(DataList.FromList(Json.ToList(msgString))));
                    Console.WriteLine(messages.Last().Content);
                }

                // Populate the chat window
                foreach (var msg in messages)
                {
                    AddMessage(msg);
                }

                // Listen for new messages
                while (true)
                {
                    if (!client.Connected()) break;

                    while (client.PacketCount() > 0)
                    {
                        Packet packetMessage = client.GetPacket();
                        Packet packetEventId = client.GetPacket();

                        Message message = new Message(DataList.FromList(Json.ToList(Encoding.ASCII.GetString(packetMessage.Data))));
                        string eventId = Encoding.ASCII.GetString(packetEventId.Data);
                        if (this.eventId.ToString() == eventId)
                        {
                            Console.WriteLine(message.Content);
                            AddMessage(message);
                        }
                    }

                    Thread.Sleep(100);
                }
            }
            catch
            {
                return;
            }
        }

        private void AddMessage(Message message)
        {
            string messageText = $"{message.Content}";

            Label msgLabel = new Label();
            msgLabel.AutoSize = false;
            msgLabel.Width = chat.Width - SystemInformation.VerticalScrollBarWidth - 2;

            // Calculate height of label
            SizeF size = TextRenderer.MeasureText(messageText, msgLabel.Font, new Size(msgLabel.Width, 0), TextFormatFlags.WordBreak);
            msgLabel.Height = (int)Math.Ceiling(size.Height);
            msgLabel.Text = messageText;

            // Calculate label position
            msgLabel.Location = new Point(0, currentHeight - chat.VerticalScroll.Value);
            currentHeight += msgLabel.Height;

            // Create alternating label colors
            if (currentMessage % 2 == 0)
            {
                msgLabel.BackColor = Color.FromArgb(245, 245, 245);
            }
            currentMessage++;

            // Add message to chat window
            chat.Invoke((MethodInvoker)delegate ()
            {
                chat.Controls.Add(msgLabel);
                chat.ScrollControlIntoView(msgLabel);
            });
        }
    }
}
