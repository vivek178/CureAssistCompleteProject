using System;
using System.IO;
using System.Threading.Tasks;
using Amazon.S3;
using Amazon;
using Microsoft.Extensions.Configuration;
using Amazon.S3.Util;
using Amazon.S3.Model;
using System.Collections.Generic;
using TestReportAPi.DataAccessLayer;
using TestReportAPi.Models;
using TestReportAPi.BusinessLayer.Exceptions;

namespace TestReportAPi.BusinessLayer
{
  public class TestReportService: ITestReportService
  {
    
    private readonly ITestReportRepository _repository;
    private IAmazonS3 _client;
    private string accessKey;
    private string secretKey;
    public TestReportService(ITestReportRepository repository, IConfiguration config)
    {
      _repository = repository;
      accessKey = "AKIAQUIYJ2BUI2SWRQHH"; // config.GetSection("AWSSDK:access_key").Value;
      secretKey =  "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"; // config.GetSection("AWSSDK:secret_key").Value;
    }
    public string AddTestReportToPatient(string patientId, TestReport tr)
    {
      return _repository.AddTestReportToPatient(patientId, tr);
    }
    public List<TestReport> GetAllTestReports()
    {
      return _repository.GetAllTestReports();
    }
    public List<TestReport> GetTestReportsOfPatient(string patientId)
    {
      var result = _repository.GetAllTestReports();
      var reqResult = result.FindAll(t => t.PatientId == patientId);

      if(reqResult.Count != 0)
      {
        return _repository.GetTestReportsOfPatient(patientId);
      }
      else
      {
        throw new NoTestReportsForPatientException($"No Test reports were uploaded for the patient with id {patientId}");
      }      
    }
    public TestReport GetSingleReportOfPatient(string patientId, string fileName)
    {
      return _repository.GetSingleReportOfPatient(patientId, fileName);
    }

    public string GetSpecifiedTestReportOfPatient(string patientId, string fileName)
    {
      TestReport tr = _repository.GetSingleReportOfPatient(patientId, fileName);

      string urlString = "";
      try
      {
          GetPreSignedUrlRequest request1 = new GetPreSignedUrlRequest
          {
              BucketName = "cgi-wave7-dotnet",
              Key = tr.FileLocation,
              Expires = DateTime.Now.AddMinutes(5)
          };
          _client = new AmazonS3Client(accessKey, secretKey, RegionEndpoint.APSouth1);
          urlString = _client.GetPreSignedURL(request1);
      }
      catch (AmazonS3Exception e)
      {
          Console.WriteLine("Error encountered on server. Message:'{0}' when writing an object", e.Message);
      }
      catch (Exception e)
      {
          Console.WriteLine("Unknown encountered on server. Message:'{0}' when writing an object", e.Message);
      }
      return urlString;
    }
  }
}