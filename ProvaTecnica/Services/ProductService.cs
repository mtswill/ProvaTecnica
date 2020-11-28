using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProvaTecnica.Data;
using ProvaTecnica.Models;
using Microsoft.EntityFrameworkCore;
using ProvaTecnica.Services.Exceptions;

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
            return _context.Product.Include(product => product.Category).ToList();
        }

        public void Insert(Product obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

        public Product FindById(int id)
        {
            return _context.Product.Include(obj => obj.Category).FirstOrDefault(obj => obj.Id == id);
        }

        public void Remove(int id)
        {
            var obj = _context.Product.Find(id);
            _context.Product.Remove(obj);
            _context.SaveChanges();
        }

        public void Update(Product obj)
        {
            if(!_context.Product.Any(x => x.Id == obj.Id)) 
            {
                throw new NotFoundException("Id not found");
            }
            try
            {
                _context.Update(obj);
                _context.SaveChanges();
            }
            catch(DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
