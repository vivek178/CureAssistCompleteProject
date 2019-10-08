using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Patient_Portal.Exceptions
{
    public class PatientNotFoundException:ApplicationException
    {
        public PatientNotFoundException() { }
        public PatientNotFoundException(string message) : base(message) { }
    }
}
