using System;

namespace doctor_dc_backend.BusinessLayer.Exceptions
{
  public class TimeSlotNotFoundException: ApplicationException
  {
    public TimeSlotNotFoundException() { }
    public TimeSlotNotFoundException(string message): base(message) { }
  }
}