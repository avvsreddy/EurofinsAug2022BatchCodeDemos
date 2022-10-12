using System.Web.Http;

namespace ProductsCatalogServiceAug2022.Controllers
{
    public class ProductsController : ApiController
    {
        //GET .....api/products
        [HttpGet]
        public string Hello()
        {
            return "Welcome to Web API";
        }


    }
}
