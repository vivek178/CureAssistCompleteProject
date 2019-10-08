using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Patient_Portal.Models
{
    public class Patient
    {

        [Key]
        public string patientId { get; set; }
        public string userId{get;set;}
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string BloodGroup { get; set; }
        [Required]
        public string UAID { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public long PhoneNumber { get; set; }

        public long EmergencyContactNumber { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string city { get; set; }
    }
}

