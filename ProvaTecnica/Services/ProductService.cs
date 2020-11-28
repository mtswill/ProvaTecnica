using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProvaTecnica.Data;
using ProvaTecnica.Models;

namespace ProvaTecnica.Services
{
    public class ProductService
    {
        private readonly ProvaTecnicaContext _context;

        public ProductService(ProvaTecnicaContext context)
        {
            _context = context;
        }

        public List<Product> FindAll()
        {
            return _context.Product.ToList();
        }

        public void Insert(Product obj)
        {
            obj.Category = _context.Category.First();
            _context.Add(obj);
            _context.SaveChanges();
        }
    }
}
