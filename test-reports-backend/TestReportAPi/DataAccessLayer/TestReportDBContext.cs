using System;
using System.Collections.Generic;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;
using TestReportAPi.Models;

namespace TestReportAPi.DataAccessLayer
{
  public class TestReportDBContext
  {
    MongoClient mongoClient;
    IMongoDatabase database;
    public TestReportDBContext() { }
    public TestReportDBContext(IConfiguration config) 
    {
      if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Production")
      {
          mongoClient = new MongoClient(Environment.GetEnvironmentVariable("MONGODB_HOST"));
      }
      else
      {
          mongoClient = new MongoClient(config.GetSection("MongoDB:server").Value);
      }
      database = mongoClient.GetDatabase(config.GetSection("MongoDB:database").Value);
    }
    public IMongoCollection<TestReport> TestReports => database.GetCollection<TestReport>("TestReports");
  }
}