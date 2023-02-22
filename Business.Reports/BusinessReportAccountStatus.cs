using Data.Accounts;
using Data.Clients;
using Data.Movements;
using Transversal.Entities.DTO;
using Transversal.Entities.Reports.AccountStatus;
using Transversal.Strategy;
using static Transversal.Entities.ConstantMessages;

namespace Business.Reports
{
    public class BusinessReportAccountStatus : BusinessStrategy
    {
        private AccountStatusRequest accountStatusRequest;

        public BusinessReportAccountStatus(AccountStatusRequest accountStatusRequest)
        {
            this.accountStatusRequest = accountStatusRequest;
        }

        protected override void Process()
        {
            if (accountStatusRequest != null)
            {
                if (accountStatusRequest.IdCliente == 0)
                {
                    SetValidation(VALIDATION_MESSAGES.ID_CLIENTE_OBLIGATORIO);
                }

                if (accountStatusRequest.FechaInicial == DateTime.MinValue)
                {
                    SetValidation(VALIDATION_MESSAGES.FECHA_INICIAL_OBLIGATORIA);
                }

                if (accountStatusRequest.FechaFinal == DateTime.MinValue)
                {
                    SetValidation(VALIDATION_MESSAGES.FECHA_FINAL_OBLIGATORIA);
                }

                if (accountStatusRequest.FechaInicial > accountStatusRequest.FechaFinal)
                {
                    SetValidation(VALIDATION_MESSAGES.ERROR_RANGO_FECHAS);
                }

                if (State == StateStrategy.Execution)
                {
                    //Obtener los datos del cliente
                    DataClientGetById DataClientGetById = new DataClientGetById(accountStatusRequest.IdCliente);

                    if (DataClientGetById.Execute() == StateStrategy.Success)
                    {
                        ClientSearchDTO clientSearchDTO = (ClientSearchDTO)DataClientGetById.Result;

                        if (clientSearchDTO != null)
                        {
                            DataAccountGetList dataAccountGetList = new DataAccountGetList();

                            if (dataAccountGetList.Execute() == StateStrategy.Success)
                            {
                                List<AccountSearchDTO> accounts = (List<AccountSearchDTO>)dataAccountGetList.Result;

                                //Obtener las Cuentas del Cliente consultado
                                accounts = accounts.FindAll(x => x.IdCliente == accountStatusRequest.IdCliente).ToList();

                                if (accounts.Count > 0)
                                {
                                    //Listado de Movimientos para el Reporte
                                    List<AccountStatusResponse> movementsReport = new List<AccountStatusResponse>();

                                    foreach (AccountSearchDTO account in accounts)
                                    {
                                        //Consultar los Movimientos asociados a cada cuenta del Cliente consultado
                                        DataMovementGetList dataMovementGetList = new DataMovementGetList();

                                        if (dataMovementGetList.Execute() == StateStrategy.Success)
                                        {
                                            List<MovementSearchDTO> movementsCliente = (List<MovementSearchDTO>)dataMovementGetList.Result;

                                            //Se filtran los movimientos del CLiente consultado
                                            movementsCliente = movementsCliente.FindAll(x => x.IdCuenta == account.IdCuenta);

                                            //Se filtran por rango de fechas consultadas
                                            movementsCliente = movementsCliente.Where(x => x.FechaMovimiento.Date >= accountStatusRequest.FechaInicial.Date
                                            && x.FechaMovimiento.Date <= accountStatusRequest.FechaFinal.Date).ToList();

                                            if (movementsCliente.Count > 0)
                                            {
                                                foreach (MovementSearchDTO movement in movementsCliente)
                                                {
                                                    movementsReport.Add(new AccountStatusResponse(movement.FechaMovimiento, clientSearchDTO.Nombre, account.NumeroCuenta,
                                                        account.NombreTipoCuenta, account.SaldoInicial, movement.NombreEstado, movement.Valor,
                                                        movement.SaldoDisponible));
                                                }                                                
                                            }
                                        }
                                    }

                                    if (movementsReport.Count > 0)
                                    {
                                        movementsReport.OrderBy(x => x.Fecha).ThenBy(x =>x.NumeroCuenta);
                                        SetResult(movementsReport);
                                    }
                                    else
                                    {
                                        SetException(VALIDATION_MESSAGES.CUENTA_SIN_MOVIMIENTOS);
                                    }
                                }
                                else
                                {
                                    SetException(VALIDATION_MESSAGES.CLIENTE_SIN_CUENTA_ASOCIADA);
                                }
                            }
                        }
                        else
                        {
                            SetException(EXCEPTION_MESSAGES.CLIENTE_NO_EXISTE);
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
