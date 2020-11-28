using Microsoft.EntityFrameworkCore;
using ProvaTecnica.Models;

namespace ProvaTecnica.Data
{
    public class ProvaTecnicaContext : DbContext
    {
        public ProvaTecnicaContext (DbContextOptions<ProvaTecnicaContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Product { get; set; }
    }
}
