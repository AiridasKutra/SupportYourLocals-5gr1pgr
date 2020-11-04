using System;
using System.Device.Location;
using System.Windows.Forms;
using localhostUI.Classes;
using localhostUI.EventClasses;
using localhostUI.Classes.LocationClasses;
using localhostUI.Backend;
using localhostUI.Classes.UserInformationClasses;
using System.Drawing;
using GoogleMaps.LocationServices;

namespace localhostUI
{
    public partial class UiMain : Form
    {
        private EventInformation eventsInformation;
        private SportTypes sportTypes;


        /*[DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();*/

        public UiMain()
        {
            InitializeComponent();
        }

        private void MainLoad(object sender, EventArgs e)
        {
            eventsInformation = new EventInformation();
            sportTypes = new SportTypes();
            //  [Placeholder]   . Added so some choices would appear in the drop down menu.
            sportTypes.SportList.Add("Any");
            sportTypes.SportList.Add("Football");
            sportTypes.SportList.Add("Basketball");
            sportTypes.SportList.Add("Volleyball");
            sportTypes.SportList.Add("Tennis");
            sportTypes.SportList.Add("Table Tennis");
            sportTypes.SportList.Add("Golf");
            sportTypes.SportList.Add("Rugby");

            //  [Placeholder]   . Added user adress to locate nearby events in the future.
            Console.WriteLine("USER DATA READ: "+ (Program.UserDataManager.UserData != null));
            Console.WriteLine("USER ADDRESS AVAILABLE: " + (Program.UserDataManager.UserData.Address != null));

            if (Program.UserDataManager.UserData != null && Program.UserDataManager.UserData.Address != null)
            {
                userAdressBox.Text = Program.UserDataManager.UserData.Address;
                usernameBox.Text = Program.UserDataManager.UserData.Username;
            }

            sportBox.Items.AddRange(sportTypes.SportList.ToArray());
            removeSportBox.Items.AddRange(sportTypes.SportList.ToArray());
            //sorry if ur eyes r bleeding.

            refreshSportsTable();
            SetUpCurrentEventsTab();
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
            if (!LocationInformation.IsValidAddress(eventAdressBox.Text) || eventAdressBox.Text.Length == 0)
            {
                eventCreationResultLabel.Text = "Event address is invalid.";
                eventCreationResultLabel.ForeColor = Color.FromArgb(255, 128, 128);
                return;
            }
            
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
            filterSportSelector.Items.Clear();
            for (int i = 0; i < sportTypes.SportList.Count; i++)
            {
                filterSportSelector.Items.Add(sportTypes.SportList[i]);
            }
        }

        private void SearchMapsBrowser(object sender, EventArgs e)
        {
            LocationInformation.OpenAdressInBrowser(eventAdressBox.Text);
        }

        private void UserSearchMapsBrowser(object sender, EventArgs e)
        {
            try
            {
                LocationInformation.OpenAdressInBrowser(userAdressBox.Text);
            }
            catch(FormatException ex)
            {
                MessageBox.Show("Your adress contains characters which are not allowed.\nUnallowed characters: ! * ' ( ) ; : @ & = + $ / ? % # [ ]", "Illegal characters found.",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(ex.Message);
            }
            catch(Exception ex)
            {
                MessageBox.Show("We were unable to open this address in the browser.", "Something went wrong.",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }

        private void menuTabs_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabControl tabControl = (TabControl)sender;
            switch (tabControl.SelectedIndex)
            {
                case 0:
                    SetUpCurrentEventsTab();
                    break;
                default:
                    break;
            }
        }

        private void ChangeUserAddress(object sender, EventArgs e)
        {
            
            if(userAdressBox.Text == Program.UserDataManager.UserData.Address)
            {
                addressResultLabel.Text = "This is already your address.";
                addressResultLabel.ForeColor = Color.Black;
                return;
            }
            //Bug here, after changing it to an invalid address, and then changing it to a valid one, the line still reads invalid.
            if (Program.UserDataManager.UserData.ChangeAddress(userAdressBox.Text))
            {
                addressResultLabel.Text = "Address has been accepted.";
                addressResultLabel.ForeColor = Color.Black;
                userAdressBox.Text = Program.UserDataManager.UserData.Address;
                Program.UserDataManager.SaveToDataPool();
            }
            else
            {
                addressResultLabel.Text = "Address is invalid.";
                addressResultLabel.ForeColor = Color.FromArgb(255, 128, 128);
            }
        }

        private void ChangeUsername(object sender, EventArgs e)
        {
            try
            {
                if(usernameBox.Text == Program.UserDataManager.UserData.Username)
                {
                    usernameChangeResultLabel.Text = "This is already your username";
                    return;
                }
                if (usernameBox.Text.Length < 3)
                {
                    usernameChangeResultLabel.Text = "Username must be atleast 3 characters";
                    usernameChangeResultLabel.ForeColor = Color.FromArgb(255, 128, 128);
                    return;
                }
                else
                {
                    Program.UserDataManager.UserData.Username = usernameBox.Text;
                    Program.UserDataManager.SaveToDataPool();
                    usernameChangeResultLabel.Text = "Username changed successfully";
                    usernameChangeResultLabel.ForeColor = Color.Black;
                }
            }
            catch
            {
                usernameChangeResultLabel.Text = "Something went wrong while changing username";
                usernameChangeResultLabel.ForeColor = Color.FromArgb(255, 128, 128);
            }
        }

        private void SaveToFile(object sender, FormClosingEventArgs e)
        {
            Program.UserDataManager.Save();
        }

        private void FormattAdressButton(object sender, EventArgs e)
        {
            Console.WriteLine(LocationInformation.FormatAddress(userAdressBox.Text));
        }
    }
}

