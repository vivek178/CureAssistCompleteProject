using System.Threading.Tasks;
using pharmacy_portal_backend.Entities;

namespace pharmacy_portal_backend.BusinessLayer
{
    public interface IPrescriptionOrderRequestNotificationService
    {
        Task SendOrderNotificationAsync(PrescriptionOrderRequest prescriptionOrderRequest);
    }
}