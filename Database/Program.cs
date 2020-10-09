using Common;
using Common.Formatting;
using Common.Network;
using Database.Network;
using System;
using System.Text;
using System.Threading;

namespace Database
{
    class Program
    {
        static private Database db;
        static private Mutex mData;

        static void Main(string[] args)
        {
            db = new Database("data.json");
            //db.Print();
            mData = new Mutex();

            TCPServer server = new TCPServer(54000);
            RequestHandler requestHandler = new RequestHandler(db, server);
            requestHandler.Start();

            //Thread serverThread = new Thread(new ThreadStart(RunServer));
            //serverThread.Start();

            while (true)
            {
                string input = Console.ReadLine();
                object result;
                lock (mData)
                {
                    result = db.Execute(input);
                }
                if (result != null)
                    Console.WriteLine(result);
                else
                    Console.WriteLine("Command returned null");
            }
        }

        static void RunServer()
        {
            TCPServer server = new TCPServer(54000);
            if (server.Start())
            {
                while (true)
                {
                    while (server.PacketCount() > 0)
                    {
                        Packet packet = server.GetPacket();
                        string message = Encoding.ASCII.GetString(packet.Data);

                        object result;
                        lock (mData)
                        {
                            result = db.Execute(message);
                        }
                        if (result != null)
                        {
                            string jsonStr = Json.FromList(DataList.ToList(((DataList)result)));
                            server.Send(new Packet
                            {
                                Data = Encoding.ASCII.GetBytes(jsonStr),
                                PacketId = 0,
                                SenderId = packet.SenderId
                            });
                        }
                        else
                        {
                            server.Send(new Packet
                            {
                                Data = Encoding.ASCII.GetBytes("null"),
                                PacketId = 0,
                                SenderId = packet.SenderId
                            });
                        }
                    }
                    Thread.Sleep(10);
                }
            }
            else
            {
                Console.WriteLine("Server start failed");
            }
        }
    }
}
