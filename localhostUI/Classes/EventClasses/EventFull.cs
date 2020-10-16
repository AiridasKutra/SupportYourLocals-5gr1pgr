using Common;
using localhostUI.EventClasses;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Text;

namespace localhostUI.Classes.EventClasses
{
    class EventFull : EventBase
    {
        private string name;
        private List<string> sports;
        private List<Team> teams;
        // Coordinate structure TODO
        private string address;
        private DateTime startDate;
        private DateTime endDate;
        private decimal price;
        private string description;
        private List<string> links;
        private List<string> images; // Links to images (first one always the thumbnail)

        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public List<string> GetSports()
        {
            return sports;
        }
        public List<Team> GetTeams()
        {
            return teams;
        }
        public List<string> GetLinks()
        {
            return links;
        }
        public List<string> GetImages()
        {
            return images;
        }

        private void Init()
        {
            sports = new List<string>();
            teams = new List<Team>();
            links = new List<string>();
            images = new List<string>();

            name = "";
            address = "";
            startDate = new DateTime(0L);
            endDate = new DateTime(0L);
            price = 0;
            description = "";
        }

        public EventFull()
        {
            Init();
        }

        public EventFull(DataList data)
        {
            Init();

            try
            {
                // Basic conversions
                object nameObj = data.Get("name");
                if (nameObj != null)
                {
                    name = (string)nameObj;
                }
                object addressObj = data.Get("address");
                if (addressObj != null)
                {
                    address = (string)addressObj;
                }
                object startDateObj = data.Get("start_date");
                if (startDateObj != null)
                {
                    startDate = DateTime.ParseExact((string)startDateObj, "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind);
                }
                object endDateObj = data.Get("end_date");
                if (startDateObj != null)
                {
                    endDate = DateTime.ParseExact((string)startDateObj, "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind);
                }
                object priceObj = data.Get("price");
                if (priceObj != null)
                {
                    price = (decimal)priceObj;
                }
                object descriptionObj = data.Get("description");
                if (descriptionObj != null)
                {
                    description = (string)descriptionObj;
                }

                // Complex conversions
                object sportsObj = data.Get("sports");
                if (sportsObj != null)
                {
                    foreach (ListItem sport in (DataList)sportsObj)
                    {
                        sports.Add((string)sport.item);
                    }
                }
                object linksObj = data.Get("links");
                if (linksObj != null)
                {
                    foreach (ListItem link in (DataList)linksObj)
                    {
                        links.Add((string)link.item);
                    }
                }
                object imagesObj = data.Get("images");
                if (imagesObj != null)
                {
                    foreach (ListItem image in (DataList)imagesObj)
                    {
                        images.Add((string)image.item);
                    }
                }
                object teamsObj = data.Get("teams");
                if (teamsObj != null)
                {
                    foreach (ListItem team in (DataList)teamsObj)
                    {
                        string name = team.name;
                        List<Player> players = new List<Player>();

                        object playersObj = team.item;
                        if (playersObj != null)
                        {
                            foreach (ListItem player in (DataList)playersObj)
                            {
                                players.Add(new Player((string)player.item));
                            }
                        }
                    }
                }
            }
            catch (InvalidCastException)
            {
                // TODO: log incident
            }
        }

        public static DataList ToDataList(EventFull ev)
        {
            DataList data = new DataList();

            // Simple
            data.Add(ev.name, "name");
            data.Add(ev.address, "address");
            data.Add(ev.startDate.ToString("O"), "start_date");
            data.Add(ev.endDate.ToString("O"), "end_date");
            data.Add(ev.price, "price");
            data.Add(ev.description, "description");

            // Complex
            DataList sportsDl = new DataList();
            foreach (string sport in ev.sports)
            {
                sportsDl.Add(sport);
            }
            DataList linksDl = new DataList();
            foreach (string link in ev.links)
            {
                linksDl.Add(link);
            }
            DataList imagesDl = new DataList();
            foreach (string image in ev.images)
            {
                imagesDl.Add(image);
            }
            DataList teamsDl = new DataList();
            foreach (Team team in ev.teams)
            {
                DataList playersDl = new DataList();
                foreach (Player player in team.GetPlayers())
                {
                    playersDl.Add(player);
                }
                teamsDl.Add(playersDl, team.Name);
            }

            data.Add(sportsDl, "sports");
            data.Add(linksDl, "links");
            data.Add(imagesDl, "images");
            data.Add(teamsDl, "teams");

            return data;
        }
    }
}
