using Business.Transversal;
using Data.EntityFramework.Entities;
using Services;
using Transversal.Entities.DTO;
using Transversal.Strategy;
using static Transversal.Entities.ConstantMessages;

namespace Data.Movements
{
    public class DataMovementGetById : DataStrategy
    {
        private int id;

        public DataMovementGetById(int id)
        {
            this.id = id;
        }

        protected override void Process()
        {
            BusinessUtilsTransversal utils = new BusinessUtilsTransversal();

            using (var context = new ApiRestDbManuelRojasContext())
            {
                MovementRepositoryService movementRepository = new MovementRepositoryService(context);

                Movimiento entityMovimiento = movementRepository.GetById(id);

                if (entityMovimiento != null)
                {
                    SetResult(new MovementSearchDTO(entityMovimiento.IdMovimiento, entityMovimiento.IdCuenta,
                        utils.GetTipoDeMovimiento(entityMovimiento.IdTipoMovimiento), entityMovimiento.Valor, entityMovimiento.FechaMovimiento,
                        entityMovimiento.SaldoDisponible, utils.GetEstado(entityMovimiento.Estado)));
                }
                else
                {
                    SetException(EXCEPTION_MESSAGES.MOVIMIENTO_NO_EXISTE);
                }
            }
        }
    }
}
