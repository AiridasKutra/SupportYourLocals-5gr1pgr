using System;
using System.Collections.Generic;
using System.Text;

namespace localhostUI.EventClasses
{
    class Team
    {
        private string name;
        private List<Player> teamPlayers;

        public string Name { get => name; set => name = value; }
        public List<Player> TeamPlayers { get => teamPlayers; set => teamPlayers = value; }
    }
}
