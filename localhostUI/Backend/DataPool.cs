﻿using Common;
using localhostUI.Backend.DataManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace localhostUI.Backend
{
    class DataPool
    {
        public List<DataList> eventsBrief;
        public List<DataList> eventsFull;
        public List<DataList> eventsDraft;
        public DataList userData;

        public DataPool()
        {
            eventsBrief = new List<DataList>();
            eventsFull = new List<DataList>();
            eventsDraft = new List<DataList>();
        }

        public void LoadDrafts()
        {
            string fileName = "FileDrafts.json";
            DraftFileReader draftFileReader = new DraftFileReader(fileName);
            Program.DataManager.Read(draftFileReader, out DataList data);
            if(data != null)
            {
                try
                {
                    foreach (ListItem ev in data)
                    {
                        eventsDraft.Add((DataList)ev.item);
                        Console.WriteLine(((DataList)ev.item).items[0].ToString());
                    }
                }
                catch (InvalidCastException)
                {
                    Console.WriteLine("Invalid cast exception thrown");
                    eventsDraft.Clear();
                }
            }
            else
            {
                eventsDraft = null;
            }
            
        }

        public void SaveDrafts()
        {
            string fileName = "FileDrafts.json";
            DataList dataList = new DataList();
            DraftFileWriter draftFileWriter = new DraftFileWriter(fileName);
            try
            {
                foreach (DataList draft in eventsDraft)
                {
                    dataList.Add(draft);
                }
                Program.DataManager.Write(draftFileWriter, dataList);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public void LoadEventsBrief()
        {
            // Select all events
            LoadEventsBrief("select from <tablename>");
        }

        public void LoadEventsBrief(string command)
        {
            // Split command into separate keywords
            List<string> commlets = new List<string>(command.ToLower().Split(' ', StringSplitOptions.RemoveEmptyEntries));

            // Find <tablename>, replace with events_brief, and join back together
            int index = commlets.IndexOf("<tablename>");
            if (index != -1 && index < commlets.Count)
            {
                commlets[index] = "events_brief";
            }
            command = string.Join(' ', commlets.ToArray());
            
            // Load the events
            eventsBrief = LoadEvents(command);
        }

        public void LoadEventsFull()
        {
            // Select all events
            LoadEventsFull("select from <tablename>");
        }

        public void LoadEventsFull(string command)
        {
            // Split command into separate keywords
            List<string> commlets = new List<string>(command.ToLower().Split(' ', StringSplitOptions.RemoveEmptyEntries));

            // Find <tablename>, replace with events_brief, and join back together
            int index = commlets.IndexOf("<tablename>");
            if (index != -1 && index < commlets.Count)
            {
                commlets[index] = "events_full";
            }
            command = string.Join(' ', commlets.ToArray());

            // Load the events
            eventsFull = LoadEvents(command);
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
    }
}
