using Common;
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


        private SearchFilter filter;
        private List<string> keywords;

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

            filter = new SearchFilter();
            keywords = new List<string>();
        }

        public bool Test(DataList data)
        {
            try
            {
                return filter.Test(data);
            }
            catch (InvalidCastException)
            {
                return false;
            };
        }

        public void AddSport(string name)
        {
            // Create filter function
            Func<DataList, bool> filterFunc = (data) =>
            {
                object sports = data.Get("sports");
                if (sports != null)
                {
                    foreach (var sport in (DataList)sports)
                    {
                        if ((string)sport.item == name)
                        {
                            return true;
                        }
                    }
                    return false;
                }
                else
                {
                    return false;
                }
            };

            // Add filter
            if (!filter.AddFilter("sport_filter", filterFunc))
            {
                filter.CreateAndAddFilter("sport_filter", false, filterFunc);
            }
        }

        public void AddTeam(string name)
        {
            // Create filter function
            Func<DataList, bool> filterFunc = (data) =>
            {
                object teams = data.Get("teams");
                if (teams != null)
                {
                    foreach (var team in (DataList)teams)
                    {
                        if (team.name == name)
                        {
                            return true;
                        }
                    }
                    return false;
                }
                else
                {
                    return false;
                }
            };

            // Add filter
            if (!filter.AddFilter("team_filter", filterFunc))
            {
                filter.CreateAndAddFilter("team_filter", false, filterFunc);
            }
        }

        public void SetMinPrice(decimal minPrice)
        {
            // Create filter function
            Func<DataList, bool> filterFunc = (data) =>
            {
                object price = data.Get("price");
                if (price != null)
                {
                    return (decimal)price >= minPrice;
                }
                else
                {
                    return false;
                }
            };

            // Add filter
            if (!filter.AddFilter("price_filter", filterFunc))
            {
                filter.CreateAndAddFilter("price_filter", true, filterFunc);
            }
        }

        public void SetMaxPrice(decimal maxPrice)
        {
            // Create filter function
            Func<DataList, bool> filterFunc = (data) =>
            {
                object price = data.Get("price");
                if (price != null)
                {
                    return (decimal)price <= maxPrice;
                }
                else
                {
                    return false;
                }
            };

            // Add filter
            if (!filter.AddFilter("price_filter", filterFunc))
            {
                filter.CreateAndAddFilter("price_filter", true, filterFunc);
            }
        }

        public void SetLowerDate(DateTime lowerDate)
        {
            // Create filter function
            Func<DataList, bool> filterFunc = (data) =>
            {
                object date = data.Get("start_date");
                if (date != null)
                {
                    return (DateTime)date >= lowerDate;
                }
                else
                {
                    return false;
                }
            };

            // Add filter
            if (!filter.AddFilter("date_filter", filterFunc))
            {
                filter.CreateAndAddFilter("date_filter", true, filterFunc);
            }
        }

        public void SetUpperDate(DateTime upperDate)
        {
            // Create filter function
            Func<DataList, bool> filterFunc = (data) =>
            {
                object date = data.Get("start_date");
                if (date != null)
                {
                    return (DateTime)date <= upperDate;
                }
                else
                {
                    return false;
                }
            };

            // Add filter
            if (!filter.AddFilter("date_filter", filterFunc))
            {
                filter.CreateAndAddFilter("date_filter", true, filterFunc);
            }
        }
    }
}
