using Humanizer.Configuration;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using WebStore.Models;

namespace WebStore
{
    public class MyDbContext : DbContext
    {
        public DbSet<ProductEntity> Products { get; set; }

        public DbSet<SupplierEntity> Suppliers { get; set; }

        public DbSet<CategoryEntity> Categories { get; set; }

        public DbSet<OrderEntity> Orders { get; set; }

        public DbSet<CustomerEntity> Customers { get; set; }

        public DbSet<BranchEntity> branches { get; set; }

        public DbSet<EmployeeEntity> employees { get; set; }

        public DbSet<PaymentEntity> payments { get; set; }

        public DbSet<ReviewEntity> reviews { get; set; }

        public DbSet<ShoppingCartEntity> shoppingCarts { get; set; }

        
        public MyDbContext(DbContextOptions<MyDbContext> options, IConfiguration configuration) : base(options)
        {}
    }
}
