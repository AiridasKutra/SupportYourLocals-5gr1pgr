using Common;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace localhostUI.Backend
{
    class Message
    {
        public int Id { get; set; }

        public int Sender { get; set; }

        public string Content { get; set; }

        public DateTime SendTime { get; set; }

        public Message() { }

        public Message(DataList data, bool defaultId = false)
        {
            if (data == null) return;

            try
            {
                object idObj = data.Get("id");
                if (idObj != null && !defaultId)
                {
                    Id = (int)idObj;
                }
                object senderObj = data.Get("sender");
                if (senderObj != null)
                {
                    Sender = (int)senderObj;
                }
                object contentObj = data.Get("content");
                if (contentObj != null)
                {
                    Content = (string)contentObj;
                }
                try
                {
                    object dateObj = data.Get("send_time");
                    if (dateObj != null)
                    {
                        SendTime = DateTime.ParseExact((string)dateObj, "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind);
                    }
                }
                catch (FormatException)
                {
                    // TODO: log incident
                }
            }
            catch (InvalidCastException) { }
        }

        public DataList ToDataList()
        {
            DataList data = new DataList();

            data.Add(Id, "id");
            data.Add(Sender, "sender");
            data.Add(Content, "content");
            data.Add(SendTime.ToString("O"), "send_time");

            return data;
        }
    }
}
