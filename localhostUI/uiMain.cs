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
using System.Runtime.InteropServices;
using System.Threading;
using System.ComponentModel;

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
        PictureBox menuSeparatorPicture2;
        Button accountManagerButton;

        int BANNER_HEIGHT = 100;
        int USER_MENU_WIDTH = 250;

        public UiMain()
        {
            // Auto log in
            string email = Program.UserDataManager.UserData.SavedEmail;
            string password = Program.UserDataManager.UserData.SavedPassword;

            if (email != "" && password != "")
            {
                ulong vfid = Program.Client.Login(email, password);
                if (vfid != 0)
                {
                    Program.Client.SetVfid(vfid);
                    loggedIn = true;
                }
                else
                {
                    Program.UserDataManager.UserData.SavedEmail = "";
                    Program.UserDataManager.UserData.SavedPassword = "";
                    Program.UserDataManager.Save();
                }
            }

            Program.Client.OnTimeout += (s, e) =>
            {
                ShowPanel(new TimeoutPanel());
            };

            InitializeComponent();

            menuSeparatorPicture2 = new PictureBox();
            menuSeparatorPicture2.Image = Properties.Resources.MenuSeparator;
            menuSeparatorPicture2.Location = new Point(0, 90);
            menuSeparatorPicture2.Size = new Size(250, 15);

            accountManagerButton = new Button();
            accountManagerButton.FlatStyle = FlatStyle.Flat;
            accountManagerButton.FlatAppearance.BorderSize = 0;
            accountManagerButton.BackColor = Color.Snow;
            accountManagerButton.Text = "Account manager";
            accountManagerButton.Font = new Font("Arial Rounded MT Bold", 12);
            accountManagerButton.ForeColor = Color.FromArgb(64, 64, 64);
            accountManagerButton.TextAlign = ContentAlignment.MiddleLeft;
            accountManagerButton.Click += accountManagerButton_Click;
            accountManagerButton.Location = new Point(0, 105);
            accountManagerButton.Size = new Size(250, 30);

            // Maximize
            WindowState = FormWindowState.Maximized;

            DrawBanner();
            bannerPanel.BringToFront();

            //overlayPicturePanel.Size = new Size(ClientSize.Width, ClientSize.Height);
            //overlayPicturePanel.Location = new Point(0, 0);

            // Move user menu panel
            //userMenuPanel.Location = new Point(ClientSize.Width - USER_MENU_WIDTH, BANNER_HEIGHT);
            //userMenuPanel.Size = new Size(USER_MENU_WIDTH, 300);

            // Disable horizontal scroll in content panel
            contentPanel.HorizontalScroll.Maximum = 0;
            contentPanel.AutoScroll = false;
            contentPanel.VerticalScroll.Visible = false;
            contentPanel.AutoScroll = true;
        }

        public bool menuOpened = false;
        private DateTime animationStart;

        private void OpenMenu()
        {
            menuOpened = true;
            userMenuPanel.Visible = true;
            animationStart = DateTime.Now;
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += RunAnimation;
            worker.RunWorkerAsync();
        }

        private void CloseMenu()
        {
            menuOpened = false;
            animationStart = DateTime.Now;
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += RunAnimation;
            worker.RunWorkerAsync();
        }

        private void RunAnimation(object sender, EventArgs args)
        {
            while ((DateTime.Now - animationStart).TotalMilliseconds < 150)
            {
                double progress = (DateTime.Now - animationStart).TotalMilliseconds / 150;
                progress = Math.Sin(progress * Math.PI / 2);
                int posX = ClientSize.Width - USER_MENU_WIDTH;
                int posY;
                if (menuOpened)
                {
                    posY = BANNER_HEIGHT - (int)(userMenuPanel.Height * (1 - progress));
                }
                else
                {
                    posY = BANNER_HEIGHT - (int)(userMenuPanel.Height * progress);
                }
                Invoke((Action)(() => userMenuPanel.Location = new Point(posX, posY)));
            }
            if (!menuOpened)
            {
                Invoke((Action)(() => userMenuPanel.Visible = false));
            }
        }

        public void DrawBanner()
        {
            UserAccount acc = Program.UserDataManager.UserAccount;

            bannerPanel.Size = new Size(ClientSize.Width, BANNER_HEIGHT);

            // Create banner buttons
            Button currentEventsButton = new Button();
            currentEventsButton.Text = "SYL";
            currentEventsButton.Font = new Font("Arial", 50.0f, FontStyle.Bold);
            currentEventsButton.ForeColor = Color.LightGray;
            currentEventsButton.TextAlign = ContentAlignment.MiddleCenter;
            currentEventsButton.FlatStyle = FlatStyle.Flat;
            currentEventsButton.FlatAppearance.BorderSize = 0;
            currentEventsButton.Location = new Point(0, 0);
            currentEventsButton.Size = new Size(200, BANNER_HEIGHT);
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
            eventManagerButton.Location = new Point(200, 0);
            eventManagerButton.Size = new Size(200, BANNER_HEIGHT);
            eventManagerButton.Click += (e, s) =>
            {
                ShowPanel(new MainEventManagerPanel());
            };

            bannerPanel.Controls.Clear();
            bannerPanel.Controls.Add(currentEventsButton);
            //bannerPanel.Controls.Add(eventManagerButton);

            if (loggedIn)
            {
                userMenuPanel.Visible = false;

                // Create login info label
                Label loginInfoLabel = new Label();
                loginInfoLabel.Font = new Font("Arial", 11, FontStyle.Italic);
                loginInfoLabel.ForeColor = Color.FromArgb(64, 64, 64);
                loginInfoLabel.AutoSize = false;
                loginInfoLabel.Size = new Size(200, 30);
                loginInfoLabel.Location = new Point(ClientSize.Width - BANNER_HEIGHT - 215, (BANNER_HEIGHT - loginInfoLabel.Size.Height) / 2);
                loginInfoLabel.Text = $"Logged in as {Program.UserDataManager.UserAccount.Username}";
                loginInfoLabel.TextAlign = ContentAlignment.MiddleRight;

                // Create menu panel open/close button
                PictureBox menuButtonPicture = new PictureBox();
                menuButtonPicture.Location = new Point(ClientSize.Width - BANNER_HEIGHT, 0);
                menuButtonPicture.Size = new Size(BANNER_HEIGHT, BANNER_HEIGHT);
                menuButtonPicture.Image = Properties.Resources.UserMenuIcon;
                menuButtonPicture.MouseEnter += (e, s) =>
                {
                    menuButtonPicture.Image = Properties.Resources.UserMenuIconHover;
                };
                menuButtonPicture.MouseLeave += (e, s) =>
                {
                    if (!menuOpened)
                    {
                        menuButtonPicture.Image = Properties.Resources.UserMenuIcon;
                    }
                };
                menuButtonPicture.Click += (e, s) =>
                {
                    if (!menuOpened)
                    {
                        OpenMenu();
                    }
                    else
                    {
                        CloseMenu();
                    }
                };

                bannerPanel.Controls.Add(loginInfoLabel);
                bannerPanel.Controls.Add(menuButtonPicture);

                // Set separator images
                menuSeparatorPicture1.Image = Properties.Resources.MenuSeparator;

                // Add administrator menu options
                if (acc.Can((uint)Permissions.VIEW_ACCOUNTS) ||
                    acc.Can((uint)Permissions.DELETE_ACCOUNTS) ||
                    acc.Can((uint)Permissions.SILENCE_ACCOUNTS) ||
                    acc.Can((uint)Permissions.BAN_ACCOUNTS))
                {
                    menuSeparatorPicture1.Location = new Point(0, 135);
                    logoutButton.Location = new Point(0, 150);

                    userMenuPanel.Controls.Add(menuSeparatorPicture2);
                    userMenuPanel.Controls.Add(accountManagerButton);
                }
                else
                {
                    menuSeparatorPicture1.Location = new Point(0, 90);
                    logoutButton.Location = new Point(0, 105);

                    userMenuPanel.Controls.Remove(menuSeparatorPicture2);
                    userMenuPanel.Controls.Remove(accountManagerButton);
                }

                // Set menu panel height
                int height = 0;
                foreach (var control in userMenuPanel.Controls)
                {
                    height += ((Control)control).Height;
                }
                userMenuPanel.Size = new Size(userMenuPanel.Width, height + 5);
            }
            else
            {
                // Create login/register buttons
                Button loginButton = new Button();
                loginButton.Text = "Login";
                loginButton.Font = new Font("Arial", 12, FontStyle.Bold);
                loginButton.ForeColor = Color.White;
                loginButton.BackColor = Color.FromArgb(109, 168, 135);
                loginButton.TextAlign = ContentAlignment.MiddleCenter;
                loginButton.FlatStyle = FlatStyle.Flat;
                loginButton.FlatAppearance.BorderSize = 1;
                loginButton.FlatAppearance.BorderColor = Color.White;
                loginButton.Location = new Point(ClientSize.Width - 250, 25);
                loginButton.Size = new Size(100, 50);
                loginButton.Click += (e, s) =>
                {
                    ShowPanel(new LoginPanel());
                };

                // Create login/register buttons
                Button registerButton = new Button();
                registerButton.Text = "Sign up";
                registerButton.Font = new Font("Arial", 12, FontStyle.Bold);
                registerButton.ForeColor = Color.FromArgb(109, 168, 135);
                registerButton.BackColor = Color.White;
                registerButton.TextAlign = ContentAlignment.MiddleCenter;
                registerButton.FlatStyle = FlatStyle.Flat;
                registerButton.FlatAppearance.BorderSize = 1;
                registerButton.FlatAppearance.BorderColor = Color.White;
                registerButton.Location = new Point(ClientSize.Width - 125, 25);
                registerButton.Size = new Size(100, 50);
                registerButton.Click += (e, s) =>
                {
                    ShowPanel(new RegistrationPanel());
                };

                bannerPanel.Controls.Add(loginButton);
                bannerPanel.Controls.Add(registerButton);
            }
        }

        private void eventManagerButton_Click(object sender, EventArgs e)
        {
            ShowPanel(new MainEventManagerPanel());
        }

        private void accountButton_Click(object sender, EventArgs e)
        {
            ShowPanel(new AccountSettingsPanel());
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {
            ShowPanel(new AppSettingsPanel());
        }

        private void accountManagerButton_Click(object sender, EventArgs e)
        {
            ShowPanel(new AccountsPanel());
        }

        public void logoutButton_Click(object sender, EventArgs e)
        {
            Program.UserDataManager.UserData.SavedEmail = "";
            Program.UserDataManager.UserData.SavedPassword = "";
            Program.UserDataManager.Save();
            Program.Client.Logout();
            loggedIn = false;
            userMenuPanel.Visible = false;
            ShowPanel(new MainEventListPanel(null));
            DrawBanner();
        }

        private void MainLoad(object sender, EventArgs e)
        {
            ShowPanel(new MainEventListPanel(this));

            UiMain_Resize(null, null);

            return;
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
        Panel content = null;

        public void ShowPanel(IPanel panelForm)
        {
            panelForm.SetMainRef(this);
            contentPanel.Controls.Clear();
            content = panelForm.GetPanel();
            content.Location = new Point(0, 0);
            content.Visible = true;
            content.Size = new Size(content.Size.Width, Math.Max(content.Size.Height, ClientSize.Height - BANNER_HEIGHT));
            contentPanel.Size = new Size(content.Size.Width, ClientSize.Height - BANNER_HEIGHT);
            contentPanel.Location = new Point((ClientSize.Width - content.Width) / 2, 100);
            contentPanel.Controls.Add(content);
        }

        public void FitCurrentPanel()
        {
            content.Size = new Size(content.Size.Width, Math.Max(content.Size.Height, ClientSize.Height - BANNER_HEIGHT));
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
                // Move and resize content panel
                int newX = (Size.Width - contentPanel.Controls[0].Width) / 2;
                if (newX < 0)
                {
                    newX = 0;
                }
                contentPanel.Location = new Point(newX, 100);
                if (contentPanel.Size.Height != ClientSize.Height - BANNER_HEIGHT)
                {
                    contentPanel.Size = new Size(contentPanel.Size.Width, ClientSize.Height - BANNER_HEIGHT);
                    contentPanel.Invalidate();
                }

                // Redraw banner
                DrawBanner();

                //overlayPicturePanel.Size = new Size(ClientSize.Width, ClientSize.Height);
            }
            catch { }
        }
    }
}

