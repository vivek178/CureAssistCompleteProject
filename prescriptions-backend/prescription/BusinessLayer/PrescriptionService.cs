using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using prescription.BusinessLayer.Exceptions;
using prescription.DataAccessLayer;
using prescription.Entities;

namespace prescription.BusinessLayer
{
    public class PrescriptionService : IPrescriptionService
    {
        private readonly IPrescriptionRepository repository;
        public PrescriptionService(IPrescriptionRepository prescriptionRepository)
        {
            repository = prescriptionRepository;
        }

        public void AddPrescription(Prescription prescription)
        {
                repository.AddPrescription(prescription);
        }

        public Prescription GetPrescriptionByPrescriptionId(string prescriptionId)
        {
            return repository.GetPrescriptionByPrescriptionId(prescriptionId);
        }

        public List<Prescription> GetPrescriptionByPatientId(string patientId)
        {
            return repository.GetPrescriptionByPatientId(patientId);

            //if (result.Count == 0)
            //{
            //    throw new PrescriptionNotFoundException("No prescriptions with such phone number was found");
            //}
            //else
            //{
            //    return result;
            //}

        }


        public bool RemovePrescription(string prescriptionid)
        {
            var _del = repository.GetPrescriptionByPrescriptionId(prescriptionid);
            if (_del == null)
            {
                throw new PrescriptionNotFoundException($"prescription with Id{prescriptionid} not found");
            }
            else
                return repository.RemovePrescription(prescriptionid);


        }

      public List<Prescription> GetPrescriptions()
      {
          return repository.GetPrescriptions();
      }
    }
}
