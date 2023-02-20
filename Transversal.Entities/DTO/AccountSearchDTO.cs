namespace Transversal.Entities.DTO
{
    public class AccountSearchDTO
    {
        public int IdCuenta { get; set; }

        public int IdCliente { get; set; }

        public string NumeroCuenta { get; set; } = null!;

        public string? NombreTipoCuenta { get; set; }

        public decimal Saldo { get; set; }

        public string? NombreEstado { get; set; }

        public AccountSearchDTO()
        {

        }

        public AccountSearchDTO(int idCuenta)
        {
            IdCuenta = idCuenta;
        }
        public AccountSearchDTO(decimal saldo)
        {
            Saldo = saldo;
        }

        public AccountSearchDTO(int idCuenta, decimal saldo)
        {
            IdCuenta = idCuenta;
            Saldo = saldo;
        }

        public AccountSearchDTO(int idCuenta, int idCliente, string numeroCuenta, string nombreTipoCuenta, decimal saldo, string nombreEstado)
        {
            IdCuenta = idCuenta;
            IdCliente = idCliente;
            NumeroCuenta = numeroCuenta;
            NombreTipoCuenta = nombreTipoCuenta;
            Saldo = saldo;
            NombreEstado = nombreEstado;
        }
    }
}
