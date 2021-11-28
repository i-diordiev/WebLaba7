using Microsoft.EntityFrameworkCore;
using WebLaba7.Models;

namespace WebLaba7.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Receipt> Receipts { get; set; }
    }
}