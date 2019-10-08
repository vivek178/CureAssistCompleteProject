using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Patient_Portal.DataAccess;
using Patient_Portal.Exceptions;
using Patient_Portal.Models;

namespace Patient_Portal.BusinessLayer
{
    public class PatientProfileService : IPatientProfileService
    {
        private readonly IPatientProfileRepository patientRepo;
        public PatientProfileService(IPatientProfileRepository patientRepo)
        {
            this.patientRepo = patientRepo;
        }
        public Task<int> AddPatientProfile(Patient patient)
        {
            var _patient = patientRepo.ViewProfile(patient.Email);
            if (_patient == null)
            {
                return patientRepo.AddPatientProfile(patient);
            }
            else
            {
                throw new PatientAlreadyExistsWithIdException($"patient with this{patient.Email} already exists");
            }
        }

        public  Task<int> UpdatePatientProfile(string emailid,Patient patient)
        {
            var getPatientId = patientRepo.ViewProfile(emailid);
            if (getPatientId == null)
            {
                throw new PatientNotFoundException($"patient with this{patient.patientId} not found");
            }
            else
            {
                return patientRepo.UpdatePatientProfile(emailid, patient);
            }
        }

        public Patient ViewProfile(string emailid)
        {
            var getPatientId = patientRepo.ViewProfile(emailid);
            if (getPatientId == null)
            {
                throw new PatientNotFoundException($"patient with this{emailid} not found");
            }
            else
                return getPatientId;
        }
        public Patient GetPatientById(string userId)
        {
            var getPatientId = patientRepo.GetPatientById(userId);
            if (getPatientId == null)
            {
                throw new PatientNotFoundException($"patient with this{userId} not found");
            }
            else
                return getPatientId;
        }



        public Task<List<Patient>> ViewProfileDetails()
        {
            return patientRepo.ViewProfileDetails();
        }
    }
}
