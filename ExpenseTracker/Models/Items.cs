using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ExpenseTracker.Models
{
    public class Items
    {
        public int Id { get; set; }
        [Required]
        public string Borrower { get; set; }
        [Required]

        [DisplayName("Item Name")]
        public string ItemName { get; set; }
        [Required]
        public string Lender { get; set; }
    }
}
