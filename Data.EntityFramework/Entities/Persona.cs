using System;
using System.Collections.Generic;

namespace Data.EntityFramework.Entities;

public partial class Persona
{
    public int IdPersona { get; set; }

    public string Nombre { get; set; } = null!;

    public int IdTipoIdentificacion { get; set; }

    public string Identificacion { get; set; } = null!;

    public int IdGenero { get; set; }

    public string Edad { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public virtual ICollection<Cliente> Clientes { get; } = new List<Cliente>();

    public virtual ParTipoGenero IdGeneroNavigation { get; set; } = null!;

    public virtual ParTipoIdentificacion IdTipoIdentificacionNavigation { get; set; } = null!;
}
