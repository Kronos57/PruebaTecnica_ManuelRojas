using Data.EntityFramework.Entities;
using Repository;
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
            using (var context = new ApiRestDbManuelRojasContext())
            {
                AccountRepository accountRepository = new AccountRepository(context);

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
        }
    }
}
