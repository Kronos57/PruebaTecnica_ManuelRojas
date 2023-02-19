using Data.EntityFramework.Entities;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ServiceMovementRepository : IMovementRepository
    {
        public Task CreateMovementAsync(Movimiento movimiento)
        {
            throw new NotImplementedException();
        }

        public Task DeleteMovementAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Movimiento>> GetAllMovementsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Movimiento> GetMovementByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateMovementAsync(Movimiento movimiento)
        {
            throw new NotImplementedException();
        }
    }
}
