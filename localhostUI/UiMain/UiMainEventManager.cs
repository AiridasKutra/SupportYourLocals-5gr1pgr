using Common;
using localhostUI.Backend;
using localhostUI.Backend.DataManagement;
using localhostUI.Classes.EventClasses;
using localhostUI.UiEvent;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace localhostUI
{
    public partial class UiMain
    {
        private void SaveDraftFile(object sender, EventArgs e)
        {   
            AddDraftFileToList();
        }

        private void AddDraftFileToList()
        {
            //EventFull eventFull = new EventFull
            //{
            //    Name = nameBox.Text,
            //    Address = eventAdressBox.Text,
            //    StartDate = dateBox.Value,
            //    Price = priceBox.Value,
            //    Description = descriptionBox.Text
            //};
            //eventFull.AddSport(sportBox.Text);

            //DataList data = EventFull.ToDataList(eventFull);
            //drafts.Add(data);
        }

        private void SetUpEventManagerTab()
        {
            // Make horizontal scrollbar invisible
            emanagerMyEventsPanel.HorizontalScroll.Maximum = 0;
            emanagerMyEventsPanel.AutoScroll = false;
            emanagerMyEventsPanel.VerticalScroll.Visible = false;
            emanagerMyEventsPanel.AutoScroll = true;

            emanagerDraftsPanel.HorizontalScroll.Maximum = 0;
            emanagerDraftsPanel.AutoScroll = false;
            emanagerDraftsPanel.VerticalScroll.Visible = false;
            emanagerDraftsPanel.AutoScroll = true;

            // Load panels
            LoadMyEvents();
            LoadDrafts();
        }

        /// <summary>
        /// For now this function loads all events in the database,
        /// but in the future it will be changed to only display
        /// the events of the currently logged in user.
        /// </summary>
        public void LoadMyEvents()
        {
            emanagerMyEventsPanel.Controls.Clear();

            // Get all events
            List<EventBrief> events = Program.DataProvider.GetEventsBrief(new EventOptions());

            // Add events to display
            int counter = 0;
            foreach (var @event in events)
            {
                Panel eventPanel = new Panel();
                eventPanel.Location = new Point(0, counter * 35);
                eventPanel.Size = new Size(300, 35);

                Label eventName = new Label();
                eventName.Font = new Font("Arial", 13.0f, FontStyle.Bold);
                eventName.Text = @event.Name;
                eventName.AutoSize = false;
                eventName.Location = new Point(0, counter * 35);
                eventName.Size = new Size(300, 35);
                eventName.TextAlign = ContentAlignment.MiddleLeft;
                int color = 225 + (counter % 2) * 10;
                eventName.BackColor = Color.FromArgb(color, color, color);

                eventName.Click += (sender, e) =>
                {
                    // Get full event data from database
                    List<EventFull> eventData = Program.Client.SelectEventsFull(@event.Id);
                    //Program.DataManager.Read(new DatabaseReader($"select from events_full id {@event.Id}"), out eventData);
                    try
                    {
                        new EventEditor(this, eventData[0], true).Show();
                    }
                    catch (InvalidCastException)
                    {
                        Console.WriteLine($"ERROR: Event \"{@event.Name}\" can't be opened (invalid data)");
                    }
                    catch (IndexOutOfRangeException)
                    {
                        Console.WriteLine($"ERROR: No events with id '{@event.Id}' retrieved from database");
                    }
                    catch (NullReferenceException)
                    {
                        Console.WriteLine($"ERROR: database reader returned null");
                    }
                };

                emanagerMyEventsPanel.Controls.Add(eventName);
                counter++;
            }
        }

        public void LoadDrafts()
        {
            emanagerDraftsPanel.Controls.Clear();

            // Get all events
            Program.DraftManager.LoadDrafts();
            List<EventFull> drafts = Program.DraftManager.GetEvents();

            // Add drafts to display
            int counter = 0;
            foreach (var draft in drafts)
            {
                Panel eventPanel = new Panel();
                eventPanel.Location = new Point(0, counter * 35);
                eventPanel.Size = new Size(300, 35);

                Label eventName = new Label();
                eventName.Font = new Font("Arial", 13.0f, FontStyle.Bold);
                eventName.Text = draft.Name;
                eventName.AutoSize = false;
                eventName.Location = new Point(0, 0);
                eventName.Size = new Size(265, 35);
                eventName.TextAlign = ContentAlignment.MiddleLeft;
                int color = 225 + (counter % 2) * 10;
                eventName.BackColor = Color.FromArgb(color, color, color);

                Button removeButton = new Button();
                removeButton.BackgroundImage = Properties.Resources.CloseButton;
                removeButton.BackgroundImageLayout = ImageLayout.Center;
                removeButton.ImageAlign = ContentAlignment.MiddleCenter;
                removeButton.BackColor = Color.FromArgb(color, color, color);
                removeButton.FlatStyle = FlatStyle.Flat;
                removeButton.FlatAppearance.BorderSize = 0;
                removeButton.Location = new Point(265, 0);
                removeButton.Size = new Size(35, 35);

                int draftId = draft.Id;
                removeButton.Click += (sender, e) =>
                {
                    try
                    {
                        List<EventFull> draftList = Program.DraftManager.GetEvents();
                        foreach (var @draft in draftList)
                        {
                            if (@draft.Id == draftId)
                            {
                                draftList.Remove(@draft);
                                Program.DraftManager.SaveDrafts();
                                Program.DraftManager.LoadDrafts();
                                LoadDrafts();
                                break;
                            }
                        }
                    }
                    catch (InvalidCastException)
                    {
                        Console.WriteLine("ERROR: save failed because a draft is corrupted");
                    }
                };

                eventName.Click += (sender, e) =>
                {
                    new EventEditor(this, draft, true).Show();
                };

                eventPanel.Controls.Add(eventName);
                eventPanel.Controls.Add(removeButton);

                emanagerDraftsPanel.Controls.Add(eventPanel);
                counter++;
            }
        }

        private void emanagerCreateNewEventButton_Click(object sender, EventArgs e)
        {
            new EventEditor(this).Show();
        }
    }
}
