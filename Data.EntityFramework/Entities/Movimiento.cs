using System;
using System.Collections.Generic;

namespace Data.EntityFramework.Entities;

public partial class Movimiento
{
    public int IdMovimiento { get; set; }

    public int IdCuenta { get; set; }

    public int IdTipoMovimiento { get; set; }

    public decimal Valor { get; set; }

    public DateTime FechaMovimiento { get; set; }

    public decimal Saldo { get; set; }

    public bool Estado { get; set; }

    public virtual Cuenta IdCuentaNavigation { get; set; } = null!;

    public virtual ParTipoMovimiento IdTipoMovimientoNavigation { get; set; } = null!;
}
