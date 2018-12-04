using System;
using Microsoft.EntityFrameworkCore;
using WebAppAspnetcore.Data.Entities;

namespace WebAppAspnetcore.Data
{
    public class DutchContext : DbContext
    {
        public DutchContext(DbContextOptions<DutchContext> options) : base(options)
        {
            
        }
        
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Order>()
                        .HasData(new Order()
                        {
                            Id = 1,
                            OrderDate = DateTime.UtcNow,
                            OrderNumber = "12345"
                        });
            }
    }
}
