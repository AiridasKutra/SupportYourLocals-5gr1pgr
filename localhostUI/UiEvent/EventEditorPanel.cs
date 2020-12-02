﻿using Common;
using GoogleMaps.LocationServices;
using localhostUI.Backend;
using localhostUI.Backend.DataManagement;
using localhostUI.Classes;
using localhostUI.Classes.EventClasses;
using localhostUI.Classes.LocationClasses;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace localhostUI.UiEvent
{
    public partial class EventEditorPanel : Form, IPanel
    {
        private EventFull @event = new EventFull();
        private bool draft;

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

        public EventEditorPanel(IPanel caller)
        {
            this.draft = false;
            this.caller = caller;

            InitializeComponent();
            FillInSports();
            Text = "Create event";
            finishButton.Text = "Create";
            finishButton.Click += CreateEvent;

            deleteEventButton.Text = "Save as draft";
            deleteEventButton.Click += SaveDraft;
        }

        public EventEditorPanel(IPanel caller, EventFull @event, bool draft = false)
        {
            this.draft = draft;
            this.caller = caller;

            InitializeComponent();

            Text = "Edit event";
            this.@event = @event;
            headerLabel.Text = "Edit event information.";

            FillInSports();
            FillInBoxes();
            FillInPhotos();

            if (draft)
            {
                finishButton.Text = "Create";
                finishButton.Click += CreateEvent;
                deleteEventButton.Text = "Save as draft";
                deleteEventButton.Click += SaveDraft;

            }
            else
            {
                finishButton.Text = "Save";
                finishButton.Click += EditEvent;
                deleteEventButton.Text = "Delete event";
                deleteEventButton.Click += DeleteEvent;
            }
        }

        private void FillInBoxes()
        {

            this.eventNameBox.Text = this.@event.Name;
            this.priceBox.Value = this.@event.Price;
            this.addressBox.Text = this.@event.Address.ToStringNormal();
            this.descriptionBox.Text = this.@event.Description;
            try
            {
                this.dateBox.Value = this.@event.StartDate;
                this.sportBox.Text = this.@event.Sports[0];
            }
            catch (ArgumentOutOfRangeException)
            {
                return;
            }
        }

        private void FillInSports()
        {
            //this.sportBox.Items.Clear();

            //List<string> sports = origin.SportList;
            //foreach (string sport in sports)
            //{
            //    this.sportBox.Items.Add(sport);
            //}
        }

        private void FillInPhotos()
        {
            photoPanel.Controls.Clear();
            thumbnailPanel.Controls.Clear();
            var photos = new List<string>(@event.Images.Skip(1));
            string thumbnail ="";
            if (@event.Images.Count > 0) 
            { 
                thumbnail = @event.Images.FirstOrDefault();
                // Add picture
                PictureBox picture = new PictureBox();
                picture.Click += ShowThumbnailBox;
                picture.Size = new Size(180, 180);
                picture.Location = new Point(15, 0);
                picture.BorderStyle = BorderStyle.FixedSingle;
                try
                {
                    using (WebClient client = new WebClient())
                    {
                        Stream stream = client.OpenRead(thumbnail);
                        Bitmap bitmap = new Bitmap(stream);
                        Bitmap bitmapScaled = new Bitmap(bitmap, new Size(180, 180));
                        picture.Image = bitmapScaled;

                        stream.Flush();
                        stream.Close();
                    }
                }
                catch { }
                thumbnailPanel.Controls.Add(picture);

                // Add remove button
                Button removeButton = new Button();
                removeButton.BackgroundImage = Properties.Resources.CloseButton;
                removeButton.FlatStyle = FlatStyle.Flat;
                removeButton.FlatAppearance.BorderSize = 0;
                removeButton.BackColor = Color.Transparent;
                removeButton.Location = new Point(0, 1);
                removeButton.Size = new Size(13, 13);
                removeButton.Margin = new Padding(0);
                removeButton.Padding = new Padding(0);
                removeButton.Click += (sender, e) =>
                {
                    @event.Images.Remove(thumbnail);
                    FillInPhotos();
                };
                thumbnailPanel.Controls.Add(removeButton);

            }

            int counter = 0;
            foreach (var link in photos)
            {
                // Add picture
                PictureBox picture = new PictureBox();
                picture.Click += ShowPhotoBox;
                picture.Size = new Size(180, 180);
                picture.Location = new Point(15 + 200 * counter,0);
                picture.BorderStyle = BorderStyle.FixedSingle;
                try
                {
                    using (WebClient client = new WebClient())
                    {
                        Stream stream = client.OpenRead(link);
                        Bitmap bitmap = new Bitmap(stream);
                        Bitmap bitmapScaled = new Bitmap(bitmap, new Size(180, 180));
                        picture.Image = bitmapScaled;

                        stream.Flush();
                        stream.Close();
                    }
                }
                catch { }
                photoPanel.Controls.Add(picture);

                // Add remove button
                Button removeButton = new Button();
                removeButton.BackgroundImage = Properties.Resources.CloseButton;
                removeButton.FlatStyle = FlatStyle.Flat;
                removeButton.FlatAppearance.BorderSize = 0;
                removeButton.BackColor = Color.Transparent;
                removeButton.Location = new Point( 1 + 200 * counter,1);
                removeButton.Size = new Size(13, 13);
                removeButton.Margin = new Padding(0);
                removeButton.Padding = new Padding(0);
                removeButton.Click += (sender, e) =>
                {
                    @event.Images.Remove(link);
                    FillInPhotos();
                };
                photoPanel.Controls.Add(removeButton);

                // Add thumbnail tag
                if (counter == 0)
                {
                    Label thumbnailTag = new Label();
                    thumbnailTag.Text = "Thumbnail";
                    thumbnailTag.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                    thumbnailTag.Location = new Point(20, 200 * counter);
                    photoPanel.Controls.Add(thumbnailTag);
                }

                counter++;
            }

            photoPanel.VerticalScroll.Maximum = 0;
            photoPanel.AutoScroll = false;
            photoPanel.HorizontalScroll.Visible = false;
            photoPanel.AutoScroll = true;
        }

        private void FillInEvent()
        {
            this.@event.Sports.Clear();
            this.@event.Name = this.eventNameBox.Text;
            this.@event.StartDate = this.dateBox.Value;
            this.@event.Sports.Add(this.sportBox.Text);
            this.@event.Price = this.priceBox.Value;
            this.@event.Description = this.descriptionBox.Text;
        }

        private void EditEvent(object sender, EventArgs e)
        {

            if (this.eventNameBox.Text == "")
            {
                finishResultLabel.Text = "You cannot remove the name.";
                return;
            }
            if (this.addressBox.Text != this.@event.Address.ToStringNormal())
            {
                try
                {
                    //EXTENTION METHOD
                    this.@event.Address = this.addressBox.Text.FormatAddressInfo();
                    MapPoint location = this.@event.Address.ToStringNormal().LatLongFromString();
                    this.@event.Latitude = location.Latitude;
                    this.@event.Longitude = location.Longitude;
                }
                catch
                {
                    finishResultLabel.Text = "Invalid address.";
                    return;
                }
            }
            FillInEvent();
            Program.Client.EditEvent(@event);
            //Program.DataManager.Write(new DatabaseEntryEditor("events_full", @event.Id), EventFull.ToDataList(@event));

            mainForm.ShowPanel(caller);
            //origin.LoadMyEvents();
            this.Close();
        }

        private void CreateEvent(object sender, EventArgs e)
        {

            if (this.eventNameBox.Text == "")
            {
                finishResultLabel.Text = "A name is required to create an event.";
                return;
            }
            try
            {
                //EXTENSION METHOD
                this.@event.Address = this.addressBox.Text.FormatAddressInfo();
                MapPoint location = this.@event.Address.ToStringNormal().LatLongFromString();
                this.@event.Latitude = location.Latitude;
                this.@event.Longitude = location.Longitude;
            }
            catch
            {
                finishResultLabel.Text = "Invalid address.";
                return;
            }
            FillInEvent();
            Program.Client.CreateEvent(@event);
            //Program.DataManager.Write(new DatabaseEntryAdder("events_full"), EventFull.ToDataList(@event));

            mainForm.ShowPanel(caller);
            //origin.LoadMyEvents();
            this.Close();
        }

        private void DeleteEvent(object sender, EventArgs e)
        {
            Program.Client.DeleteEvent(@event.Id);
            //Program.DataManager.Write(new DatabaseEntryRemover("events_full", @event.Id), null);

            mainForm.ShowPanel(caller);
            //origin.LoadMyEvents();
            Close();
        }

        private void SaveDraft(object sender, EventArgs e)
        {
            FillInEvent();

            if (!draft)
            {
                Program.DraftManager.AddEvent(@event);
                Program.DraftManager.SaveDrafts();
                Program.DraftManager.LoadDrafts();
            }
            else
            {
                try
                {
                    List<EventFull> drafts = Program.DraftManager.GetEvents();
                    foreach (var draft in drafts)
                    {
                        if (draft.Id == @event.Id)
                        {
                            drafts[drafts.IndexOf(draft)] = @event;
                            Program.DraftManager.SaveDrafts();
                            Program.DraftManager.LoadDrafts();
                            break;
                        }
                    }
                }
                catch (InvalidCastException)
                {
                    Console.WriteLine("ERROR: save failed because a draft is corrupted");
                }
            }

            mainForm.ShowPanel(caller);
            //origin.LoadMyEvents();
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
            if (@event.Images.Count == 0)
            {
                @event.Images.Add("");
            }
            this.@event.Images[0] = this.thumbnailLinkBox.Text;
            FillInPhotos();
            this.thumbnailLinkBox.Clear();
        }

        private void AddPhoto(object sender, EventArgs e)
        {
            int index = @event.Images.IndexOf(imagineLinkBox.Text);
            if (index != -1)
            {
                @event.Images[index] = imagineLinkBox.Text;
            }
            else
            {
                @event.Images.Add(imagineLinkBox.Text);
            }
            FillInPhotos();
            imagineLinkBox.Clear();
        }

        private void ShowThumbnailBox(object sender, EventArgs e)
        {
            thumbnailLinkBox.Visible = true;
            addThumbnailButton.Visible = true;
        }

        private void ShowPhotoBox(object sender, EventArgs e)
        {
            imagineLinkBox.Visible = true;
            addPhotoButton.Visible = true;
        }
    }
}
