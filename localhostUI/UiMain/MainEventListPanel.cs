using Common;
using localhostUI.Backend;
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

            // Set sport to "Any"
            filterSportSelector.Items.Add("Any");
            filterSportSelector.SelectedIndex = 0;

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
            int START_HEIGHT = 250;
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
                    catch { }
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

                                float ratio;
                                if (bitmap.Width / (float)bitmap.Height > 16.0f / 9.0f)
                                {
                                    ratio = IMAGE_HEIGHT / (float)bitmap.Height;
                                }
                                else
                                {
                                    ratio = IMAGE_WIDTH / (float)bitmap.Width;
                                }

                                int newWidth = (int)(bitmap.Width * ratio);
                                int newHeight = (int)(bitmap.Height * ratio);
                                int posX = -Math.Abs(newWidth - IMAGE_WIDTH) / 2;
                                int posY = -Math.Abs(newHeight - IMAGE_HEIGHT) / 2;

                                Bitmap scaledBitmap = new Bitmap(newWidth, newHeight);
                                Graphics g = Graphics.FromImage(scaledBitmap);
                                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                                g.DrawImage(bitmap, posX, posY, newWidth, newHeight);
                                g.Dispose();
                                thumbnail.Image = scaledBitmap;

                                stream.Flush();
                                stream.Close();
                            }
                        }
                        catch { }
                    };
                    worker.RunWorkerAsync();

                // Name label
                Label eventName = new Label();
                eventName.Text = eBrief.Name;
                eventName.AutoSize = false;
                eventName.Location = new Point(0, IMAGE_HEIGHT);
                eventName.MinimumSize = new Size(IMAGE_WIDTH, BANNER_HEIGHT);
                eventName.Font = new Font("Arial Rounded", 12, FontStyle.Bold);
                eventName.BackColor = Color.White;
                eventName.TextAlign = ContentAlignment.MiddleLeft;

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
                eventPanel.Controls.Add(eventName);
                //eventPanel.Controls.Add(eventSports);
                //eventPanel.Controls.Add(eventDistance);

                eventGridPanel.Controls.Add(eventPanel);

                col = (++col) % COL_COUNT;
                count++;

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
