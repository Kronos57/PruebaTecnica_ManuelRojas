namespace Transversal.Entities.DTO
{
    public class PersonSearchDTO
    {
        public int IdPersona { get; set; }

        public string Nombre { get; set; } = null!;

        public string? NombreTipoIdentificacion { get; set; }

        public string? Identificacion { get; set; }

        public string NombreGenero { get; set; } = null!;

        public string Edad { get; set; } = null!;    

        public string Direccion { get; set; } = null!;

        public string Telefono { get; set; } = null!;


        public PersonSearchDTO()
        {

        }

        public PersonSearchDTO(int idPersona)
        {
            IdPersona = idPersona;
        }

        public PersonSearchDTO(int idPersona, string nombre, string nombreTipoIdentificacion, string identificacion, 
            string nombreGenero, string edad, string direccion, string telefono)
        {
            IdPersona = idPersona;
            Nombre = nombre;
            NombreTipoIdentificacion = nombreTipoIdentificacion;
            Identificacion = identificacion;
            NombreGenero = nombreGenero;
            Edad = edad;
            Direccion = direccion;
            Telefono = telefono;
        }
    }
}
