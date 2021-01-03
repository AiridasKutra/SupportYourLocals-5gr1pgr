using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Classes; 

namespace localhost.Backend
{
    public class StorageAccess
    {
        public static List<Event> EventDrafts;
        
        public static void SaveEventDraft()
        {
            var backingFile = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "EventDrafts.json");

            using (var writer = File.CreateText(backingFile))
            {
                string output = JsonConvert.SerializeObject(EventDrafts);
                writer.WriteLine(output);
            }
        }

        public static void LoadEventDraft()
        {
            var backingFile = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "EventDrafts.json");

            if(!File.Exists(backingFile))
            {
                EventDrafts = new List<Event>();
                return;
            }

            string text;
            using (var reader = new StreamReader(backingFile))
            {
                text = reader.ReadToEnd();
            }
            EventDrafts = JsonConvert.DeserializeObject<List<Event>>(text);
        }

        public static void AddDraft(Event @event)
        {
            var e = EventDrafts.LastOrDefault();
            if (e == null)
            {
                @event.Id = 0;
            }
            else
            {
                @event.Id = e.Id + 1;
            }
            EventDrafts.Add(@event);
        }

        public static void RemoveDraft(int Id)
        {
            EventDrafts.RemoveAll(item => item.Id == Id);
        }

    }
}