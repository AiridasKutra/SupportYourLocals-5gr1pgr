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
                Console.WriteLine(data);

                DataList row1 = new DataList();
                row1.Add("sportas", "name");
                row1.Add("miske", "location");
                row1.Add("sportavimas", "sport");
                row1.Add(4.20, "price");
                DataList teams1 = new DataList();
                teams1.Add("as");
                teams1.Add("tu");
                row1.Add(teams1, "teams");
                client.AddEntry(row1, "table1");

                data = client.ExecuteCommand("select from table1");
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
