using System;
using System.Collections.Generic;
using System.Text;

namespace localhostUI.EventClasses
{
    class Team
    {
        private string name;
        private List<Player> players;

        public string Name { get { return name; } set { name = value; } }
        public List<Player> GetPlayers()
        {
            return players;
        }

        public Team()
        {
            name = "";
            players = new List<Player>();
        }

        public Team(string name, List<Player> players)
        {
            this.name = name;
            this.players = players;
        }
    }
}
