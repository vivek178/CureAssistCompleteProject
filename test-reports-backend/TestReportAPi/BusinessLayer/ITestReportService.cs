using System;
using System.Collections.Generic;
using TestReportAPi.Models;

namespace TestReportAPi.BusinessLayer
{
  public interface ITestReportService
  {
    string AddTestReportToPatient(string patientId, TestReport tr);
    List<TestReport> GetAllTestReports();
    List<TestReport> GetTestReportsOfPatient(string patientId);
    TestReport GetSingleReportOfPatient(string patientId, string fileName);
    string GetSpecifiedTestReportOfPatient(string patientId, string fileName);
  }
}