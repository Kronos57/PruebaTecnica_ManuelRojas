using Data.EntityFramework.Entities;
using Repository;
using Transversal.Entities.DTO;
using Transversal.Strategy;

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

                Cuenta entityCuenta = context.Cuentas.FirstOrDefault(x => x.IdCuenta == accountDTO.IdCuenta);

                if (entityCuenta != null) 
                {
                    entityCuenta.IdCliente = accountDTO.IdCliente;
                    entityCuenta.NumeroCuenta = accountDTO.NumeroCuenta;
                    entityCuenta.IdTipoCuenta = accountDTO.IdTipoCuenta;
                    entityCuenta.Saldo= accountDTO.Saldo;
                    entityCuenta.Estado = accountDTO.Estado;

                    accountRepository.Update(entityCuenta);
                    SetResponseResult("Cuenta Actualizada Correctamente");
                }
                else
                {
                    State = StateStrategy.Exception;
                }              
            }
        }
    }
}
