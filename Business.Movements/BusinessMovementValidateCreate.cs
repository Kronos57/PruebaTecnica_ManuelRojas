using Data.Accounts;
using Data.Movements;
using System.Transactions;
using Transversal.Entities;
using Transversal.Entities.DTO;
using Transversal.Strategy;
using static Transversal.Entities.ConstantMessages;

namespace Business.Movements
{
    public class BusinessMovementValidateCreate : BusinessStrategy
    {
        private MovementDTO movementDTO;

        public BusinessMovementValidateCreate(MovementDTO movementDTO)
        {
            this.movementDTO = movementDTO;
        }

        protected override void Process()
        {
            using (var scope = new TransactionScope())//Nueva transacción
            {
                if (movementDTO != null)
                {
                    if (State == StateStrategy.Execution)
                    {
                        if (ValidarCuenta(movementDTO.IdCuenta))
                        {
                            if (State == StateStrategy.Execution)
                            {
                                decimal saldoActual = ObtenerSaldoActual();

                                //Se valida si el saldo de la cuenta es cero
                                if (!ValidarSaldoCero(saldoActual))
                                {
                                    if (State == StateStrategy.Execution)
                                    {
                                        //Se valida el Cupo Diario de movimientos
                                        if (!ValidarCupoDiario(movementDTO.IdCuenta))
                                        {
                                            if (State == StateStrategy.Execution)
                                            {
                                                //Se procesa el movimiento
                                                ProcesarMovimiento(movementDTO.IdTipoMovimiento, movementDTO.Valor, saldoActual);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    SetValidation(VALIDATION_MESSAGES.ERROR_MODELO_DATOS);
                }

                scope.Complete();
            }
        }

        /// <summary>
        /// Método que consulta si la cuenta existe y esta activa
        /// </summary>
        /// <returns></returns>
        public bool ValidarCuenta(int idCuenta)
        {
            //Obtener la información de la Cuenta
            bool cuentaActiva = false;
            DataAccountGetById dataAccountGetById = new DataAccountGetById(idCuenta);

            if (dataAccountGetById.Execute() == StateStrategy.Success)
            {
                AccountSearchDTO accountSearchDTO = (AccountSearchDTO)dataAccountGetById.Result;

                if (accountSearchDTO != null)
                {
                    if (accountSearchDTO.NombreEstado.Equals(Enum.GetName(typeof(StateEnum), 1)))
                    {
                        cuentaActiva = true;
                    }
                    else
                    {
                        SetException(EXCEPTION_MESSAGES.CUENTA_INACTIVA);
                    }
                }
                else
                {
                    SetException(EXCEPTION_MESSAGES.CUENTA_NO_EXISTE);
                }
            }

            return cuentaActiva;
        }

        /// <summary>
        /// Método que valida si el saldo de la cuenta esta en Cero
        /// </summary>
        /// <param name="saldoActual"></param>
        /// <returns></returns>
        private bool ValidarSaldoCero(decimal saldoActual)
        {
            bool saldoCero = false;

            //Se valida Saldo en Cero
            if (saldoActual <= 0)
            {
                saldoCero = true;
                SetValidation(VALIDATION_MESSAGES.SALDO_CERO);
            }

            return saldoCero;
        }

        /// <summary>
        /// Método que obtiene el saldo actual de la cuenta
        /// </summary>
        /// <returns></returns>
        public decimal ObtenerSaldoActual()
        {
            decimal saldoActual = 0;
            DataMovementGetList dataMovementGetList = new DataMovementGetList();

            if (dataMovementGetList.Execute() == StateStrategy.Success)
            {
                List<MovementSearchDTO> movementsCliente = (List<MovementSearchDTO>)dataMovementGetList.Result;

                //Filtrar los movimientos de la Cuenta consultada
                movementsCliente = movementsCliente.FindAll(x => x.IdCuenta == movementDTO.IdCuenta);

                saldoActual = movementsCliente.OrderByDescending(x => x.IdMovimiento).First().SaldoDisponible;
            }
            else
            {
                SetException(EXCEPTION_MESSAGES.SALDO_NO_DISPONIBLE);
            }

            return saldoActual;
        }

        /// <summary>
        /// Método que procesa el movimiento y guarda el registro en base de datos
        /// </summary>
        /// <returns></returns>
        public void ProcesarMovimiento(int tipoMovimiento, decimal valor, decimal saldoActual)
        {
            decimal nuevoSaldoDisponible = 0;

            //Validar si el movimiento es Débito o Crédito
            //Retiro
            if (tipoMovimiento == Convert.ToInt32(MovementTypeEnum.Debito))
            {
                //Se valida si el saldo es suficiente
                if (saldoActual >= valor)
                {
                    //Se recalcula el Saldo Disponible 
                    nuevoSaldoDisponible = saldoActual - valor;
                }
                else
                {
                    SetException(VALIDATION_MESSAGES.SALDO_INSUFICIENTE);
                }
            }
            //Consignación
            else if (tipoMovimiento == Convert.ToInt32(MovementTypeEnum.Credito))
            {
                //Se recalcula el Saldo Disponible 
                nuevoSaldoDisponible = saldoActual + valor;
            }

            //Se registra el Movimiento
            RegistrarMovimiento(nuevoSaldoDisponible);
        }

        /// <summary>
        /// Método que guarda el registro de un movimiento actualizando el saldo de la cuenta
        /// </summary>
        /// <param name="nuevoSaldo"></param>
        private void RegistrarMovimiento(decimal nuevoSaldo)
        {
            if (State == StateStrategy.Execution)
            {
                //Se asigna el nuevo valor del Saldo Disponible
                movementDTO.SaldoDisponible = nuevoSaldo;

                DataMovementCreate dataMovementCreate = new DataMovementCreate(movementDTO);

                //Se registra el nuevo Movimiento
                if (dataMovementCreate.Execute() == StateStrategy.Success)
                {
                    SetResponseResult(MOVEMENT_MESSAGES.MOVIMIENTO_CREADO);
                }
            }
        }

        /// <summary>
        /// Método que retorna si se execede el cupo diario de movimientos
        /// </summary>
        /// <param name="idCuenta"></param>
        /// <returns></returns>
        public bool ValidarCupoDiario(int idCuenta)
        {
            bool excedeCupoDiario = false;
            decimal cupoDiario = Convert.ToDecimal("700000");//Ejemplo Cupo Diario
            decimal movimientosDia = ConsultarMovimientosDia(idCuenta);
            decimal movimientoTotal = movimientosDia + movementDTO.Valor;

            if (movimientoTotal > cupoDiario)
            {
                excedeCupoDiario = true;
                SetValidation(VALIDATION_MESSAGES.CUPO_DIARIO_SUPERADO);
            }

            return excedeCupoDiario;
        }

        /// <summary>
        /// Método que retorna el valor total de los movimientos realizados en una cuenta en el día actual
        /// </summary>
        /// <param name="idCuenta"></param>
        /// <returns></returns>
        public decimal ConsultarMovimientosDia(int idCuenta)
        {
            decimal valorMovimientosDia = 0;
            DateTime fechaHoy = DateTime.Today;

            DataMovementGetList dataMovementGetList = new DataMovementGetList();

            if (dataMovementGetList.Execute() == StateStrategy.Success)
            {
                List<MovementSearchDTO> movementsCliente = (List<MovementSearchDTO>)dataMovementGetList.Result;

                //Se consultan los movimientos realizados en la cuenta para el día actual
                movementsCliente = movementsCliente.FindAll(x => x.IdCuenta == idCuenta);
                movementsCliente = movementsCliente.Where(x => x.FechaMovimiento.Date == fechaHoy.Date).ToList();

                if (movementsCliente.Any())
                {
                    foreach (var movement in movementsCliente)
                    {
                        valorMovimientosDia += movement.Valor;
                    }
                }
            }

            return valorMovimientosDia;
        }
    }
}
