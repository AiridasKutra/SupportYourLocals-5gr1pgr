﻿using System;
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
using System.Runtime.InteropServices;
using System.Threading;

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

        public bool loggedIn = false;

        int BANNER_HEIGHT = 100;

        public UiMain()
        {
            InitializeComponent();
            DrawBanner();

            overlayPicturePanel.Size = new Size(ClientSize.Width, ClientSize.Height);
            overlayPicturePanel.Location = new Point(0, 0);

            // Disable horizontal scroll in content panel
            contentPanel.HorizontalScroll.Maximum = 0;
            contentPanel.AutoScroll = false;
            contentPanel.VerticalScroll.Visible = false;
            contentPanel.AutoScroll = true;
        }

        public void DrawBanner()
        {
            bannerPanel.Size = new Size(ClientSize.Width, BANNER_HEIGHT);

            // Create banner buttons
            Button currentEventsButton = new Button();
            currentEventsButton.Text = "SYL";
            currentEventsButton.Font = new Font("Arial", 30.0f, FontStyle.Bold);
            currentEventsButton.ForeColor = Color.LightGray;
            currentEventsButton.TextAlign = ContentAlignment.MiddleCenter;
            currentEventsButton.FlatStyle = FlatStyle.Flat;
            currentEventsButton.FlatAppearance.BorderSize = 0;
            currentEventsButton.Location = new Point(0, 0);
            currentEventsButton.Size = new Size(150, BANNER_HEIGHT);
            currentEventsButton.Click += (e, s) =>
            {
                ShowPanel(new MainEventListPanel(this));
            };

            Button eventManagerButton = new Button();
            eventManagerButton.Text = "EVENT MANAGER";
            eventManagerButton.Font = new Font("Arial", 20.0f, FontStyle.Bold);
            eventManagerButton.ForeColor = Color.White;
            eventManagerButton.TextAlign = ContentAlignment.MiddleCenter;
            eventManagerButton.FlatStyle = FlatStyle.Flat;
            eventManagerButton.FlatAppearance.BorderSize = 0;
            eventManagerButton.Location = new Point(150, 0);
            eventManagerButton.Size = new Size(200, BANNER_HEIGHT);
            eventManagerButton.Click += (e, s) =>
            {
                ShowPanel(new MainEventManagerPanel());
            };

            bannerPanel.Controls.Clear();
            bannerPanel.Controls.Add(currentEventsButton);
            bannerPanel.Controls.Add(eventManagerButton);

            if (!loggedIn)
            {
                Button loginButton = new Button();
                loginButton.Text = "LOGIN";
                loginButton.Font = new Font("Arial", 15.0f, FontStyle.Bold);
                loginButton.ForeColor = Color.White;
                loginButton.TextAlign = ContentAlignment.MiddleCenter;
                loginButton.FlatStyle = FlatStyle.Flat;
                loginButton.FlatAppearance.BorderSize = 0;
                loginButton.Location = new Point(ClientSize.Width - 150, 0);
                loginButton.Size = new Size(150, BANNER_HEIGHT);
                loginButton.Click += (e, s) =>
                {
                    ShowPanel(new LoginPanel());
                };
                bannerPanel.Controls.Add(loginButton);
            }
            else
            {
                Button logoutButton = new Button();
                logoutButton.Text = "LOGOUT";
                logoutButton.Font = new Font("Arial", 15.0f, FontStyle.Bold);
                logoutButton.ForeColor = Color.White;
                logoutButton.TextAlign = ContentAlignment.MiddleCenter;
                logoutButton.FlatStyle = FlatStyle.Flat;
                logoutButton.FlatAppearance.BorderSize = 0;
                logoutButton.Location = new Point(ClientSize.Width - 150, 0);
                logoutButton.Size = new Size(150, BANNER_HEIGHT);
                logoutButton.Click += (e, s) =>
                {
                    loggedIn = false;
                    Program.Client.Logout();
                    DrawBanner();
                };
                bannerPanel.Controls.Add(logoutButton);
            }
        }

        private void MainLoad(object sender, EventArgs e)
        {
            ShowPanel(new MainEventListPanel(this));

            // Maximize
            WindowState = FormWindowState.Maximized;

            return;
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

        [DllImport("user32.dll")]
        private static extern bool ShowScrollBar(IntPtr hWnd, int wBar, bool bShow);

        // NEW CODE
        public void ShowPanel(IPanel panelForm)
        {
            panelForm.SetMainRef(this);
            contentPanel.Controls.Clear();
            Panel content = panelForm.GetPanel();
            content.Location = new Point(0, 0);
            content.Visible = true;
            content.Size = new Size(content.Size.Width, Math.Max(content.Size.Height, ClientSize.Height - BANNER_HEIGHT));
            contentPanel.Size = new Size(content.Size.Width, ClientSize.Height - BANNER_HEIGHT);
            contentPanel.Location = new Point((ClientSize.Width - content.Width) / 2, 100);
            contentPanel.Controls.Add(content);
        }

        public void ShowImage(Image image)
        {
            //overlayPicturePanel
            Bitmap background = new Bitmap(ClientSize.Width, ClientSize.Height);
            DrawToBitmap(background, new Rectangle(0, 0, background.Width, background.Height));

            for (int y = 0; y < background.Height; y++)
            {
                for (int x = 0; x < background.Width; x++)
                {
                    var pixel = background.GetPixel(x, y);
                    Color newPixel = Color.FromArgb((int)(pixel.R * 0.5f), (int)(pixel.G * 0.5f), (int)(pixel.B * 0.5f));
                    background.SetPixel(x, y, newPixel);
                }
            }

            using (Graphics g = Graphics.FromImage(background))
            {
                int posX = (background.Width - image.Width) / 2;
                int posY = (background.Height - image.Height) / 2;
                g.DrawImage(image, posX, posY);
            }

            PictureBox pic = new PictureBox();
            pic.Image = background;

            overlayPicturePanel.Controls.Clear();
            overlayPicturePanel.Controls.Add(pic);
            overlayPicturePanel.Visible = true;
        }
        
        private void UiMain_Resize(object sender, EventArgs e)
        {
            try
            {
                int newX = (Size.Width - contentPanel.Controls[0].Width) / 2;
                if (newX < 0)
                {
                    newX = 0;
                }
                contentPanel.Location = new Point(newX, 100);
                contentPanel.Size = new Size(contentPanel.Size.Width, ClientSize.Height - BANNER_HEIGHT);

                DrawBanner();

                overlayPicturePanel.Size = new Size(ClientSize.Width, ClientSize.Height);
            }
            catch { }
        }
    }
}

