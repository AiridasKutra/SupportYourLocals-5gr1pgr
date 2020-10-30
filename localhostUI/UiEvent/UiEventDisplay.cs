using Common;
using GoogleMaps.LocationServices;
using localhostUI.Backend.DataManagement;
using localhostUI.Classes.EventClasses;
using localhostUI.Classes.LocationClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;

namespace localhostUI.UiEvent
{
    public partial class UiEventDisplay : Form
    {
        private Form caller;
        private EventFull @event;

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
                linkText.Location = new Point(470, 168 + (i * 20));

                Controls.Add(linkText);
            }
        }

        private void ReturnButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ShowAddressButton_Click(object sender, EventArgs e)
        {
            AddressData data = LocationInformation.AddressFromLatLong(@event.Latitude, @event.Longitude);
            LocationInformation.OpenAdressInBrowser(data.Address);
        }
    }
}
