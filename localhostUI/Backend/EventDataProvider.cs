using localhostUI.Classes.EventClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace localhostUI.Backend
{
    class EventDataProvider
    {
        public bool InitialLoadDoneBrief { get; set; }
        public bool InitialLoadDoneFull { get; set; }

        public EventDataProvider()
        {
            InitialLoadDoneBrief = false;
            InitialLoadDoneFull = false;
        }

        public List<EventBrief> GetEventsBrief(EventOptions options)
        {
            Program.DataPool.LoadEventsBrief();
            InitialLoadDoneBrief = true;

            List<EventBrief> events = new List<EventBrief>();
            foreach (var evBrief in Program.DataPool.eventsBrief)
            {
                if (options.Test(evBrief))
                {
                    events.Add(new EventBrief(evBrief));
                }
            }
            return events;
        }

        public List<EventFull> GetEventsFull(EventOptions options)
        {
            Program.DataPool.LoadEventsFull();
            InitialLoadDoneFull = true;

            List<EventFull> events = new List<EventFull>();
            foreach (var evFull in Program.DataPool.eventsFull)
            {
                if (options.Test(evFull))
                {
                    events.Add(new EventFull(evFull));
                }
            }
            return events;
        }
    }
}
