using System;
using System.Collections.Generic;

namespace Data.EntityFramework.Entities;

public partial class ParTipoMovimiento
{
    public int IdTipoMovimiento { get; set; }

    public string NombreTipoMovimiento { get; set; } = null!;

    public bool Estado { get; set; }

    public virtual ICollection<Movimiento> Movimientos { get; } = new List<Movimiento>();
}
