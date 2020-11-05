using Common;
using GoogleMaps.LocationServices;
using localhostUI.Backend;
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

namespace localhostUI.UiEvent
{
    public partial class EventEditor : Form
    {
        private EventFull @event = new EventFull();
        private UiMain origin;
        private bool draft;

        public EventEditor(UiMain origin)
        {
            this.origin = origin;
            this.draft = false;

            InitializeComponent();

            this.Text = "Create event";
            this.finishButton.Text = "Create";
            this.finishButton.Click += CreateEvent;

            deleteEventButton.Visible = false;
            saveDraftButton.Visible = true;
        }

        public EventEditor(UiMain origin, EventFull @event, bool draft = false)
        {
            this.origin = origin;
            this.draft = draft;

            InitializeComponent();

            this.Text = "Edit event";
            this.@event = @event;
            this.headerLabel.Text = "Edit event information.";
            this.FillInBoxes();
            this.FillInPhotos();
            this.finishButton.Click += EditEvent;

            if (draft)
            {
                finishButton.Text = "Create";
                deleteEventButton.Visible = false;
                saveDraftButton.Visible = true;
            }
            else
            {
                finishButton.Text = "Save";
                deleteEventButton.Visible = true;
                saveDraftButton.Visible = false;
            }
        }

        private void FillInBoxes()
        {
            this.eventNameBox.Text = this.@event.Name;
            this.priceBox.Value = this.@event.Price;
            this.addressBox.Text = this.@event.Address;
            this.descriptionBox.Text = this.@event.Description;
            try
            {
                this.dateBox.Value = this.@event.StartDate;
                this.sportBox.Text = this.@event.GetSports()[0];
            }
            catch (ArgumentOutOfRangeException)
            {
                return;
            }
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

        private void FillInEvent()
        {
            this.@event.GetSports().Clear();
            this.@event.Address = this.addressBox.Text;
            this.@event.Name = this.eventNameBox.Text;
            this.@event.StartDate = this.dateBox.Value;
            this.@event.AddSport(this.sportBox.Text);
            this.@event.Price = this.priceBox.Value;
            this.@event.Description = this.descriptionBox.Text;
        }

        private void EditEvent(object sender, EventArgs e)
        {
            FillInEvent();

            if (this.addressBox.Text != this.@event.Address)
            {
                if (LocationInformation.IsValidAddress(this.addressBox.Text))
                {
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

            Program.DataManager.Write(new DatabaseEntryEditor("events_full", @event.Id), EventFull.ToDataList(@event));

            Program.DataProvider.InitialLoadDoneBrief = false;
            Program.DataProvider.InitialLoadDoneFull = false;
            origin.LoadMyEvents();
            this.Close();
        }

        private void CreateEvent(object sender, EventArgs e)
        {
            FillInEvent();

            if (LocationInformation.IsValidAddress(this.addressBox.Text))
            {
                MapPoint location = LocationInformation.LatLongFromAddress(this.@event.Address);
                this.@event.Latitude = location.Latitude;
                this.@event.Longitude = location.Longitude;
            }
            else
            {
                finishResultLabel.Text = "Invalid address.";
                return;
            }

            Program.DataManager.Write(new DatabaseEntryAdder("events_full"), EventFull.ToDataList(@event));

            Program.DataProvider.InitialLoadDoneBrief = false;
            Program.DataProvider.InitialLoadDoneFull = false;
            origin.LoadMyEvents();
            this.Close();
        }

        private void DeleteEvent(object sender, EventArgs e)
        {
            Program.DataManager.Write(new DatabaseEntryRemover("events_full", @event.Id), null);

            Program.DataProvider.InitialLoadDoneBrief = false;
            Program.DataProvider.InitialLoadDoneFull = false;
            origin.LoadMyEvents();
            Close();
        }

        private void SaveDraft(object sender, EventArgs e)
        {
            FillInEvent();

            if (!draft)
            {
                Program.DataPool.eventsDraft.Add(EventFull.ToDataList(@event));
                Program.DataPool.SaveDrafts();
                Program.DataPool.LoadDrafts();
            }
            else
            {
                try
                {
                    for (int i = 0; i < Program.DataPool.eventsDraft.Count; i++)
                    {
                        if ((int)Program.DataPool.eventsDraft[i].Get("id") == @event.Id)
                        {
                            Program.DataPool.eventsDraft[i] = EventFull.ToDataList(@event);
                            Program.DataPool.SaveDrafts();
                            Program.DataPool.LoadDrafts();
                            break;
                        }
                    }
                }
                catch (InvalidCastException)
                {
                    Console.WriteLine("ERROR: save failed because a draft is corrupted");
                }
            }

            origin.LoadDrafts();
            Close();
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
            if (@event.GetImages().Count == 0)
            {
                @event.AddImage("");
            }
            this.@event.GetImages()[0] = this.thumbnailLinkBox.Text;
            FillInPhotos();
        }

        private void AddPhoto(object sender, EventArgs e)
        {
            this.@event.AddImage(this.imagineLinkBox.Text);
            FillInPhotos();
        }
    }
}
