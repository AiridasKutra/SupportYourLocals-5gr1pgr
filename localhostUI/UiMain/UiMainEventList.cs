using localhostUI.Backend;
using localhostUI.Classes.EventClasses;
using localhostUI.UiEvent;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace localhostUI
{
    public partial class UiMain
    {
        private void LoadMainEvents(EventOptions options)
        {
            CurrentEventsTable.Controls.Clear();

            // Get events
            List<EventBrief> events = Program.DataProvider.GetEventsBrief(options);

            // Add all of them to a list
            int col = 0;
            int count = 0;
            foreach (var eBrief in events)
            {
                // Main container
                Panel eventPanel = new Panel();
                eventPanel.AutoSize = false;
                eventPanel.Size = new Size(240, 238);
                eventPanel.Margin = new Padding(8);
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
                eventName.Font = new Font("Comic Sans MS", 12);
                eventName.BackColor = Color.FromArgb(240, 240, 240);
                eventName.TextAlign = ContentAlignment.MiddleLeft;

                // Sport label
                Label eventSports = new Label();
                eventSports.Text = "";
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
    }
}
