using System;
using System.Collections.Generic;

namespace Data.EntityFramework.Entities;

public partial class ParTipoCuentum
{
    public int IdTipoCuenta { get; set; }

    public string NombreTipoCuenta { get; set; } = null!;

    public bool Estado { get; set; }

    public virtual ICollection<Cuenta> Cuenta { get; } = new List<Cuenta>();
}
