using System;
using System.Collections.Generic;
using System.Text;

namespace localhostUI.EventClasses
{
    class Event
    {
        private string name;
        private DateTime date;
        private string sport;
        private float price;
        private string description;
        private string adress;
        private List<Team> team;

        

        public Event(string name, DateTime date, string sport, string description, string adress, float price = 0)
        {
            this.Name = name;
            this.Date = date;
            this.Sport = sport;
            this.Description = description;
            this.Price = price;
            this.Team = new List<Team>();
        }

        public string Name { get => name; set => name = value; }
        public DateTime Date { get => date; set => date = value; }
        public string Sport { get => sport; set => sport = value; }
        public float Price { get => price; set => price = value; }
        public string Description { get => description; set => description = value; }
        public string Adress { get => adress; set => adress = value; }
        public List<Team> Team { get => team; set => team = value; }

        public override string ToString()
        {
            return this.Name + " " + this.Date.ToString() + " " + Sport + " " + Price;
        }
        /*
         * More to come:
         * -location
         * -author
         * -external links
         * -event type
         */
    }
}