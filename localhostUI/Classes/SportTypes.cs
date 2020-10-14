using System;
using System.Collections.Generic;
using System.Text;

namespace localhostUI.Classes
{
    class SportTypes
    {
        private List<string> sportList;
        public List<string> SportList { get; set; }
        public SportTypes()
        {
            this.SportList = new List<string>();
        }
    }
}
