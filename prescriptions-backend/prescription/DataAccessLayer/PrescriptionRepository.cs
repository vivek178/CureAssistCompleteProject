using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using prescription.Entities;


namespace prescription.DataAccessLayer
{
    public class PrescriptionRepository : IPrescriptionRepository
    {
        private readonly PrescriptionDbContext context;
        public PrescriptionRepository(PrescriptionDbContext prescriptionDbContext)
        {
            context = prescriptionDbContext;
        }

        public void AddPrescription(Prescription prescription)
        {
            context.prescriptions.InsertOne(prescription);
        }

        public bool RemovePrescription(string prescriptionid)
        {

            var deleteResult = context.prescriptions.DeleteOne(c => c.prescriptionId == prescriptionid);

            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;

        }

        public List<Prescription> GetPrescriptionByPatientId(string patientId)
        {
            return context.prescriptions.Find(d => d.patientId == patientId).ToList();
        }


        public Prescription GetPrescriptionByPrescriptionId(string prescriptionId)
        {
            return context.prescriptions.Find(p => p.prescriptionId == prescriptionId).SingleOrDefault();
        }

        public List<Prescription> GetPrescriptions()
        {
            return context.prescriptions.Find(_ => true).ToList();
        }

    }
       
}
