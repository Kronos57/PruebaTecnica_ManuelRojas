using Data.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ServiceAccountRepository : IAccountRepository
    {
        private readonly ApiRestDbManuelRojasContext _dbContext;

        public ServiceAccountRepository(ApiRestDbManuelRojasContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateAccountAsync(Cuenta cuenta)
        {
            await _dbContext.Cuentas.AddAsync(cuenta);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAccountAsync(int id)
        {
            var cuenta = await _dbContext.Cuentas.FindAsync(id);
            _dbContext.Cuentas.Remove(cuenta);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Cuenta> GetAccountByIdAsync(int id)
        {
            return await _dbContext.Cuentas.FirstOrDefaultAsync(p => p.IdCuenta == id);
        }

        public async Task<IEnumerable<Cuenta>> GetAllAccountsAsync()
        {
            return await _dbContext.Cuentas.ToListAsync();
        }

        public async Task UpdateAccountAsync(Cuenta cuenta)
        {
            _dbContext.Cuentas.Update(cuenta);
            await _dbContext.SaveChangesAsync();
        }
    }
}
