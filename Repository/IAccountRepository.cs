using Data.EntityFramework.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IAccountRepository
    {
        Task<IEnumerable<Cuenta>> GetAllAccountsAsync();
        Task<Cuenta> GetAccountByIdAsync(int id);
        Task CreateAccountAsync(Cuenta cuenta);
        Task UpdateAccountAsync(Cuenta cuenta);
        Task DeleteAccountAsync(int id);
    }
}
