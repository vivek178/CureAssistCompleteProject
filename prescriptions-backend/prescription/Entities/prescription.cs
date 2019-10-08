using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using System.Xml.Serialization;

namespace prescription.Entities
{
    public class Prescription
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string prescriptionId { get; set; }
        public string prescriptionDate { get; set; }
        public string patientId { get; set; }
        public string patientName { get; set; }
        public string doctorName { get; set; }
        public string patientPhoneNumber { get; set; }
        public string doctorphoneNumber { get; set; }
        public string[] symptoms { get; set; }
        public string remarks { get; set; }
        public string[] suggestedTests { get; set;}
        public List<prescribedMedicines> allPrescribedMedicines { get; set; }
    }
}
