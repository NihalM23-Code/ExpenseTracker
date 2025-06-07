using ExpenseTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Data
{
    public class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options):base (options)
        {

        }
        public DbSet<Items> Item { get; set; }
        public DbSet<Expense> Expense { get; set; }

        public DbSet<ExpenseCategories> Categories { get; set; }


    }
}
