using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace AppointmentsWebAPI.Entities
{
    public class TimeSlot
    {

        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime Date { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime StartTime { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime EndTime { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

        public override bool Equals(Object other)
        {
            if((other == null) || ! this.GetType().Equals(other.GetType()))
            {
                return false;
            }
            else
            {
                TimeSlot slot = (TimeSlot)other;
                if (this.Date.Date.ToString() == slot.Date.Date.ToString() && 
                    this.StartTime.ToUniversalTime().ToString() == slot.StartTime.ToUniversalTime().ToString() &&
                    this.EndTime.ToUniversalTime().ToString() == slot.EndTime.ToUniversalTime().ToString())
                {
                    return true;
                }
                else
                {

                    return false;
                }
            }
        }
    }
}