using Humanizer.Configuration;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using WebStore.Models;

namespace WebStore
{
    public class MyDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Branch> branches { get; set; }

        public DbSet<Employee> employees { get; set; }

        public DbSet<Payment> payments { get; set; }

        public DbSet<Review> reviews { get; set; }

        public DbSet<ShoppingCart> shoppingCarts { get; set; }

        
        public MyDbContext(DbContextOptions<MyDbContext> options, IConfiguration configuration) : base(options)
        {}
    }
}
