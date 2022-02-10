using CleanSuporte.Aplication.Interfaces;
using CleanSuporte.Aplication.Services;
using CleanSuporte.Aplication.ViewModels;
using CleanSuporte.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanSuporte.Mvc.Controllers
{

    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _productService.GetProducts();
            return View(result);
        }

       
        [HttpGet()]
       public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,Description,Price")] ProductViewModel product)
        {
            if (ModelState.IsValid)
            {
                _productService.Add(product);
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Add([FromBody]Product product)
        {
            var productVM = new ProductViewModel
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price
            };

            _productService.Add(productVM);
            return RedirectToAction(nameof(Index));
           
        }

      
        [HttpGet()]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var productVM = await _productService.GetById(id);

            if (productVM == null) return NotFound();
            return View(productVM);

        }

        [HttpPost]
        public IActionResult Edit([Bind("Id,Name,Description,Price")] ProductViewModel productVM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _productService.Update(productVM);
                }
                catch(Exception)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(productVM);
        }

        [HttpPut]
        public IActionResult Att([FromBody] Product product)
        {
            var productVM = new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price
            };
            
            if (ModelState.IsValid)
            {
                try
                {
                    _productService.Update(productVM);
                }
                catch(Exception)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            
            return View(productVM);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if(id==null)
            {
                return NotFound();
            }

            var productVM = await _productService.GetById(id);
            if (productVM == null)
            {
                return NotFound();
            }
            return View(productVM);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();
            var productVM = await _productService.GetById(id);

            if (productVM == null)
                return NotFound();

            return View(productVM);

        }

        [HttpPost(), ActionName("Delete")]
        public IActionResult DeleteConfirmed(int? id)
        {
            if (id == null)
                return NotFound();

            try
            {
                _productService.Remove(id);
                return RedirectToAction("Index");
            }
            catch(Exception)
            {
                return NotFound();
                
            }
            
        }
        
    }
}
