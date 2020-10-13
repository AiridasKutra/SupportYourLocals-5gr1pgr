using System;
using System.Collections.Generic;
using System.Text;

namespace localhostUI.EventClasses
{
    class Player
    {
        private int age;
        private string name;
        private List<string> extraInfo;

        public int Age { get => age; set => age = value; }
        public string Name { get => name; set => name = value; }
        public List<string> ExtraInfo { get => extraInfo; set => extraInfo = value; }
    }
}
