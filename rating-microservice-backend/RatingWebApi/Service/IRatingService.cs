using RatingWebApi.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RatingWebApi.Service
{
    public interface IRatingService
    {
        string SubmitReview(FrequencyTable frequency);

        string GetReviewByPatientAndDoctorId(string PatientId, string DoctorId);

        float GetReviewByDoctorId(string DoctorId);

        List<FrequencyTable> GetAllData();


    }
}
