using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProvaTecnica.Data;
using ProvaTecnica.Models;

namespace ProvaTecnica.Services
{
    public class CategoryService
    {
        private readonly ProvaTecnicaContext _context;

        public CategoryService(ProvaTecnicaContext context)
        {
            _context = context;
        }

        public List<Category> FindAll()
        {
            return _context.Category.OrderBy(x => x.Name).ToList();
        }
    }
}
