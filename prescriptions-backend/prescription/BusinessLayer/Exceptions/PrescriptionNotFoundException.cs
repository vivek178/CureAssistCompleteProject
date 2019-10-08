using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace prescription.BusinessLayer.Exceptions
{
    public class PrescriptionNotFoundException:ApplicationException
    {
        public PrescriptionNotFoundException() { }

        public PrescriptionNotFoundException(string message) : base(message) { }

    }
}
