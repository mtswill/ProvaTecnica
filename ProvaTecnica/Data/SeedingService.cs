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

            Category c1 = new Category(5, "Carro", "Departamento de carros");
            Category c2 = new Category(6, "Moto", "Departamento de motos");

            Product p1 = new Product(7, "celta", "hatch", 10000.00, "Chevrolet", c1);
            Product p2 = new Product(8, "fan", "150cc", 6000.00, "Honda", c2);

            _context.Category.AddRange(c1, c2);
            _context.Product.AddRange(p1, p2);

            _context.SaveChanges();
        }
    }
}
