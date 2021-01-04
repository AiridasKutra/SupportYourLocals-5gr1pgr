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
    public class DraftManager
    {
        private static List<Event> _eventDrafts;

        public static List<Event> GetDrafts()
        {
            return _eventDrafts;
        }

        public static Event GetDraft(int id)
        {
            return _eventDrafts.FirstOrDefault(item => item.Id == id);
        }

        public static bool SetDraft(int id, Event @event)
        {
            Event ev = _eventDrafts.FirstOrDefault(item => item.Id == id);
            if (ev != null)
            {
                ev = @event;
                return true;
            }
            return false;
        }
        
        public static void Save()
        {
            var backingFile = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "EventDrafts.json");

            using (var writer = File.CreateText(backingFile))
            {
                string output = JsonConvert.SerializeObject(_eventDrafts);
                writer.WriteLine(output);
            }
        }

        public static void Load()
        {
            var backingFile = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "EventDrafts.json");

            if(!File.Exists(backingFile))
            {
                _eventDrafts = new List<Event>();
                return;
            }

            string text;
            using (var reader = new StreamReader(backingFile))
            {
                text = reader.ReadToEnd();
            }
            _eventDrafts = JsonConvert.DeserializeObject<List<Event>>(text);
        }

        public static void AddDraft(Event @event)
        {
            var e = _eventDrafts.LastOrDefault();
            if (e == null)
            {
                @event.Id = 0;
            }
            else
            {
                @event.Id = e.Id + 1;
            }
            _eventDrafts.Add(@event);
        }

        public static void RemoveDraft(int Id)
        {
            _eventDrafts.RemoveAll(item => item.Id == Id);
        }
    }
}