using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseTracker.Models
{
    public class Expense
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Expense Name")]
        public string ExpenseName { get; set; }
        [Required]
        [Range(1,int.MaxValue,ErrorMessage ="Amount should be greater than 0")]
        public float Amount { get; set; }
        [Required]
        public int ExpenseCategoryId { get; set; }
        [ForeignKey("ExpenseCategoryId")]
        [ValidateNever]
        public virtual ExpenseCategories ExpenseCategory { get; set; }
    }
}
