using Data.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using Repository;

namespace Services
{
    public class ClientRepositoryService : IClientRepository
    {
        private readonly ApiRestDbManuelRojasContext _dbContext;

        public ClientRepositoryService(ApiRestDbManuelRojasContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Cliente entity)
        {
            _dbContext.Entry(entity).State = EntityState.Added;
            _dbContext.Clientes.Add(entity);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Cliente> GetAll()
        {
            return _dbContext.Clientes.ToList();
        }

        public Cliente GetById(int id)
        {
            return _dbContext.Clientes.Find(id);
        }

        public void Remove(int id)
        {
            Cliente? cliente = _dbContext.Clientes.Find(id);

            if (cliente != null)
            {
                _dbContext.Entry(cliente).State = EntityState.Deleted;
                _dbContext.Clientes.Remove(cliente);
                _dbContext.SaveChanges();
            }
        }

        public void Update(Cliente entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.Clientes.Update(entity);
            _dbContext.SaveChanges();
        }
    }
}
