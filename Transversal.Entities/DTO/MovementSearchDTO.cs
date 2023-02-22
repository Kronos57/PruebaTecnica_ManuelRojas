namespace Transversal.Entities.DTO
{
    public class MovementSearchDTO
    {
        public int IdMovimiento { get; set; }

        public int IdCuenta { get; set; }

        public string? NombreTipoMovimiento { get; set; }

        public decimal Valor { get; set; }

        public DateTime FechaMovimiento { get; set; }

        public decimal SaldoDisponible { get; set; }

        public string? NombreEstado { get; set; }


        public MovementSearchDTO()
        {

        }

        public MovementSearchDTO(int idMovimiento)
        {
            IdMovimiento = idMovimiento;
        }

        public MovementSearchDTO(int idMovimiento, int idCuenta, string nombreTipoMovimiento, decimal valor, 
            DateTime fechaMovimiento, decimal saldoDisponible, string nombreEstado)
        {
            IdMovimiento = idMovimiento;
            IdCuenta = idCuenta;
            NombreTipoMovimiento = nombreTipoMovimiento;
            Valor = valor;
            FechaMovimiento = fechaMovimiento;
            SaldoDisponible = saldoDisponible;
            NombreEstado = nombreEstado;
        }
    }
}
