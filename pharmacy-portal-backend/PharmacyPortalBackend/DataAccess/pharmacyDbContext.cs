using Microsoft.EntityFrameworkCore;
using pharmacy_portal_backend.Entities;

namespace pharmacy_portal_backend.DataAccess
{
    public class PharmacyDbContext : DbContext
    {
        public PharmacyDbContext() { }
        public PharmacyDbContext(DbContextOptions<PharmacyDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Pharmacy> pharmacies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pharmacy>().HasKey(n => new { n.PharmacyId });
        }
    }
}