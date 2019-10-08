using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace doctor_dc_backend.BusinessLayer.Exceptions
{
    public class DoctorNotFoundException:ApplicationException
    {
        public DoctorNotFoundException() { }
        public DoctorNotFoundException(string message) : base(message) { }
    }
}
