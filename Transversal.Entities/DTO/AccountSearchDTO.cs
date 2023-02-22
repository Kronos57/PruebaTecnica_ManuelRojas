namespace Transversal.Entities.DTO
{
    public class AccountSearchDTO
    {
        public int IdCuenta { get; set; }

        public int IdCliente { get; set; }

        public string NumeroCuenta { get; set; } = null!;

        public string? NombreTipoCuenta { get; set; }

        public decimal SaldoInicial { get; set; }

        public string? NombreEstado { get; set; }

        public AccountSearchDTO()
        {

        }

        public AccountSearchDTO(int idCuenta)
        {
            IdCuenta = idCuenta;
        }
        public AccountSearchDTO(decimal saldoDisponible)
        {
            SaldoInicial = saldoDisponible;
        }

        public AccountSearchDTO(int idCuenta, decimal saldo)
        {
            IdCuenta = idCuenta;
            SaldoInicial = saldo;
        }

        public AccountSearchDTO(int idCuenta, int idCliente, string numeroCuenta, string nombreTipoCuenta, decimal saldoInicial, string nombreEstado)
        {
            IdCuenta = idCuenta;
            IdCliente = idCliente;
            NumeroCuenta = numeroCuenta;
            NombreTipoCuenta = nombreTipoCuenta;
            SaldoInicial = saldoInicial;
            NombreEstado = nombreEstado;
        }
    }
}
