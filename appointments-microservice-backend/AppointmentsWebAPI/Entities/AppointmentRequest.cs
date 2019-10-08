using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace AppointmentsWebAPI.Entities
{
    public class AppointmentRequest
    {
        [JsonProperty("attendees")]
        public List<string> Attendees { get; set; }

        [JsonProperty("symptom")]
        public string[] Symptom { get; set; }

        [JsonProperty("slot")]
        public TimeSlot Slot  { get; set; }
    }
}