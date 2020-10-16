using System;
using System.Collections.Generic;
using System.Security.Permissions;
using System.Text;

namespace localhostUI.Backend
{
    class EventOptions
    {
        private List<string> sports;
        private List<string> teams;
        private List<string> players;
        private decimal minPrice;
        private decimal maxPrice;
        private int minDistance; // In meters
        private int maxDistance; // In meters
        private DateTime lowerDate;
        private DateTime upperDate;
        private List<string> keywords;

        public List<string> Sports { get { return sports; } }
        public List<string> Teams { get { return teams; } }
        public List<string> Players { get { return players; } }
        public decimal MinPrice { get { return minPrice; } }
        public decimal MaxPrice { get { return maxPrice; } }
        public int MinDistance { get { return minDistance; } }
        public int MaxDistance { get { return maxDistance; } }
        public DateTime LowerDate { get { return lowerDate; } }
        public DateTime UpperDate { get { return upperDate; } }
        public List<string> Keywords { get { return keywords; } }

        public EventOptions()
        {
            sports = new List<string>();
            teams = new List<string>();
            players = new List<string>();
            keywords = new List<string>();
            lowerDate = new DateTime(0L);
            upperDate = new DateTime(0L);
            minPrice = 0;
            maxPrice = decimal.MaxValue;
            minDistance = 0;
            maxDistance = int.MaxValue;
        }


    }
}
