using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace AppointmentsWebAPI.Entities
{
    // TODO: Use better name than using Appointment
    public class DayCalendar
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string DayCalendarId { get; set; }

        public string UserId { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime Date { get; set; } 

        public List<Slot> Slots { get; set; }
    }
}