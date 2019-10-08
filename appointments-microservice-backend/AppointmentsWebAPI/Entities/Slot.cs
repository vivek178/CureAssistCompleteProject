using System;
using System.Collections.Generic;

namespace AppointmentsWebAPI.Entities
{
    public class Slot
    {
        public TimeSlot TimeSlot { get; set; }

        public List<AttendeeWithSymptom> Attendees { get; set; }
    }
}