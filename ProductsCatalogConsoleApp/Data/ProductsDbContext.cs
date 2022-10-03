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

        // 2. Configure/map the tables with Entity

        public DbSet<Product> Products { get; set; }
        public DbSet<Catagory> Catagories { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }

    }
}
