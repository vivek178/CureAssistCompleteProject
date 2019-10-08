using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentsWebAPI.Entities
{
    public class AttendeeWithSymptom
    {
        public string AttendeeId { get; set; }
    
        public string[] Symptoms { get; set; }
    }
}
