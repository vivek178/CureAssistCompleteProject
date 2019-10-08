using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using prescription.Entities;

namespace prescription.DataAccessLayer
{
    public class PrescriptionDbContext
    {
        MongoClient mongoClient;
        IMongoDatabase database;

        public PrescriptionDbContext(IConfiguration config)
        {
            //mongoClient = new MongoClient(config.GetSection("MongoDB:server").Value);
            mongoClient = new MongoClient(Environment.GetEnvironmentVariable("MongoConnectionString_db"));
            database = mongoClient.GetDatabase(config.GetSection("MongoDB:database").Value);
        }
        public IMongoCollection<Prescription> prescriptions => database.GetCollection<Prescription>("prescriptionRepo");
    }
}
