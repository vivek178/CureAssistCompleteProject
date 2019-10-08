using Microsoft.EntityFrameworkCore;
using Patient_Portal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Patient_Portal.DataAccess
{
    public class PatientProfileRepository : IPatientProfileRepository
    {
        private readonly PatientDbContext patientContext;
        public PatientProfileRepository(PatientDbContext patientContext)
        {
            this.patientContext = patientContext;
        }
        public Task<int> AddPatientProfile(Patient patient)
        {
            patientContext.patients.AddAsync(patient);
            return patientContext.SaveChangesAsync();
        }
        public Patient ViewProfile(string emailid)
        {
            var _patient = patientContext.patients.Where(u=>u.Email==emailid).FirstOrDefault();
            return _patient;
        }
        public Patient GetPatientById(string userId)
        {
            var _patient = patientContext.patients.Where(u => u.userId == userId).FirstOrDefault();
            return _patient;
        }
        public Task<int> UpdatePatientProfile(string emailid,Patient patient)
        {
            var patientbyid = patientContext.patients.Where(u => u.Email == emailid).FirstOrDefault();
            patientbyid.FirstName = patient.FirstName;
            patientbyid.LastName = patient.LastName;
            patientbyid.PhoneNumber = patient.PhoneNumber;
            patientbyid.UAID = patient.UAID;
            patientbyid.BloodGroup = patient.BloodGroup;
            patientbyid.city = patient.city;
            patientbyid.DateOfBirth = patient.DateOfBirth;
            patientbyid.EmergencyContactNumber = patient.EmergencyContactNumber;
            patientbyid.Email = patient.Email;
            patientContext.patients.Update(patientbyid);
            return patientContext.SaveChangesAsync();
            
        }

        public Task<List<Patient>> ViewProfileDetails()
        {
            return patientContext.patients.ToListAsync<Patient>();
        }


    }
}
