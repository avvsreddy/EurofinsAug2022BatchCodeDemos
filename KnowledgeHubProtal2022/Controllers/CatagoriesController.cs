using KnowledgeHubProtal2022.Models.Data;
using KnowledgeHubProtal2022.Models.Entities;
using System.Linq;
using System.Web.Mvc;

namespace KnowledgeHubProtal2022.Controllers
{
    public class CatagoriesController : Controller
    {

        private KnowledgeHubDbContext db = new KnowledgeHubDbContext();

        // GET: Catagories
        // .../catagories/index
        public ActionResult Index()
        {
            // fetch the catagories information from model/dal
            var catagories = db.Catagories.ToList();
            // pass the data into view

            //ViewBag.Catagoreis = catagories;
            //ViewData["catagories"] = catagories;
            //TempData["catagories"] = catagories;

            return View(catagories);
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Save(Catagory catagory)
        {
            // validate
            if (!ModelState.IsValid)
                return View("Create");
            db.Catagories.Add(catagory);
            db.SaveChanges();
            TempData["Message"] = $"Catagory {catagory.Name} Successfully Created";
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var catagoryToDelete = db.Catagories.Find(id);
            db.Catagories.Remove(catagoryToDelete);
            db.SaveChanges();
            TempData["Message"] = $"Catagory {catagoryToDelete.Name} Successfully Deleted";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var catagoryToEdit = db.Catagories.Find(id);
            return View(catagoryToEdit);
        }

        [HttpPost]
        public ActionResult Edit(Catagory catagory)
        {
            if (!ModelState.IsValid)
                return View();
            db.Entry(catagory).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            TempData["Message"] = $"Catagory {catagory.Name} Successfully Modified";
            return RedirectToAction("Index");

        }
    }
}