using Data.EntityFramework.Entities;
using Services;
using System.Transactions;
using Transversal.Strategy;
using static Transversal.Entities.ConstantMessages;

namespace Data.Clients
{
    public class DataClientDelete : DataStrategy
    {
        private int id;
        public DataClientDelete(int id)
        {
            this.id = id;
        }

        protected override void Process()
        {
            using (var scope = new TransactionScope())//Nueva transacción
            {

                using (var context = new ApiRestDbManuelRojasContext())
                {
                    ClientRepositoryService clientRepository = new ClientRepositoryService(context);

                    Cliente entityCliente = clientRepository.GetById(id);

                    if (clientRepository != null)
                    {
                        //Solo borrado lógico
                        entityCliente.Estado = false;
                        clientRepository.Update(entityCliente);

                        //Opción para borrado definitivo.
                        //clientRepository.Remove(entityCliente.IdCliente);

                        SetResponseResult(CLIENT_MESSAGES.CLIENTE_ELIMINADO);
                    }
                    else
                    {
                        SetException(EXCEPTION_MESSAGES.CLIENTE_NO_EXISTE);
                    }
                }

                scope.Complete();
            }
        }
    }
}
