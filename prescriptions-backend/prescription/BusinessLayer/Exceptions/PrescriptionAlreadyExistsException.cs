using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace prescription.BusinessLayer.Exceptions
{
    public class PrescriptionAlreadyExistsException:ApplicationException
    {
        public PrescriptionAlreadyExistsException()
        {

        }


        public PrescriptionAlreadyExistsException(string message) : base(message) { }
    }
}
