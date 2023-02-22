namespace Transversal.Entities.Reports.AccountStatus
{
    public class AccountStatusResponse
    {
        public DateTime Fecha { get; set; }

        public string? Cliente { get; set; }

        public string? NumeroCuenta { get; set; }

        public string? Tipo { get; set; }

        public decimal SaldoInicial { get; set; }

        public string? NombreEstado { get; set; }

        public decimal Movimiento { get; set; }

        public decimal SaldoDisponible { get; set; }


        public AccountStatusResponse()
        {

        }

        public AccountStatusResponse(DateTime fecha, string cliente, string numeroCuenta, string tipo, decimal saldoInicial, string nombreEstado, 
            decimal movimiento, decimal saldoDisponible)
        {
            Fecha = fecha;
            Cliente = cliente;
            NumeroCuenta = numeroCuenta;
            Tipo = tipo;
            SaldoInicial = saldoInicial;
            NombreEstado = nombreEstado;
            Movimiento = movimiento;
            SaldoDisponible = saldoDisponible;
        }
    }
}
