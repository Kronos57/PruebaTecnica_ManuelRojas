using Data.EntityFramework.Entities;
using Repository;
using Transversal.Entities.DTO;
using Transversal.Strategy;

namespace Data.Movements
{
    public class DataMovementCreate : DataStrategy
    {
        private MovementDTO movementDTO;
        public DataMovementCreate(MovementDTO movementDTO)
        {
            this.movementDTO = movementDTO;
        }

        protected override void Process()
        {
            using (var context = new ApiRestDbManuelRojasContext())
            {
                MovementRepository movementRepository = new MovementRepository(context);

                Movimiento entityMovimiento = new Movimiento
                {
                    IdMovimiento = movementDTO.IdMovimiento,
                    IdCuenta = movementDTO.IdCuenta,
                    IdTipoMovimiento = movementDTO.IdTipoMovimiento,
                    Valor = movementDTO.Valor,
                    FechaMovimiento = movementDTO.FechaMovimiento,
                    SaldoDisponible = movementDTO.SaldoDisponible,
                    Estado = movementDTO.Estado
                };

                movementRepository.Add(entityMovimiento);               
            }
        }
    }
}
