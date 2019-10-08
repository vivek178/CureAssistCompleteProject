using pharmacy_portal_backend.Entities;
using System.Collections.Generic;

namespace pharmacy_portal_backend.DataAccess
{
    public interface IPharmacyProfileRepo
    {
        int AddPharmacyProfile(Pharmacy pharmacy);
        Pharmacy ViewProfile(string EmailId);
        int UpdatePharmacyProfile(string EmailId,Pharmacy pharmacy);
        List<Pharmacy> ViewProfileDetails();
    }
}
