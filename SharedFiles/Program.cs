using Common;
using Common.Network;
using System;

namespace SharedFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This project is not for production");

            ClientWrapper client = new ClientWrapper();
            client.Connect("localhost", 54000);

            if (client.Connected())
            {
                DataList data = client.ExecuteCommand("select from table1");
                Console.WriteLine(data.items[0].ToString());
                Console.WriteLine(data);
            }
            else
            {
                Console.WriteLine("Connection failed");
            }

            client.Disconnect();

            Console.ReadKey();
        }
    }
}
