using System;
using System.Threading.Tasks;
using TestReportAPi.BusinessLayer;
using TestReportAPi.BusinessLayer.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestReportAPi.Models;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Configuration;
using System.IO;
using Amazon;
using Amazon.S3;
using Amazon.S3.Transfer;
using Amazon.S3.Model;
using Amazon.S3.Util;
using System.Collections.Generic;

namespace TestReportAPi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class TestReportsController: ControllerBase
  {
    private readonly ITestReportService _service;
    private IAmazonS3 _client;
    private string accessKey;
    private string secretKey;
    public TestReportsController(ITestReportService service, IConfiguration config)
    {
      _service = service;
      accessKey = "AKIAQUIYJ2BUI2SWRQHH"; // config.GetSection("AWSSDK:access_key").Value;
      secretKey =  "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"; // config.GetSection("AWSSDK:secret_key").Value;
    }

    [HttpGet]
    public IActionResult GetAllTestReports()
    {
      try
      {
        return Ok(_service.GetAllTestReports());
      }
      catch (Exception exe)
      {
        return BadRequest(exe.Message);
      }
    }

    [HttpGet]
    [Route("{patientId}")]
    public IActionResult GetTestReportsOfPatient(string patientId)
    {
      try
      {
        return Ok(_service.GetTestReportsOfPatient(patientId));
      }
      catch (NoTestReportsForPatientException trExe)
      {
        return NotFound(trExe.Message);
      }
      catch (Exception exe)
      {
        return BadRequest(exe.Message);
      }
    }

    [HttpPost]
    [Route("{patientId}/upload/{testName}")]
    public async Task<IActionResult> UploadPatientTestReport(string patientId, [FromForm] IFormFile file, string testName)
    {
      try
      {
        if(file == null || file.Length == 0)
          return Content("File Not Selected");
        string fileName = file.FileName;
        Console.WriteLine(fileName);
        string extension = Path.GetExtension(fileName);
        Console.WriteLine(extension);
        var key = string.Format("{0}/{1}-" +  DateTime.Now.ToString("MM-dd-yy") + extension, patientId, testName);
        Console.WriteLine(key);

        _client = new AmazonS3Client(accessKey, secretKey, RegionEndpoint.APSouth1);

        var request = new PutObjectRequest{
          BucketName = "cgi-wave7-dotnet",
          Key = key,
          AutoCloseStream = false,
          InputStream = file.OpenReadStream()
        };

        Console.WriteLine(request.ToString());

        await _client.PutObjectAsync(request);
        TestReport tr = new TestReport();
        tr.PatientId = patientId;
        tr.NameOfTestConducted = testName;
        tr.FileLocation = key;
        tr.FileName = testName + "-" + DateTime.Now.ToString("MM-dd-yy");

        return Ok(_service.AddTestReportToPatient(patientId, tr));
      }
      catch (Exception exe)
      {
        return BadRequest(exe.Message);
      }
    }
    [HttpGet]
    [Route("{patientId}/report/{fileName}")]
    public IActionResult GetSingleReportOfPatient(string patientId, string fileName)
    {
      try
      {
        return Ok(_service.GetSingleReportOfPatient(patientId, fileName));
      }
      catch (Exception exe)
      {
        return BadRequest(exe.Message);
      }
    }
    [HttpGet]
    [Route("{patientId}/report/{fileName}/link")]
    public IActionResult GetSpecifiedTestReportOfPatient(string patientId, string fileName)
    {
      try
      {
        return Ok(_service.GetSpecifiedTestReportOfPatient(patientId, fileName));
      }
      catch (Exception exe)
      {
        return BadRequest(exe.Message);
      }
      
    }    
  }
}