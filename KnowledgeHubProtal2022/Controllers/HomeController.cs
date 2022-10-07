using System.Web.Mvc;

namespace KnowledgeHubProtal2022.Controllers
{
    public class HomeController : Controller
    {

        // ...
        public ActionResult Index()
        {
            return View();
        }
        //.../home/about
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        // .../home/hello
        public ActionResult Hello()
        {

            string msg = "Welcome to our knowledge hub protal";
            ViewBag.Message = msg;
            // aspx
            // razor

            return View();

        }
    }
}