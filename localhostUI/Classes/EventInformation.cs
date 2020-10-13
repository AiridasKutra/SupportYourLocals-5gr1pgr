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

        public List<Event> Events { get; set; }

        public EventInformation()
        {
            //Just this now so no Null whatever bullshittery.
            this.Events = new List<Event>();

            //Read data from file or server and put it into the list pls.
        }

    }
}
