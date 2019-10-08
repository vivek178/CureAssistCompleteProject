using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace prescription.Entities
{
    public class prescribedMedicines
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string prescribedMedicineId { get; set; }
        public string medicineName { get; set; }
        public string medicineQuantity{get; set;}
        public string prescribedDosage { get; set; }
        public string[] prescribedTimings { get; set; }
        public string prescribedDays { get; set; }
    }
}
