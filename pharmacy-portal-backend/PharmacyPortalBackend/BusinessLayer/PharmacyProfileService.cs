using pharmacy_portal_backend.DataAccess;
using pharmacy_portal_backend.Entities;
using pharmacy_portal_backend.Exceptions;
using System.Collections.Generic;

namespace pharmacy_portal_backend.BusinessLayer
{
    public class PharmacyProfileService :IPharmacyProfileService
    {
         private readonly IPharmacyProfileRepo ipharmacyUpdate;
       public PharmacyProfileService(IPharmacyProfileRepo pharmacyUpdate)
       {
           this.ipharmacyUpdate = pharmacyUpdate;
       }
       public int AddPharmacyProfile(Pharmacy pharmacy)
       {
           var _pharmacy = ipharmacyUpdate.ViewProfile(pharmacy.EmailId);
           if (_pharmacy == null)
           {
               return ipharmacyUpdate.AddPharmacyProfile(pharmacy);
           }
           else
           {
               throw new PharmacyAlreadyExist($"Pharmacy with this {pharmacy.EmailId} already exists");
           }
       }

       public int UpdatePharmacyProfile(string EmailId, Pharmacy pharmacy)
       {
           var getPharmacyId = ipharmacyUpdate.ViewProfile(EmailId);
           if (getPharmacyId == null)
           {
               throw new PharmacyNotFound($"Pharmacy with this {EmailId} not found");
           }
           else
           {               

                getPharmacyId.PharmacyName = pharmacy.PharmacyName;
                getPharmacyId.PharmacyRegisterNumber = pharmacy.PharmacyRegisterNumber;               
                getPharmacyId.PhoneNumber = pharmacy.PhoneNumber;               
                getPharmacyId.EmailId = pharmacy.EmailId;              
                getPharmacyId.PharmacyLocation = pharmacy.PharmacyLocation;
                return ipharmacyUpdate.UpdatePharmacyProfile(EmailId,getPharmacyId);
           }
       }
       public Pharmacy ViewProfile(string EmailId)
       {
           var getPharmacyId = ipharmacyUpdate.ViewProfile(EmailId);
           if (getPharmacyId == null)
           {
               throw new PharmacyNotFound($"Pharmacy with this {EmailId} not found");
           }
           else
               return getPharmacyId;
       }
       public List<Pharmacy> ViewProfileDetails()
       {
           return ipharmacyUpdate.ViewProfileDetails();
       }
    }
}
