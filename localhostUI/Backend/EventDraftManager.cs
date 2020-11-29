using Common;
using localhostUI.Backend.DataManagement;
using localhostUI.Classes.EventClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace localhostUI.Backend
{
    class EventDraftManager
    {
        private readonly List<EventFull> events;

        public EventDraftManager()
        {
            events = new List<EventFull>();
        }

        public List<EventFull> GetEvents() { return events; }

        public void AddEvent(EventFull eventFull) { events.Add(eventFull); }

        public void LoadDrafts()
        {
            events.Clear();
            
            DraftFileReader draftFileReader = new DraftFileReader();
            Program.DataManager.Read(draftFileReader, out DataList data);
            if (data != null)
            {
                int id = 0;
                foreach (ListItem ev in data)
                {
                    try
                    {
                        ((DataList)ev.item).Remove("id");
                        ((DataList)ev.item).Add(id, "id");
                        events.Add(new EventFull((DataList)ev.item));
                    }
                    catch (InvalidCastException)
                    {
                        Console.WriteLine("Invalid draft data...");
                    }
                    id++;
                }
            }
        }

        public void SaveDrafts()
        {
            DataList dataList = new DataList();
            DraftFileWriter draftFileWriter = new DraftFileWriter();
            try
            {
                foreach (EventFull draft in events)
                {
                    dataList.Add(draft.ToDataList());
                }
                Program.DataManager.Write(draftFileWriter, dataList);
            }
            catch (Exception)
            {
                Console.WriteLine("Error saving drafts...");
            }
        }






    }
}
