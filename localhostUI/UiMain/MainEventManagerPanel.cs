using localhostUI.Backend;
using localhostUI.Classes.EventClasses;
using localhostUI.UiEvent;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace localhostUI
{
    public partial class MainEventManagerPanel : Form, IPanel
    {
        private int ITEM_WIDTH = 400;
        private int ITEM_HEIGHT = 50;
        private int START_HEIGHT = 125;
        private int MARGINS = 10;

        private UiMain mainForm;

        public void Reload() { }

        public Panel GetPanel()
        {
            return mainPanel;
        }

        public void SetMainRef(UiMain main)
        {
            mainForm = main;
        }

        public MainEventManagerPanel()
        {
            InitializeComponent();
            SetUpEventManagerTab();
        }

        public void SetUpEventManagerTab()
        {
            // Make horizontal scrollbar invisible
            //emanagerMyEventsPanel.HorizontalScroll.Maximum = 0;
            //emanagerMyEventsPanel.AutoScroll = false;
            //emanagerMyEventsPanel.VerticalScroll.Visible = false;
            //emanagerMyEventsPanel.AutoScroll = true;

            //emanagerDraftsPanel.HorizontalScroll.Maximum = 0;
            //emanagerDraftsPanel.AutoScroll = false;
            //emanagerDraftsPanel.VerticalScroll.Visible = false;
            //emanagerDraftsPanel.AutoScroll = true;

            // Load panels
            LoadMyEvents();
            LoadDrafts();

            // Set panel size
            eventsPanel.Location = new Point(eventsPanel.Location.X, START_HEIGHT);
            draftsPanel.Location = new Point(draftsPanel.Location.X, START_HEIGHT);
            int h1 = eventsPanel.Size.Height;
            int h2 = draftsPanel.Size.Height;
            mainPanel.Size = new Size(mainPanel.Size.Width, START_HEIGHT + Math.Max(h1, h2));
        }

        public void LoadMyEvents()
        {
            eventsPanel.Controls.Clear();

            // Add create event button
            Button createEventButton = new Button();
            createEventButton.BackColor = Color.WhiteSmoke;
            createEventButton.FlatStyle = FlatStyle.Flat;
            createEventButton.FlatAppearance.BorderSize = 0;
            createEventButton.Location = new Point(0, 0);
            createEventButton.Size = new Size(ITEM_WIDTH, ITEM_HEIGHT);
            createEventButton.Font = new Font("Arial Rounded", 15.0f, FontStyle.Bold);
            createEventButton.Text = "+ Create new event";
            createEventButton.TextAlign = ContentAlignment.MiddleCenter;
            createEventButton.Click += createEventButton_Click;
            eventsPanel.Controls.Add(createEventButton);

            // Get all events
            List<EventBrief> events = Program.DataProvider.GetEventsBrief(new EventOptions());

            // Add events to display
            int counter = 1;
            foreach (var @event in events)
            {
                Panel eventPanel = new Panel();
                eventPanel.Location = new Point(0, counter * (ITEM_HEIGHT + MARGINS));
                eventPanel.Size = new Size(ITEM_WIDTH, ITEM_HEIGHT);

                Label eventName = new Label();
                eventName.Font = new Font("Arial Rounded", 15.0f, FontStyle.Bold);
                eventName.Text = @event.Name;
                eventName.AutoSize = false;
                eventName.Location = new Point(0, 0);
                eventName.Size = new Size(ITEM_WIDTH, ITEM_HEIGHT);
                eventName.Padding = new Padding(10, 0, 0, 0);
                eventName.TextAlign = ContentAlignment.MiddleLeft;
                //eventName.BackColor = Color.FromArgb(109, 168, 135);
                eventName.BackColor = Color.FromArgb(230, 230, 230);

                eventName.Click += (sender, e) =>
                {
                    // Get full event data from database
                    List<EventFull> eventData = Program.Client.SelectEventsFull(@event.Id);
                    //Program.DataManager.Read(new DatabaseReader($"select from events_full id {@event.Id}"), out eventData);
                    try
                    {
                        mainForm.ShowPanel(new EventEditorPanel(eventData[0], true));
                        //new EventEditorPanel(this, eventData[0], true).Show();
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

                eventPanel.Controls.Add(eventName);
                eventsPanel.Controls.Add(eventPanel);
                counter++;
            }

            eventsPanel.Size = new Size(400, (ITEM_HEIGHT + MARGINS) * (events.Count + 1));
        }

        public void LoadDrafts()
        {
            draftsPanel.Controls.Clear();

            // Get all events
            Program.DraftManager.LoadDrafts();
            List<EventFull> drafts = Program.DraftManager.GetEvents();

            // Add drafts to display
            int counter = 0;
            foreach (var draft in drafts)
            {
                Panel eventPanel = new Panel();
                eventPanel.Location = new Point(0, counter * (ITEM_HEIGHT + MARGINS));
                eventPanel.Size = new Size(ITEM_WIDTH, ITEM_HEIGHT);

                Label eventName = new Label();
                eventName.Font = new Font("Arial Rounded", 15.0f, FontStyle.Bold);
                eventName.Text = draft.Name;
                eventName.AutoSize = false;
                eventName.Location = new Point(0, 0);
                eventName.Size = new Size(ITEM_WIDTH - ITEM_HEIGHT, ITEM_HEIGHT);
                eventName.Padding = new Padding(10, 0, 0, 0);
                eventName.TextAlign = ContentAlignment.MiddleLeft;
                //eventName.BackColor = Color.FromArgb(109, 168, 135);
                eventName.BackColor = Color.FromArgb(230, 230, 230);

                Button removeButton = new Button();
                removeButton.BackgroundImage = Properties.Resources.CloseButton;
                removeButton.BackgroundImageLayout = ImageLayout.Center;
                removeButton.ImageAlign = ContentAlignment.MiddleCenter;
                //removeButton.BackColor = Color.FromArgb(109, 168, 135);
                removeButton.BackColor = Color.FromArgb(230, 230, 230);
                removeButton.FlatStyle = FlatStyle.Flat;
                removeButton.FlatAppearance.BorderSize = 0;
                removeButton.Location = new Point(ITEM_WIDTH - ITEM_HEIGHT, 0);
                removeButton.Size = new Size(ITEM_HEIGHT, ITEM_HEIGHT);

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
                    mainForm.ShowPanel(new EventEditorPanel(draft, true));
                    //new EventEditor(this, draft, true).Show();
                };

                eventPanel.Controls.Add(eventName);
                eventPanel.Controls.Add(removeButton);

                draftsPanel.Controls.Add(eventPanel);
                counter++;
            }

            draftsPanel.Size = new Size(400, (ITEM_HEIGHT + MARGINS) * drafts.Count);
        }

        private void createEventButton_Click(object sender, EventArgs e)
        {
            mainForm.ShowPanel(new EventEditorPanel());
            //new EventEditor(this).Show();
            //BackgroundWorker worker = new BackgroundWorker();
            //worker.DoWork += (s, e) =>
            //{
            //    try
            //    {
            //        for (int i = 0; i < 1000; i++)
            //        {
            //            Invoke((Action)(() => { titleLabel.Location = new Point(titleLabel.Location.X, titleLabel.Location.Y + 1); }));
            //            Thread.Sleep(6);
            //        }
            //    }
            //    catch { return; }
            //};
            //worker.RunWorkerAsync();
        }
    }
}
