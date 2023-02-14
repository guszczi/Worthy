using backend.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Entities.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Price> Prices { get; set; }
        public virtual DbSet<Rating> Ratings { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Shop> Shops { get; set; }
        public virtual DbSet<Link> Links { get; set; }
    }
}