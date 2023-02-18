namespace Transversal.Entities
{
    public class PersonaDTO
    {
        public int IdPersona { get; set; }

        public string Nombre { get; set; } = null!;

        public string? Genero { get; set; }

        public string Edad { get; set; } = null!;

        public string? Identificacion { get; set; }

        public string Direccion { get; set; } = null!;

        public string Telefono { get; set; } = null!;

        public PersonaDTO()
        {

        }

        public PersonaDTO(int idPersona)
        {
            IdPersona = idPersona;
        }

        public PersonaDTO(int idPersona, string nombre, string genero, string edad, string identificacion, string direccion, string telefono)
        {
            IdPersona = idPersona;
            Nombre = nombre;
            Genero = genero;
            Edad = edad;
            Identificacion = identificacion;
            Direccion = direccion;
            Telefono = telefono;
        }
    }
}
