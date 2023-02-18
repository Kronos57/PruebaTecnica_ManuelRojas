namespace Transversal.Entities
{
    public class MovimientoDTO
    {
        public int IdMovimiento { get; set; }

        public DateTime FechaMovimiento { get; set; }

        public string? TipoMovimiento { get; set; }

        public string? NumeroCuenta { get; set; }
       
        public decimal ValorMovimiento { get; set; }
        
        public decimal SaldoCuenta { get; set; }

        public MovimientoDTO()
        {

        }

        public MovimientoDTO(int idMovimiento)
        {
            IdMovimiento = idMovimiento;
        }

        public MovimientoDTO(int idMovimiento, DateTime fechaMovimiento, string tipoMovimiento, string numeroCuenta, decimal valorMovimiento, decimal saldoCuenta)
        {
            IdMovimiento = idMovimiento;
            FechaMovimiento = fechaMovimiento;
            TipoMovimiento = tipoMovimiento;
            NumeroCuenta = numeroCuenta;
            ValorMovimiento = valorMovimiento;
            SaldoCuenta = saldoCuenta;
        }
    }
}
