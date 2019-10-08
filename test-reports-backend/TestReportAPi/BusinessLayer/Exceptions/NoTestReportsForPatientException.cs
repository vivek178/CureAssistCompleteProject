using System;

namespace TestReportAPi.BusinessLayer.Exceptions
{
  public class NoTestReportsForPatientException: ApplicationException
  {
    public NoTestReportsForPatientException() {}
    public NoTestReportsForPatientException(string message): base(message) { }
  }
}