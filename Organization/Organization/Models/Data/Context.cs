using Microsoft.EntityFrameworkCore;

namespace Organization.Models.Data
{
    public class MySuperOrgContext:DbContext
    {
       public MySuperOrgContext(DbContextOptions<MySuperOrgContext> options):base(options) { }
            public DbSet<TradingOrganization> TradingOrganizations { get; set; }
            public DbSet<TradingPoint> TradingPoints { get; set; }
            public DbSet<Seller> Sellers { get; set; }
            public DbSet<Supplier> Suppliers { get; set; }
            public DbSet<SupplierOrder> SupplierOrders { get; set; }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
            modelBuilder.Entity<TradingOrganization>().HasKey(p => p.TOId);
            modelBuilder.Entity<TradingOrganization>().ToTable("TradingOrganization");

            modelBuilder.Entity<TradingPoint>().HasKey(p => p.TPId);
            modelBuilder.Entity<TradingPoint>().ToTable("TradingPoint");

            modelBuilder.Entity<Seller>().HasKey(p => p.SellerId);
            modelBuilder.Entity<Seller>().ToTable("Seller");

            modelBuilder.Entity<Supplier>().HasKey(p => p.SupId);
            modelBuilder.Entity<Supplier>().ToTable("Supplier");

            modelBuilder.Entity<SupplierOrder>().HasKey(p => p.SupOId);
            modelBuilder.Entity<SupplierOrder>().ToTable("SupplierOrder");
        }        
    }
}
