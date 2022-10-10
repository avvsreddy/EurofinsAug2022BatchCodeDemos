using KnowledgeHubProtal2022.Models.Data;
using KnowledgeHubProtal2022.Models.Entities;
using System;
using System.Linq;
using System.Web.Mvc;

namespace KnowledgeHubProtal2022.Controllers
{
    public class ArticlesController : Controller
    {
        // TODO: use IoC

        private IArticlesRepository articlesRepo = new ArticlesRepository();
        private ICatagoriesRepository catagoryRepo = new CatagoriesRepository();
        // GET: Articles
        public ActionResult Index()
        {
            // fetch articlers for browse

            return View(articlesRepo.GetArticlesForBrowse());
        }

        [HttpGet]
        public ActionResult Submit()
        {
            // get all catagories
            var catagories = from c in catagoryRepo.GetCatagories()
                             select new SelectListItem { Text = c.Name, Value = c.CatagoryID.ToString() };

            ViewBag.CatagoryID = catagories;
            return View();
        }
        [HttpPost]
        public ActionResult Submit(Article article)
        {
            if (!ModelState.IsValid)
                return View();

            article.IsApproved = false;
            article.DateSubmited = DateTime.Now;
            article.PostedBy = User.Identity.Name;

            articlesRepo.Submit(article);
            TempData["Message"] = $"Article {article.Title} submited successfully and notified to adminstrator for review";

            //TODO: send email notification to administrator

            //var catagories = from c in catagoryRepo.GetCatagories()
            //                 select new SelectListItem { Text = c.Name, Value = c.CatagoryID.ToString() };

            //ViewBag.CatagoryID = catagories;
            return RedirectToAction("Submit");
        }

    }
}