using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Database.TableClasses
{
    public class Sport
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public Sport() { }
    }
}
