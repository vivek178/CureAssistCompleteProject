using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using AppointmentsWebAPI.Entities;
using System.Linq;


namespace AppointmentsWebAPI.DataAccessLayer
{
    public class DayCalendarRepo : IDayCalendarRepo
    {
        // IMongoCollection of DayCalendar type.
        private readonly IMongoCollection<DayCalendar> appointments;

        public DayCalendarRepo(ICalendarsDBContext appointmentsDBContext)
        {
            appointments = appointmentsDBContext.GetAppointmentsCollection();
        }

        public async Task BookAppointmentAsync(AppointmentRequest appointmentRequest)
        {
            // Making a Builders Filter Query (filterByUserAndDateInAppointmentRequest) which will execute on appointments( a mongo collection).
            var filterByUsersAndDateInAppointmentRequest = Builders<DayCalendar>.Filter.And(
                Builders<DayCalendar>.Filter.In(x => x.UserId, appointmentRequest.Attendees),
                Builders<DayCalendar>.Filter.Where(x => x.Date.Equals(appointmentRequest.Slot.Date.Date))
            );

            // execute Builders query on appointments collection.
            var dayCalendarsOfAttendeesAsync = appointments.FindAsync(filterByUsersAndDateInAppointmentRequest);

            // converting IAsyncCursor to List<DayCalendar> type.
            var dayCalendarOfAttendees = (await dayCalendarsOfAttendeesAsync).ToList();

            // getting list of Attendees.
            var attendeesWithoutDayCalendar = appointmentRequest.Attendees.Except(dayCalendarOfAttendees.Select(x => x.UserId)).ToList();

            // Creating a documnet of User whose document is not created.
            foreach (var attendee in attendeesWithoutDayCalendar)
            {
                var appointment = new DayCalendar()
                {
                    UserId = attendee,
                    Date = appointmentRequest.Slot.Date,
                    Slots = new List<Slot>()
                        {
                            new Slot()
                            {
                                TimeSlot = appointmentRequest.Slot,
                                Attendees = new List<AttendeeWithSymptom>()
                                {

                                }
                            },
                        }
                };
                this.appointments.InsertOne(appointment);
                dayCalendarOfAttendees.Add(appointment);
            }

            // Code to update Slot and Attendees of the Slot.
            foreach (var dayCalendarOfAttendee in dayCalendarOfAttendees)
            {
                var slots = dayCalendarOfAttendee.Slots.ToList();
                var slot = slots.Where(x => x.TimeSlot.Equals(appointmentRequest.Slot)).FirstOrDefault();
                if (slot == null)
                {
                    slot = new Slot() { TimeSlot = appointmentRequest.Slot, Attendees = new List<AttendeeWithSymptom>() { } };
                    dayCalendarOfAttendee.Slots.Add(slot);
                }

                //var otherAttendees = dayCalendarOfAttendees.Select(x => x.UserId).Except(new List<string> { dayCalendarOfAttendee.UserId }).ToList();
                //slot.Attendees.AddRange(otherAttendees);

                var OtherAttendeeName = dayCalendarOfAttendees.Select(x => x.UserId).Except(new List<string> { dayCalendarOfAttendee.UserId });
                var attendeeName = OtherAttendeeName.ElementAt(0);
           
                AttendeeWithSymptom attendeeWithSymptom = new AttendeeWithSymptom
                {
                    AttendeeId = attendeeName,
                    Symptoms = appointmentRequest.Symptom
                };
                //appointmentRequest.Symptom.CopyTo(attendeeWithSymptom.Symptoms, 0);

                slot.Attendees.Add(attendeeWithSymptom);

                var filter = Builders<DayCalendar>.Filter.Eq(x => x.UserId, dayCalendarOfAttendee.UserId);
                appointments.ReplaceOne<DayCalendar>( x => x.DayCalendarId == dayCalendarOfAttendee.DayCalendarId, dayCalendarOfAttendee);

            }
        }

        public async Task<List<DayCalendar>> GetAppointmentByUserId(string userId)
        {
            var userAppointment = await appointments.FindAsync(x => x.UserId == userId);
            var listOfUserAllAppointment = await userAppointment.ToListAsync();
            return listOfUserAllAppointment;
        }  

        public async Task<DayCalendar> GetAppointmentByUserIDAndDateTime(string userId, DateTime date)
        {
            var userDayAppointment = await appointments.FindAsync(x => x.UserId == userId && x.Date == date.Date);
            var specificDayCalendar = userDayAppointment.FirstOrDefault();
            return specificDayCalendar;
        }
    }
}




