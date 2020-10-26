using localhostUI.Backend;
using localhostUI.Classes.EventClasses;
using System;
using System.Collections.Generic;
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
            foreach (var eBrief in events)
            {
                // Main container
                Panel eventPanel = new Panel();
                eventPanel.AutoSize = true;

                // Name label
                Label eventName = new Label();
                eventName.Text = eBrief.Name;
                eventName.AutoSize = true;
                eventName.Location = new System.Drawing.Point(0, 0);
                eventName.Font = new System.Drawing.Font("Comic Sans MS", 15);

                // Sport label
                Label eventSports = new Label();
                eventSports.Text = "";
                foreach (var sport in eBrief.GetSports())
                {
                    eventSports.Text += $"{sport}  ";

                }
                eventSports.AutoSize = true;
                eventSports.Location = new System.Drawing.Point(0, 30);

                // Add everything
                eventPanel.Controls.Add(eventName);
                eventPanel.Controls.Add(eventSports);

                CurrentEventsTable.Controls.Add(eventPanel);

                // Redraw
                Invalidate();
            }

            CurrentEventsTable.RowCount = events.Count;
        }
    }
}
