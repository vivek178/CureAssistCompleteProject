using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RatingWebApi.Entity;
using RatingWebApi.DataAccessLayer;

namespace RatingWebApi.Service
{
    public class RatingService : IRatingService
    {
        private readonly IRatingRepo ratingRepo;

        public RatingService(IRatingRepo repo)
        {
            ratingRepo = repo;
        }

        public List<FrequencyTable> GetAllData()
        {
            return ratingRepo.GetAllData();
        }

        public float GetReviewByDoctorId(string DoctorId)
        {
            return ratingRepo.GetReviewByDoctorId(DoctorId);
        }

        public string GetReviewByPatientAndDoctorId(string PatientId, string DoctorId)
        {
            return ratingRepo.GetReviewByPatientAndDoctorId(PatientId, DoctorId);
        }

        public string SubmitReview(FrequencyTable frequency)
        {
            return ratingRepo.SubmitReview(frequency);
        }
    }
}
