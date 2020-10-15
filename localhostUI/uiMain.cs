using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Common;
using Common.Formatting;
using localhostUI.Classes;
using localhostUI.EventClasses;
using Newtonsoft.Json;

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

            eventsInformation = LoadEvents();
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
            SaveEvents();


        }
        private void SaveEvents()
        {
            DataList data = new DataList();

            DataList sportTypes = new DataList();
            foreach (string sport in eventsInformation.SportTypes)
            {
                sportTypes.Add(sport);
            }

            DataList events = new DataList();
            foreach (Event ev in eventsInformation.Events)
            {
                events.Add(ev.Name);
                events.Add(ev.Date.ToString());
                events.Add(ev.Sport);
                events.Add(ev.Price);
                events.Add(ev.Description);
                events.Add(ev.Adress);
                
                DataList teams = new DataList();
                foreach (Team team in ev.Team)
                {
                    teams.Add(team.Name);
                    DataList players = new DataList();
                    foreach (Player player in team.TeamPlayers)
                    {
                        players.Add(player.Age);
                        players.Add(player.Name);
                        DataList extraInfo = new DataList();
                        foreach(string info in player.ExtraInfo)
                        {
                            extraInfo.Add(info); //need to check if we will use it as is
                        }
                        players.Add(extraInfo);
                    }
                    teams.Add(players);
                }
                events.Add(teams);
            }

            data.Add(sportTypes);
            data.Add(events);
            

            string jsonstr = Json.FromList(DataList.ToList(data));
            File.WriteAllText("EventsInfo.json", jsonstr);
        }

        private EventInformation LoadEvents()
        {
            string jsonstr = File.ReadAllText("EventsInfo.json");
            
            DataList data = DataList.FromList(Json.ToList(jsonstr));//pagrindinis DataList


            //DataList list = (DataList)data.items[0];
            //pasiemam pirma DataList, kuris turi sportTypes duomenis
            DataList sportTypes = (DataList)data.items[0];
            //pasiemam antra DataList, kuris turi Events duomenis
            DataList events = (DataList)data.items[1];

            List<string> SportTypes = new List<string>();
            List<Event> Events = new List<Event>();

            foreach (ListItem arg in sportTypes)
            {
                SportTypes.Add((string)arg.item);
            }
            string name, teamName, playerName;
            int age;
            DateTime date;
            string sport;
            float price;
            string description;
            string adress;
            List<Team> team = new List<Team>();
            List<Player> player = new List<Player>();
            List<string> extraInfo = new List<string>();
            try
            {
                for (int i = 0; events.items.Count > i; i += 7)
                {
                    name = (string)events.items[i];
                    date = Convert.ToDateTime((string)events.items[i + 1]);//might break
                    sport = (string)events.items[i + 2];
                    price = (float)events.items[i + 3];
                    description = (string)events.items[i + 4];
                    adress = (string)events.items[i + 5];
                    var teee = (DataList)events.items[i + 6];
                    var e1 = new Event(name, date, sport, description, adress, price)
                    {
                        Adress = adress
                    };

                    
                    for(int j = 0; teee.items.Count > j; j += 2)
                    {
                        teamName = (string)teee.items[j];
                        var eventTeam = (DataList)teee.items[j + 1];
                        for (int k = 0; eventTeam.items.Count > k; k += 3)
                        {
                            age = (int)eventTeam.items[k];
                            playerName = (string)eventTeam.items[k + 1];
                            var extraInfo1 = (DataList)eventTeam.items[k + 2];
                            for(int l = 0; extraInfo1.items.Count > l; l++)
                            {
                                extraInfo.Add((string)extraInfo1.items[l]);
                            }
                            var p1 = new Player
                            {
                                Age = age,
                                Name = playerName,
                                ExtraInfo = extraInfo
                            };
                            player.Add(p1);
                        }
                        var p = new Team
                        {
                            Name = teamName,
                            TeamPlayers = player
                        };
                        team.Add(p);
                    }
                    e1.Team = team;
                    Events.Add(e1);
                }
            }
            catch (ArgumentOutOfRangeException e)
            {

                throw e;
            }

            EventInformation eventInformation = new EventInformation();
            eventInformation.SportTypes = SportTypes;
            eventInformation.Events = Events;
            return eventInformation;
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
