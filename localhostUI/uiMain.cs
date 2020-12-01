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
using System.Collections.Generic;
using Common;
using Common.Formatting;
using System.IO;

namespace localhostUI
{
    public partial class UiMain : Form
    {
        private EventInformation eventsInformation;
        private SportTypes sportTypes;
        public List<string> SportList
        {
            get
            {
                return sportTypes.SportList;
            }
        } 

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

            if (Program.UserDataManager.UserData != null && Program.UserDataManager.UserData.Address != null)
            {
                userAdressBox.Text = Program.UserDataManager.UserData.Address;
                usernameBox.Text = Program.UserDataManager.UserData.Username;
            }

            RefreshSportsTable();
            SetUpCurrentEventsTab();
            Program.DraftManager.LoadDrafts();
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

        private void RefreshSportsTable()
        {
            filterSportSelector.Items.Clear();
            for (int i = 0; i < sportTypes.SportList.Count; i++)
            {
                filterSportSelector.Items.Add(sportTypes.SportList[i]);
            }
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
                case 1:
                    SetUpEventManagerTab();
                    break;
                default:
                    break;
            }
        }

        private void ChangeUserAddress(object sender, EventArgs e)
        {
            if(userAdressBox.Text == "" || userAdressBox.Text == null)
            {
                Program.UserDataManager.UserData.Address = "";
                addressResultLabel.Text = "Your address information has been deleted.";
                return;
            } 
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
                Program.UserDataManager.Save();
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
                    Program.UserDataManager.Save();
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

