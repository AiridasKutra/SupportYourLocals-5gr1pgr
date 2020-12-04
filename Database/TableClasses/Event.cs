using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;

namespace Database.TableClasses
{
    class Event
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Author account ID
        /// </summary>
        public int Author { get; set; }

        [StringLength(150)]
        public string Name { get; set; }

        [StringLength(150)]
        public AddressInfo Address { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public DateTime StartDate { get; set; }

        public decimal Price { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        [StringLength(50)]
        public string Tags { get; set; }

        public List<string> Sports { get; set; }

        public List<string> Links { get; set; }

        public List<string> Images { get; set; }

        // Moderation
        /// <summary>
        /// Invisible events can only be seen by the author, moderators, and administrators.
        /// </summary>
        public bool Visible { get; set; }

        private void Init()
        {
            Id = -1;

            Sports = new List<string>();
            Links = new List<string>();
            Images = new List<string>();

            Name = "";
            Latitude = 0.0;
            Longitude = 0.0;
            Address = new AddressInfo();
            StartDate = new DateTime(0L);
            Price = 0;
            Description = "";
            Tags = "";
            Visible = true;
        }

        public Event()
        {
            Init();
        }

        public Event(DataList data, bool defaultId = false)
        {
            Init();

            if (data == null) return;

            try
            {
                object idObj = data.Get("id");
                if (idObj != null && !defaultId)
                {
                    Id = (int)idObj;
                }

                // Basic conversions
                object nameObj = data.Get("name");
                if (nameObj != null)
                {
                    Name = (string)nameObj;
                }
                object authorObj = data.Get("author");
                if (authorObj != null)
                {
                    Author = (int)authorObj;
                }
                object coordinatesObj = data.Get("coordinates");
                if (coordinatesObj != null)
                {
                    object latitudeObj = ((DataList)coordinatesObj).Get(0);
                    object longitudeObj = ((DataList)coordinatesObj).Get(1);
                    if (latitudeObj != null) Latitude = (double)latitudeObj;
                    if (longitudeObj != null) Longitude = (double)longitudeObj;
                }
                object addressObj = data.Get("address");
                if (addressObj != null)
                {
                    Address = AddressInfo.FromString((string)addressObj);
                }
                try
                {
                    object startDateObj = data.Get("start_date");
                    if (startDateObj != null)
                    {
                        StartDate = DateTime.ParseExact((string)startDateObj, "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind);
                    }
                }
                catch (FormatException)
                {
                    // TODO: log incident
                }
                object priceObj = data.Get("price");
                if (priceObj != null)
                {
                    Price = (decimal)priceObj;
                }
                object descriptionObj = data.Get("description");
                if (descriptionObj != null)
                {
                    Description = (string)descriptionObj;
                }
                object visibleObj = data.Get("visible");
                if (visibleObj != null)
                {
                    Visible = (bool)visibleObj;
                }

                // Complex conversions
                object sportsObj = data.Get("sports");
                if (sportsObj != null)
                {
                    foreach (ListItem sport in (DataList)sportsObj)
                    {
                        Sports.Add((string)sport.item);
                    }
                }
                object linksObj = data.Get("links");
                if (linksObj != null)
                {
                    foreach (ListItem link in (DataList)linksObj)
                    {
                        Links.Add((string)link.item);
                    }
                }
                object imagesObj = data.Get("images");
                if (imagesObj != null)
                {
                    foreach (ListItem image in (DataList)imagesObj)
                    {
                        Images.Add((string)image.item);
                    }
                }
                object tagsObj = data.Get("tags");
                if (tagsObj != null)
                {
                    Tags = ((string)tagsObj);
                }
            }
            catch (InvalidCastException)
            {
                // TODO: log incident
            }
        }

        public DataList ToFullDataList()
        {
            DataList data = new DataList();

            // Simple
            data.Add(Id, "id");
            data.Add(Author, "author");
            data.Add(Name, "name");
            data.Add(Address.ToString(), "address");
            data.Add(StartDate.ToString("O"), "start_date");
            data.Add(Price, "price");
            data.Add(Description, "description");
            data.Add(Tags, "tags");
            data.Add(Visible, "visible");

            // Complex
            DataList sportsDl = new DataList();
            foreach (string sport in Sports)
            {
                sportsDl.Add(sport);
            }
            DataList linksDl = new DataList();
            foreach (string link in Links)
            {
                linksDl.Add(link);
            }
            DataList imagesDl = new DataList();
            foreach (string image in Images)
            {
                imagesDl.Add(image);
            }
            DataList coordinatesDl = new DataList();
            coordinatesDl.Add(Latitude);
            coordinatesDl.Add(Longitude);

            data.Add(sportsDl, "sports");
            data.Add(linksDl, "links");
            data.Add(imagesDl, "images");
            data.Add(coordinatesDl, "coordinates");

            return data;
        }

        public DataList ToBriefDataList()
        {
            DataList data = new DataList();

            // Simple
            data.Add(Id, "id");
            data.Add(Author, "author");
            data.Add(Name, "name");
            data.Add(StartDate.ToString("O"), "start_date");
            data.Add(Price, "price");
            data.Add(Tags, "tags");
            data.Add(Visible, "visible");

            // Complex
            DataList sportsDl = new DataList();
            foreach (string sport in Sports)
            {
                sportsDl.Add(sport);
            }
            DataList imagesDl = new DataList();
            foreach (string image in Images)
            {
                imagesDl.Add(image);
                break; // Add only 1
            }
            DataList coordinatesDl = new DataList();
            coordinatesDl.Add(Latitude);
            coordinatesDl.Add(Longitude);

            data.Add(sportsDl, "sports");
            data.Add(imagesDl, "images");
            data.Add(coordinatesDl, "coordinates");

            return data;
        }
    }
}
