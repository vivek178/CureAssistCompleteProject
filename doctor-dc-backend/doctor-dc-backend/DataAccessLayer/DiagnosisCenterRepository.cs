using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using doctor_dc_backend.Models;

namespace doctor_dc_backend.DataAccessLayer
{
    public class DiagnosisCenterRepository : IDiagCenRepository
    {
        private readonly DiagnosisCenterDbContext dcDbContext;
        public DiagnosisCenterRepository(DiagnosisCenterDbContext dbContext)
        {
            dcDbContext = dbContext;
        }
        public void AddDiagnosticCenter(DiagnosisCenter dc)
        {
            dcDbContext.DiagnosisCenters.InsertOne(dc);
        }
        public DiagnosisCenter GetDiagnosticCenterById(string userid)
        {
            return dcDbContext.DiagnosisCenters.Find(dc => dc.userid == userid).SingleOrDefault();
        }
        public List<DiagnosisCenter> GetAllDiagnosticCenters()
        {
            return dcDbContext.DiagnosisCenters.Find(_ => true).ToList();
        }
        public bool UpdateDiagnosticCenter(string userid, DiagnosisCenter dc)
        {
            var reqDiagCen = Builders<DiagnosisCenter>.Filter.Where(d => d.userid == userid);
            var _reqDiagCen = dcDbContext.DiagnosisCenters.Find(d => d.userid == userid).SingleOrDefault();
            if(reqDiagCen != null)
            {
                dc.diagnosticCenterSlots = _reqDiagCen.diagnosticCenterSlots;
                var result = dcDbContext.DiagnosisCenters.ReplaceOne(reqDiagCen, dc);
                return (result.IsAcknowledged && (result.ModifiedCount > 0));
            }
            else
            {
                return false;
            }
        }
        public bool DeleteDiagnosticCenter(string userid)
        {
            var dc = Builders<DiagnosisCenter>.Filter.Where(d => d.userid == userid);
            if(dc != null)
            {
                var result = dcDbContext.DiagnosisCenters.DeleteOne(dc);
                return (result.IsAcknowledged && (result.DeletedCount > 0));
            }
            else
            {
                return false;
            }
        }
        public List<DiagnosisCenter> SearchDiagnosticCenters(string city, string name = "", string testsConducted = "",string pincode="")
        {
            var matchCity = Builders<DiagnosisCenter>.Filter.Eq(dc => dc.diagnosticCenterCity, city);
            var matchNameAndTestsConducted = Builders<DiagnosisCenter>.Filter.Or(
                Builders<DiagnosisCenter>.Filter.Where(dc => dc.diagnosticCenterName.ToLower().Contains(name.ToLower())),
                Builders<DiagnosisCenter>.Filter.Where(dc => dc.testsConducted.ToLower().Contains(testsConducted.ToLower())),
                Builders<DiagnosisCenter>.Filter.Where(dc => dc.pincode.Equals(pincode))
            );

            var matchResult = Builders<DiagnosisCenter>.Filter.And(matchCity, matchNameAndTestsConducted);
            return dcDbContext.DiagnosisCenters.Find(matchResult).ToList();
        }

        public void AddDiagnosticCenterTimeSlot(string userid, DiagnosticCenterTimeSlots ts)
        {
            Random r = new Random();
            ts.slotId = r.Next(1111, 9999).ToString();
            ts.diagnosticCenterId = userid;
            ts.userId = userid;
            var reqDC = Builders<DiagnosisCenter>.Filter.Eq(dc => dc.userid, userid);
            var updateReqDC = Builders<DiagnosisCenter>.Update.Push(d => d.diagnosticCenterSlots, ts);

            dcDbContext.DiagnosisCenters.UpdateOne(reqDC, updateReqDC);
        }
        public List<DiagnosticCenterTimeSlots> GetAllTimeSlotsOfDiagnosticCenter(string userid)
        {
            return dcDbContext.DiagnosisCenters.Find(d => d.userid == userid).SingleOrDefault().diagnosticCenterSlots;
        }

        public DiagnosticCenterTimeSlots GetSpecificSlotOfDiagnosticCenter(string userid, string slotId)
        {
            var _timeSlots = dcDbContext.DiagnosisCenters.Find(d => d.userid == userid).SingleOrDefault().diagnosticCenterSlots;
            return _timeSlots.Find(t => t.slotId == slotId && t.diagnosticCenterId == userid);
        }

        public bool UpdateTimeSlotOfDiagnosticCenter(string userid, string slotId, DiagnosticCenterTimeSlots ts)
        {
            var reqDC = Builders<DiagnosisCenter>.Filter.Eq(dc => dc.userid, userid);
            DiagnosisCenter updateReqDC = dcDbContext.DiagnosisCenters.Find(d => d.userid == userid).SingleOrDefault();
            ts.slotId = slotId;
            ts.diagnosticCenterId = userid;
            updateReqDC.diagnosticCenterSlots[updateReqDC.diagnosticCenterSlots.FindIndex(t => t.slotId == slotId)] = ts;

            var result = dcDbContext.DiagnosisCenters.ReplaceOne(reqDC, updateReqDC);
            if(result.IsAcknowledged && (result.ModifiedCount > 0))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteTimeSlotOfDiagnosticCenter(string userid, string slotId)
        {
            
            var reqDC = Builders<DiagnosisCenter>.Filter.Eq(dc => dc.userid, userid);
            DiagnosisCenter updateReqDC = dcDbContext.DiagnosisCenters.Find(d => d.userid == userid).SingleOrDefault();

            DiagnosticCenterTimeSlots dcTs = updateReqDC.diagnosticCenterSlots.Find(t => t.slotId == slotId);
            updateReqDC.diagnosticCenterSlots.Remove(dcTs);
            
            var result = dcDbContext.DiagnosisCenters.ReplaceOne(reqDC, updateReqDC);
            if(result.IsAcknowledged && (result.ModifiedCount > 0))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
