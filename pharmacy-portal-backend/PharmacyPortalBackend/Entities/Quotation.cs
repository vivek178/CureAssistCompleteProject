namespace pharmacy_portal_backend.Entities
{
    public class Quotation
    {
        public string PharmacyId { get; set; }
        public PrescribedMedicine[] PrescribedMedicines { get; set; }
        public int TotalCost { get; set; }
    
    }
}