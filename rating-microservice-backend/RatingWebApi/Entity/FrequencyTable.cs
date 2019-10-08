using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RatingWebApi.Entity
{
    public class FrequencyTable
    {
        [Key]
        public int RatingId { get; set; }

        public string PatientId { get; set; }

        public string DoctorId { get; set; }

        public float Rating { get; set; }
    }
}
