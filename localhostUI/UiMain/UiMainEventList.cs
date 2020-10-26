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
        private void LoadMainEvents()
        {
            CurrentEventsTable.Controls.Clear();

            List<EventBrief> events = Program.DataProvider.GetEventsBrief(new EventOptions());

            for (int i = 0; i < events.Count; i++)
            {
                Label eventName = new Label();
                eventName.Text = events[i].Name;
                eventName.AutoSize = true;
                eventName.BorderStyle = BorderStyle.FixedSingle;
                CurrentEventsTable.Controls.Add(eventName);
            }

            CurrentEventsTable.RowCount = events.Count;
        }
    }
}
