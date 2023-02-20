using Data.EntityFramework.Entities;
using Repository;
using Transversal.Strategy;

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

                accountRepository.Remove(id);
                SetResponseResult("Cuenta Eliminada Correctamente");
            }
        }
    }
}
