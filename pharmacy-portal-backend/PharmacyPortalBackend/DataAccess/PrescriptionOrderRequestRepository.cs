using System;
using System.Linq;
using MongoDB.Driver;
using System.Threading.Tasks;
using System.Collections.Generic;
using pharmacy_portal_backend.Entities;

namespace pharmacy_portal_backend.DataAccess
{
    public class PrescriptionOrderRequestRepository : IPrescriptionOrderRequestRepository
    {
        private readonly PrescriptionOrderDBContext context;
        public PrescriptionOrderRequestRepository(PrescriptionOrderDBContext context)
        {
            this.context = context;
        }
        public async Task<bool> DeletePrescriptionOrderByIdAsync(string prescriptionId)
        {
            var currorder = Builders<PrescriptionOrderRequest>.Filter.Where(c => c.PrescriptionId == prescriptionId);
            if (currorder != null)
            {
                var result = await context.PrescriptionOrderRequests.DeleteOneAsync(currorder);
                return (result.IsAcknowledged && (result.DeletedCount > 0));
            }
            else
            {
                return false;
            }
        }

        public async Task<PrescriptionOrderRequest> ViewPrescriptionOrderByIdAsync(string prescriptionId)
        {
            var order = await context.PrescriptionOrderRequests.FindAsync(c => c.PrescriptionId == prescriptionId);
            return order.FirstOrDefault();
        }

        public async Task<List<PrescriptionOrderRequest>> ViewPrescriptionOrderRequestsAsync()
        {
            var prescriptionOrderRequests = await context.PrescriptionOrderRequests.FindAsync(_ => true);
            return prescriptionOrderRequests.ToList();
        }

        public async Task AddResponseByPharmacyAsync(PrescriptionOrderRequest currentOrder)
        {
            await context.PrescriptionOrderRequests.InsertOneAsync(currentOrder);
        }
    }
}
