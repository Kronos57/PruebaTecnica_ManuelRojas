using Business.Transversal;
using Data.EntityFramework.Entities;
using Services;
using Transversal.Entities.DTO;
using Transversal.Strategy;

namespace Data.Accounts
{
    public class DataAccountGetList : DataStrategy
    {
        public DataAccountGetList() { }

        protected override void Process()
        {
            List<AccountSearchDTO> accounts = new List<AccountSearchDTO>();
            BusinessUtilsTransversal utils = new BusinessUtilsTransversal();

            using (var context = new ApiRestDbManuelRojasContext())
            {
                AccountRepositoryService accountRepository = new AccountRepositoryService(context);

                IEnumerable<Cuenta> entityAccounts = accountRepository.GetAll();

                foreach (Cuenta entityAccount in entityAccounts)
                {
                    accounts.Add(new AccountSearchDTO(entityAccount.IdCuenta, entityAccount.IdCliente, entityAccount.NumeroCuenta,
                        utils.GetTipoDeCuenta(entityAccount.IdTipoCuenta), entityAccount.SaldoInicial, utils.GetEstado(entityAccount.Estado)));
                }
            }

            SetResult(accounts);
        }
    }
}
