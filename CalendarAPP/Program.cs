using CalendarAPP.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalendarAPP
{
    class Program
    {
        static void Main(string[] args)
        {
            Event calenderevent = new Event();
            List<Event> events = calenderevent.CreateEvents();
            StringBuilder str = new StringBuilder();
            foreach (var v in events)
            {
                Console.WriteLine($"Event Name : {v.EventName} \t StartDate : {v.StartTime} \t EndDate :{v.EndTime}");
            }
            List<Event> overLappingEvent = calenderevent.CheckForOverBook(events);
            formatEventList(str, overLappingEvent);
            Console.Write(str.ToString());
            Console.ReadLine();
        }

        private static void formatEventList(StringBuilder str, List<Event> overLappingEvent)
        {
            foreach (var item in overLappingEvent)
            {
                str.Append($"{item.EventName} OverLapping with :");
                foreach (var v in item.OverLappingEvent)
                {
                    str.Append($"  {v.EventName}");
                }
                str.Append("\n");
            }
        }
    }
}
