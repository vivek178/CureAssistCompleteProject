using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AppointmentsWebAPI.Entities;


namespace AppointmentsWebAPI.DataAccessLayer
{
    public interface IDayCalendarRepo
    {
        Task BookAppointmentAsync(AppointmentRequest appointmentRequest);

        Task<List<DayCalendar>> GetAppointmentByUserId(string userId);

        Task<DayCalendar> GetAppointmentByUserIDAndDateTime(string userId, DateTime date);
    }
}