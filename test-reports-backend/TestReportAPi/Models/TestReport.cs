using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;

namespace TestReportAPi.Models
{
  public class TestReport
  {
    [BsonId]
    [BsonIgnoreIfDefault]
    [BsonRepresentation(BsonType.ObjectId)]
    public string TestReportId { get; set; }
    public string NameOfTestConducted { get; set; }
    public string PatientId { get; set; }
    public string PatientName { get; set; }
    public string PatientPhoneNumber { get; set; }
    public string DiagnosticCenterId { get; set; }
    public string DiagnosticCenterName { get; set; }
    public string DiagnosticCenterPhone { get; set; }
    public string FileName { get; set; }
    public string FileLocation { get; set; }
  }
}
