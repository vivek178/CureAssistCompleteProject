using System;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Patient_Portal.BusinessLayer;
using Patient_Portal.Models;

namespace Patient_Portal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientProfileService patientService;
        public PatientController(IPatientProfileService patientService)
        {
            this.patientService = patientService;
        }
        //GET: api/patient
        [HttpGet]
        public async Task<IActionResult> Get()
        {

            var patients = await patientService.ViewProfileDetails();
            return Ok(patients);
        }

        // GET: api/patient/abc @gmail.com

        //[HttpGet]
        //[Route("login")]
        //public IActionResult Login(string emailid)
        //{
        //    var value = (Request.HttpContext.User.Identity as ClaimsIdentity).FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress").Value;
        //    //foreach(var claim in (Request.HttpContext.User.Identity as ClaimsIdentity).Claims)
        //    //{
        //    //    Console.WriteLine(claim.Value);
        //    //}
        //    //return Ok(true);
        //    var testvalue = value;
        //    try
        //    {
        //        return Ok(patientService.ViewProfile(testvalue));
        //    }
        //    catch (Exception ex)
        //    {
        //        return NotFound(ex.Message);
        //    }
        //}
        [HttpGet]

        [Route("viewprofile")]
        public IActionResult Login()
        {
            //foreach (var claim in (Request.HttpContext.User.Identity as ClaimsIdentity).Claims)
            //{
            //    Console.WriteLine(claim.Value);
            //}
            var emailid = (Request.HttpContext.User.Identity as ClaimsIdentity).FindFirst("EmailId").Value;
            try
            {
                return Ok(patientService.ViewProfile(emailid));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        //get api/patient/patientid
        [HttpGet]
        [Route("{userId}")]
        public IActionResult GetPatientById(string userId)
        {
            try
            {
                return Ok(patientService.GetPatientById(userId));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        // POST: api/patient
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Patient patient)
        {

            try
            {
                var patients = await patientService.AddPatientProfile(patient);

                return StatusCode((int)HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // PUT: api/patient
        [HttpPut("updateprofile")]
        public async Task<IActionResult> Put([FromBody] Patient patient)
        {
            var emailid = (Request.HttpContext.User.Identity as ClaimsIdentity).FindFirst("EmailId").Value;
            try
            {
                var resultPatient = patientService.ViewProfile(emailid);
                if (resultPatient != null)
                {

                    return Ok(await patientService.UpdatePatientProfile(emailid, patient));
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

        }
    }
}
