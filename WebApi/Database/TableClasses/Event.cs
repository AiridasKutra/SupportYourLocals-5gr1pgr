using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;

namespace Database.TableClasses
{
    public class Event
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

        public Event(Event @event, bool brief = false)
        {
            Init();

            Id = @event.Id;
            Author = @event.Author;
            Name = @event.Name;
            Latitude = @event.Latitude;
            Longitude = @event.Longitude;
            StartDate = @event.StartDate;
            Price = @event.Price;
            Tags = @event.Tags;
            Visible = @event.Visible;
            Sports = new List<string>(@event.Sports);
            Images = new List<string>(@event.Images);

            if (!brief)
            {
                Links = new List<string>(@event.Links);
                Description = @event.Description;
                Address = @event.Address;
            }
        }
    }
}
