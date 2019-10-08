using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace pharmacy_portal_backend.Entities
{
    public class PrescriptionOrderRequest
    { 
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string OrderId { get; set; }
        public string PrescriptionId { get; set; }
        public DateTime PrescriptionDate { get; set; }
        public string PatientId { get; set; }
        public string PatientName { get; set; }
        public string PatientPhoneNumber { get; set; }
        public string DoctorName { get; set; }
        public string DoctorPhoneNumber { get; set; }
        public string[] Symptoms { get; set; }
        public string Remarks { get; set; }
        public List<PrescribedMedicine> PrescribedMedicines { get; set; }
        public string CurrentLocation { get; set; }
        public string Pincode { get; set; }
    }
}
