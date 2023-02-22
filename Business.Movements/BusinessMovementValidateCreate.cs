using Data.Accounts;
using Data.Movements;
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
            if (movementDTO != null)
            {
                if (State == StateStrategy.Execution)
                {
                    //Obtener la información de la Cuenta
                    DataAccountGetById dataAccountGetById = new DataAccountGetById(movementDTO.IdCuenta);

                    if (dataAccountGetById.Execute() == StateStrategy.Success)
                    {
                        AccountSearchDTO accountSearchDTO = (AccountSearchDTO)dataAccountGetById.Result;

                        if (accountSearchDTO != null)
                        {
                            DataMovementGetList dataMovementGetList = new DataMovementGetList();

                            if (dataMovementGetList.Execute() == StateStrategy.Success)
                            {
                                int tipoMovimiento = movementDTO.IdTipoMovimiento;
                                decimal saldoActual = 0;
                                decimal valorMovimiento = movementDTO.Valor;
                                decimal nuevoSaldoDisponible = 0;

                                List<MovementSearchDTO> movementsCliente = (List<MovementSearchDTO>)dataMovementGetList.Result;

                                //Filtrar los movimienos de la Cuenta consultada
                                movementsCliente = movementsCliente.FindAll(x => x.IdCuenta == movementDTO.IdCuenta);
                                
                                saldoActual = movementsCliente.OrderByDescending(x => x.IdMovimiento).First().SaldoDisponible;

                                //Validar si el movimiento es Débito o Crédito
                                //Retiro
                                if (tipoMovimiento == Convert.ToInt32(MovementTypeEnum.Debito))
                                {
                                    //Se valida si el saldo es suficiente
                                    if (saldoActual >= valorMovimiento)
                                    {
                                        //Se recalcula el Saldo Disponible 
                                        nuevoSaldoDisponible = saldoActual - valorMovimiento;
                                    }
                                    else
                                    {
                                        SetException(VALIDATION_MESSAGES.SALDO_NO_DISPONIBLE);
                                        return;
                                    }
                                }
                                //Consignación
                                else if (tipoMovimiento == Convert.ToInt32(MovementTypeEnum.Credito))
                                {
                                    //Se recalcula el Saldo Disponible 
                                    nuevoSaldoDisponible = saldoActual + valorMovimiento;
                                }

                                //Se asigna el nuevo valor del Saldo Disponible
                                movementDTO.SaldoDisponible = nuevoSaldoDisponible;

                                DataMovementCreate dataMovementCreate = new DataMovementCreate(movementDTO);

                                //Se registra el nuevo Movimiento
                                if (dataMovementCreate.Execute() == StateStrategy.Success)
                                {
                                    SetResponseResult(MOVEMENT_MESSAGES.MOVIMIENTO_CREADO);
                                }
                            }                            
                        }
                        else
                        {
                            SetException(EXCEPTION_MESSAGES.CUENTA_NO_EXISTE);
                        }
                    }
                }
            }
            else
            {
                SetValidation(VALIDATION_MESSAGES.ERROR_MODELO_DATOS);
            }
        }
    }
}
