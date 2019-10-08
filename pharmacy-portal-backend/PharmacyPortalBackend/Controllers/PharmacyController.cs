using Microsoft.AspNetCore.Mvc;
using pharmacy_portal_backend.BusinessLayer;
using pharmacy_portal_backend.Entities;
using System;
using System.Security.Claims;

namespace pharmacy_portal_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PharmacyController : ControllerBase
    {
        private readonly IPharmacyProfileService pharmacyProfileService;
        public PharmacyController(IPharmacyProfileService profileService)
        {
            this.pharmacyProfileService = profileService;
        }

        // GET: api/pharmacy
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(pharmacyProfileService.ViewProfileDetails());
        }

        // GET: api/pharmacy/EmailId
        [HttpGet]
        [Route("viewprofile")]
        public IActionResult GetByEmailId()
        {
           
            var emailid = (Request.HttpContext.User.Identity as ClaimsIdentity).FindFirst("EmailId").Value;
            
            try
            {
                return Ok(pharmacyProfileService.ViewProfile(emailid));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // POST: api/pharmacy
        [HttpPost]
        public IActionResult Post([FromBody] Pharmacy pharmacy)
        {
            try
            {
                return Created("created", pharmacyProfileService.AddPharmacyProfile(pharmacy));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // PUT: api/Pharmacy/EmailId
        [HttpPut]
        [Route("editprofile")]
        public IActionResult Put([FromBody] Pharmacy pharmacy)
        {
            var emailid = (Request.HttpContext.User.Identity as ClaimsIdentity).FindFirst("EmailId").Value;
            try
            {
                var resultPharmacy = pharmacyProfileService.ViewProfile(emailid);
                if (resultPharmacy != null)
                {
                    return Ok(pharmacyProfileService.UpdatePharmacyProfile(emailid, pharmacy));
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

