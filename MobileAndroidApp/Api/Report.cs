using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Database.TableClasses
{
    public class Report
    {
        public int Id { get; set; }

        public int EventId { get; set; }

        public string Type { get; set; }

        public string Comment { get; set; }

        public Report() {}
    }
}
