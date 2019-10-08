using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using doctor_dc_backend.Models;
using doctor_dc_backend.DataAccessLayer;
using doctor_dc_backend.BusinessLayer.Exceptions;

namespace doctor_dc_backend.BusinessLayer
{
    public class DiagnosisCenterService : IDiagCenService
    {
        private readonly IDiagCenRepository repository;
        public DiagnosisCenterService(IDiagCenRepository dcRepo)
        {
            repository = dcRepo;
        }
        public void AddDiagnosticCenter(DiagnosisCenter dc)
        {
            var _dc = repository.GetDiagnosticCenterById(dc.diagnosticCenterId);
            if(_dc == null)
            {
                repository.AddDiagnosticCenter(dc);
            }
            else
            {
                throw new DiagnosisCenterAlreadyExistsException($"Diagnosis Center with id {dc.diagnosticCenterId} already exists");
            }
        }
        public DiagnosisCenter GetDiagnosticCenterById(string dcId)
        {
            var dc = repository.GetDiagnosticCenterById(dcId);
            if(dc != null)
            {
                return dc;
            }
            else
            {
                throw new DiagnosisCenterNotFoundException($"Diagnosis Center with id {dcId} not found");
            }
        }
        public List<DiagnosisCenter> GetAllDiagnosticCenters()
        {
            return repository.GetAllDiagnosticCenters();
        }
        public List<DiagnosisCenter> SearchDiagnosticCenters(string city, string name = "", string testsConducted = "", string pincode="")
        {
            return repository.SearchDiagnosticCenters(city, name, testsConducted, pincode);
        }
        public bool UpdateDiagnosticCenter(string dcId, DiagnosisCenter dc)
        {
            var reqDiagCen = repository.GetDiagnosticCenterById(dcId);
            if(reqDiagCen != null)
            {
                return repository.UpdateDiagnosticCenter(dcId, dc);
            }
            else
            {
                throw new DiagnosisCenterNotFoundException($"Diagnosis Center with id {dcId} not found");
            }
        }
        public bool DeleteDiagnosticCenter(string dcId)
        {
            var reqDiagCen = repository.GetDiagnosticCenterById(dcId);
            if(reqDiagCen != null)
            {
                return repository.DeleteDiagnosticCenter(dcId);
            }
            else
            {
                throw new DiagnosisCenterNotFoundException($"Diagnosis Center with id {dcId} not found");
            } 
        }

        public void AddDiagnosticCenterTimeSlot(string dcId, DiagnosticCenterTimeSlots ts)
        {
            repository.AddDiagnosticCenterTimeSlot(dcId, ts);
        }

        public List<DiagnosticCenterTimeSlots> GetAllTimeSlotsOfDiagnosticCenter(string dcId)
        {
            return repository.GetAllTimeSlotsOfDiagnosticCenter(dcId);
        }

        public DiagnosticCenterTimeSlots GetSpecificSlotOfDiagnosticCenter(string dcId, string slotId)
        {
            var ts = repository.GetSpecificSlotOfDiagnosticCenter(dcId, slotId);
            if (ts != null)
            {
                return ts;
            }
            else
            {
                throw new TimeSlotNotFoundException("No Such Time Slot Exists");
            }
        }

        public bool UpdateTimeSlotOfDiagnosticCenter(string dcId, string slotId, DiagnosticCenterTimeSlots ts)
        {
            var _ts = repository.GetSpecificSlotOfDiagnosticCenter(dcId, slotId);
            if (_ts != null)
            {
                return repository.UpdateTimeSlotOfDiagnosticCenter(dcId, slotId, ts);
            }
            else
            {
                throw new TimeSlotNotFoundException("No Such Time Slot Exists");
            }
        }

        public bool DeleteTimeSlotOfDiagnosticCenter(string dcId, string slotId)
        {
            var _ts = repository.GetSpecificSlotOfDiagnosticCenter(dcId, slotId);
            if (_ts != null)
            {
                return repository.DeleteTimeSlotOfDiagnosticCenter(dcId, slotId);
            }
            else
            {
                throw new TimeSlotNotFoundException("No Such Time Slot Exists");
            }
        }
    }
}
