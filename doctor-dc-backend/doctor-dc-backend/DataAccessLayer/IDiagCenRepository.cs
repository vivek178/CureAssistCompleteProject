using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using doctor_dc_backend.Models;


namespace doctor_dc_backend.DataAccessLayer
{
    public interface IDiagCenRepository
    {
        void AddDiagnosticCenter(DiagnosisCenter dc);
        DiagnosisCenter GetDiagnosticCenterById(string userid);
        List<DiagnosisCenter> GetAllDiagnosticCenters();
        List<DiagnosisCenter> SearchDiagnosticCenters(string city, string dcName = "", string testsConducted = "",string pincode="");
        bool UpdateDiagnosticCenter(string userid, DiagnosisCenter dc);
        bool DeleteDiagnosticCenter(string userid);
        void AddDiagnosticCenterTimeSlot(string userid, DiagnosticCenterTimeSlots ts);
        List<DiagnosticCenterTimeSlots> GetAllTimeSlotsOfDiagnosticCenter(string userid);
        DiagnosticCenterTimeSlots GetSpecificSlotOfDiagnosticCenter(string userid, string slotId);
        bool UpdateTimeSlotOfDiagnosticCenter(string userid, string slotId, DiagnosticCenterTimeSlots ts);
        bool DeleteTimeSlotOfDiagnosticCenter(string userid, string slotId);
    }
}
