using Common;
using localhostUI.Backend;
using localhostUI.Classes;
using localhostUI.Classes.EventClasses;
using localhostUI.Classes.LocationClasses;
using localhostUI.Classes.UserInformationClasses;
using localhostUI.UiEvent;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace localhostUI
{
    public partial class MainEventListPanel : Form, IPanel
    {
        private UiMain mainForm;
        private Form caller;

        public void Reload() { }

        public Panel GetPanel()
        {
            return mainPanel;
        }

        public void SetMainRef(UiMain main)
        {
            mainForm = main;
        }

        public MainEventListPanel(Form caller)
        {
            this.caller = caller;

            InitializeComponent();
            SetUpCurrentEventsTab();
        }

        private void SetUpCurrentEventsTab()
        {
            // Get events
            List<EventBrief> unfilteredEvents = Program.DataProvider.GetEventsBrief(new EventOptions());

            // Set max slider values
            decimal maxPrice = 0;
            foreach (var @event in unfilteredEvents)
            {
                // Price
                if (@event.Price > maxPrice)
                {
                    maxPrice = @event.Price;
                }
            }
            filterMaxPriceSlider.Maximum = (int)maxPrice * 10;
            filterMaxPriceSlider.Value = filterMaxPriceSlider.Maximum;
            filterMaxPriceSlider_Scroll(null, null);

            // Set selected dates
            filterLowerDateSelector.Value = DateTime.Now.AddDays(-7);
            filterUpperDateSelector.Value = DateTime.Now.AddMonths(1);

            // Check permission to see invisible events
            if (Program.UserDataManager.UserAccount.Can((uint)Permissions.SET_EVENT_VISIBILITY))
            {
                showInvisibleEventsCheckBox.Visible = true;
            }

            // Load sports
            filterSportSelector.Items.Clear();
            filterSportSelector.Items.Add("Any");
            filterSportSelector.SelectedIndex = 0;
            List<string> sports = Program.Client.SelectSports();
            foreach (string sport in sports)
            {
                filterSportSelector.Items.Add(sport);
            }

            // Load events
            searchButton_Click(null, null);
        }

        private void LoadMainEvents(EventOptions options)
        {
            eventGridPanel.Controls.Clear();

            // Get events
            List<EventBrief> events = Program.DataProvider.GetEventsBrief(options);
            List<int> scores = new List<int>();
            List<double> distances = new List<double>();

            // Filter invisible
            if (!showInvisibleEventsCheckBox.Checked)
            {
                events = events.Where(item => item.Visible).ToList();
            }

            // Calculate distances
            UserData user = Program.UserDataManager.GetData();
            bool isAddressAdded = !(user.Address == "" || user.Address == null || (user.Latitude == 0 && user.Longitude == 0));
            foreach (var evBrief in events)
            {
                distances.Add(MathSupplement.Distance(user.Latitude, user.Longitude, evBrief.Latitude, evBrief.Longitude));
            }

            if (options.Keywords.Count > 0)
            {
                // Calculate scores
                KeywordFinder kFinder = new KeywordFinder();
                foreach (var evBrief in events)
                {
                    DataList @event = evBrief.ToDataList();
                    scores.Add(kFinder.Find(options.Keywords.ToArray(), @event));
                }

                // Sort by score
                EventBrief[] eventArray = events.ToArray();
                int[] scoreArray = scores.ToArray();
                Array.Sort(scoreArray, eventArray);
                events = eventArray.ToList();
                scores = scoreArray.ToList();
                events.Reverse();
                scores.Reverse();
            }
            else
            {
                // Sort by distance
                EventBrief[] eventArray = events.ToArray();
                double[] distanceArray = distances.ToArray();
                Array.Sort(distanceArray, eventArray);
                events = eventArray.ToList();
                distances = distanceArray.ToList();
            }

            // Grid variables
            int COL_COUNT = 3;
            int ROW_COUNT = (events.Count + COL_COUNT - 1) / COL_COUNT;
            int IMAGE_WIDTH = 304;
            int IMAGE_HEIGHT = 171;
            int BANNER_HEIGHT = 60;
            int START_HEIGHT = 350;
            int MARGINS = (1000 - IMAGE_WIDTH * COL_COUNT) / (COL_COUNT + 1);

            // Calculate size of event grid panel
            eventGridPanel.Size = new Size(1000, MARGINS + (IMAGE_HEIGHT + BANNER_HEIGHT + MARGINS) * ROW_COUNT);
            eventGridPanel.Location = new Point(0, START_HEIGHT);
            mainPanel.Size = new Size(1000, START_HEIGHT + eventGridPanel.Size.Height);

            // Add all of them to a list
            int col = 0;
            int count = 0;
            foreach (var eBrief in events)
            {
                // Skip events with 0 score
                if (scores.Count > 0)
                {
                    if (scores[count] == 0)
                    {
                        count++;
                        continue;
                    }
                }

                // Main container
                Panel eventPanel = new Panel();
                eventPanel.AutoSize = false;
                eventPanel.Size = new Size(IMAGE_WIDTH, IMAGE_HEIGHT + BANNER_HEIGHT);
                eventPanel.BorderStyle = BorderStyle.FixedSingle;
                eventPanel.Click += (sender, e) =>
                {
                    try
                    {
                        mainForm.ShowPanel(new UiEventDisplayPanel(eBrief.Id, this));
                        //new UiEventDisplay(eBrief.Id, this).Show();
                    }
                    catch
                    {
                        mainForm.ShowPanel(this);
                    }
                };

                // Calculate position of event panel
                eventPanel.Location = new Point
                (
                    MARGINS + (IMAGE_WIDTH + MARGINS) * col,
                    (IMAGE_HEIGHT + BANNER_HEIGHT + MARGINS) * (count / 3)
                );

                // Thumbnail
                PictureBox thumbnail = new PictureBox();
                thumbnail.Size = new Size(IMAGE_WIDTH, IMAGE_HEIGHT);
                thumbnail.Location = new Point(0, 0);
                thumbnail.Click += (sender, e) =>
                {
                    try
                    {
                        mainForm.ShowPanel(new UiEventDisplayPanel(eBrief.Id, this));
                        //new UiEventDisplay(eBrief.Id, this).Show();
                    }
                    catch { }
                };
                BackgroundWorker worker = new BackgroundWorker();
                worker.DoWork += (s, e) =>
                {
                    try
                    {
                        using (WebClient client = new WebClient())
                        {
                            Stream stream = client.OpenRead(eBrief.Images[0]);
                            Bitmap bitmap = new Bitmap(stream);

                            thumbnail.Image = Helper.ScaleBitmap(bitmap, IMAGE_WIDTH, IMAGE_HEIGHT, 16.0f / 9.0f);

                            stream.Flush();
                            stream.Close();
                        }
                    }
                    catch { }
                };
                worker.RunWorkerAsync();

                // Info panel
                Panel infoPanel = new Panel();
                infoPanel.Location = new Point(0, IMAGE_HEIGHT);
                infoPanel.Size = new Size(IMAGE_WIDTH, BANNER_HEIGHT);

                if (!eBrief.Visible)
                {
                    infoPanel.BackColor = Color.FromArgb(255, 200, 200);
                }

                // Name label
                Label eventName = new Label();
                eventName.Text = eBrief.Name;
                eventName.AutoSize = false;
                eventName.Location = new Point(10, 0);
                eventName.Size = new Size(IMAGE_WIDTH - 20, 30);
                //eventName.Font = new Font("Segoe UI Semibold", 12);
                eventName.Font = new Font("Arial", 12);
                eventName.ForeColor = Color.FromArgb(16, 16, 16);
                //eventName.BackColor = Color.White;
                eventName.TextAlign = ContentAlignment.MiddleLeft;

                int attempt = 0;
                while (true)
                {
                    Size nameSize = Helper.CalculateLabelSize(eventName, 1000);
                    if (nameSize.Width > eventName.Size.Width - 20)
                    {
                        eventName.Text = eventName.Text.Remove(eventName.Text.Length - 1);
                        attempt++;
                        continue;
                    }
                    else
                    {
                        if (attempt != 0)
                        {
                            eventName.Text += "...";

                            // Create tooltip
                            ToolTip fullEventName = new ToolTip();
                            fullEventName.SetToolTip(eventName, eBrief.Name);
                        }
                        break;
                    }
                }

                // Distance label
                Label distanceLabel = new Label();
                distanceLabel.Font = new Font("Arial", 9);
                distanceLabel.ForeColor = Color.Gray;
                distanceLabel.Location = new Point(10, 25);
                distanceLabel.AutoSize = false;
                distanceLabel.TextAlign = ContentAlignment.MiddleCenter;

                double distance = MathSupplement.Distance(eBrief.Latitude, eBrief.Longitude, user.Latitude, user.Longitude);
                if (distance < 1000.0)
                {
                    distanceLabel.Text = $"{distance:0}m";
                }
                else
                {
                    distanceLabel.Text = $"{distance / 1000.0:0.0}km";
                }

                Size distanceLabelSize = Helper.CalculateLabelSize(distanceLabel, IMAGE_WIDTH);
                distanceLabel.Size = new Size(distanceLabelSize.Width, 30);

                // Separator panel
                Panel separatorPanel1 = new Panel();
                separatorPanel1.Location = new Point(distanceLabel.Location.X + distanceLabel.Size.Width + 5, 33);
                separatorPanel1.Size = new Size(1, 16);
                separatorPanel1.BorderStyle = BorderStyle.FixedSingle;

                // Sport label
                Label sportLabel = new Label();
                sportLabel.Font = new Font("Arial", 9);
                sportLabel.ForeColor = Color.Gray;
                sportLabel.Location = new Point(distanceLabel.Location.X + distanceLabel.Size.Width + 12, 25);
                sportLabel.AutoSize = false;
                sportLabel.TextAlign = ContentAlignment.MiddleCenter;
                try { sportLabel.Text = eBrief.Sports[0]; } catch { sportLabel.Text = ""; }

                Size sportLabelSize = Helper.CalculateLabelSize(sportLabel, IMAGE_WIDTH);
                sportLabel.Size = new Size(sportLabelSize.Width, 30);

                // Separator panel
                Panel separatorPanel2 = new Panel();
                separatorPanel2.Location = new Point(sportLabel.Location.X + sportLabel.Size.Width + 5, 33);
                separatorPanel2.Size = new Size(1, 16);
                separatorPanel2.BorderStyle = BorderStyle.FixedSingle;

                // Date label
                Label dateLabel = new Label();
                dateLabel.Font = new Font("Arial", 9);
                dateLabel.ForeColor = Color.Gray;
                dateLabel.Location = new Point(sportLabel.Location.X + sportLabel.Size.Width + 12, 25);
                dateLabel.AutoSize = false;
                dateLabel.TextAlign = ContentAlignment.MiddleCenter;
                { // Create date/time label
                    string finalString = "";

                    if ((DateTime.Now - eBrief.StartDate).Ticks > 0)
                    {
                        int daysAgo = (DateTime.Now - eBrief.StartDate).Days;
                        finalString += $"Happened ";
                        if (daysAgo == 0)
                        {
                            finalString += "today";
                        }
                        else if (daysAgo == 1)
                        {
                            finalString += $"{daysAgo} day ago";
                        }
                        else
                        {
                            finalString += $"{daysAgo} days ago";
                        }
                    }
                    else
                    {
                        if (eBrief.StartDate.Year != DateTime.Now.Year)
                        {
                            finalString += $"{eBrief.StartDate:yyyy-MM-dd HH:mm}";
                        }
                        else
                        {
                            if ((eBrief.StartDate - DateTime.Now).TotalDays == 1)
                            {
                                finalString += $"Tomorrow, {eBrief.StartDate:HH:mm}";
                            }
                            else if ((eBrief.StartDate - DateTime.Now).TotalDays < 1)
                            {
                                finalString += $"Today, {eBrief.StartDate:HH:mm}";
                            }
                            else
                            {
                                finalString += $"{eBrief.StartDate:MMMM dd, HH:mm}";
                            }
                        }
                    }
                    dateLabel.Text = finalString;
                }

                Size dateLabelSize = Helper.CalculateLabelSize(dateLabel, IMAGE_WIDTH);
                dateLabel.Size = new Size(dateLabelSize.Width, 30);


                infoPanel.Controls.Add(eventName);
                infoPanel.Controls.Add(distanceLabel);
                infoPanel.Controls.Add(separatorPanel1);
                infoPanel.Controls.Add(sportLabel);
                infoPanel.Controls.Add(separatorPanel2);
                infoPanel.Controls.Add(dateLabel);

                //// Sport label
                //Label eventSports = new Label();
                //eventSports.Text = "";
                //eventSports.Font = new Font("Arial", 11);
                //foreach (var sport in eBrief.Sports)
                //{
                //    eventSports.Text += $"{sport}  ";

                //}
                //eventSports.AutoSize = false;
                //eventSports.Location = new Point(0, 210);
                //eventSports.Size = new Size(180, 25);
                //eventSports.BackColor = Color.FromArgb(230, 230, 230);
                //eventSports.TextAlign = ContentAlignment.MiddleLeft;

                //// Distance label
                //Label eventDistance = new Label();
                //eventDistance.Text = "";
                //eventDistance.Font = new Font("Arial", 11, FontStyle.Bold);
                //eventDistance.Text += $"{distances[count] / 1000.0:0.0}km";
                //eventDistance.AutoSize = false;
                //eventDistance.Location = new Point(180, 210);
                //eventDistance.Size = new Size(60, 25);
                //eventDistance.BackColor = Color.FromArgb(230, 230, 230);
                //eventDistance.TextAlign = ContentAlignment.MiddleCenter;
                //if (!isAddressAdded)
                //{
                //    eventDistance.Text = "";
                //}

                // Add everything
                eventPanel.Controls.Add(thumbnail);
                eventPanel.Controls.Add(infoPanel);
                //eventPanel.Controls.Add(eventSports);
                //eventPanel.Controls.Add(eventDistance);

                eventGridPanel.Controls.Add(eventPanel);

                col = (++col) % COL_COUNT;
                count++;

                if (mainForm != null)
                {
                    mainForm.FitCurrentPanel();
                }

                // Redraw
                Invalidate();
            }
        }

        private EventOptions GetEventOptionsFromFilters()
        {
            EventOptions options = new EventOptions();
            if (filterSportSelector.SelectedIndex > 0)
            {
                options.AddSport((string)filterSportSelector.SelectedItem);
            }
            else if (filterSportSelector.SelectedIndex == -1)
            {
                options.AddSport(filterSportSelector.Text);
            }
            options.SetLowerDate(filterLowerDateSelector.Value);
            options.SetUpperDate(filterUpperDateSelector.Value);
            options.SetMaxPrice(filterMaxPriceSlider.Value / 10m);
            if (filterMaxDistanceSlider.Value > 0)
            {
                options.SetMaxDistance(filterMaxDistanceSlider.Value / 10.0);
            }

            return options;
        }

        private void filterMaxPriceSlider_Scroll(object sender, EventArgs e)
        {
            filterMaxPriceValueLabel.Text = $"{filterMaxPriceSlider.Value / 10.0:0.0}€";
        }

        private void filterMaxDistanceSlider_Scroll(object sender, EventArgs e)
        {
            filterMaxDistanceValueLabel.Text = $"{filterMaxDistanceSlider.Value / 10.0:0.0}km";
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            EventOptions options = GetEventOptionsFromFilters();

            if (!string.IsNullOrEmpty(filterSearchTextBox.Text))
            {
                string[] keywords = filterSearchTextBox.Text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                foreach (var keyword in keywords)
                {
                    options.AddKeyword(keyword);
                }
            }

            LoadMainEvents(options);
        }
    }
}
