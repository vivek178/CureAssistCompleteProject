using pharmacy_portal_backend.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pharmacy_portal_backend.BusinessLayer
{
   public interface IPrescriptionOrderRequestService
    {
        Task<PrescriptionOrderRequest> ViewPrescriptionOrderReqByIdAsync(string prescriptionId);
        Task<List<PrescriptionOrderRequest>> ViewPrescriptionOrderReqsAsync();
        Task<bool> DeletePrescriptionOrderReqByIdAsync(string prescriptionId);
        Task AddResponseByPharmacyAsync(PrescriptionOrderRequest currentOrder);
    }
}
