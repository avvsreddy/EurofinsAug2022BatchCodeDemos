using System;
using System.Web.Mvc;

namespace KnowledgeHubProtal2022.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        [OutputCache(Duration = 30)]
        public ActionResult Index()
        {
            ViewBag.ToDay = DateTime.Now.ToLongTimeString();
            return View();
        }

        public ActionResult Hello()
        {
            //
            //
            int a = 10;
            int b = 0;
            int r = a / b;
            return View();
        }

    }
}