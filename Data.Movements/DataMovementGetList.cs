using Business.Transversal;
using Data.EntityFramework.Entities;
using Repository;
using Transversal.Entities.DTO;
using Transversal.Strategy;

namespace Data.Movements
{
    public class DataMovementGetList : DataStrategy
    {
        public DataMovementGetList() { }

        protected override void Process()
        {
            List<MovementSearchDTO> movements = new List<MovementSearchDTO>();
            BusinessUtilsTransversal utils = new BusinessUtilsTransversal();

            using (var context = new ApiRestDbManuelRojasContext())
            {
                MovementRepository movementRepository = new MovementRepository(context);

                IEnumerable<Movimiento> entityMovimientos = movementRepository.GetAll();

                foreach (Movimiento entityMovimiento in entityMovimientos)
                {
                    movements.Add(new MovementSearchDTO(entityMovimiento.IdMovimiento, entityMovimiento.IdCuenta,
                        utils.GetTipoDeMovimiento(entityMovimiento.IdTipoMovimiento), entityMovimiento.Valor, entityMovimiento.FechaMovimiento,
                        entityMovimiento.SaldoDisponible, utils.GetEstado(entityMovimiento.Estado)));
                }
            }

            SetResult(movements);
        }
    }
}
