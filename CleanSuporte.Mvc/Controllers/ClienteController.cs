using CleanSuporte.Domain.Entities;
using CleanSuporte.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanSuporte.Mvc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : Controller
    {
        private readonly IClienteRepository _clienteRepository;
        public ClienteController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _clienteRepository.GetClientes();
            return new ObjectResult(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Detalhe(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var result = await _clienteRepository.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return new ObjectResult(result);

        }

        [HttpPost]
        public IActionResult Add([FromBody] Cliente cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _clienteRepository.Add(cliente);
                    //return RedirectToAction(nameof(Index));
                }
                return Ok();
            }catch(Exception)
            {
                return Conflict();
            }  
        }

        //[HttpPut("Edit")]
        [HttpPut]
        public async Task<IActionResult> Att([FromBody] Cliente cliente)
        {
            try
            {
                _clienteRepository.Update(cliente);
                var result = await _clienteRepository.GetClientes();
                return new ObjectResult(result);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        //[HttpDelete("Delete")]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] Cliente cliente)
        {
            try
            {
                _clienteRepository.Remove(cliente);
                var result = await _clienteRepository.GetClientes();
                return Ok();
            }
            catch
            {
                return NotFound();
            }
        }

    }
}
