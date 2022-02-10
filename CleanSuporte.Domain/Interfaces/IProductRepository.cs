using CleanSuporte.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanSuporte.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task <IEnumerable<Product>> GetProducts();
        Task<Product> GetById(int? id);
        
        Task Add(Product product);
        void Update(Product product);
        void Remove(Product product);
    }
}
