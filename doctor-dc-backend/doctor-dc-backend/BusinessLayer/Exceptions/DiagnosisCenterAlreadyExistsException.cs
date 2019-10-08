using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace doctor_dc_backend.BusinessLayer.Exceptions
{
    public class DiagnosisCenterAlreadyExistsException: ApplicationException
    {
        public DiagnosisCenterAlreadyExistsException() { }
        public DiagnosisCenterAlreadyExistsException(string message): base(message) { }
    }
}
