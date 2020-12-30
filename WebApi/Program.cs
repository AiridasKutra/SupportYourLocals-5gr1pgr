using Database;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace WebApiDatabase
{
    public static class Program
    {
        static public DatabaseInterface Database { get; private set; }
        static private MainDbContext context;

        //[DllImport("kernel32.dll", SetLastError = true)]
        //[return: MarshalAs(UnmanagedType.Bool)]
        //static extern bool AllocConsole();

        public static void Main(string[] args)
        {
            //AllocConsole();

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
            else if (preset == "local")
            {
                serverName = "193.219.91.103,14119";
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
                Database = new DatabaseInterface(context);
                //db.Print();
                //mData = new Mutex();

                CreateHostBuilder(args).Build().Run();

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
                        Database = new DatabaseInterface(context);
                    }
                    else
                    {
                        Console.WriteLine($"Unrecognized command");
                    }
                }
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
