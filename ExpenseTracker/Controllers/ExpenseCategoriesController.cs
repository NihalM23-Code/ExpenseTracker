using ExpenseTracker.Data;
using ExpenseTracker.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.Controllers
{
    public class ExpenseCategoriesController : Controller
    {
        private readonly ApplicationDBContext _db;
        public ExpenseCategoriesController(ApplicationDBContext db) { _db = db; }
        public IActionResult Index()
        {
            List<ExpenseCategories> categories = _db.Categories.ToList();
            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ExpenseCategories categories)
        {
            if(ModelState.IsValid)
            {
                _db.Add(categories);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categories);
        }

        public IActionResult Update(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            else
            {
                ExpenseCategories obj = _db.Categories.Find(id);
                if(obj == null)
                {
                    return NotFound();
                }
                else
                {
                    return View(obj);
                }
            }
               
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(ExpenseCategories ex)
        {
            if(ModelState.IsValid)
            {
                _db.Categories.Update(ex);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ex);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            else
            {
                ExpenseCategories obj = _db.Categories.Find(id);
                if (obj == null)
                {
                    return NotFound();
                }
                else
                {
                    return View(obj);
                }
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost (int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            else
            {
                ExpenseCategories obj = _db.Categories.Find(id);
                if (obj == null)
                {
                    return NotFound();
                }
                else
                {
                   _db.Categories.Remove(obj);
                   _db.SaveChanges();
                   return RedirectToAction("Index");
                }
            }
        }
    }
}
