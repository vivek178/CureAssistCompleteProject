using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using doctor_dc_backend.Models;

namespace doctor_dc_backend.BusinessLayer
{
    public interface IDiagCenService
    {
        void AddDiagnosticCenter(DiagnosisCenter dc);
        DiagnosisCenter GetDiagnosticCenterById(string dcId);
        List<DiagnosisCenter> GetAllDiagnosticCenters();
        List<DiagnosisCenter> SearchDiagnosticCenters(string city, string name = "", string testsConducted = "",string pincode="");
        bool UpdateDiagnosticCenter(string dcId, DiagnosisCenter dc);
        bool DeleteDiagnosticCenter(string dcId);
        void AddDiagnosticCenterTimeSlot(string dcId, DiagnosticCenterTimeSlots ts);
        List<DiagnosticCenterTimeSlots> GetAllTimeSlotsOfDiagnosticCenter(string dcId);
        DiagnosticCenterTimeSlots GetSpecificSlotOfDiagnosticCenter(string dcId, string slotId);
        bool UpdateTimeSlotOfDiagnosticCenter(string dcId, string slotId, DiagnosticCenterTimeSlots ts);
        bool DeleteTimeSlotOfDiagnosticCenter(string dcId, string slotId);
    }
}
