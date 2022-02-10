using CleanSuporte.Aplication.Interfaces;
using CleanSuporte.Domain.Entities;
using CleanSuporte.Domain.Interfaces;
using CleanSuporte.Infra.Data.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanSuporte.Mvc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class ProdutosController : Controller
    {
        private readonly IProductRepository _productRepository;
        public ProdutosController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Index()
        {

            //var result = await _productService.GetProducts();
            var result = await _productRepository.GetProducts();
            return new ObjectResult(result);
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> Detalhe(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var result = await _productRepository.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return new ObjectResult(result);

        }

        [Authorize]
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Add([FromBody] Product product)
        {
            if (ModelState.IsValid)
            {
                _productRepository.Add(product);
                //return RedirectToAction(nameof(Index));
            }
            return new ObjectResult(product); 
        }

        [Authorize]
        [HttpPut("Edit")]
        public async Task<IActionResult> Att([FromBody] Product product)
        {
            try
            {
                _productRepository.Update(product);
                var result = await _productRepository.GetProducts();
                return new ObjectResult(result);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [Authorize]
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromBody] Product product)
        {
            try
            {
                _productRepository.Remove(product);
                var result = await _productRepository.GetProducts();
                return new ObjectResult(result);
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
