using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ExpenseTracker.Models.ViewModel
{
    public class ExpenseVM
    {
        public Expense Expense { get; set; }
        [ValidateNever]
        public List<SelectListItem> DropDown {  get; set; } 
    }
}
