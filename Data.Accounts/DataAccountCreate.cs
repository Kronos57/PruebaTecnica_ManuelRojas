using Data.EntityFramework.Entities;
using Services;
using System.Transactions;
using Transversal.Entities.DTO;
using Transversal.Strategy;
using static Transversal.Entities.ConstantMessages;

namespace Data.Accounts
{
    public class DataAccountCreate : DataStrategy
    {
        private AccountDTO accountDTO;
        public DataAccountCreate(AccountDTO accountDTO)
        {
            this.accountDTO = accountDTO;
        }

        protected override void Process()
        {
            using (var scope = new TransactionScope())//Nueva transacción
            {
                using (var context = new ApiRestDbManuelRojasContext())
                {
                    AccountRepositoryService accountRepository = new AccountRepositoryService(context);

                    Cuenta entityCuenta = new Cuenta
                    {
                        IdCuenta = accountDTO.IdCuenta,
                        IdCliente = accountDTO.IdCliente,
                        NumeroCuenta = accountDTO.NumeroCuenta,
                        IdTipoCuenta = accountDTO.IdTipoCuenta,
                        SaldoInicial = accountDTO.SaldoInicial,
                        Estado = accountDTO.Estado
                    };

                    accountRepository.Add(entityCuenta);
                    SetResponseResult(ACCOUNT_MESSAGES.CUENTA_CREADA);
                }

                scope.Complete();
            }
        }
    }
}
