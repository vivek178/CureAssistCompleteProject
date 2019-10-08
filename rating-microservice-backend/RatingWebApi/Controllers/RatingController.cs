using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RatingWebApi.Entity;
using RatingWebApi.Service;


namespace RatingWebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RatingController : ControllerBase
    {

        private readonly IRatingService ratingService;

        public RatingController(IRatingService service)
        {
            ratingService = service;
        }


        // GET: Rating
        [HttpGet]
        public IEnumerable<FrequencyTable> Get()
        {
            return ratingService.GetAllData();
            //return new string[] { "value1", "value2" };
        }


        // GET: Rating/DoctorRating
        [HttpGet]
        [Route("DoctorRating")]
        public float Get([FromQuery] string DoctorId)
        {
            var result = ratingService.GetReviewByDoctorId(DoctorId);
            return result;
        }


        // GET: Rating/PatientDoctorRating
        [HttpGet]
        [Route("PatientDoctorRating")]
        public string Get([FromQuery] string PatientId, string DoctorId)
        {
            var result = ratingService.GetReviewByPatientAndDoctorId(PatientId, DoctorId);
            return result;
        }


        // POST: Rating
        [HttpPost]
        public string Post([FromBody] FrequencyTable frequency)
        {
            var result = ratingService.SubmitReview(frequency);
            return result;
        }

    }
}
