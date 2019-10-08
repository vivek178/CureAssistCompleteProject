using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using doctor_dc_backend.Models;

namespace doctor_dc_backend.DataAccessLayer
{
    public class DiagnosisCenterDbContext
    {
        MongoClient mongoClient;
        IMongoDatabase database;

        public DiagnosisCenterDbContext(IConfiguration config)
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

        public IMongoCollection<DiagnosisCenter> DiagnosisCenters => database.GetCollection<DiagnosisCenter>("DiagnosisCentersDatabase");
        // public IMongoCollection<DiagnosticCenterTimeSlots> DiagnosticCenterTimeSlots => database.GetCollection<DiagnosticCenterTimeSlots>("DcTimeSlotsDatabase");
    }
}
