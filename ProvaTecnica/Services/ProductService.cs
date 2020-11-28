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
            _context.Add(obj);
            _context.SaveChanges();
        }

        public Product FindById(int id)
        {
            return _context.Product.FirstOrDefault(obj => obj.Id == id);
        }

        public void Remove(int id)
        {
            var obj = _context.Product.Find(id);
            _context.Product.Remove(obj);
            _context.SaveChanges();
        }
    }
}
