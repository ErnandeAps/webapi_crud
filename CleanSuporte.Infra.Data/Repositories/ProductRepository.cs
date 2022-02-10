using CleanSuporte.Domain.Entities;
using CleanSuporte.Domain.Interfaces;
using CleanSuporte.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanSuporte.Infra.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetById(int? id)
        {
            return await _context.Products.FindAsync(id);
            
        }
        public async Task  Add(Product product)
        {
            await _context.AddAsync(product);
            await _context.SaveChangesAsync();
        }
        public void Update(Product produtct)
        {
            _context.Update(produtct);
            _context.SaveChanges();
        }

        public void Remove(Product product)
        {
            _context.Remove(product);
            _context.SaveChanges();
        }
    }
}
