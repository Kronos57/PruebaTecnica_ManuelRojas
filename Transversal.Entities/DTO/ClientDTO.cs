namespace Transversal.Entities.DTO
{
    public class ClientDTO : PersonDTO
    {
        public int IdCliente { get; set; }

        public string? Contrasenia { get; set; }

        public string? Estado { get; set; }

        public ClientDTO()
        {

        }

        public ClientDTO(int idCliente)
        {
            IdCliente = idCliente;
        }

        public ClientDTO(int idCliente, string contrasenia, string estado)
        {
            IdCliente = idCliente;
            Contrasenia = contrasenia;
            Estado = estado;
        }
    }
}
