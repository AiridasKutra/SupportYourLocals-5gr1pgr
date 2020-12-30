using Database.TableClasses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiDatabase.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventsController : ControllerBase
    {
        private readonly ILogger<EventsController> _logger;

        public EventsController(ILogger<EventsController> logger)
        {
            _logger = logger;
        }

        private Account GetAccountFromHeader()
        {
            HttpContext.Request.Headers.TryGetValue("AccountId", out StringValues stringValues);
            if (stringValues.Count == 1)
            {
                int accId = -1;
                int.TryParse(stringValues[0], out accId);

                if (accId != -1)
                {
                    return Program.Database.QSelectAccounts(item => item.Id == accId).FirstOrDefault();
                }
            }
            return null;
        }

        [HttpGet("full/{id}")]
        public Event GetFullEvent(int id)
        {
            HttpContext.Response.StatusCode = 200;
            return Program.Database.QSelectEvents(item => item.Id == id).FirstOrDefault();
            //var rng = new Random();
            //return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            //{
            //    Date = DateTime.Now.AddDays(index),
            //    TemperatureC = rng.Next(-20, 55),
            //    Summary = Summaries[rng.Next(Summaries.Length)]
            //})
            //.ToArray();

            //return Enumerable.Range(1, 5).Select(index => new Event()).ToArray();
        }

        [HttpGet("brief")]
        public IEnumerable<Event> GetBriefEvents()
        {
            HttpContext.Response.StatusCode = 200;
            return Program.Database.QSelectEvents(item => true).Select(item => new Event(item, true));
        }

        [HttpPost]
        public void CreateEvent(Event @event)
        {
            Account acc = GetAccountFromHeader();
            if (acc != null)
            {
                @event.Author = acc.Id;
                Program.Database.QCreateEvent(@event);
                Program.Database.SaveChanges();
                HttpContext.Response.StatusCode = 201;
                return;
            }
            HttpContext.Response.StatusCode = 400;
        }

        [HttpPut("{id}")]
        public void EditEvent(int id, Event @event)
        {
            Program.Database.QEditEvent(id, @event);
            Program.Database.SaveChanges();
            HttpContext.Response.StatusCode = 200;
            return;
        }

        [HttpDelete("{id}")]
        public void DeleteEvent(int id)
        {
            Program.Database.QDeleteEvent(item => item.Id == id);
            Program.Database.SaveChanges();
            HttpContext.Response.StatusCode = 200;
            return;
        }

        [HttpPut("visibility/{id}/{visible}")]
        public void SetEventVisibility(int id, int visible)
        {
            bool setTo = false;
            if (visible == 0) setTo = false;
            else if (visible == 1) setTo = true;
            else
            {
                HttpContext.Response.StatusCode = 400;
                return;
            }

            var events = Program.Database.QSelectEvents(item => item.Id == id);
            if (events.Count > 0)
            {
                events[0].Visible = setTo;
                Program.Database.SaveChanges();
                HttpContext.Response.StatusCode = 200;
                return;
            }
            HttpContext.Response.StatusCode = 400;
        }

        [HttpGet("count")]
        public int GetEventCount()
        {
            return Program.Database.QSelectEvents(item => true).Count;
        }
    }
}
