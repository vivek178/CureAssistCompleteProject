using Microsoft.EntityFrameworkCore;
using Patient_Portal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Patient_Portal.DataAccess
{
    public class PatientDbContext : DbContext
    {
        public PatientDbContext() { }
        public PatientDbContext(DbContextOptions<PatientDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Patient> patients { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // defining primary key to patientId.
            modelBuilder.Entity<Patient>().HasKey(n => new { n.patientId });
        }
    }
}
