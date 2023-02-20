using Business.Transversal;
using Data.EntityFramework.Entities;
using Repository;
using Transversal.Entities.DTO;
using Transversal.Strategy;

namespace Data.Accounts
{
    internal class DataAccountGetBalanceById : DataStrategy
    {
        private Int32 id;

        public DataAccountGetBalanceById(int id) 
        {
            this.id = id;
        }

        protected override void Process()
        {
            BusinessUtilsTransversal utils = new BusinessUtilsTransversal();

            using (var context = new ApiRestDbManuelRojasContext())
            {
                AccountRepository accountRepository = new AccountRepository(context);

                Cuenta entityAccount = accountRepository.GetById(id);
               
                SetResult(new AccountSearchDTO(entityAccount.Saldo));
            }
        }
    }
}
