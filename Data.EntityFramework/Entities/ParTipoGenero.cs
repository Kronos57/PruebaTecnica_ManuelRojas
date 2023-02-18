using System;
using System.Collections.Generic;

namespace Data.EntityFramework.Entities;

public partial class ParTipoGenero
{
    public int IdGenero { get; set; }

    public string NombreTipoGenero { get; set; } = null!;

    public bool Estado { get; set; }

    public virtual ICollection<Persona> Personas { get; } = new List<Persona>();
}
