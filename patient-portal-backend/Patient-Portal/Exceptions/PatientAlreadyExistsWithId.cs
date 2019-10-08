using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Patient_Portal.Exceptions
{
    public class PatientAlreadyExistsWithIdException:ApplicationException
    {
        public PatientAlreadyExistsWithIdException() { }
        public PatientAlreadyExistsWithIdException(string message) : base(message) { }
    }
}
