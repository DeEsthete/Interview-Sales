using Microsoft.EntityFrameworkCore;
using SalesInterview.Entities;

namespace SalesInterview.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sale>().HasKey(x => x.Id);
            modelBuilder.Entity<SaleProduct>().HasKey(x => new { x.ProductId, x.SaleId });
        }

        public DbSet<Sale> Sales { get; set; }
        public DbSet<SaleProduct> SaleProducts { get; set; }
    }
}