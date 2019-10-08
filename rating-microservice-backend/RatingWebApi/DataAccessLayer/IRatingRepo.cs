using RatingWebApi.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RatingWebApi.DataAccessLayer
{
    public interface IRatingRepo
    {
        // submit the review.
        string SubmitReview(FrequencyTable frequency);

        // Used for getting review from patientid and doctorid. this is used by the patient.
        string GetReviewByPatientAndDoctorId(string PatientId, string DoctorId);

        // Used for getting review from doctor's Id. This will used by doctor.
        float GetReviewByDoctorId(string DoctorId);

        // Used for getting entire values of database;
        List<FrequencyTable> GetAllData();

    }
}
