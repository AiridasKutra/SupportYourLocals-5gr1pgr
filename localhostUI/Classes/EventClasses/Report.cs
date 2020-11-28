using Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace localhostUI.Classes.EventClasses
{
    class Report
    {
        public int Id { get; set; }

        public int EventId { get; set; }

        public string Type { get; set; }

        public string Comment { get; set; }

        public Report() { }

        public Report(DataList data, bool defaultId = false)
        {
            if (data == null) return;

            try
            {
                object idObj = data.Get("id");
                if (idObj != null && !defaultId)
                {
                    Id = (int)idObj;
                }
                object eventIdObj = data.Get("event_id");
                if (eventIdObj != null)
                {
                    EventId = (int)eventIdObj;
                }
                object typeObj = data.Get("type");
                if (typeObj != null)
                {
                    Type = (string)typeObj;
                }
                object commentObj = data.Get("comment");
                if (commentObj != null)
                {
                    Comment = (string)commentObj;
                }
            }
            catch (InvalidCastException) { }
        }

        public DataList ToDataList()
        {
            DataList data = new DataList();

            data.Add(Id, "id");
            data.Add(EventId, "event_id");
            data.Add(Type, "type");
            data.Add(Comment, "comment");

            return data;
        }
    }
}
