using ProductsCatalogConsoleApp.Entities;
using System.Data.Entity;

namespace ProductsCatalogConsoleApp.Data
{
    public class ProductsDbContext : DbContext
    {

        // 1. Configure the Database
        public ProductsDbContext() : base("name=default")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            // Fluent API
            // TPC
            modelBuilder.Entity<Customer>().Map(c => c.MapInheritedProperties()).ToTable("Customers");

            modelBuilder.Entity<Supplier>().Map(s => s.MapInheritedProperties()).ToTable("Suppliers");

        }


        // 2. Configure/map the tables with Entity

        public DbSet<Product> Products { get; set; }
        public DbSet<Catagory> Catagories { get; set; }

        //public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Person> People { get; set; }
        //public DbSet<Customer> Customers { get; set; }

    }
}
