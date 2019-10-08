
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using prescription.BusinessLayer;
using prescription.BusinessLayer.Exceptions;
using prescription.Entities;

namespace prescription.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionController : ControllerBase
    {
        private readonly IPrescriptionService service;
        public PrescriptionController(IPrescriptionService prescriptionService)
        {
            service = prescriptionService;
        }

        [HttpGet]

         public IActionResult GetPrescriptions()
         {
            try
            {
                return Ok(service.GetPrescriptions());
            }
            catch(Exception exe)
            {
                return BadRequest(exe.Message);
            }
         }




        
        [HttpGet]
        [Route("prescription/{patientId}")]
        public IActionResult Get(string patientId)
        {

            try
            {
                return Ok(service.GetPrescriptionByPatientId(patientId));
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet]
        [Route("{prescriptionId}")]
        public IActionResult GetPrescription(string prescriptionId)
        {

            try
            {
                return Ok(service.GetPrescriptionByPrescriptionId(prescriptionId));
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }




        [HttpPost]
        public IActionResult Post([FromBody] Prescription prescription)
        {
            try
            {
                service.AddPrescription(prescription);
                return StatusCode((int)HttpStatusCode.Created, prescription);
            }
            catch (Exception exe)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, exe.Message);
            }
        }

        [HttpDelete]
        [Route("{prescriptionid}")]
        public IActionResult Delete(string prescriptionid)
        {
            try
            {
                return Ok(service.RemovePrescription(prescriptionid));
            }
            catch (PrescriptionNotFoundException nnf)
            {
                return NotFound(nnf.Message);
            }
            catch
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }

        }


    }
}