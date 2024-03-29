﻿namespace Transversal.Entities.DTO
{
    public class PersonDTO
    {
        public int IdPersona { get; set; }

        public string Nombre { get; set; } = null!;

        public int IdTipoIdentificacion { get; set; }

        public string? Identificacion { get; set; }

        public int IdGenero { get; set; }

        public string Edad { get; set; } = null!;

        public string Direccion { get; set; } = null!;

        public string Telefono { get; set; } = null!;

        public PersonDTO()
        {

        }

        public PersonDTO(int idPersona)
        {
            IdPersona = idPersona;
        }

        public PersonDTO(int idPersona, string nombre, int idTipoIdentificacion, int idGenero, string edad, 
            string identificacion, string direccion, string telefono)
        {
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
