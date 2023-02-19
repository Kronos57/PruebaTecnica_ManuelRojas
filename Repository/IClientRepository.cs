using Data.EntityFramework.Entities;

namespace Repository
{
    public interface IClientRepository
    {
        Task<IEnumerable<Cliente>> GetAllClientsAsync();
        Task<Cliente> GetClientByIdAsync(int id);
        Task CreateClientAsync(Cliente cliente);
        Task UpdateClientAsync(Cliente cliente);
        Task DeleteClientAsync(int id);
    }
}
