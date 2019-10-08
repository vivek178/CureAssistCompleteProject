using AppointmentsWebAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentsWebAPI.ServiceLayar
{
    public interface IDayCalendarService
    {
        Task BookAppointmentAsync(AppointmentRequest appointmentRequest);

        Task<List<DayCalendar>> GetAppointmentByUserId(string userId);

        Task<DayCalendar> GetAppointmentByUserIDAndDateTime(string userId, DateTime date);
    }
}
