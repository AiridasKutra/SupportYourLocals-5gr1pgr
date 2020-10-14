using localhostUI.EventClasses;
using System;
using System.Collections.Generic;
using System.Text;

/*
 * This class is used to keep all of the events and sport types hosted.
 * This class is bound to change to allow for smaller data keeping.
 * Is anybody gonna read this?
 * haha stinky poopy
 */
namespace localhostUI.Classes
{
    class EventInformation
    {

        //Hey so I dunno if havin multiple lists breaks the class single responsibility whatever. help...
        private List<Event> events;
        private List<string> sportTypes;

        internal List<Event> Events { get => events; set => events = value; }
        public List<string> SportTypes { get => sportTypes; set => sportTypes = value; }

        public void AddSport(string sport)
        {   
            //I dunno i created a seperate method cos i dunno how to make setter do the job
            //and setter thows a null exception or im just a pinhead
            this.SportTypes.Add(sport);
        }

        public EventInformation()
        {
            //Just this now so no Null whatever bullshittery.
            this.Events = new List<Event>();
            this.SportTypes = new List<string>();
            //Read data from file or server and put it into the list pls.
        }

    }
}
