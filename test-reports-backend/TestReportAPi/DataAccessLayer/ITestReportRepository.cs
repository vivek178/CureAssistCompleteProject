using System;
using System.Collections.Generic;
using TestReportAPi.Models;

namespace TestReportAPi.DataAccessLayer
{
  public interface ITestReportRepository
  {
    string AddTestReportToPatient(string patientId, TestReport tr); // Generate Test Report Json to Patient
    List<TestReport> GetAllTestReports(); // Get All the Existing TestReport Documents
    List<TestReport> GetTestReportsOfPatient(string patientId); // Get All the Test Reports of A single Patient
    TestReport GetSingleReportOfPatient(string patientId, string fileName); // Get Specific Test Report of a Patient
  }
}