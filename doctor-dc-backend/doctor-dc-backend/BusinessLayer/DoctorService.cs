using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using doctor_dc_backend.BusinessLayer.Exceptions;
using doctor_dc_backend.DataAccessLayer;
using doctor_dc_backend.Models;

namespace doctor_dc_backend.BusinessLayer
{
  public class DoctorService : IDoctorService
  {
    private readonly IDoctorRepository repository;
    public DoctorService(IDoctorRepository doctorRepository)
    {
      repository = doctorRepository;
    }
    public void AddDoctor(Doctor doc)
    {
      Doctor d = repository.GetDoctorById(doc.userid);
      if(d == null)
      {
        repository.AddDoctor(doc);
      }
      else
      {
        throw new DoctorAlreadyExistsException($"Doctor with doctorId {doc.userid} already Exists");
      }
    }
    public Doctor GetDoctorById(string userid)
    {
      Doctor doc = repository.GetDoctorById(userid);
      if(doc != null)
      {
        return doc;
      }
      else
      {
        throw new DoctorNotFoundException($"Doctor with id {userid} does not exist");
      }
    }
    public List<Doctor> GetAllDoctors()
    {
      return repository.GetAllDoctors();
    }
    public List<Doctor> SearchDoctors(string city, string docName = "", string docSpecialization = "",string pincode="")
    {
      return repository.SearchDoctors(city, docName, docSpecialization, pincode);
    }
    public bool UpdateDoctorById(string userid, Doctor doc)
    {
      Doctor reqDoc = repository.GetDoctorById(userid);
      if(reqDoc != null)
      {
        return repository.UpdateDoctorById(userid, doc);
      }
      else
      {
        throw new DoctorNotFoundException($"Doctor with id {userid} does not exist");
      }
    }
    public bool DeleteDoctorById(string userid)
    {
      Doctor reqDoc = repository.GetDoctorById(userid);
      if(reqDoc != null)
      {
        return repository.DeleteDoctorById(userid);
      }
      else
      {
        throw new DoctorNotFoundException($"Doctor with id {userid} does not exist");
      }
    }
    public void AddDoctorTimeSlot(string userid, DoctorTimeSlots ts)
    {
      repository.AddDoctorTimeSlot(userid, ts);
    }
    public List<DoctorTimeSlots> GetAllTimeSlotsOfDoctor(string userid)
    {
      return repository.GetAllTimeSlotsOfDoctor(userid);
    }
    public DoctorTimeSlots GetSpecificSlotOfDoctor(string userid, string slotId)
    {
      var ts = repository.GetSpecificSlotOfDoctor(userid, slotId);
      if(ts != null)
      {
        return ts;
      }
      else
      {
        throw new TimeSlotNotFoundException("No Such Time Slot Exists");
      }
    }
    public bool UpdateTimeSlotOfDoctor(string userid, string slotId, DoctorTimeSlots ts)
    {
      var _ts = repository.GetSpecificSlotOfDoctor(userid, slotId);
      if(_ts != null)
      {
        return repository.UpdateTimeSlotOfDoctor(userid, slotId, ts);
      }
      else
      {
        throw new TimeSlotNotFoundException("No Such Time Slot Exists");
      }
    }
    public bool DeleteTimeSlotOfDoctor(string userid, string slotId)
    {
      var _ts = repository.GetSpecificSlotOfDoctor(userid, slotId);
      if(_ts != null)
      {
        return repository.DeleteTimeSlotOfDoctor(userid, slotId);
      }
      else
      {
        throw new TimeSlotNotFoundException("No Such Time Slot Exists");
      }
    }
  }
}
