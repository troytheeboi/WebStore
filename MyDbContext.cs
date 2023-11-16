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

        public IConfiguration configurationn { get; }

        public MyDbContext(DbContextOptions<MyDbContext> options, IConfiguration configuration) : base(options)
        {
            configurationn = configuration;
        }

        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

           /* var envName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            IConfigurationRoot configuration = new ConfigurationBuilder()
                 .SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
 
                 .AddJsonFile("appsettings.json", optional: false)
                 .AddJsonFile($"appsettings.{envName}.json", optional: false)
                 .Build();*/
            optionsBuilder.UseMySql("Server=localhost;port=3306;Database=my_database;User=root;Password=Khaledomar2001;",
            new MariaDbServerVersion(new Version(10, 3, 29)));

            
        }
    }
}
