namespace Transversal.Entities.DTO
{
    public class ClientSearchDTO : PersonSearchDTO
    {
        public int IdCliente { get; set; }

        public string? Contrasenia { get; set; }

        public string? NombreEstado { get; set; }

        public ClientSearchDTO()
        {

        }

        public ClientSearchDTO(int idCliente)
        {
            IdCliente = idCliente;
        }

        public ClientSearchDTO(int idCliente, string contrasenia, string nombreEstado)
        {
            IdCliente = idCliente;
            Contrasenia = contrasenia;
            NombreEstado = nombreEstado;
        }

        public ClientSearchDTO(int idCliente, string contrasenia, string nombreEstado, int idPersona, string nombre, 
            string nombreTipoIdentificacion, string identificacion, string nombreGenero, string edad, string direccion, string telefono)
        {
            IdCliente = idCliente;
            Contrasenia = contrasenia;
            NombreEstado = nombreEstado;

            IdPersona = idPersona;
            Nombre = nombre;
            NombreTipoIdentificacion = nombreTipoIdentificacion;
            Identificacion = identificacion;
            NombreGenero = nombreGenero;
            Edad = edad;
            Direccion= direccion;
            Telefono= telefono;
        }
    }
}
