using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
 
namespace ECommerce.Models
{
    public abstract class BaseEntity {}

    public class ECommerceContext : DbContext
    {
        
        public ECommerceContext(DbContextOptions<ECommerceContext> options) : base(options) { }
        public DbSet<Customer> customers { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Order> orders { get; set; }
    }
}