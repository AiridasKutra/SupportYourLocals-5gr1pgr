using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Database.TableClasses
{
    public class Report
    {
        [Key]
        public int Id { get; set; }

        public int EventId { get; set; }

        [StringLength(64)]
        public string Type { get; set; }

        [StringLength(256)]
        public string Comment { get; set; }

        public Report() {}
    }
}
