using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace ExpenseTracker.Models
{
    public class ExpenseCategories
    {
        public int id { get; set; }
        [Required]
        [DisplayName("Category Name")]
        public string Categoryname { get; set; }

    }
}
