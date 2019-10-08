using Patient_Portal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Patient_Portal.BusinessLayer
{
    public interface IPatientProfileService
    {
        Task<int> AddPatientProfile(Patient patient);
        Patient ViewProfile(string emailid);
        Patient GetPatientById(string userId);
        Task<int> UpdatePatientProfile(string emailid,Patient patient);
        Task<List<Patient>> ViewProfileDetails();
    }
}
