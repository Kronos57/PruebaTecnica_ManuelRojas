namespace Transversal.Entities
{
    public class TransversalResponseObject
    {
        public string? Status { get; set; }

        public string? Message { get; set; }

        public DateTime Fecha { get; set; }


        public TransversalResponseObject()
        {

        }

        public TransversalResponseObject(string status, string message, DateTime fecha)
        {
            Status = status;
            Message = message;
            Fecha = fecha;
        }
    }
}
