using System;
using System.Collections.Generic;

namespace Data.EntityFramework.Entities;

public partial class Cliente
{
    public int IdCliente { get; set; }

    public int IdPersona { get; set; }

    public byte[] Contrasenia { get; set; } = null!;

    public bool Estado { get; set; }

    public virtual ICollection<Cuenta> Cuenta { get; } = new List<Cuenta>();

    public virtual Persona IdPersonaNavigation { get; set; } = null!;
}
