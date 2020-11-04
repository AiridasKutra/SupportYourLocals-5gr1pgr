using Common;
using GoogleMaps.LocationServices;
using localhostUI.Backend.DataManagement;
using localhostUI.Classes.EventClasses;
using localhostUI.Classes.LocationClasses;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace localhostUI.EventEditor
{
    public partial class EventEditor : Form
    {

        private EventFull @event = new EventFull();
        public EventEditor()
        {

            InitializeComponent();
            this.Text = "Create event";
            this.finishButton.Text = "Create";
            finishButton.Click += new System.EventHandler(this.CreateEvent);
            this.Controls.Remove(deleteEventButton);
        }
        public EventEditor(EventFull @event)
        {
            InitializeComponent();
            this.Text = "Edit event";
            this.@event = @event;
            this.finishButton.Text = "Edit";
            this.headerLabel.Text = "Edit event information.";
            finishButton.Click += new System.EventHandler(this.EditEvent);
            this.FillInBoxes();
            this.FillInPhotos();
            
        }

        private void FillInBoxes()
        {
            this.eventNameBox.Text = this.@event.Name;
            this.dateBox.Value = this.@event.StartDate;
            this.sportBox.Text = this.@event.GetSports()[0];
            this.priceBox.Value = this.@event.Price;
            this.addressBox.Text = this.@event.Address;
            this.descriptionBox.Text = this.@event.Description;
        }
        private void FillInPhotos()
        {
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
                photoPanel.Controls.Add(picture);
            }

            photoPanel.HorizontalScroll.Maximum = 0;
            photoPanel.AutoScroll = false;
            photoPanel.VerticalScroll.Visible = false;
            photoPanel.AutoScroll = true;
        }

        private void EditEvent(object sender, EventArgs e)
        {

            if (this.addressBox.Text != this.@event.Address)
            {
                if (LocationInformation.IsValidAddress(this.addressBox.Text))
                {

                    this.@event.Address = this.addressBox.Text;
                    MapPoint location = LocationInformation.LatLongFromAddress(this.@event.Address);
                    this.@event.Latitude = location.Latitude;
                    this.@event.Longitude = location.Longitude;
                }
                else
                {
                    finishResultLabel.Text = "Invalid address.";
                    return;
                }
            }
            this.@event.Name = this.eventNameBox.Text;
            this.@event.StartDate = this.dateBox.Value;
            this.@event.GetSports()[0] = this.sportBox.Text;
            this.@event.Price = this.priceBox.Value;
            this.@event.Description = this.descriptionBox.Text;
            
            //Program.DataManager.Write(new DatabaseEntryEditor("events_full",this.@event.Id), EventFull.ToDataList(this.@event));
            this.Close();
        }

        private void CreateEvent(object sender, EventArgs e)
        {
               if (LocationInformation.IsValidAddress(this.addressBox.Text))
                {

                    this.@event.Address = this.addressBox.Text;
                    MapPoint location = LocationInformation.LatLongFromAddress(this.@event.Address);
                    this.@event.Latitude = location.Latitude;
                    this.@event.Longitude = location.Longitude;
                }
                else
                {
                    finishResultLabel.Text = "Invalid address.";
                    return;
                }

            this.@event.Name = this.eventNameBox.Text;
            this.@event.StartDate = this.dateBox.Value;
            this.@event.AddSport(this.sportBox.Text);
            this.@event.Price = this.priceBox.Value;
            this.@event.Description = this.descriptionBox.Text;
            //Program.DataManager.Write(new DatabaseEntryAdder("events_full"), EventFull.ToDataList(this.@event));
            this.Close();
        }

        private void SearchMapsBrowser(object sender, EventArgs e)
        {
            try{LocationInformation.OpenAdressInBrowser(addressBox.Text);}catch{}
        }

        private void EventEditor_Load(object sender, EventArgs e)
        {

        }

        private void AddThumbnail(object sender, EventArgs e)
        {
            this.@event.GetImages()[0] = this.thumbnailLinkBox.Text;
        }

        private void AddPhoto(object sender, EventArgs e)
        {
            this.@event.AddImage(this.imagineLinkBox.Text);
            FillInPhotos();
        }

        private void DeleteEvent(object sender, EventArgs e)
        {
            Program.DataManager.Write(new DatabaseEntryRemover("events_full", @event.Id),null);
        }
    }
}
