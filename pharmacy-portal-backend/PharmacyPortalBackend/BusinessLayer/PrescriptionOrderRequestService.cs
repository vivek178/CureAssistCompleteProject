using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pharmacy_portal_backend.DataAccess;
using pharmacy_portal_backend.Entities;
using pharmacy_portal_backend.Exceptions;

namespace pharmacy_portal_backend.BusinessLayer
{
    public class PrescriptionOrderRequestService : IPrescriptionOrderRequestService
    {
        private readonly IPrescriptionOrderRequestRepository orderRepo;
        public PrescriptionOrderRequestService(IPrescriptionOrderRequestRepository repo)
        {
            orderRepo = repo;
        }
        public async Task<bool> DeletePrescriptionOrderReqByIdAsync(string prescriptionId)
        {
            var order = await orderRepo.ViewPrescriptionOrderByIdAsync(prescriptionId);
            if (order != null)
            {
                return await orderRepo.DeletePrescriptionOrderByIdAsync(prescriptionId);
            }
            else
            {
                throw new OrderNotFoundException($"order with Id {prescriptionId} not exist");
            }
        }

        public async Task<PrescriptionOrderRequest> ViewPrescriptionOrderReqByIdAsync(string prescriptionId)
        {
            var order = await orderRepo.ViewPrescriptionOrderByIdAsync(prescriptionId);
            if (order != null)
            {
                return order;
            }
            else
            {
                throw new OrderNotFoundException($"order with Id {prescriptionId} not exist");
            }
        }

        public async Task<List<PrescriptionOrderRequest>> ViewPrescriptionOrderReqsAsync()
        {
            return await orderRepo.ViewPrescriptionOrderRequestsAsync();
        }
        public async Task AddResponseByPharmacyAsync(PrescriptionOrderRequest currentOrder)
        {
            await orderRepo.AddResponseByPharmacyAsync(currentOrder);
        }
    }
}


