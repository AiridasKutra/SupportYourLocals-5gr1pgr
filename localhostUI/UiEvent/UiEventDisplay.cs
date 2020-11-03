using Common;
using GoogleMaps.LocationServices;
using localhostUI.Backend;
using localhostUI.Backend.DataManagement;
using localhostUI.Classes.EventClasses;
using localhostUI.Classes.LocationClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;

namespace localhostUI.UiEvent
{
    public partial class UiEventDisplay : Form
    {
        private Form caller;
        private EventFull @event;

        private ChatManager chatManager;

        public UiEventDisplay(int eventId, Form caller)
        {
            this.caller = caller;

            InitializeComponent();

            // Get full event data from database
            DataList eventData = new DataList();
            Program.DataManager.Read(new DatabaseReader($"select from events_full id {eventId}"), out eventData);
            @event = null;
            try
            {
                @event = new EventFull((DataList)eventData.items[0]);
            }
            catch (InvalidCastException)
            {
                @event = new EventFull();
            }

            // Title
            eventName.Text = @event.Name;

            // Sports
            foreach (var sport in @event.GetSports())
            {
                Label sportLabel = new Label();
                sportLabel.AutoSize = true;
                sportLabel.Text = sport;
                sportLabel.BackColor = Color.FromArgb(230, 230, 230);
                sportLabel.Font = new Font("Comic Sans MS", 12);
                sportDisplayBar.Controls.Add(sportLabel);
            }

            // Teams
            foreach (var team in @event.GetTeams())
            {
                Label teamLabel = new Label();
                teamLabel.AutoSize = true;
                teamLabel.Text = team.Name;
                teamLabel.BackColor = Color.FromArgb(230, 230, 230);
                teamLabel.Font = new Font("Comic Sans MS", 12);
                teamDisplayBar.Controls.Add(teamLabel);
            }

            // Address
            addressLabel.Text = @event.Address;

            // Description
            descriptionLabel.Text = @event.Description;

            // Links
            List<string> links = @event.GetLinks();
            for (int i = 0; i < links.Count; i++)
            {
                string[] linkSplit = links[i].Split(' ', 2, StringSplitOptions.RemoveEmptyEntries);
                if (linkSplit.Length != 2) continue;

                LinkLabel linkText = new LinkLabel();
                linkText.Text = linkSplit[1];
                linkText.LinkClicked += (sender, e) =>
                {
                    Process.Start(new ProcessStartInfo("cmd", $"/c start {linkSplit[0]}"));
                };
                linkText.Location = new Point(426, 370 + (i * 20));

                Controls.Add(linkText);
            }

            // Load images
            List<string> imageLinks = @event.GetImages();
            for (int i = 0; i < imageLinks.Count; i++)
            {
                PictureBox picture = new PictureBox();
                picture.Size = new Size(240, 180);
                picture.Location = new Point(0, 200 * i);
                picture.BorderStyle = BorderStyle.Fixed3D;
                try
                {
                    using (WebClient client = new WebClient())
                    {
                        Stream stream = client.OpenRead(imageLinks[i]);
                        Bitmap bitmap = new Bitmap(stream);
                        Bitmap bitmapScaled = new Bitmap(bitmap, new Size(240, 180));
                        picture.Image = bitmapScaled;

                        stream.Flush();
                        stream.Close();
                    }
                }
                catch { }
                picturePanel.Controls.Add(picture);
            }

            picturePanel.HorizontalScroll.Maximum = 0;
            picturePanel.AutoScroll = false;
            picturePanel.VerticalScroll.Visible = false;
            picturePanel.AutoScroll = true;

            // Chat
            chatMessageTextBox.KeyPress += new KeyPressEventHandler(Key_Press);

            chatPanel.HorizontalScroll.Maximum = 0;
            chatPanel.AutoScroll = false;
            chatPanel.VerticalScroll.Visible = false;
            chatPanel.AutoScroll = true;

            // Start chat
            chatManager = new ChatManager();
            chatManager.Connect(@event.Id, chatPanel);
        }

        private void ReturnButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ShowAddressButton_Click(object sender, EventArgs e)
        {
            AddressData data = LocationInformation.AddressFromLatLong(@event.Latitude, @event.Longitude);
            try
            {
                LocationInformation.OpenAdressInBrowser(data.Address);
            }
            catch
            {
                MessageBox.Show("A mistake was made in opening the address.", "Something went wrong.",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Key_Press(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                e.Handled = true;
                if (chatMessageTextBox.Text.Length == 0) return;

                SendMessage(chatMessageTextBox.Text);
                chatMessageTextBox.Text = "";
                //e.SuppressKeyPress = true;
            }
        }

        private void SendMessage_Click(object sender, EventArgs e)
        {
            if (chatMessageTextBox.Text.Length == 0) return;

            SendMessage(chatMessageTextBox.Text);
            chatMessageTextBox.Text = "";
        }

        private void SendMessage(string message)
        {
            chatManager.SendMessage($"{Program.UserDataManager.GetData().Username}: {message}");
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);

            // Properly disconnect and close chat manager
            chatManager.Disconnect();
        }
    }
}
