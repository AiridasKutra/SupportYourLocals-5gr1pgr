using Common;
using localhostUI.Backend.DataManagement;
using localhostUI.Classes.EventClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace localhostUI.Backend
{
    class EventDataProvider
    {
        private DateTime lastLoadTimeBrief;
        private DateTime lastLoadTimeFull;

        private bool initialLoadDone;

        private List<DataList> eventsBrief;
        private List<DataList> eventsFull;

        public EventDataProvider()
        {
            initialLoadDone = false;
            lastLoadTimeBrief = DateTime.UtcNow;
        }

        private void LoadEventsBrief()
        {
            // TODO: check if database had changes since last load

            // Read all brief events
            eventsBrief = LoadEvents("select from events_brief");
            lastLoadTimeBrief = DateTime.UtcNow;
            initialLoadDone = true;
        }

        public void LoadEventsFull()
        {
            // TODO: check if database had changes since last load

            // Read all full events
            eventsFull = LoadEvents("select from events_full");
            lastLoadTimeFull = DateTime.UtcNow;
            initialLoadDone = true;
        }

        private List<DataList> LoadEvents(string command)
        {
            DataList events;
            List<DataList> eventList = new List<DataList>();

            // Get data from database
            Program.DataManager.Read(new DatabaseReader(command), out events);
            try
            {
                foreach (ListItem ev in events)
                {
                    eventList.Add((DataList)ev.item);
                }
            }
            catch (InvalidCastException)
            {
                eventList.Clear();
            }

            return eventList;
        }

        public List<EventBrief> GetEventsBrief(EventOptions options)
        {
            LoadEventsBrief();

            List<EventBrief> events = new List<EventBrief>();
            foreach (var @event in eventsBrief)
            {
                if (options.Test(@event))
                {
                    events.Add(new EventBrief(@event));
                }
            }
            return events;
        }

        public List<EventFull> GetEventsFull(EventOptions options)
        {
            LoadEventsFull();

            List<EventFull> events = new List<EventFull>();
            foreach (var @event in eventsFull)
            {
                if (options.Test(@event))
                {
                    events.Add(new EventFull(@event));
                }
            }
            return events;
        }
    }
}
