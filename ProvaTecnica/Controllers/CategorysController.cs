using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProvaTecnica.Models;

namespace ProvaTecnica.Controllers
{
    public class CategorysController : Controller
    {
        public IActionResult Index()
        {
            List<Category> list = new List<Category>();
            list.Add(new Category { Id = 1, Name = "Medicamentos", Description = "Remedios" });
            list.Add(new Category { Id = 2, Name = "Remedios", Description = "Medicamentos" });
            return View(list);
        }
    }
}
