using CleanSuporte.Domain.Entities;
using CleanSuporte.Domain.Interfaces;
using CleanSuporte.Infra.Data.Context;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System;

namespace CleanSuporte.Infra.Data.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private ApplicationDbContext _context;
        public ClienteRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Cliente>> GetClientes()
        {
            return await _context.Clientes.ToListAsync();
        }

        public async Task<Cliente> GetById(int? id)
        {
            return await _context.Clientes.FindAsync(id);

        }
        public async Task Add(Cliente cliente)
        {
            await _context.AddAsync(cliente);
            await _context.SaveChangesAsync();
        }
        public void Update(Cliente cliente)
        {
            _context.Update(cliente);
            _context.SaveChanges();
        }

        public void Remove(Cliente cliente)
        {
            _context.Remove(cliente);
            _context.SaveChanges();
        }
    }
}
