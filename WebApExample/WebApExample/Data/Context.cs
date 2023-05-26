using Microsoft.EntityFrameworkCore;
using WebApExample.Models;

namespace WebApExample.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }
        public DbSet<Persons> Persons { get; set; }
        public DbSet<Trips> Trips { get; set; }
        public DbSet<Cars> Cars { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Persons>().HasKey(p => p.Id);
            modelBuilder.Entity<Persons>().ToTable("Persons");

            modelBuilder.Entity<Trips>().HasKey(p => p.TravelID);
            modelBuilder.Entity<Trips>().ToTable("Trips");

            modelBuilder.Entity<Cars>().HasKey(p => p.CarId);
            modelBuilder.Entity<Cars>().ToTable("Cars");
        }
    }
}
    
