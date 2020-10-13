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
        private SportTypes sportTypes;
        public uiMain()
        {
            InitializeComponent();
        }

        private void MainLoad(object sender, EventArgs e)
        {

            eventsInformation = new EventInformation();
            sportTypes = new SportTypes();

            //  [Placeholder]   . Added so some choices would appear in the drop down menu.
            sportTypes.SportList.Add("Football");
            sportTypes.SportList.Add("Basketball");
            sportTypes.SportList.Add("Volleyball");
            sportTypes.SportList.Add("Tennis");
            sportTypes.SportList.Add("Table Tennis");
            sportTypes.SportList.Add("Golf");
            sportTypes.SportList.Add("Rugby");

            //  [Placeholder]   . Added user adress to locate nearby events in the future.
            userAdressBox.Text = "Vilnius, Didlaukio g. 59";

            sportBox.Items.AddRange(sportTypes.SportList.ToArray());
            removeSportBox.Items.AddRange(sportTypes.SportList.ToArray());
            //sorry if ur eyes r bleeding.
        }

        private void createEvent(object sender, EventArgs e)
        {
            //So like i dunno press button add event to list.
            //i think its pretty simple but i also think peugeots are good who am i to speak;
            if (eventsInformation == null) eventsInformation = new EventInformation();
            Event newEvent = new Event(nameBox.Text, dateBox.Value, sportBox.Text, descriptionBox.Text, eventAdressBox.Text, (float)priceBox.Value);
            eventsInformation.Events.Add(newEvent);
        }

        private void addSport(object sender, EventArgs e)
        {
            if (sportTypes.SportList.Contains(addSportBox.Text))
            {
                MessageBox.Show("You cannot add this sport. It already exists in the list.", "Matching sport found.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            sportTypes.SportList.Add(addSportBox.Text);

            sportBox.Items.Clear();
            removeSportBox.Items.Clear();
            
            sportBox.Items.AddRange(sportTypes.SportList.ToArray());
            removeSportBox.Items.AddRange(sportTypes.SportList.ToArray());
        }

        private void removeSport(object sender, EventArgs e)
        {
            if (!sportTypes.SportList.Contains(removeSportBox.Text))
            {
                MessageBox.Show("You cannot remove this sport. It does not exist in the list.", "No such sport found.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            sportTypes.SportList.Remove(removeSportBox.Text);

            sportBox.Items.Clear();
            removeSportBox.Items.Clear();

            sportBox.Items.AddRange(sportTypes.SportList.ToArray());
            removeSportBox.Items.AddRange(sportTypes.SportList.ToArray());
            removeSportBox.Text = "";
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
                int a = 5;}
*/
