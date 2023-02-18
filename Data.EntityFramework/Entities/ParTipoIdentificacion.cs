using System;
using System.Collections.Generic;

namespace Data.EntityFramework.Entities;

public partial class ParTipoIdentificacion
{
    public int IdTipoIdentificacion { get; set; }

    public string NombreTipoIdentificacion { get; set; } = null!;

    public bool Estado { get; set; }

    public virtual ICollection<Persona> Personas { get; } = new List<Persona>();
}
