using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Database.TableClasses
{
    class Sport
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public Sport() { }

        public Sport(DataList data, bool defaultId = false)
        {
            if (data == null) return;

            try
            {
                object idObj = data.Get("id");
                if (idObj != null && !defaultId)
                {
                    Id = (int)idObj;
                }
                object nameObj = data.Get("name");
                if (nameObj != null)
                {
                    Name = (string)nameObj;
                }
            }
            catch (InvalidCastException) { }
        }

        public DataList ToDataList()
        {
            DataList data = new DataList();

            data.Add(Id, "id");
            data.Add(Name, "name");

            return data;
        }
    }
}
