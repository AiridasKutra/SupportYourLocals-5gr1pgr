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

        public string Name { get { return name; } set { name = value; } }

        public Player()
        {
            extraInfo = new List<string>();
        }

        public Player(string name)
        {
            this.name = name;
        }
    }
}
