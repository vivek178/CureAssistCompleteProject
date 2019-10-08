using Microsoft.AspNetCore.Mvc;
using pharmacy_portal_backend.BusinessLayer;
using pharmacy_portal_backend.Exceptions;
using pharmacy_portal_backend.Entities;
using System;
using System.Threading.Tasks;

namespace PharmacyPortalBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionsController : ControllerBase
    {
        private readonly IPrescriptionOrderRequestService orderService;
        private readonly IPrescriptionOrderRequestNotificationService prescriptionNotificationService;
        public PrescriptionsController(IPrescriptionOrderRequestService service, IPrescriptionOrderRequestNotificationService prescriptionNotificationService)
        {
            orderService = service;
            this.prescriptionNotificationService = prescriptionNotificationService;
        }

        [HttpGet]
        public async Task<IActionResult> ViewOrders()
        {
            try
            {
                return Ok(await orderService.ViewPrescriptionOrderReqsAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostPrescription([FromBody] PrescriptionOrderRequest prescription)
        {
            try
            {
                await prescriptionNotificationService.SendOrderNotificationAsync(prescription);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{prescriptionId}")]
        public async Task<IActionResult> ViewOrderByPrescriptionId([FromRoute] string prescriptionId)
        {
            try
            {
                return Ok(await orderService.ViewPrescriptionOrderReqByIdAsync(prescriptionId));
            }
            catch (OrderNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("delete/{prescriptionId}")]
        public async Task<IActionResult> DeleteOrderByPrescriptionId(string prescriptionId)
        {
            try
            {
                return Ok(await orderService.DeletePrescriptionOrderReqByIdAsync(prescriptionId));
            }
            catch (OrderNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception x)
            {
                return BadRequest(x.Message);
            }
        }

        [HttpPost]
        [Route("pharmacyresponse")]
        public async Task<IActionResult> AddResponseByPharmacy([FromBody] PrescriptionOrderRequest currentOrder)
        {
            await orderService.AddResponseByPharmacyAsync(currentOrder);
            return Ok("added successfully");
        }
    } 
}
