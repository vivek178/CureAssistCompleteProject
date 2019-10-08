using doctor_dc_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace doctor_dc_backend.BusinessLayer
{
   public interface IDoctorService
    {
        void AddDoctor(Doctor doc);
        Doctor GetDoctorById(string userid);
        List<Doctor> GetAllDoctors();
        List<Doctor> SearchDoctors(string city, string docName = "", string docSpecialization = "", string pincode="");
        bool UpdateDoctorById(string userid, Doctor doc);
        bool DeleteDoctorById(string userid);
        void AddDoctorTimeSlot(string userid, DoctorTimeSlots ts);
        List<DoctorTimeSlots> GetAllTimeSlotsOfDoctor(string userid);
        DoctorTimeSlots GetSpecificSlotOfDoctor(string userid, string slotId);
        bool UpdateTimeSlotOfDoctor(string userid, string slotId, DoctorTimeSlots ts);
        bool DeleteTimeSlotOfDoctor(string userid, string slotId);
    }
}
