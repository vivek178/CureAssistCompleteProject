using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using AppointmentsWebAPI.Entities;
using System.Threading.Tasks;

namespace AppointmentsWebAPI.DataAccessLayer
{
    public interface ICalendarsDBContext
    {
        IMongoCollection<DayCalendar> GetAppointmentsCollection();
    }
}