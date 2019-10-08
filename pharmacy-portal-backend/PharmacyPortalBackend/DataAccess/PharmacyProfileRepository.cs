using pharmacy_portal_backend.Entities;
using pharmacy_portal_backend.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace pharmacy_portal_backend.DataAccess
{
    public class PharmacyProfileRepo : IPharmacyProfileRepo
    {
        private readonly PharmacyDbContext pharmacyContext;
        public PharmacyProfileRepo(PharmacyDbContext pharmacyDb)
        {
            this.pharmacyContext = pharmacyDb;
        }

        public int AddPharmacyProfile(Pharmacy pharmacy)
        {
            pharmacyContext.pharmacies.Add(pharmacy);
            return pharmacyContext.SaveChanges();
        }

        public int UpdatePharmacyProfile(string EmailId,Pharmacy pharmacy)
        {
            var pharmacyById = pharmacyContext.pharmacies.Where(n=>n.EmailId==EmailId).FirstOrDefault();
            pharmacyContext.pharmacies.Update(pharmacyById);
            return pharmacyContext.SaveChanges();
        }

        public Pharmacy ViewProfile(string EmailId)
        {
            var _pharmacy = pharmacyContext.pharmacies.Where(n => n.EmailId == EmailId).FirstOrDefault();
            return _pharmacy;
        }

        public List<Pharmacy> ViewProfileDetails()
        {
            return pharmacyContext.pharmacies.ToList();
        }
    }
}


