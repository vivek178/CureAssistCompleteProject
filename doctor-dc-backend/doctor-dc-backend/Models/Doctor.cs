using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace doctor_dc_backend.Models
{
    public class Doctor
    {
        [XmlIgnore]
        public List<DoctorTimeSlots> ts = new List<DoctorTimeSlots>();
        [BsonId]
        [BsonIgnoreIfDefault]
        [BsonRepresentation(BsonType.ObjectId)]
        public string doctorId { get; set; }
        public string userid { get; set; }
        public string doctorFirstName { get; set; }
        public string doctorLastName { get; set; }
        public string doctorEmail { get; set; }
        public string doctorPhoneNumber { get; set; }
        public string doctorRegNum { get; set; }
        public string doctorSpecialization { get; set; }
        public int doctorExperience { get; set; }
        public string doctorCity { get; set; }
        public string doctorAddress { get; set; }
        public string pincode { get; set; }
        public virtual List<DoctorTimeSlots> doctorSlots { 
            get
            {
                return ts;
            }
            set
            {
                if(value == null)
                {
                    value = new List<DoctorTimeSlots>();
                }
                else
                {
                    ts = value;
                }
            }
         }      
    }
}
