using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AppointmentsWebAPI.Entities;
using AppointmentsWebAPI.DataAccessLayer;
using AppointmentsWebAPI.ServiceLayar;
using System.Globalization;

namespace AppointmentsWebAPI.Controllers
{

    public class DayAppointment
    {
       public string UserId { get; set; }
       public DateTime Date { get; set; }
    }


    [Route("[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private IDayCalendarService _dayCalendarService;
        public AppointmentsController(IDayCalendarService dayCalendarservice)
        {
            _dayCalendarService = dayCalendarservice;
        }

        // For Getting all document for all date with matching userid.
        [HttpGet]
        [Route("Allappointments")]
        public async Task<ActionResult<List<DayCalendar>>> GetAllAppointmentByUserID([FromQuery] string UserId)
        {
            return Ok(await _dayCalendarService.GetAppointmentByUserId(UserId));
        }


        // for getting all document for specific date with matching userid and date.
        [HttpGet]
        [Route("DayAppointment")]
        public async Task<ActionResult<DayCalendar>> GetAppointmentByUserIdAndDate([FromQuery] string UserId, string date)
        {
            Console.WriteLine(date);
            DateTime Date = DateTime.Parse(date);
            try 
            {
                return Ok(await _dayCalendarService.GetAppointmentByUserIDAndDateTime(UserId, Date));
            }
            catch (Exception exe)
            {
                return BadRequest(exe.Message);
            }
            
        }


        // for creating new appointment.
        [HttpPost]
        public async Task<IActionResult> BookAppointment([FromBody]AppointmentRequest appointmentRequest )
        {
            await _dayCalendarService.BookAppointmentAsync(appointmentRequest);
            return Ok();
        }


        // for deleting an exsisting appointment.
        [HttpDelete]
        public async Task<ActionResult<DayCalendar>> CancelAppointmentByUserIdAndDateAndStartTime()
        {
            return null;
        }

    }
}