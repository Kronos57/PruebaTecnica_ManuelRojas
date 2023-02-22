using Data.EntityFramework.Entities;
using Repository;
using Transversal.Entities.DTO;
using Transversal.Strategy;
using static Transversal.Entities.ConstantMessages;

namespace Data.Accounts
{
    public class DataAccountUpdate : DataStrategy
    {
        private AccountDTO accountDTO;
        public DataAccountUpdate(AccountDTO accountDTO)
        {
            this.accountDTO = accountDTO;
        }

        protected override void Process()
        {
            using (var context = new ApiRestDbManuelRojasContext())
            {
                AccountRepository accountRepository = new AccountRepository(context);

                Cuenta entityCuenta = accountRepository.GetById(accountDTO.IdCuenta);

                if (entityCuenta != null)
                {
                    entityCuenta.IdCliente = accountDTO.IdCliente;
                    entityCuenta.NumeroCuenta = accountDTO.NumeroCuenta;
                    entityCuenta.IdTipoCuenta = accountDTO.IdTipoCuenta;
                    entityCuenta.SaldoInicial = accountDTO.SaldoInicial;
                    entityCuenta.Estado = accountDTO.Estado;

                    accountRepository.Update(entityCuenta);
                    SetResponseResult(ACCOUNT_MESSAGES.CUENTA_ACTUALIZADA);
                }
                else
                {
                    SetException(EXCEPTION_MESSAGES.CUENTA_NO_EXISTE);
                }
            }
        }
    }
}
