using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarAPP.Entity
{
    public class Event
    {

        public Event()
        {
            OverLappingEvent = new List<Event>();
        }

        public int EventId { get; set; }
        public string EventName { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool isOverLapping { get; set; }
        public List<Event> OverLappingEvent { get; set; }

        internal List<Event> CreateEvents()
        {
            List<Event> events = new List<Event>();
            Event e = new Event()
            {
                EventId = 1,
                EventName = "Event 1",
                StartTime = DateTime.Now.AddHours(0.5),
                EndTime = DateTime.Now.AddHours(4),
            };
            events.Add(e);
            Event e2 = new Event()
            {
                EventId = 2,
                EventName = "Event 2",
                StartTime = System.DateTime.Now.AddHours(0.5),
                EndTime = System.DateTime.Now.AddHours(2),
            };
            events.Add(e2);
            Event e3 = new Event()
            {
                EventId = 3,
                EventName = "Event 3",
                StartTime = System.DateTime.Now.AddHours(3),
                EndTime = System.DateTime.Now.AddHours(4),
            };
            events.Add(e3);
            Event e4 = new Event()
            {
                EventId = 4,
                EventName = "Event 4",
                StartTime = System.DateTime.Now.AddHours(5),
                EndTime = System.DateTime.Now.AddHours(7),
            };            
            events.Add(e4);
            return events;
        }

        public List<Event> CheckForOverBook(List<Event> events)
        {
            List<Event> orderByStartdateEvents = new List<Event>();
            if (events != null && events.Count > 0)
            {
                orderByStartdateEvents = events.OrderBy(e => e.StartTime).ToList();
                int length = orderByStartdateEvents.Count;
                for (int i = 0; i < length; i++)
                {
                    int indexi = i;
                    var currentNode = orderByStartdateEvents[i];
                    for (var j = 0; j < length - i; j++)
                    {
                        int indexj = j;
                        Event oCompareEvent = events[j];
                        if (currentNode.EventId != oCompareEvent.EventId)
                        {
                            if (oCompareEvent.StartTime <= currentNode.EndTime && oCompareEvent.EndTime > currentNode.StartTime || oCompareEvent.EndTime <= currentNode.StartTime && oCompareEvent.StartTime > currentNode.EndTime)
                            {
                                currentNode.isOverLapping = true;
                                currentNode.OverLappingEvent.Add(oCompareEvent);
                            }
                        }
                    }
                }


                //var nextNode = orderByStratTime[i + 1];

                //if (currentNode.EndTime >= nextNode.StartTime) { }
                //foreach (var eve in orderByStratTime)
                //{
                //    for (int i = 0; i < orderByStratTime.Count() - 1; i++)
                //    {
                //        if (orderByStratTime[i].EndTime >= eve.StartTime && orderByStratTime[i].StartTime <= eve.EndTime)
                //        {
                //            orderByStratTime[i].isOverLapping = true;
                //        } 
                //    }
                //    //eve.overLapping = orderByStratTime.Any(a => a.StartTime <= eve.StartTime);
                //}

            }
            return orderByStartdateEvents.Where(o => o.isOverLapping == true).ToList();
            //throw new NotImplementedException();
        }

        public override string ToString()
        {
            return string.Concat($"Event {EventId} : conflicts wiht Event {OverLappingEvent.Select(o =>o.EventName )}");
        }
    }

}
