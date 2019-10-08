using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using pharmacy_portal_backend.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pharmacy_portal_backend.DataAccess
{
    public class PrescriptionOrderDBContext
    {
        MongoClient mongoClient;
        IMongoDatabase database;
        public PrescriptionOrderDBContext(IConfiguration config)
        {
            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Production")
            {
                mongoClient = new MongoClient(Environment.GetEnvironmentVariable("mongodb"));
            }
            else
            {
                mongoClient = new MongoClient(config.GetSection("MongoDB:server").Value);
            }

            database = mongoClient.GetDatabase(config.GetSection("MongoDB:database").Value);
        }
        public IMongoCollection<PrescriptionOrderRequest> PrescriptionOrderRequests => database.GetCollection<PrescriptionOrderRequest>("Prescriptions");
    }
}
