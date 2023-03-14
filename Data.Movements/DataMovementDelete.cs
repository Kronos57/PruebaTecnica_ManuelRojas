using Data.EntityFramework.Entities;
using Services;
using System.Transactions;
using Transversal.Strategy;
using static Transversal.Entities.ConstantMessages;

namespace Data.Movements
{
    public class DataMovementDelete : DataStrategy
    {
        private Int32 id;

        public DataMovementDelete(int id)
        {
            this.id = id;
        }

        protected override void Process()
        {
            using (var scope = new TransactionScope())//Nueva transacción
            {
                using (var context = new ApiRestDbManuelRojasContext())
                {
                    MovementRepositoryService movementRepository = new MovementRepositoryService(context);

                    Movimiento entityMovimiento = movementRepository.GetById(id);

                    if (entityMovimiento != null)
                    {
                        //Solo borrado lógico
                        entityMovimiento.Estado = false;
                        movementRepository.Update(entityMovimiento);

                        //Opción para borrado definitivo.
                        //movementRepository.Remove(id);
                    }
                    else
                    {
                        SetException(EXCEPTION_MESSAGES.MOVIMIENTO_NO_EXISTE);
                    }
                }

                scope.Complete();
            }
        }
    }
}
