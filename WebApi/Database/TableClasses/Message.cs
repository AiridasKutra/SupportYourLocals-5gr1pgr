using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Database.TableClasses
{
    public class Message
    {
        public int Id { get; set; }

        public int Sender { get; set; }

        public string Content { get; set; }

        public DateTime SendTime { get; set; }

        public Message() { }
    }
}
