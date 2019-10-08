using System.ComponentModel.DataAnnotations;

namespace pharmacy_portal_backend.Entities
{
    public class Pharmacy
    {
        [Key]
        public int PharmacyId { get; set; }
        [Required]
        public string PharmacyName { get; set; }
        [Required]
        public string PharmacyLocation { get; set; }
        [Required]
        public string PharmacyPincode { get; set; }
        [Required]
        public string PharmacyRegisterNumber { get; set; }
        [Required]
        public long PhoneNumber { get; set; }
        [Required]
        public string EmailId { get; set; }
    }
}
