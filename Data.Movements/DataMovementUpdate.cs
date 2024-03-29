﻿using Data.EntityFramework.Entities;
using Services;
using System.Transactions;
using Transversal.Entities.DTO;
using Transversal.Strategy;
using static Transversal.Entities.ConstantMessages;

namespace Data.Movements
{
    public class DataMovementUpdate : DataStrategy
    {
        private MovementDTO movementDTO;
        public DataMovementUpdate(MovementDTO movementDTO)
        {
            this.movementDTO = movementDTO;
        }

        protected override void Process()
        {
            using (var scope = new TransactionScope())//Nueva transacción
            {
                using (var context = new ApiRestDbManuelRojasContext())
                {
                    MovementRepositoryService movementRepository = new MovementRepositoryService(context);

                    Movimiento entityMovimiento = movementRepository.GetById(movementDTO.IdMovimiento);

                    if (entityMovimiento != null)
                    {
                        entityMovimiento.IdCuenta = movementDTO.IdCuenta;
                        entityMovimiento.IdTipoMovimiento = movementDTO.IdTipoMovimiento;
                        entityMovimiento.Valor = movementDTO.Valor;
                        entityMovimiento.FechaMovimiento = movementDTO.FechaMovimiento;
                        entityMovimiento.SaldoDisponible = movementDTO.SaldoDisponible;
                        entityMovimiento.Estado = movementDTO.Estado;

                        movementRepository.Update(entityMovimiento);
                        SetResponseResult(MOVEMENT_MESSAGES.MOVIMIENTO_ACTUALIZADO);
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
