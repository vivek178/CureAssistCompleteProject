using System;
using System.Collections.Generic;
using System.Linq;
using TestReportAPi.Models;
using MongoDB.Driver;

namespace TestReportAPi.DataAccessLayer
{
  public class TestReportRepository: ITestReportRepository
  {  
      private readonly TestReportDBContext _context;
      public TestReportRepository(TestReportDBContext context)
      {
        _context = context;
      }
      public string AddTestReportToPatient(string patientId, TestReport tr)
      {
        tr.PatientId = patientId;
        _context.TestReports.InsertOne(tr);
        return ($"Added Test Report to patient with Id {patientId}");
      }
      public List<TestReport> GetAllTestReports()
      {
        return _context.TestReports.Find(_ => true).ToList();
      }
      public List<TestReport> GetTestReportsOfPatient(string patientId)
      {
        return _context.TestReports.Find(tr => tr.PatientId == patientId).ToList();
      }
      public TestReport GetSingleReportOfPatient(string patientId, string fileName)
      {
        return _context.TestReports.Find(tr => (tr.PatientId == patientId) && (tr.FileName == fileName)).SingleOrDefault();
      }
  }
}