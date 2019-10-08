using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using AppointmentsWebAPI.Entities;
using System.Threading.Tasks;
using System;

namespace AppointmentsWebAPI.DataAccessLayer
{
    public class CalendarsContext: ICalendarsDBContext 
    {
        public MongoClient mongoClient;
        public IMongoDatabase mongoDatabase;

        public CalendarsContext(IConfiguration cfg)
        {
            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Production")
            {
                mongoClient = new MongoClient(Environment.GetEnvironmentVariable("MongoConnectionString_db"));
            }
            else
            {
                mongoClient = new MongoClient(cfg.GetSection("MongoDB:MongoConnectionString_db").Value);
            }
            mongoDatabase = mongoClient.GetDatabase(cfg.GetSection("MongoDB:MongoDatabase").Value);  
        }

        public IMongoCollection<DayCalendar> GetAppointmentsCollection() 
        {
            return  mongoDatabase.GetCollection<DayCalendar>("appointments");
        }
    }
}