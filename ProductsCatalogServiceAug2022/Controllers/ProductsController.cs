using ProductsCatalogServiceAug2022.Models.Data;
using ProductsCatalogServiceAug2022.Models.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ProductsCatalogServiceAug2022.Controllers
{
    public class ProductsController : ApiController
    {

        IProductsCatalogRepository repo = new ProductsCatalogRepository();
        //GET .....api/products
        [HttpGet]
        public List<Product> GetProducts()
        {
            return repo.GetProducts();
        }
        // GET ....../api/products/23
        public IHttpActionResult GetProduct(int id)
        {
            var prodcut = repo.GetProduct(id);
            if (prodcut == null)
            {
                // return 404
                return NotFound();

            }
            // return ok+data
            return Ok(prodcut);
        }
        // GET ...../api/products/brand/apple
        [HttpGet]
        [Route("api/products/brand/{brand}")]
        public IHttpActionResult GetProductByBrand(string brand)
        {
            var products = repo.GetProducts().Where(p => p.Brand == brand);
            if (products.Count() == 0)
                return NotFound();
            return Ok(products);
        }

        // get cheapest product
        [Route("api/products/cheapest")]
        public IHttpActionResult GetCheapestProduct()
        {
            var product = repo.GetProducts().OrderBy(p => p.Price).FirstOrDefault();
            return Ok(product);
        }
        // get costliest product
        [Route("api/products/costliest")]
        public IHttpActionResult GetCostliestProduct()
        {
            var product = repo.GetProducts().OrderByDescending(p => p.Price).FirstOrDefault();
            return Ok(product);
        }
        // color based product : color
        [Route("api/products/color/{color}")]
        public IHttpActionResult GetProductByColor(string color)
        {
            var products = repo.GetProducts().Where(p => p.Color == color);
            if (products.Count() == 0)
                return NotFound();
            return Ok(products);
        }
        // get price range product : min max
        [Route("api/products/min/{min}/max/{max}")]
        public IHttpActionResult GetProductByColor(int min, int max)
        {
            var products = repo.GetProducts().Where(p => p.Price >= min && p.Price <= max);
            if (products.Count() == 0)
                return NotFound();
            return Ok(products);
        }

        // get available products

        [Route("api/products/instock")]
        public IHttpActionResult GetProductsInStock()
        {
            var products = repo.GetProducts().Where(p => p.IsAvailable);
            if (products.Count() == 0)
                return NotFound();
            return Ok(products);
        }

    }
}
