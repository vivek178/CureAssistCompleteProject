using prescription.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace prescription.BusinessLayer
{
    public interface IPrescriptionService
    {
        void AddPrescription(Prescription prescription);
        List<Prescription> GetPrescriptionByPatientId(string patientId);

        List<Prescription> GetPrescriptions();
        Prescription GetPrescriptionByPrescriptionId(string prescriptionId);
        bool RemovePrescription(string prescriptionid);
    }
}
