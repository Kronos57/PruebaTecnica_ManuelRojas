using Business.Transversal;
using Data.EntityFramework.Entities;
using Repository;
using Transversal.Entities.DTO;
using Transversal.Strategy;

namespace Data.Accounts
{
    public class DataAccountGetById : DataStrategy
    {
        private Int32 id;

        public DataAccountGetById(int id)
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

                SetResult(new AccountSearchDTO(entityAccount.IdCuenta, entityAccount.IdCliente, entityAccount.NumeroCuenta,
                        utils.GetTipoDeCuenta(entityAccount.IdTipoCuenta), entityAccount.Saldo,
                        utils.GetEstado(entityAccount.Estado)));
            }
        }
    }
}
