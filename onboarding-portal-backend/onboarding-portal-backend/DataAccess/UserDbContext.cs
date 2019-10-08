using Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class UserDbContext:DbContext
    {
        public UserDbContext() { }

        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(n => new { n.UserId });
            modelBuilder.Entity<User>().HasAlternateKey(n => new { n.EmailId });

        }
        public DbSet<User> Users { get; set; }
    }
}
