namespace pharmacy_portal_backend.Entities
{
    public class PrescribedMedicine
    {
        public string MedicineName { get; set; }
        public string MedicineQuantity { get; set; }
        public string PrescribedDosage { get; set; }
        public string[] PrescribedTimings { get; set; }
        public int PrescribedDays { get; set; }       
        public int MedicinePrice { get; set; }
    }
}
