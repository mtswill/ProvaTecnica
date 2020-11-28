using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProvaTecnica.Models;

namespace ProvaTecnica.Data
{
    public class SeedingService
    {
        private ProvaTecnicaContext _context;

        public SeedingService(ProvaTecnicaContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if(_context.Category.Any() || _context.Product.Any())
            {
                return;
            }

            Category c1 = new Category(1, "Default name", "Default description");

            Product p1 = new Product(1, "Default name", "Default description", 10.00, "Default brand", c1);

            _context.Category.AddRange(c1);
            _context.Product.AddRange(p1);

            _context.SaveChanges();
        }
    }
}
