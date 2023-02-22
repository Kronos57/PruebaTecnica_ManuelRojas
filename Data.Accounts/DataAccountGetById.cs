using Business.Transversal;
using Data.EntityFramework.Entities;
using Repository;
using Transversal.Entities.DTO;
using Transversal.Strategy;
using static Transversal.Entities.ConstantMessages;

namespace Data.Accounts
{
    public class DataAccountGetById : DataStrategy
    {
        private int id;

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

                Cuenta entityCuenta = accountRepository.GetById(id);

                if (entityCuenta != null)
                {
                    SetResult(new AccountSearchDTO(entityCuenta.IdCuenta, entityCuenta.IdCliente, entityCuenta.NumeroCuenta,
                        utils.GetTipoDeCuenta(entityCuenta.IdTipoCuenta), entityCuenta.SaldoInicial, utils.GetEstado(entityCuenta.Estado)));
                }
                else
                {
                    SetException(EXCEPTION_MESSAGES.CUENTA_NO_EXISTE);
                }
            }
        }
    }
}
