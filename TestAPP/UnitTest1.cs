using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalendarAPP.Entity;
using System.Collections.Generic;

namespace TestAPP
{
    [TestClass]
    public class EventOverBookTest
    {
        [TestMethod]
        public void ChekForEventOverBookWith_SignleEevnt()
        {
            // Arrange
            Event e = new Event();
            List<Event> events = new List<Event>();
            events.Add(new Event() {
                EventName ="E1",
                EventId = 1,
                StartTime = DateTime.Now.AddHours(2),
                EndTime = DateTime.Now.AddHours(3)
            });
            // Act 
            int result = e.CheckForOverBook(events).Count;

            // Assert
            Assert.IsTrue(result == 0, "No over book events");
        }

        [TestMethod]
        public void ChekForEventOverBookWith_SameStartDateAndEndDate()
        {
            // Arrange
            Event e = new Event();
            List<Event> events = new List<Event>();
            events.Add(new Event()
            {
                EventName = "E1",
                EventId = 1,
                StartTime = DateTime.Now.AddHours(2),
                EndTime =  DateTime.Now.AddHours(3)
            });
            events.Add(new Event()
            {
                EventName = "E2",
                EventId = 2,
                StartTime =  DateTime.Now.AddHours(2),
                EndTime = DateTime.Now.AddHours(3)
            });
            // Act 
            int result = e.CheckForOverBook(events).Count;

            // Assert
            Assert.IsTrue(result == 2, "Event is over lapping");
        }

        [TestMethod]
        public void ChekForEventOverBookWith_DuplicateEvent()
        {
            // Arrange
            Event e = new Event();
            List<Event> events = new List<Event>();
            events.Add(new Event()
            {
                EventName = "E1",
                EventId = 1,
                StartTime = DateTime.Now.AddHours(2),
                EndTime = DateTime.Now.AddHours(3)
            });
            events.Add(new Event()
            {
                EventName = "E1",
                EventId = 1,
                StartTime = DateTime.Now.AddHours(2),
                EndTime = DateTime.Now.AddHours(3)
            });
            // Act 
            int result = e.CheckForOverBook(events).Count;

            // Assert
            Assert.IsTrue(result == 0, $"Expected Result = 0 and Retrun events {result}");
        }

        [TestMethod]
        public void ChekForEventOverBookWith_Atleast2EventOverride()
        {
            
            Event e = new Event();
            List<Event> events = new List<Event>();
            events.Add(new Event()
            {
                EventName = "E1",
                EventId = 1,
                StartTime = DateTime.Now.AddHours(2),
                EndTime = DateTime.Now.AddHours(5)
            });
            events.Add(new Event()
            {
                EventName = "E2",
                EventId = 2,
                StartTime = DateTime.Now.AddHours(5),
                EndTime = DateTime.Now.AddHours(6)
            });
            events.Add(new Event()
            {
                EventName = "E3",
                EventId = 3,
                StartTime = DateTime.Now.AddHours(3),
                EndTime = DateTime.Now.AddHours(4)
            });
            int result = e.CheckForOverBook(events).Count;
            Assert.IsTrue(result >= 2, $"Duplicate event/events {result}");
        }

        [TestMethod]
        public void ChekForEventOverBookWith_NullAsAnEvent()
        {

            Event e = new Event();
            List<Event> events = new List<Event>();
            events = null;
            int result = e.CheckForOverBook(events).Count;
            Assert.IsTrue(result == 0, "method should return 0 events");
        }

    }
}
