namespace Transversal.Entities.DTO
{
    public class AccountDTO
    {
        public int IdCuenta { get; set; }

        public int IdCliente { get; set; }

        public string NumeroCuenta { get; set; } = null!;

        public int IdTipoCuenta { get; set; }

        public decimal SaldoInicial { get; set; }


        public bool Estado { get; set; }

        public AccountDTO()
        {

        }

        public AccountDTO(int idCuenta)
        {
            IdCuenta = idCuenta;
        }

        public AccountDTO(int idCuenta, int idCliente, string numeroCuenta, int idTipoCuenta, decimal saldoInicial, bool estado)
        {
            IdCuenta = idCuenta;
            IdCliente = idCliente;
            NumeroCuenta = numeroCuenta;
            IdTipoCuenta = idTipoCuenta;
            SaldoInicial = saldoInicial;
            Estado = estado;
        }
    }
}
