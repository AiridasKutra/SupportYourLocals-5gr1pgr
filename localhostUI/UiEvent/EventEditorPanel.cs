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
            FillInPhotos();
            headerLabel.Text = "Create event";
            finishButton.Text = "Create";
            finishButton.Click += CreateEvent;

            deleteEventButton.Text = "Save as draft";
            deleteEventButton.Click += SaveDraft;

            UserAccount acc = Program.UserDataManager.UserAccount;
            if (!acc.Can((uint)Permissions.MANAGE_SELF_EVENT))
            {
                finishButton.Visible = false;
            }

            // Set maps button image
            checkAddressButton.BackgroundImage = Properties.Resources.MapsButton;
        }

        public EventEditorPanel(IPanel caller, EventFull @event, bool draft = false)
        {
            this.draft = draft;
            this.caller = caller;

            InitializeComponent();

            Text = "Edit event";
            this.@event = @event;
            headerLabel.Text = "Edit event information";

            FillInSports();
            FillInBoxes();
            FillInPhotos();

            UserAccount acc = Program.UserDataManager.UserAccount;
            if (draft)
            {
                finishButton.Text = "Create";
                finishButton.Click += CreateEvent;
                deleteEventButton.Text = "Save as draft";
                deleteEventButton.Click += SaveDraft;

                if (!acc.Can((uint)Permissions.MANAGE_SELF_EVENT))
                {
                    finishButton.Visible = false;
                }
            }
            else
            {
                finishButton.Text = "Save";
                finishButton.Click += EditEvent;
                deleteEventButton.Text = "Delete event";
                deleteEventButton.Click += DeleteEvent;
                deleteEventButton.BackColor = Color.Tomato;

                if (@event.Author == acc.Id)
                {
                    if (!acc.Can((uint)Permissions.MANAGE_SELF_EVENT))
                    {
                        finishButton.Visible = false;
                    }
                }
                else
                {
                    if (!acc.Can((uint)Permissions.EDIT_OTHER_EVENTS))
                    {
                        finishButton.Visible = false;
                    }
                    if (!acc.Can((uint)Permissions.DELETE_OTHER_EVENTS))
                    {
                        deleteEventButton.Visible = false;
                    }
                }
            }

            // Set maps button image
            checkAddressButton.BackgroundImage = Properties.Resources.MapsButton;
        }

        private void FillInBoxes()
        {
            this.eventNameBox.Text = this.@event.Name;
            this.priceBox.Value = this.@event.Price;
            this.addressBox.Text = this.@event.Address.ToStringNormal();
            this.descriptionBox.Text = this.@event.Description;
            this.timeTextBox.Text = this.@event.StartDate.ToString("HH:mm");
            this.dateBox.Value = this.@event.StartDate;// -= new TimeSpan(@event.StartDate.Hour, @event.StartDate.Minute, 0);
            this.tagsTextBox.Text = this.@event.Tags;
            try
            {
                this.sportBox.Text = this.@event.Sports[0];
            }
            catch (ArgumentOutOfRangeException)
            {
                return;
            }
        }

        private void FillInSports()
        {
            sportBox.Items.Clear();
            List<string> sports = Program.Client.SelectSports();
            foreach (string sport in sports)
            {
                sportBox.Items.Add(sport);
            }
        }

        private void FillInPhotos()
        {
            if (@event.Images.Count == 0)
            {
                @event.Images.Add("<none>");
                @event.Images.Add("<none>");
            }
            else if (@event.Images.Count == 1)
            {
                @event.Images.Add("<none>");
            }

            photoPanel.Controls.Clear();
            thumbnailPanel.Controls.Clear();

            List<string> photos = new List<string>(@event.Images.Skip(1));
            string thumbnail = "";

            int IMAGE_WIDTH = 180;
            int IMAGE_HEIGHT = 180;
            int MARGINS = 20;

            if (@event.Images.Count > 0) 
            { 
                thumbnail = @event.Images.FirstOrDefault();

                // Add picture
                PictureBox picture = new PictureBox();
                picture.Click += ShowThumbnailBox;
                picture.Size = new Size(IMAGE_WIDTH, IMAGE_HEIGHT);
                picture.Location = new Point(0, 0);
                picture.BorderStyle = BorderStyle.FixedSingle;

                picture.MouseDoubleClick += (s, e) =>
                {
                    try
                    {
                        @event.Images[0] = "<none>";
                        FillInPhotos();
                    }
                    catch { }
                };

                BackgroundWorker worker = new BackgroundWorker();
                worker.DoWork += (s, e) =>
                {
                    try
                    {
                        if (thumbnail == "<none>")
                        {
                            picture.Image = Properties.Resources.PlaceholderPhoto;
                        }
                        else
                        {
                            using (WebClient client = new WebClient())
                            {
                                Stream stream = client.OpenRead(thumbnail);
                                Bitmap bitmap = new Bitmap(stream);

                                picture.Image = Helper.ScaleBitmap(bitmap, IMAGE_WIDTH, IMAGE_HEIGHT, 1.0f);

                                stream.Flush();
                                stream.Close();
                            }
                        }
                    }
                    catch { }
                };
                worker.RunWorkerAsync();

                thumbnailPanel.Controls.Add(picture);

                // Add remove button
                //Button removeButton = new Button();
                //removeButton.BackgroundImage = Properties.Resources.CloseButton;
                //removeButton.FlatStyle = FlatStyle.Flat;
                //removeButton.FlatAppearance.BorderSize = 0;
                //removeButton.BackColor = Color.Transparent;
                //removeButton.Location = new Point(0, 1);
                //removeButton.Size = new Size(13, 13);
                //removeButton.Margin = new Padding(0);
                //removeButton.Padding = new Padding(0);
                //removeButton.Click += (sender, e) =>
                //{
                //    @event.Images.Remove(thumbnail);
                //    FillInPhotos();
                //};
                //thumbnailPanel.Controls.Add(removeButton);

            }

            int counter = 0;
            foreach (var image in photos)
            {
                // Add picture
                PictureBox picture = new PictureBox();
                picture.Click += ShowPhotoBox;
                picture.Size = new Size(IMAGE_WIDTH, IMAGE_HEIGHT);
                picture.Location = new Point((IMAGE_WIDTH + MARGINS) * counter, 0);
                picture.BorderStyle = BorderStyle.FixedSingle;

                picture.MouseDoubleClick += (s, e) =>
                {
                    @event.Images.Remove(image);
                    if (@event.Images.Count == 1)
                    {
                        @event.Images.Add("<none>");
                    }
                    FillInPhotos();
                };

                BackgroundWorker worker = new BackgroundWorker();
                worker.DoWork += (s, e) =>
                {
                    try
                    {

                        if (image == "<none>")
                        {
                            picture.Image = Properties.Resources.PlaceholderPhoto;
                        }
                        else
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
                    }
                    catch { }
                };
                worker.RunWorkerAsync();

                photoPanel.Controls.Add(picture);

                // Add remove button
                //Button removeButton = new Button();
                //removeButton.BackgroundImage = Properties.Resources.CloseButton;
                //removeButton.FlatStyle = FlatStyle.Flat;
                //removeButton.FlatAppearance.BorderSize = 0;
                //removeButton.BackColor = Color.Transparent;
                //removeButton.Location = new Point(1 + 200 * counter, 1);
                //removeButton.Size = new Size(13, 13);
                //removeButton.Margin = new Padding(0);
                //removeButton.Padding = new Padding(0);
                //removeButton.Click += (sender, e) =>
                //{
                //    @event.Images.Remove(image);
                //    FillInPhotos();
                //};
                //photoPanel.Controls.Add(removeButton);

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

        private bool FillInTime()
        {
            string[] timeParts = this.timeTextBox.Text.Split(':', 2, StringSplitOptions.RemoveEmptyEntries);
            if (timeParts.Length != 2)
            {
                return false;
            }

            int hour;
            int minute;

            if (!int.TryParse(timeParts[0], out hour))
            {
                return false;
            }
            if (!int.TryParse(timeParts[1], out minute))
            {
                return false;
            }
            if (hour > 23 || hour < 0)
            {
                return false;
            }
            if (minute > 59 || minute < 0)
            {
                return false;
            }
            @event.StartDate = new DateTime
            (
                @event.StartDate.Year,
                @event.StartDate.Month,
                @event.StartDate.Day,
                hour,
                minute,
                0
            );
            return true;
        }

        private void FillInEvent()
        {
            this.@event.Sports.Clear();
            this.@event.Name = this.eventNameBox.Text;
            this.@event.Sports.Add(this.sportBox.Text);
            this.@event.StartDate = this.dateBox.Value;
            this.@event.Price = this.priceBox.Value;
            this.@event.Description = this.descriptionBox.Text;
            this.@event.Tags = this.tagsTextBox.Text;
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
            if (!FillInTime())
            {
                finishResultLabel.Text = "Invalid time.";
                return;
            }
            @event.Images.RemoveAll(item => item == "<none>");

            Program.Client.EditEvent(@event);
            //Program.DataManager.Write(new DatabaseEntryEditor("events_full", @event.Id), EventFull.ToDataList(@event));

            mainForm.ShowPanel(caller);
            caller.Reload();
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
            if (!FillInTime())
            {
                finishResultLabel.Text = "Invalid time.";
                return;
            }
            @event.Images.RemoveAll(item => item == "<none>");

            Program.Client.CreateEvent(@event);
            //Program.DataManager.Write(new DatabaseEntryAdder("events_full"), EventFull.ToDataList(@event));

            mainForm.ShowPanel(caller);
            caller.Reload();
            //origin.LoadMyEvents();
            this.Close();
        }

        private void DeleteEvent(object sender, EventArgs e)
        {
            Program.Client.DeleteEvent(@event.Id);
            //Program.DataManager.Write(new DatabaseEntryRemover("events_full", @event.Id), null);

            mainForm.ShowPanel(caller);
            caller.Reload();
            //origin.LoadMyEvents();
            Close();
        }

        private void SaveDraft(object sender, EventArgs e)
        {
            try
            {
                //EXTENTION METHOD
                this.@event.Address = this.addressBox.Text.FormatAddressInfo();
                MapPoint location = this.@event.Address.ToStringNormal().LatLongFromString();
                this.@event.Latitude = location.Latitude;
                this.@event.Longitude = location.Longitude;
            }
            catch { }
            FillInEvent();
            FillInTime();
            @event.Images.RemoveAll(item => item == "<none>");

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
            caller.Reload();
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
            int index = @event.Images.IndexOf(imageLinkBox.Text);
            if (index == -1)
            {
                if (@event.Images.Count == 2)
                {
                    if (@event.Images[1] == "<none>")
                    {
                        @event.Images[1] = imageLinkBox.Text;
                    }
                    else
                    {
                        @event.Images.Add(imageLinkBox.Text);
                    }
                }
                else
                {
                    @event.Images.Add(imageLinkBox.Text);
                }
            }
            FillInPhotos();
            imageLinkBox.Clear();
        }

        private void ShowThumbnailBox(object sender, EventArgs e)
        {
            thumbnailLinkBox.Visible = true;
            addThumbnailButton.Visible = true;
        }

        private void ShowPhotoBox(object sender, EventArgs e)
        {
            imageLinkBox.Visible = true;
            addPhotoButton.Visible = true;
        }

        private void returnButton_MouseEnter(object sender, EventArgs e)
        {
            returnButton.BackgroundImage = Properties.Resources.BackButtonGreenHover;
        }

        private void returnButton_MouseLeave(object sender, EventArgs e)
        {
            returnButton.BackgroundImage = Properties.Resources.BackButtonGreen;
        }

        private void returnButton_Click(object sender, EventArgs e)
        {
            mainForm.ShowPanel(caller);
        }

        private void checkAddressButton_MouseEnter(object sender, EventArgs e)
        {
            checkAddressButton.BackgroundImage = Properties.Resources.MapsButtonHover;
        }

        private void checkAddressButton_MouseLeave(object sender, EventArgs e)
        {
            checkAddressButton.BackgroundImage = Properties.Resources.MapsButton;
        }

        private void addThumbnailButton_MouseEnter(object sender, EventArgs e)
        {
            addThumbnailButton.BackgroundImage = Properties.Resources.PlusButtonHover;
        }

        private void addThumbnailButton_MouseLeave(object sender, EventArgs e)
        {
            addThumbnailButton.BackgroundImage = Properties.Resources.PlusButton;
        }

        private void addPhotoButton_MouseEnter(object sender, EventArgs e)
        {
            addPhotoButton.BackgroundImage = Properties.Resources.PlusButtonHover;
        }

        private void addPhotoButton_MouseLeave(object sender, EventArgs e)
        {
            addPhotoButton.BackgroundImage = Properties.Resources.PlusButton;
        }
    }
}
