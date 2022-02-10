using CleanSuporte.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanSuporte.Domain.Interfaces
{
    public interface IClienteRepository
    {
        //Cria lista enumerada de clientes
        Task<IEnumerable<Cliente>> GetClientes();
        Task<Cliente> GetById(int? id);
        Task Add(Cliente cliente);
        void Update(Cliente cliente);
        void Remove(Cliente cliente);

    }
}
