using ProductsCatalogServiceAug2022.Models.Entities;
using System.Collections.Generic;

namespace ProductsCatalogServiceAug2022.Models.Data
{
    public interface IProductsCatalogRepository
    {
        List<Product> GetProducts();
        Product GetProduct(int id);

        void Delete(int id);
        void Create(Product product);
        void Update(Product product);
    }
}
