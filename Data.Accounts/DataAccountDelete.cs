using Data.EntityFramework.Entities;
using Services;
using System.Transactions;
using Transversal.Strategy;
using static Transversal.Entities.ConstantMessages;

namespace Data.Accounts
{
    public  class DataAccountDelete : DataStrategy
    {
        private Int32 id;

        public DataAccountDelete(int id)
        {
            this.id = id;
        }

        protected override void Process()
        {
            using (var scope = new TransactionScope())//Nueva transacción
            {
                using (var context = new ApiRestDbManuelRojasContext())
                {
                    AccountRepositoryService accountRepository = new AccountRepositoryService(context);

                    Cuenta entityCuenta = accountRepository.GetById(id);

                    if (entityCuenta != null)
                    {
                        //Solo borrado lógico
                        entityCuenta.Estado = false;
                        accountRepository.Update(entityCuenta);

                        //Opción para borrado definitivo.
                        //accountRepository.Remove(id);

                        SetResponseResult(ACCOUNT_MESSAGES.CUENTA_ELIMINADA);
                    }
                    else
                    {
                        SetException(EXCEPTION_MESSAGES.CUENTA_NO_EXISTE);
                    }
                }

                scope.Complete();
            }
        }
    }
}
