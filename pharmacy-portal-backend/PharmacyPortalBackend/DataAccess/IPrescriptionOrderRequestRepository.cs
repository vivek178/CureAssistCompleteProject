using System.Threading.Tasks;
using System.Collections.Generic;
using pharmacy_portal_backend.Entities;
namespace pharmacy_portal_backend.DataAccess
{
   public interface IPrescriptionOrderRequestRepository
    {
        Task<PrescriptionOrderRequest> ViewPrescriptionOrderByIdAsync(string prescriptionOrderReqId);
        Task<List<PrescriptionOrderRequest>> ViewPrescriptionOrderRequestsAsync();
        Task<bool> DeletePrescriptionOrderByIdAsync(string prescriptionOrderReqId);
        Task AddResponseByPharmacyAsync(PrescriptionOrderRequest prescriptionOrderRequest);
    }
}
