namespace Transversal.Entities
{
    public class ResponseObject
    {
        public string? Status { get; set; }

        public string? Message { get; set; }

        public DateTime Fecha { get; set; }


        public ResponseObject()
        {

        }

        public ResponseObject(string status, string message, DateTime fecha)
        {
            Status = status;
            Message = message;
            Fecha = fecha;
        }
    }
}
