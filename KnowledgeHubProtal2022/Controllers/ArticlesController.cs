using KnowledgeHubProtal2022.Models.Data;
using KnowledgeHubProtal2022.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace KnowledgeHubProtal2022.Controllers
{
    public class ArticlesController : Controller
    {
        // TODO: use IoC

        private IArticlesRepository articlesRepo = null;// new ArticlesRepository();
        private ICatagoriesRepository catagoryRepo = null;// new CatagoriesRepository();
        // GET: Articles

        public ArticlesController(IArticlesRepository articlesRepo, ICatagoriesRepository catagoryRepo)
        {
            this.articlesRepo = articlesRepo;
            this.catagoryRepo = catagoryRepo;
        }


        [OutputCache(Duration = 30, VaryByParam = "data", Location = System.Web.UI.OutputCacheLocation.Any)]
        public ActionResult Index(string data = null)
        {

            ViewBag.ToDay = DateTime.Now.ToLongTimeString();
            // fetch articlers for browse
            List<Article> articles = new List<Article>();
            if (data == null)
                articles = articlesRepo.GetArticlesForBrowse();
            else
                articles = (from a in articlesRepo.GetArticlesForBrowse()
                            where a.Title.ToLower().Contains(data.ToLower()) || a.Description.ToLower().Contains(data.ToLower()) || a.Catagory.Name.ToLower().Contains(data.ToLower()) || a.Catagory.Description.ToLower().Contains(data.ToLower())
                            select a).ToList();

            return View(articles);
        }

        [Authorize]
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
        [Authorize]
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

        [ChildActionOnly]
        public ActionResult CatagoryHyperlinks()
        {
            var catagories = catagoryRepo.GetCatagories();
            return PartialView(catagories);
        }
        [Authorize(Roles = "admin")]
        public ActionResult Review()
        {
            var articlesForReview = articlesRepo.GetArticlesForReview();
            return View(articlesForReview);
        }
        [Authorize(Roles = "admin")]
        public ActionResult Approve(List<int> articleIds)
        {
            articlesRepo.Approve(articleIds);
            TempData["Message"] = $"{articleIds.Count} articles approved";
            //TODO: send mail notification to article author
            return RedirectToAction("Review");
        }
        [Authorize(Roles = "admin")]
        public ActionResult Reject(List<int> articleIds)
        {
            articlesRepo.Reject(articleIds);
            TempData["Message"] = $"{articleIds.Count} articles rejected";
            //TODO: send mail notification to article author
            return RedirectToAction("Review");
        }

    }
}