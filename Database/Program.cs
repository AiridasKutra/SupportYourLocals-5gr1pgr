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
        static private MainDbContext context;

        static void Main(string[] args)
        {
            string serverName = "";
            string database = "";
            string username = "";
            string password = "";

            Console.Write("Preset: ");
            string preset = Console.ReadLine();
            if (preset == "vuvm")
            {
                serverName = "localhost,54001";
                database = "lh";
                username = "SA";
                password = "Supportyourlocals123";
            }
            else
            {
                Console.Write("Server name:");
                serverName = Console.ReadLine();
                Console.Write("Database name:");
                database = Console.ReadLine();
                Console.Write("Username:");
                username = Console.ReadLine();
                Console.Write("Password:");
                password = Console.ReadLine();
            }

            using (context = new MainDbContext(serverName, database, username, password))
            {
                db = new Database(context);
                //db.Print();
                mData = new Mutex();

                ushort port;
                while (true)
                {
                    Console.Write("Enter the port: ");
                    string portStr = Console.ReadLine();
                    try
                    {
                        port = ushort.Parse(portStr);
                    }
                    catch
                    {
                        Console.WriteLine("Invalid port");
                        continue;
                    }
                    break;
                }

                TCPServer server = new TCPServer(port);
                RequestHandler requestHandler = new RequestHandler(db, server);
                requestHandler.Start();

                //Thread serverThread = new Thread(new ThreadStart(RunServer));
                //serverThread.Start();

                Console.WriteLine("Server started.");
                while (true)
                {
                    string input = Console.ReadLine();
                    if (input == "quit" || input == "exit")
                    {
                        Environment.Exit(0);
                    }
                    else if (input == "restart" || input == "rs")
                    {
                        context.Dispose();
                        context = new MainDbContext(serverName, database, username, password);
                        db = new Database(context);
                    }
                    else if (input == "clients")
                    {
                        Console.WriteLine($"{server.ClientCount()} clients | {server.ThreadCount()} threads");
                        continue;
                    }

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
