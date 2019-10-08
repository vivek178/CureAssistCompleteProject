using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using doctor_dc_backend.Models;
using doctor_dc_backend.BusinessLayer;
using doctor_dc_backend.BusinessLayer.Exceptions;

namespace doctor_dc_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiagnosisCenterController : ControllerBase
    {
        private readonly IDiagCenService service;
        public DiagnosisCenterController(IDiagCenService dcService)
        {
            service = dcService;
        }
        [HttpGet]
        public IActionResult GetAllDiagnosticCenters()
        {
            try
            {
                return Ok(service.GetAllDiagnosticCenters());
            }
            catch(Exception exe)
            {
                return BadRequest(exe.Message);
            }
        }
        [HttpPost]
        public IActionResult AddDiagnosticCenter([FromBody] DiagnosisCenter dc)
        {
            try
            {
                service.AddDiagnosticCenter(dc);
                return Ok("Diagnostic Center Added");
            }
            catch(DiagnosisCenterAlreadyExistsException dcExe)
            {
                return BadRequest(dcExe.Message);
            }
            catch(Exception exe)
            {
                return BadRequest(exe.Message);
            }
        }
        [HttpPut]
        [Route("{dcId}")]
        public IActionResult UpdateDiagnosticCenter(string dcId, [FromBody] DiagnosisCenter dc)
        {
            try
            {
                return Ok(service.UpdateDiagnosticCenter(dcId, dc));
            }  
            catch(DiagnosisCenterNotFoundException dcExe)
            {
                return NotFound(dcExe.Message);
            }
            catch(Exception exe)
            {
                return BadRequest(exe.Message);
            }
        } 
        [HttpGet]
        [Route("{userid}")]
        public IActionResult GetDiagnosticCenterById(string userid)
        {
            try
            {
                return Ok(service.GetDiagnosticCenterById(userid));
            }
            catch(DiagnosisCenterNotFoundException dcExe)
            {
                return NotFound(dcExe.Message);
            }
            catch(Exception exe)
            {
                return BadRequest(exe.Message);
            }            
        }
        [HttpDelete]
        [Route("{dcId}")]
        public IActionResult DeleteDiagnosticCenter(string dcId)
        {
            try
            {
                return Ok(service.DeleteDiagnosticCenter(dcId));
            }
            catch(DiagnosisCenterNotFoundException dcExe)
            {
                return NotFound(dcExe.Message);
            }
            catch(Exception exe)
            {
                return BadRequest(exe.Message);
            }
        }
        [HttpGet]
        [Route("search")]
        public IActionResult SearchDiagnosticCenters([FromQuery] string city, [FromQuery] string dcName = "", [FromQuery] string testsConducted = "",[FromQuery] string pincode="")
        {
            try
            {
                return Ok(service.SearchDiagnosticCenters(city, dcName, testsConducted,pincode));
            }
            catch(Exception exe)
            {
                return BadRequest(exe.Message);
            }
        }

        [HttpPost]
        [Route("{dcId}/timeslots")]
        public IActionResult AddDiagnosticCenterTimeSlots(string dcId, [FromBody] DiagnosticCenterTimeSlots ts)
        {
            try
            {
                service.AddDiagnosticCenterTimeSlot(dcId, ts);
                return Ok($"Time Slot added for diagnosticCenter with id {dcId}");
            }
            catch (Exception exe)
            {
                return BadRequest(exe.Message);
            }
        }
        [HttpGet]
        [Route("{dcId}/timeslots")]
        public IActionResult GetAllTimeSlotsOfDiagnosticCenter(string dcId)
        {
            try
            {
                return Ok(service.GetAllTimeSlotsOfDiagnosticCenter(dcId));
            }
            catch (Exception exe)
            {
                return BadRequest(exe.Message);
            }
        }

        [HttpGet]
        [Route("{dcId}/timeslots/{slotId}")]
        public IActionResult GetSpecificSlotOfDiagnosticCenter(string dcId, string slotId)
        {
            try
            {
                return Ok(service.GetSpecificSlotOfDiagnosticCenter(dcId, slotId));
            }
            catch (Exception exe)
            {
                return BadRequest(exe.Message);
            }
        }

        [HttpPut]
        [Route("{dcId}/timeslots/{slotId}")]
        public IActionResult UpdateSlotOfDoctor(string dcId, string slotId, [FromBody] DiagnosticCenterTimeSlots ts)
        {
            try
            {
                return Ok(service.UpdateTimeSlotOfDiagnosticCenter(dcId, slotId, ts));
            }
            catch (TimeSlotNotFoundException tExe)
            {
                return NotFound(tExe.Message);
            }
            catch (Exception exe)
            {
                return BadRequest(exe.Message);
            }
        }

        [HttpDelete]
        [Route("{dcId}/timeslots/{slotId}")]
        public IActionResult DeleteTimeSlotOfDiagnosticCenter(string dcId, string slotId)
        {
            try
            {
                return Ok(service.DeleteTimeSlotOfDiagnosticCenter(dcId, slotId));
            }
            catch (TimeSlotNotFoundException tExe)
            {
                return NotFound(tExe.Message);
            }
            catch (Exception exe)
            {
                return BadRequest(exe.Message);
            }
        }
    }
}