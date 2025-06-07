using ExpenseTracker.Data;
using ExpenseTracker.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.Controllers
{
    public class ItemsController : Controller
    {
        private readonly ApplicationDBContext _db;
        public ItemsController(ApplicationDBContext db) { _db = db; }
        public IActionResult Index()
        {
            List<Items> ObjectItems = _db.Item.ToList();
            return View(ObjectItems);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Items item)
        {
            if(ModelState.IsValid)
            {
                _db.Add(item);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
