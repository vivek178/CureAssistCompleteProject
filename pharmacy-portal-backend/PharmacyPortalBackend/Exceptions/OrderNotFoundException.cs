using System;

namespace pharmacy_portal_backend.Exceptions
{
    public class OrderNotFoundException : ApplicationException
    {
        public OrderNotFoundException() { }
        public OrderNotFoundException(string message) : base(message) { }
    }
}
