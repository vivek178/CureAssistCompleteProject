using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using doctor_dc_backend.Models;
using MongoDB.Driver;

namespace doctor_dc_backend.DataAccessLayer
{
  public class DoctorRepository : IDoctorRepository
  {
    private readonly DoctorDbContext context;
    public DoctorRepository(DoctorDbContext doctorDbContext)
    {
      context = doctorDbContext;
    }
    public void AddDoctor(Doctor doc)
    {
      context.Doctors.InsertOne(doc);
    }
    public List<Doctor> GetAllDoctors()
    {
      return context.Doctors.Find(_ => true).ToList();
    }
    public Doctor GetDoctorById(string userid)
    {
      return context.Doctors.Find(d => d.userid == userid).SingleOrDefault();
    }
    public List<Doctor> SearchDoctors(string city, string docName = "", string specialization = "", string pincode="")
    {
      var matchCity = Builders<Doctor>.Filter.Eq(d => d.doctorCity, city);

            var matchFirstNameLastNameOrSpecilization =
            Builders<Doctor>.Filter.Or(
              Builders<Doctor>.Filter.Where(d => d.doctorFirstName.ToLower().Contains(docName.ToLower())),
              Builders<Doctor>.Filter.Where(d => d.doctorLastName.ToLower().Contains(docName.ToLower())),
              Builders<Doctor>.Filter.Where(d => d.doctorSpecialization.ToLower().Contains(specialization.ToLower())),
              Builders<Doctor>.Filter.Where(d => d.pincode.Equals(pincode)));
      
      var matchResult = Builders<Doctor>.Filter.And(matchCity, matchFirstNameLastNameOrSpecilization);
      return context.Doctors.Find(matchResult).ToList();
    }
    public bool UpdateDoctorById(string userid, Doctor doc)
    {
      var reqDoc = Builders<Doctor>.Filter.Where(d => d.userid == userid);
      var _reqDoc = context.Doctors.Find(d => d.userid == userid).SingleOrDefault();
      if(reqDoc != null)
      {
        doc.doctorSlots = _reqDoc.doctorSlots;
        var result = context.Doctors.ReplaceOne(reqDoc, doc);
        return (result.IsAcknowledged && (result.ModifiedCount > 0));
      }
      else
      {
        return false;
      }
    }
    public bool DeleteDoctorById(string userid)
    {
      var reqDoc = Builders<Doctor>.Filter.Where(d => d.userid == userid);
      if(reqDoc != null)
      {
        var result = context.Doctors.DeleteOne(reqDoc);
        return (result.IsAcknowledged && (result.DeletedCount > 0));
      }
      else
      {
        return false;
      }
    }
    public void AddDoctorTimeSlot(string userid, DoctorTimeSlots ts)
    {
      Random _r = new Random();
      ts.slotId = _r.Next(1111,9999).ToString();
      ts.doctorId = userid;
      ts.userId = userid;
      var reqDoctor = Builders<Doctor>.Filter.Eq(d => d.userid, userid);
      var updatingReqDoctor = Builders<Doctor>.Update.Push(d => d.doctorSlots, ts);

      context.Doctors.UpdateOne(reqDoctor, updatingReqDoctor);

    }
    public List<DoctorTimeSlots> GetAllTimeSlotsOfDoctor(string userid)
    {
      return context.Doctors.Find(d => d.userid == userid).SingleOrDefault().doctorSlots;
    }
    public DoctorTimeSlots GetSpecificSlotOfDoctor(string userid, string slotId)
    {
      var _timeSlots = context.Doctors.Find(d => d.userid == userid).SingleOrDefault().doctorSlots;
      return _timeSlots.Find(t => t.slotId == slotId && t.doctorId == userid);
    }
    public bool UpdateTimeSlotOfDoctor(string userid, string slotId, DoctorTimeSlots ts)
    {
      var reqDoc = Builders<Doctor>.Filter.Eq(d => d.userid, userid);
      ts.slotId = slotId;
      ts.doctorId = userid;
      Doctor updatingDoctor = context.Doctors.Find(d => d.userid == userid).SingleOrDefault();
      updatingDoctor.doctorSlots[updatingDoctor.doctorSlots.FindIndex(t => t.slotId == slotId)] = ts;

      var result = context.Doctors.ReplaceOne(reqDoc, updatingDoctor);

      if(result.IsAcknowledged && (result.ModifiedCount > 0))
      {
        return true;
      }
      else
      {
        return false;
      }
    }
    public bool DeleteTimeSlotOfDoctor(string userid, string slotId)
    {
      
      var reqDoc = Builders<Doctor>.Filter.Eq(d => d.userid, userid);
      Doctor updatingDoctor = context.Doctors.Find(d => d.userid == userid).SingleOrDefault();
      DoctorTimeSlots dTs = updatingDoctor.doctorSlots.Find(t => t.slotId == slotId);
      updatingDoctor.doctorSlots.Remove(dTs);

      var result = context.Doctors.ReplaceOne(reqDoc, updatingDoctor);

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
