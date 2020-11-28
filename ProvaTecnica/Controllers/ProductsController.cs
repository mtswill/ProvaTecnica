using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProvaTecnica.Services;
using ProvaTecnica.Models;
using ProvaTecnica.Models.ViewModels;
using ProvaTecnica.Services.Exceptions;

namespace ProvaTecnica.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductService _productService;
        private readonly CategoryService _categoryService;

        public ProductsController(ProductService productService, CategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var list = _productService.FindAll();
            return View(list);
        }

        public IActionResult Create()
        {
            var categories = _categoryService.FindAll();
            var viewModel = new ProductFormViewModel { Categories = categories };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product product)
        {
            _productService.Insert(product);
            return RedirectToAction(nameof(Index));

        }

        public IActionResult Delete(int? id)
        {
            if(id == null) return NotFound();

            var obj = _productService.FindById(id.Value);
            if(obj == null) return NotFound();

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _productService.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id)
        {
            if(id == null) return NotFound();

            var obj = _productService.FindById(id.Value);
            if(obj == null) return NotFound();

            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if(id == null) return NotFound();

            var obj = _productService.FindById(id.Value);
            if(obj == null) return NotFound();

            List<Category> categories = _categoryService.FindAll();
            ProductFormViewModel viewModel = new ProductFormViewModel { Product = obj, Categories = categories };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Product product)
        {
            if(id != product.Id) return BadRequest();
            try
            {
                _productService.Update(product);
                return RedirectToAction(nameof(Index));
            }
            catch(NotFoundException)
            {
                return NotFound();
            }
            catch(DbConcurrencyException)
            {
                return BadRequest();
            }
        }
    }
}
