using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppointmentsWebAPI.Entities;
using AppointmentsWebAPI.DataAccessLayer;

namespace AppointmentsWebAPI.ServiceLayar
{
    public class DayCalendarService : IDayCalendarService
    {
        private readonly IDayCalendarRepo _dayCalendarRepo;
        public DayCalendarService(IDayCalendarRepo calendarRepo)
        {
            _dayCalendarRepo = calendarRepo;
        }


        public async Task BookAppointmentAsync(AppointmentRequest appointmentRequest)
        {
           await _dayCalendarRepo.BookAppointmentAsync(appointmentRequest);
        }

        public async Task<List<DayCalendar>> GetAppointmentByUserId(string userId)
        {
           return await _dayCalendarRepo.GetAppointmentByUserId(userId);
        }

        public async Task<DayCalendar> GetAppointmentByUserIDAndDateTime(string UserId, DateTime date)
        {
            return await _dayCalendarRepo.GetAppointmentByUserIDAndDateTime(UserId, date);
        }
    }
}
