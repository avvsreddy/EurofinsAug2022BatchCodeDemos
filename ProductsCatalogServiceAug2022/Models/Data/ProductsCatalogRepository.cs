using ProductsCatalogServiceAug2022.Models.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ProductsCatalogServiceAug2022.Models.Data
{
    public class ProductsCatalogRepository : IProductsCatalogRepository
    {
        private ProductsCatalogDbContext db = new ProductsCatalogDbContext();
        public void Create(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            //db.Products.Remove(db.Products.Find(id));

            var productToDel = db.Products.Find(id);
            db.Entry(productToDel).State = System.Data.Entity.EntityState.Deleted;

            db.SaveChanges();
        }
        public Product GetProduct(int id)
        {
            return db.Products.Find(id);
        }
        public List<Product> GetProducts()
        {
            return db.Products.ToList();
        }
        public void Update(Product product)
        {
            db.Entry(product).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
    }
}