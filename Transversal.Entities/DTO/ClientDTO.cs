namespace Transversal.Entities.DTO
{
    public class ClientDTO : PersonDTO
    {
        public int IdCliente { get; set; }

        public string? Contrasenia { get; set; }

        public bool Estado { get; set; }

        public ClientDTO()
        {

        }

        public ClientDTO(int idCliente)
        {
            IdCliente = idCliente;
        }

        public ClientDTO(int idCliente, string contrasenia, bool estado)
        {
            IdCliente = idCliente;
            Contrasenia = contrasenia;
            Estado = estado;
        }

        public ClientDTO(int idCliente, string contrasenia, bool estado, int idPersona, string nombre,
              int idTipoIdentificacion, string identificacion, int idGenero, string edad, string direccion, string telefono)
        {
            IdCliente = idCliente;
            Contrasenia = contrasenia;
            Estado = estado;

            IdPersona = idPersona;
            Nombre = nombre;
            IdTipoIdentificacion = idTipoIdentificacion;
            Identificacion = identificacion;
            IdGenero = idGenero;
            Edad = edad;
            Direccion = direccion;
            Telefono = telefono;
        }
    }
}
