namespace Transversal.Entities.Reports.AccountStatus
{
    public class AccountStatusRequest
    {
        public int IdCliente { get; set; }

        public DateTime FechaInicial { get; set; }

        public DateTime FechaFinal { get; set; }


        public AccountStatusRequest() { }

        public AccountStatusRequest(int idCliente, DateTime fechaInicial, DateTime fechaFinal)
        {
            IdCliente = idCliente;
            FechaInicial = fechaInicial;
            FechaFinal = fechaFinal;
        }
    }
}
