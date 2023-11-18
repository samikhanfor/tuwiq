using Microsoft.EntityFrameworkCore;
using tuwiq.Models;

namespace tuwiq.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
                
        }
        public DbSet<Cats> Cats { get; set; }
        public DbSet<users> users { get; set; }


    }
}
