using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;

namespace doctor_dc_backend.Models
{
    public class DiagnosisCenter
    {
        [XmlIgnore]
        public List<DiagnosticCenterTimeSlots> ts = new List<DiagnosticCenterTimeSlots>();
        [BsonId]
        [BsonIgnoreIfDefault]
        [BsonRepresentation(BsonType.ObjectId)]
        public string diagnosticCenterId { get; set; }
        public string userid { get; set; }
        public string diagnosticCenterName { get; set; }
        public string diagnosticCenterEmail { get; set; }
        public string diagnosticCenterPhone { get; set; }
        public string diagnosticCenterCity { get; set; }
        public string diagnosticCenterRegNum { get; set; }
        public string diagnosticCenterAddress { get; set; }
        public string pincode { get; set; }
        public string testsConducted {
            get
            {
                return String.Join( ',', this.ts.Select(s => s.testConductedInSlot).ToList());
            }
            set
            {
                //value = String.Join( ',', this.ts.Select(s => s.testConductedInSlot).ToList());
            }
        }
        public virtual List<DiagnosticCenterTimeSlots> diagnosticCenterSlots
        {
            get
            {
                return ts;
            }
            set
            {
                if(value == null)
                {
                    value = new List<DiagnosticCenterTimeSlots>();
                }
                else
                {
                    ts = value;
                }
            }
        }
    }
}
