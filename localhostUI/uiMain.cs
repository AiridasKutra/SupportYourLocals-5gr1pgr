using System;
using System.Collections.Generic;
using System.Windows.Forms;
using localhostUI.Classes;
using localhostUI.EventClasses;

namespace localhostUI
{
    public partial class uiMain : Form
    {

        private EventInformation eventsInformation;
        public uiMain()
        {
            InitializeComponent();
        }

        private void MainLoad(object sender, EventArgs e)
        {

            eventsInformation = new EventInformation();

            //Placeholder. Added so some choices would appear in the drop down menu.
            eventsInformation.AddSport("Football");
            eventsInformation.AddSport("Basketball");
            eventsInformation.AddSport("Volleyball");
            eventsInformation.AddSport("Tennis");
            eventsInformation.AddSport("Table Tennis");
            eventsInformation.AddSport("Golf");
            eventsInformation.AddSport("Rugby");
            sportBox.Items.AddRange(eventsInformation.SportTypes.ToArray());
            //sorry if ur eyes r bleeding.
        }

        private void createEvent(object sender, EventArgs e)
        {
            //So like i dunno press button add event to list.
            //i think its pretty simple but i also think peugeots are good who am i to speak;
            if (eventsInformation == null) eventsInformation = new EventInformation();
            Event newEvent = new Event(nameBox.Text, dateBox.Value, sportBox.Text, descriptionBox.Text, (float)priceBox.Value);
            eventsInformation.Events.Add(newEvent);
        }


    }
}

/*Code by Kutra lol.
 * 
            TCPClient client = Program.Client;
            // Wait for response
            while (client.PacketCount() < 1)
            {
                Thread.Sleep(10);
            }
            Packet result = client.GetPacket();
            Console.WriteLine(Encoding.ASCII.GetString(result.Data));

            Packet pack = new Packet
            {
                PacketId = 0,
                SenderId = 0,
                Data = Encoding.ASCII.GetBytes("SELECT FROM table1")
            };

            client.Send(pack);
            while (client.PacketCount() < 1)
            {
                Thread.Sleep(50);
            }
            while (client.PacketCount() > 0)
            {
                Packet packet = client.GetPacket();
                string jsonStr = Encoding.ASCII.GetString(packet.Data, 0, packet.Data.Length);
                DataList data = DataList.FromList(Json.ToList(jsonStr));
                //eventList.View = View.Details;

                /*DataList events = (DataList) data.Get("5");
                DataList teams = (DataList) events.Get("teams");
                DataList players = (DataList) teams.Get("vu");
                int a = 5;}*/
