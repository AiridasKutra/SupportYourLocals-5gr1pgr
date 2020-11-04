using Common;
using localhostUI.Backend;
using localhostUI.Backend.DataManagement;
using localhostUI.Classes.EventClasses;
using localhostUI.Classes.LocationClasses;
using localhostUI.Classes.UserInformationClasses;
using localhostUI.UiEvent;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Xml.Schema;

namespace localhostUI
{
    public partial class UiMain
    {
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
            filterPriceSlider.Maximum = (int)maxPrice * 10;
            filterPriceSlider.Value = filterPriceSlider.Maximum;
            filterPriceSlider_Scroll(null, null);
            filterDistanceSlider.Maximum = 1000;

            // Set selected dates
            filterStartDate.Value = DateTime.Now.AddDays(-7);
            filterEndDate.Value = DateTime.Now.AddMonths(1);

            // Set sport to "Any"
            filterSportSelector.SelectedIndex = 0;

            // Load events
            filterButton_Click(null, null);
        }

        private void LoadMainEvents(EventOptions options)
        {
            CurrentEventsTable.Controls.Clear();

            // Get events
            List<EventBrief> events = Program.DataProvider.GetEventsBrief(options);
            List<int> scores = new List<int>();

            if (options.Keywords.Count > 0)
            {
                // Calculate scores
                KeywordFinder kFinder = new KeywordFinder();
                foreach (var evBrief in events)
                {
                    DataList @event = EventBrief.ToDataList(evBrief);
                    scores.Add(kFinder.Find(options.Keywords.ToArray(), @event));
                }

                // Sort
                EventBrief[] eventArray = events.ToArray();
                int[] scoreArray = scores.ToArray();
                Array.Sort(scoreArray, eventArray);
                events = eventArray.ToList();
                scores = scoreArray.ToList();
                events.Reverse();
                scores.Reverse();
            }

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
                eventPanel.Size = new Size(240, 238);
                eventPanel.Margin = new Padding(42, 0, 42, 0);
                eventPanel.BorderStyle = BorderStyle.Fixed3D;

                eventPanel.Click += (sender, e) =>
                {
                    new UiEventDisplay(eBrief.Id, this).Show();
                };

                // Thumbnail
                PictureBox thumbnail = new PictureBox();
                thumbnail.Size = new Size(240, 180);
                thumbnail.Location = new Point(0, 0);
                thumbnail.Click += (sender, e) =>
                {
                    new UiEventDisplay(eBrief.Id, this).Show();
                };
                try
                {
                    using (WebClient client = new WebClient())
                    {
                        Stream stream = client.OpenRead(eBrief.Thumbnail);
                        Bitmap bitmap = new Bitmap(stream);
                        Bitmap bitmapScaled = new Bitmap(bitmap, new Size(240, 180));
                        thumbnail.Image = bitmapScaled;

                        stream.Flush();
                        stream.Close();
                    }
                }
                catch
                {

                }

                // Name label
                Label eventName = new Label();
                eventName.Text = eBrief.Name;
                eventName.AutoSize = true;
                eventName.Location = new Point(0, 180);
                eventName.MinimumSize = new Size(240, 30);
                eventName.Font = new Font("Arial Rounded", 12, FontStyle.Bold);
                eventName.BackColor = Color.FromArgb(240, 240, 240);
                eventName.TextAlign = ContentAlignment.MiddleLeft;

                // Sport label
                Label eventSports = new Label();
                eventSports.Text = "";
                eventSports.Font = new Font("Arial", 11);
                foreach (var sport in eBrief.GetSports())
                {
                    eventSports.Text += $"{sport}  ";

                }
                eventSports.AutoSize = false;
                eventSports.Location = new Point(0, 210);
                eventSports.Size = new Size(240, 25);
                eventSports.BackColor = Color.FromArgb(230, 230, 230);
                eventSports.TextAlign = ContentAlignment.MiddleLeft;

                // Add everything
                eventPanel.Controls.Add(thumbnail);
                eventPanel.Controls.Add(eventName);
                eventPanel.Controls.Add(eventSports);

                CurrentEventsTable.Controls.Add(eventPanel, col, count / CurrentEventsTable.ColumnCount);

                col = (++col) % CurrentEventsTable.ColumnCount;
                count++;

                // Redraw
                Invalidate();
            }

            CurrentEventsTable.RowCount = (events.Count + 1) / CurrentEventsTable.ColumnCount;
        }

        private EventOptions GetEventOptionsFromFilters()
        {
            EventOptions options = new EventOptions();
            if (filterSportSelector.SelectedIndex != 0)
            {
                options.AddSport((string)filterSportSelector.SelectedItem);
            }
            options.SetLowerDate(filterStartDate.Value);
            options.SetUpperDate(filterEndDate.Value);
            options.SetMaxPrice(filterPriceSlider.Value / 10m);
            if (filterDistanceSlider.Value > 0)
            {
                options.SetMaxDistance(filterDistanceSlider.Value / 10.0);
            }

            return options;
        }

        private void filterButton_Click(object sender, EventArgs e)
        {
            LoadMainEvents(GetEventOptionsFromFilters());
        }

        private void filterPriceSlider_Scroll(object sender, EventArgs e)
        {
            filterPriceValueLabel.Text = $"{filterPriceSlider.Value / 10.0:0.0}€";
        }

        private void filterDistanceSlider_Scroll(object sender, EventArgs e)
        {
            filterDistanceValueLabel.Text = $"{filterDistanceSlider.Value / 10.0:0.0}km";
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            EventOptions options = GetEventOptionsFromFilters();

            string[] keywords = searchTextBox.Text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            foreach (var keyword in keywords)
            {
                options.AddKeyword(keyword);
            }

            LoadMainEvents(options);
        }
    }
}
