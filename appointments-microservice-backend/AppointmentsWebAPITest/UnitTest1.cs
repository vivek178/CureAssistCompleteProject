using NUnit.Framework;
using System;
using AppointmentsWebAPI.Entities;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var Date = DateTime.Now;
            var StartTime = DateTime.Now;
            var EndTime = DateTime.Now;

            var timeSlot1 = new TimeSlot()
            {
                Date = Date,
                StartTime = StartTime,
                EndTime = EndTime
            };
            var timeSlot2 = new TimeSlot()
            {
                Date = Date,
                StartTime = StartTime,
                EndTime = EndTime
            };
            Assert.True(timeSlot1.Equals(timeSlot2));
        }
    }
}