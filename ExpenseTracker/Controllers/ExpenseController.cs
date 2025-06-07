using ExpenseTracker.Data;
using ExpenseTracker.Models;
using ExpenseTracker.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ExpenseTracker.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly ApplicationDBContext _db;
        public ExpenseController(ApplicationDBContext db) { _db = db; }
        public IActionResult Index()
        {
            List<Expense> expenseList = _db.Expense.Include(e=>e.ExpenseCategory).ToList();
            return View(expenseList);
        }
        public IActionResult Create()
        {
            ExpenseVM expenseVM = new ExpenseVM()
            {
                Expense = new Expense(),
                DropDown = _db.Categories.Select(i => new SelectListItem
                {
                    Text = i.Categoryname,
                    Value = i.id.ToString()
                }).ToList()
            };
            return View(expenseVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ExpenseVM expenseVM)
        { 
          if(ModelState.IsValid)
            {
                _db.Expense.Add(expenseVM.Expense);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            expenseVM.DropDown = _db.Categories.Select(i => new SelectListItem
            {
                Text = i.Categoryname,
                Value = i.id.ToString()
            }).ToList();
            return View(expenseVM);
        }

        public IActionResult Update(int? id)
        {
            if(id== null|| id==0)
            {
                return NotFound();
            }
            else
            {
                ExpenseVM expenseVM = new ExpenseVM()
                {
                    Expense = _db.Expense.Find(id),
                    DropDown = _db.Categories.Select(i => new SelectListItem
                    {
                        Text = i.Categoryname,
                        Value = i.id.ToString()
                    }).ToList()
                };
                if(expenseVM == null)
                {
                    return NotFound();
                }
                else
                {
                    return View(expenseVM);
                }
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(ExpenseVM ex)
        {
            if(ModelState.IsValid)
            {
                _db.Expense.Update(ex.Expense);
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
                Expense ex = _db.Expense.Find(id);
                if (ex == null)
                {
                    return NotFound();
                }
                else
                {
                    return View(ex);
                }
            }
        }
        public IActionResult DeletePost(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            else
            {
                Expense ex = _db.Expense.Find(id);
                if (ex == null)
                {
                    return NotFound();
                }
                else
                {
                    _db.Expense.Remove(ex);
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }
                
            }
        }
    }
}
