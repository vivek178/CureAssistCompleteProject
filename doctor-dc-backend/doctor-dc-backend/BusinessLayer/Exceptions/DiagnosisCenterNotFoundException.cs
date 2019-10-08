using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace doctor_dc_backend.BusinessLayer.Exceptions
{
    public class DiagnosisCenterNotFoundException: ApplicationException
    {
        public DiagnosisCenterNotFoundException() { }
        public DiagnosisCenterNotFoundException(string message): base(message) { }
    }
}
