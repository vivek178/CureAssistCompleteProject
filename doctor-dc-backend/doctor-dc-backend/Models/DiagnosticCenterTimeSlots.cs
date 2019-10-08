using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace doctor_dc_backend.Models
{
    public class DiagnosticCenterTimeSlots
    {
        public string slotId { get; set; }
        public string diagnosticCenterId { get; set; }
        public string userId { get; set; }
        public string testConductedInSlot { get; set; }
        public string slotStartTime { get; set; } // Format HH:MM AM/PM
        public string slotEndTime { get; set; } // Format HH:MM AM/PM
        public int slotCapacity { get; set; }
    }
}
