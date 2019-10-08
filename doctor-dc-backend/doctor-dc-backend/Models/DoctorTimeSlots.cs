using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace doctor_dc_backend.Models
{
  public class DoctorTimeSlots
  {
        public  string slotId { get;set; }
        public string doctorId { get; set; }
        public string userId { get; set; }
        public  string slotStartTime { get; set; } // Format HH:MM AM/PM
        public string slotEndTime { get; set; } // Format HH:MM AM/PM
        public  int slotCapacity { get; set; }
  }
}