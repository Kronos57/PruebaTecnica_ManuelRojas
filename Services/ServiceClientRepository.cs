using Data.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using Repository;

namespace Services
{
    public class ServiceClientRepository : IClientRepository
    {
        public Task CreateClientAsync(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public Task DeleteClientAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Cliente>> GetAllClientsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Cliente> GetClientByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateClientAsync(Cliente cliente)
        {
            throw new NotImplementedException();
        }
    }
}
