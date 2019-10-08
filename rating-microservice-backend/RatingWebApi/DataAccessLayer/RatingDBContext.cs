using Microsoft.EntityFrameworkCore;
using RatingWebApi.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RatingWebApi.DataAccessLayer
{
    public class RatingDBContext : DbContext
    {
        public RatingDBContext() { }

        public RatingDBContext(DbContextOptions<RatingDBContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FrequencyTable>().HasKey( n => new { n.RatingId });
        }

        public DbSet<FrequencyTable> frequencies { get; set; }
    }
}
