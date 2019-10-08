using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace doctor_dc_backend.BusinessLayer.Exceptions
{
    public class DoctorAlreadyExistsException:ApplicationException
    {
        public DoctorAlreadyExistsException() { }
        public DoctorAlreadyExistsException(string message) : base(message) { }
    }
}
