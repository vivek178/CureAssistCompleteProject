using System;

namespace pharmacy_portal_backend.Exceptions
{
    public class PharmacyAlreadyExist : ApplicationException
    {
        public PharmacyAlreadyExist() { }
        public PharmacyAlreadyExist(string message) : base(message) { }
    }
}
