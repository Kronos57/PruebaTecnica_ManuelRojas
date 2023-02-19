namespace Transversal.Entities.DTO
{
    public class AccountDTO
    {
        public int IdCuenta { get; set; }

        public string NumeroCuenta { get; set; } = null!;

        public string? TipoCuenta { get; set; }

        public decimal SaldoInicial { get; set; }

        public string? Estado { get; set; }

        public AccountDTO()
        {

        }

        public AccountDTO(int idCuenta)
        {
            IdCuenta = idCuenta;
        }

        public AccountDTO(int idCuenta, string numeroCuenta, string tipoCuenta, decimal saldoInicial, string estado)
        {
            IdCuenta = idCuenta;
            NumeroCuenta = numeroCuenta;
            TipoCuenta = tipoCuenta;
            SaldoInicial = saldoInicial;
            Estado = estado;
        }
    }
}
