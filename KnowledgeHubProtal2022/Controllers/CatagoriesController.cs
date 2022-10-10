using KnowledgeHubProtal2022.Models.Data;
using KnowledgeHubProtal2022.Models.Entities;
using System.Web.Mvc;

namespace KnowledgeHubProtal2022.Controllers
{
    public class CatagoriesController : Controller
    {

        //private KnowledgeHubDbContext db = new KnowledgeHubDbContext();
        private ICatagoriesRepository repo = new CatagoriesRepository();

        // GET: Catagories
        // .../catagories/index
        public ActionResult Index()
        {
            // fetch the catagories information from model/dal
            var catagories = repo.GetCatagories();
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
            //db.Catagories.Add(catagory);
            //db.SaveChanges();
            repo.Create(catagory);
            TempData["Message"] = $"Catagory {catagory.Name} Successfully Created";
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var catagoryToDelete = repo.GetCatagory(id);
            //db.Catagories.Remove(catagoryToDelete);
            //db.SaveChanges();
            repo.Delete(id);
            TempData["Message"] = $"Catagory {catagoryToDelete.Name} Successfully Deleted";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var catagoryToEdit = repo.GetCatagory(id);
            return View(catagoryToEdit);
        }

        [HttpPost]
        public ActionResult Edit(Catagory catagory)
        {
            if (!ModelState.IsValid)
                return View();
            //db.Entry(catagory).State = System.Data.Entity.EntityState.Modified;
            //db.SaveChanges();
            repo.Update(catagory);
            TempData["Message"] = $"Catagory {catagory.Name} Successfully Modified";
            return RedirectToAction("Index");

        }
    }
}