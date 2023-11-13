using Microsoft.EntityFrameworkCore;

namespace WebStore.Models
{
    public class MyDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Order> Orders {  get; set; } 

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Branch> branches { get; set; }

        public DbSet<Employee> employees { get; set; }

        public DbSet<Payment> payments { get; set; }

        public DbSet<Review> reviews { get; set; }

        public DbSet<ShoppingCart> shoppingCarts { get; set; }



        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        // Replace with your actual connection string
        optionsBuilder.UseMySql("Server=localhost;port=3306;Database=my_database;User=root;Password=Khaledomar2001;",
            new MariaDbServerVersion(new Version(10, 3, 29))); // You may need to adjust the MariaDB server version
        }
    }
}
