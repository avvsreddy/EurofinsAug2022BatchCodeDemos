using ProductsCatalogServiceAug2022.Models.Entities;
using System.Data.Entity;

namespace ProductsCatalogServiceAug2022.Models.Data
{
    public class ProductsCatalogDbContext : DbContext
    {
        // db configuration
        public ProductsCatalogDbContext() : base("name=DefaultConnection")
        {

        }

        // tables config
        public DbSet<Product> Products { get; set; }
    }
}