using System;
using System.Device.Location;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using localhostUI.Classes;
using localhostUI.EventClasses;
using GoogleMaps.LocationServices;
using localhostUI.Classes.LocationClasses;
using localhostUI.Backend;

namespace localhostUI
{
    public partial class UiMain : Form
    {
        private EventInformation eventsInformation;
        private SportTypes sportTypes;
        private (bool isActiveLocation, double latitude, double longitude) coordInfo = (false, 0, 0);

        /*[DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();*/

        public UiMain()
        {
/*            AllocConsole();*/
            GetLocationProperty(ref this.coordInfo);
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
            userAdressBox.Text = "Didlaukio g. 59, Vilnius";

            sportBox.Items.AddRange(sportTypes.SportList.ToArray());
            removeSportBox.Items.AddRange(sportTypes.SportList.ToArray());
            //sorry if ur eyes r bleeding.

            refreshSportsTable();
            LoadMainEvents(new EventOptions());
            Program.DataPool.LoadDrafts();
        }


        //This function allows us to get the device location if it is allowed. 
        //The whole function returns whether we could obtain the location.
        [System.Security.SecurityCritical]
        private bool GetLocationProperty(ref (bool isActiveLocation, double latitude, double longitude) coordInfoRef)
        {
            GeoCoordinateWatcher watcher = new GeoCoordinateWatcher();

            // Do not suppress prompt, and wait 1000 milliseconds to start.
            watcher.TryStart(false, TimeSpan.FromMilliseconds(1000));

            GeoCoordinate coord = watcher.Position.Location;

            if (coord.IsUnknown != true)
            {
                coordInfoRef = (true, coord.Latitude, coord.Longitude);
                Console.WriteLine("Lat: {0}, Long: {1}",
                    coordInfoRef.latitude,
                    coordInfoRef.longitude);
            }
            else
            {
                Console.WriteLine("Unknown latitude and longitude.");
            }
            return coordInfoRef.isActiveLocation;
        }

        //Sport managing functions. All of which names correspond to their function.
        private void CreateEvent(object sender, EventArgs e)
        {
            //So like i dunno press button add event to list.
            //i think its pretty simple but i also think peugeots are good who am i to speak;
            if (eventsInformation == null) eventsInformation = new EventInformation();
            Event newEvent = new Event(nameBox.Text, dateBox.Value, sportBox.Text, descriptionBox.Text, eventAdressBox.Text, (float)priceBox.Value);
            eventsInformation.Events.Add(newEvent);
        }

        private void AddSport(object sender, EventArgs e)
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

            refreshSportsTable();
        }

        private void RemoveSport(object sender, EventArgs e)
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

            refreshSportsTable();
        }

        private void refreshSportsTable()
        {
            comboBox1.Items.Clear();
            for (int i = 0; i < sportTypes.SportList.Count; i++)
            {
                comboBox1.Items.Add(sportTypes.SportList[i]);
            }
        }

        private void SearchCoordinatesAsync(object sender, EventArgs e)
        {

            // [Placeholder] display for funcitonality.
            /*MapPoint coordinates = LocationInformation.LatLongFromAddress(userAdressBox.Text);*/
            MapPoint coordinates = userAdressBox.Text.LatLongFromString();
            Console.WriteLine($"lat: {coordinates.Latitude}\nlong: {coordinates.Longitude}");
            AddressData addressData = LocationInformation.AddressFromLatLong(coordinates.Latitude, coordinates.Longitude);
            Console.WriteLine(addressData.Address);
        
        
        }

        private void SearchMapsBrowser(object sender, EventArgs e)
        {
            LocationInformation.OpenAdressInBrowser(eventAdressBox.Text);
        }

        private void UserSearchMapsBrowser(object sender, EventArgs e)
        {
            LocationInformation.OpenAdressInBrowser(userAdressBox.Text);
        }

        private void menuTabs_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabControl tabControl = (TabControl)sender;
            switch (tabControl.SelectedIndex)
            {
                case 0:
                    LoadMainEvents(new EventOptions());
                    break;
                default:
                    break;
            }
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
