using Data.EntityFramework.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ClientRepository : IRepository<Cliente>
    {
        private readonly ApiRestDbManuelRojasContext _dbContext;

        public ClientRepository(ApiRestDbManuelRojasContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Cliente entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Cliente> GetAll()
        {
            throw new NotImplementedException();
        }

        public Cliente GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Cliente entity)
        {
            throw new NotImplementedException();
        }
    }
}
