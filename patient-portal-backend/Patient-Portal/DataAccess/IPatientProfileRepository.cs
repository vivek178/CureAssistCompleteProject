using Patient_Portal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Patient_Portal.DataAccess
{
    public interface IPatientProfileRepository
    {
        Task<int> AddPatientProfile(Patient patient);
        Patient ViewProfile(string emailid);
        Patient GetPatientById(string userId);
        Task<List<Patient>> ViewProfileDetails();
        Task<int> UpdatePatientProfile(string emailid,Patient patient);
    }
}
