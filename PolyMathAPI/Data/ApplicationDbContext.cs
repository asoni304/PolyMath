using Microsoft.EntityFrameworkCore;
using PolyMathAPI.Models;

namespace PolyMathAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }

        public DbSet<Genre> Genres { get; set; }
        public DbSet<Article> Articles { get; set; }
    }
}
