using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using doctor_dc_backend.BusinessLayer;
using doctor_dc_backend.BusinessLayer.Exceptions;
using doctor_dc_backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace doctor_dc_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService service;
        public DoctorController(IDoctorService doctorService)
        {
            service = doctorService;
        }
        [HttpGet]
        public IActionResult GetAllDoctors()
        {
            try
            {
                return Ok(service.GetAllDoctors());
            }
            catch(Exception exe)
            {
                return BadRequest(exe.Message);
            }
        }
        [HttpGet]
        [Route("{userid}")]
        public IActionResult GetDoctorById(string userid)
        {
            try
            {
                return Ok(service.GetDoctorById(userid));
            }
            catch(DoctorNotFoundException dExe)
            {
                return NotFound(dExe.Message);
            }
            catch(Exception exe)
            {
                return BadRequest(exe.Message);
            }
        }
        [HttpPost]
        public IActionResult AddDoctor([FromBody] Doctor doc)
        {
            doc.ts= new List<DoctorTimeSlots>();
            doc.doctorSlots = new List<DoctorTimeSlots>();
            try
            {
                service.AddDoctor(doc);
                return Ok("Added Doctor Successfully");
            }
            catch(DoctorAlreadyExistsException dExe)
            {
                return BadRequest(dExe.Message);
            }
            catch(Exception exe)
            {
                return BadRequest(exe.Message);
            }
        }
        [HttpPut]
        [Route("{docId}")]
        public IActionResult UpdateDoctor(string docId, [FromBody]Doctor doc)
        {
            try
            {
                return Ok(service.UpdateDoctorById(docId, doc));
            }
            catch(DoctorNotFoundException dExe)
            {
                return NotFound(dExe.Message);
            }
            catch(Exception exe)
            {
                return BadRequest(exe.Message);
            }
        }
        [HttpDelete]
        [Route("{docId}")]
        public IActionResult DeleteDoctor(string docId)
        {
            try
            {
                return Ok(service.DeleteDoctorById(docId));
            }            
            catch(DoctorNotFoundException dExe)
            {
                return NotFound(dExe.Message);
            }
            catch(Exception exe)
            {
                return BadRequest(exe.Message);
            }
        }
        [HttpGet]
        [Route("search")]
        public IActionResult GetDoctorsByQuery([FromQuery] string city, [FromQuery] string name="", [FromQuery] string specialization="", [FromQuery] string pincode="")
        {
            try
            {
                Console.WriteLine("City = " + city);
                Console.WriteLine("Doctor Name = " + name);
                Console.WriteLine("Doctor Specialization = " + specialization);
                return Ok(service.SearchDoctors(city, name, specialization, pincode));
            }
            catch(Exception exe)
            {
                return BadRequest(exe.Message);
            }
        }
        [HttpPost]
        [Route("{doctorId}/timeslots")]
        public IActionResult AddDoctorTimeSlots(string doctorId, [FromBody] DoctorTimeSlots ts)
        {
            try
            {
                service.AddDoctorTimeSlot(doctorId, ts);
                return Ok($"Time Slot added for doctor with id {doctorId}");
            }
            catch(Exception exe)
            {
                return BadRequest(exe.Message);
            }
        }
        [HttpGet]
        [Route("{userid}/timeslots")]
        public IActionResult GetAllTimeSlotsOfDoctor(string userid)
        {
            try
            {
                return Ok(service.GetAllTimeSlotsOfDoctor(userid));
            }
            catch(Exception exe)
            {
                return BadRequest(exe.Message);
            }
        }
        [HttpGet]
        [Route("{userid}/timeslots/{slotId}")]
        public IActionResult GetSpecificSlotOfDoctor(string userid, string slotId)
        {
            try
            {
                return Ok(service.GetSpecificSlotOfDoctor(userid, slotId));
            }
            catch(Exception exe)
            {
                return BadRequest(exe.Message);
            }
        }
        [HttpPut]
        [Route("{userid}/timeslots/{slotId}")]
        public IActionResult UpdateSlotOfDoctor(string userid, string slotId, [FromBody] DoctorTimeSlots ts)
        {
            try
            {
                return Ok(service.UpdateTimeSlotOfDoctor(userid, slotId, ts));
            }
            catch(TimeSlotNotFoundException tExe)
            {
                return NotFound(tExe.Message);
            }
            catch(Exception exe)
            {
                return BadRequest(exe.Message);
            }
        }
        [HttpDelete]
        [Route("{userid}/timeslots/{slotId}")]
        public IActionResult DeleteTimeSlotOfDoctor(string userid, string slotId)
        {
            try
            {
                return Ok(service.DeleteTimeSlotOfDoctor(userid, slotId));
            }
            catch(TimeSlotNotFoundException tExe)
            {
                return NotFound(tExe.Message);
            }
            catch(Exception exe)
            {
                return BadRequest(exe.Message);
            }
        }
    }
}