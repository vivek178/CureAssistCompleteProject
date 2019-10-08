using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RatingWebApi.Entity;
using System.Linq;


namespace RatingWebApi.DataAccessLayer
{
    public class RatingRepo : IRatingRepo
    {

        private readonly RatingDBContext ratingDB;

        public RatingRepo( RatingDBContext rating)
        {
            ratingDB = rating;
        }


        // Used for getting all data of dataBase;
        public List<FrequencyTable> GetAllData()
        {
            var result = ratingDB.frequencies.ToList<FrequencyTable>();
            return result;
        }


        // Used for getting what Cumulative rating has been given to doctor. This will used by doctor/patient.
        public float GetReviewByDoctorId(string DoctorId)
        {
            float avgValue = 0;
            int count = 0;
            try
            {
                var filteredResult = from f in ratingDB.frequencies where
                                     f.DoctorId == DoctorId
                                     select f;

                if (filteredResult != null)
                {
                    foreach (var item in filteredResult)
                    {
                        count++;
                        avgValue += item.Rating;
                    }

                    var result = avgValue / count;
                    return result;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception e)
            {
                return 0;
                //return e.HResult;
            }
        }


        // Used for getting what rating has given to doctor by . this is used by the patient.
        public string GetReviewByPatientAndDoctorId(string PatientId, string DoctorId)
        {
            try
            {
                var filteredResult = from f in ratingDB.frequencies where 
                                     f.PatientId == PatientId
                                     && f.DoctorId == DoctorId select f.Rating ;
                try
                {
                    if (true)
                    {
                        var result = filteredResult.SingleOrDefault();
                        return result.ToString();
                    }
                }
                catch (Exception e)
                {
                    return "there no element present in database." + e.Message;
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }


        // submit the review. If it exsist update it.
        public string SubmitReview(FrequencyTable frequency)
        {
            try
            {
                var filteredResult = from f in ratingDB.frequencies where 
                                     f.PatientId == frequency.PatientId
                                     && f.DoctorId == frequency.DoctorId select f ;

                var filteredData = filteredResult.FirstOrDefault();

                if ( filteredData == null)
                {
                    ratingDB.frequencies.Add(frequency);
                    var result = ratingDB.SaveChanges();
                    if (result == 1)
                    {
                        return "Record Has been inserted.";
                    }
                    else
                    {
                        return "record Not Inserted.";
                    }
                }
                else
                {
                    try
                    {

                        filteredData.Rating = frequency.Rating;

                        ratingDB.Entry(filteredData).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        // ratingDB.Update(frequency);
                        var result = ratingDB.SaveChanges();

                        if (result == 1)
                        {
                            return "rating updated";
                        }
                        else
                        {
                            return "rating which is exsist has not updated.";
                        }
                    }
                    catch (Exception e)
                    {
                        return e.Message;
                    }
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}
