using System;

namespace pharmacy_portal_backend.Exceptions
{
    public class PharmacyNotFound : ApplicationException
    {
        public PharmacyNotFound() { }
        public PharmacyNotFound(string message) : base(message) { }
    }
}
