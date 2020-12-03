﻿using Common;
using GoogleMaps.LocationServices;
using localhostUI.Backend;
using localhostUI.Backend.DataManagement;
using localhostUI.Classes.EventClasses;
using localhostUI.Classes.LocationClasses;
using localhostUI.Classes.UserInformationClasses;
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
    public partial class UiEventDisplayPanel : Form, IPanel
    {
        private EventFull @event;
        private ChatManager chatManager;

        private UiMain mainForm;
        private IPanel caller;

        public void Reload() { }

        public Panel GetPanel()
        {
            return mainPanel;
        }

        public void SetMainRef(UiMain main)
        {
            mainForm = main;
        }

        public UiEventDisplayPanel(int eventId, IPanel caller)
        {
            this.caller = caller;

            InitializeComponent();

            // Set return button image
            returnButton.BackgroundImage = Properties.Resources.BackButtonGreen;

            // Get full event data from database
            List<EventFull> events = Program.Client.SelectEventsFull(eventId);
            try
            {
                @event = events[0];
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine($"ERROR: Event with id {eventId} not found");
                throw;
            }

            // Title
            eventName.Text = @event.Name;

            // Sports
            foreach (var sport in @event.Sports)
            {
                Label sportLabel = new Label();
                sportLabel.AutoSize = true;
                sportLabel.Text = sport;
                sportLabel.BackColor = Color.FromArgb(230, 230, 230);
                sportLabel.Font = new Font("Arial", 12, FontStyle.Bold);
                //sportDisplayBar.Controls.Add(sportLabel);
            }

            // Distance
            UserData user = Program.UserDataManager.GetData();
            double distance = MathSupplement.Distance(@event.Latitude, @event.Longitude, user.Latitude, user.Longitude);
            if (distance < 1000.0)
            {
                distanceLabel.Text = $"{distance:0}m";
            }
            else
            {
                distanceLabel.Text = $"{distance / 1000.0:0.0}km";
            }

            // Distance and address separator
            Size distanceLabelSize = Helper.CalculateLabelSize(distanceLabel, 100);
            separatorPanel1.Location = new Point(distanceLabel.Location.X + distanceLabelSize.Width, separatorPanel1.Location.Y);

            // Address
            addressLabel.Location = new Point(distanceLabel.Location.X + distanceLabelSize.Width + 10, addressLabel.Location.Y);
            addressLabel.Text = @event.Address.ToStringNormal();

            // Show map button
            Size addressLabelSize = Helper.CalculateLabelSize(addressLabel, 500);
            showMapsButton.Location = new Point(addressLabel.Location.X + addressLabelSize.Width + 5, showMapsButton.Location.Y);
            showMapsButton.BackgroundImage = Properties.Resources.MapsButton;

            // Load images
            List<string> imageLinks = @event.Images;
            int counter = 0;
            foreach (var image in @event.Images)
            {
                int IMAGE_WIDTH = 180;
                int IMAGE_HEIGHT = 180;
                int MARGINS = 10;

                PictureBox picture = new PictureBox();
                picture.Size = new Size(IMAGE_WIDTH, IMAGE_HEIGHT);
                picture.Location = new Point((IMAGE_WIDTH + MARGINS) * counter, 0);
                picture.BorderStyle = BorderStyle.None;

                BackgroundWorker worker = new BackgroundWorker();
                worker.DoWork += (s, e) =>
                {
                    try
                    {
                        using (WebClient client = new WebClient())
                        {
                            Stream stream = client.OpenRead(image);
                            Bitmap bitmap = new Bitmap(stream);

                            picture.Image = Helper.ScaleBitmap(bitmap, IMAGE_WIDTH, IMAGE_HEIGHT, 1.0f);

                            stream.Flush();
                            stream.Close();
                        }
                    }
                    catch { }
                };
                worker.RunWorkerAsync();

                picturePanel.Controls.Add(picture);
                counter++;
            }

            picturePanel.VerticalScroll.Maximum = 0;
            picturePanel.AutoScroll = false;
            picturePanel.HorizontalScroll.Visible = false;
            picturePanel.AutoScroll = true;

            // Description
            descriptionLabel.Text = @event.Description;
            Size descriptionLabelSize = Helper.CalculateLabelSize(descriptionLabel, descriptionLabel.MaximumSize.Width);

            // Description and comment separator
            separatorPanel4.Location = new Point(separatorPanel4.Location.X, descriptionLabel.Location.Y + descriptionLabelSize.Height + 28);

            // New comment
            chatMessageTextBox.Location = new Point(0, 0);

            // Submit new comment
            sendMessageButton.Location = new Point(sendMessageButton.Location.X, chatMessageTextBox.Location.Y + chatMessageTextBox.Size.Height + 6);

            // Chat panel
            chatPanel.Location = new Point(chatPanel.Location.X, sendMessageButton.Location.Y + sendMessageButton.Size.Height + 6);

            // Load comments


            // Comments panel
            commentsPanel.Size = new Size(commentsPanel.Size.Width, chatPanel.Location.Y + chatPanel.Size.Height);

            mainPanel.Size = new Size(1000, chatPanel.Location.Y + chatPanel.Size.Height + 20);

            // Chat
            chatMessageTextBox.KeyPress += new KeyPressEventHandler(Key_Press);

            chatPanel.HorizontalScroll.Maximum = 0;
            chatPanel.AutoScroll = false;
            chatPanel.VerticalScroll.Visible = false;
            chatPanel.AutoScroll = true;

            // Start chat
            //chatManager = new ChatManager();
            //chatManager.Connect(@event.Id, chatPanel);

            // Links
            //List<string> links = @event.Links;
            //for (int i = 0; i < links.Count; i++)
            //{
            //    string[] linkSplit = links[i].Split(' ', 2, StringSplitOptions.RemoveEmptyEntries);
            //    if (linkSplit.Length != 2) continue;

            //    LinkLabel linkText = new LinkLabel();
            //    linkText.Text = linkSplit[1];
            //    linkText.LinkClicked += (sender, e) =>
            //    {
            //        Process.Start(new ProcessStartInfo("cmd", $"/c start {linkSplit[0]}"));
            //    };
            //    linkText.Location = new Point(426, 370 + (i * 20));

            //    Controls.Add(linkText);
            //}
        }

        private void ReturnButton_Click(object sender, EventArgs e)
        {
            mainForm.ShowPanel(caller);
        }

        private void ShowAddressButton_Click(object sender, EventArgs e)
        {
            AddressData data = LocationInformation.AddressFromLatLong(@event.Latitude, @event.Longitude);
            LocationInformation.OpenAdressInBrowser(data.Address);
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
            chatManager.SendMessage(new Backend.Message { Content = message });
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);

            // Properly disconnect and close chat manager
            chatManager.Disconnect();
        }

        private void chatMessageTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void returnButton_MouseEnter(object sender, EventArgs e)
        {
            returnButton.BackgroundImage = Properties.Resources.BackButtonGreenHover;
        }

        private void returnButton_MouseLeave(object sender, EventArgs e)
        {
            returnButton.BackgroundImage = Properties.Resources.BackButtonGreen;
        }

        private void showMapsButton_MouseEnter(object sender, EventArgs e)
        {
            showMapsButton.BackgroundImage = Properties.Resources.MapsButtonHover;
        }

        private void showMapsButton_MouseLeave(object sender, EventArgs e)
        {
            showMapsButton.BackgroundImage = Properties.Resources.MapsButton;
        }
    }
}
