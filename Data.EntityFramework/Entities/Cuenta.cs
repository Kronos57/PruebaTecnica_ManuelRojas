using System;
using System.Collections.Generic;

namespace Data.EntityFramework.Entities;

public partial class Cuenta
{
    public int IdCuenta { get; set; }

    public int IdCliente { get; set; }

    public string NumeroCuenta { get; set; } = null!;

    public int IdTipoCuenta { get; set; }

    public decimal Saldo { get; set; }

    public bool Estado { get; set; }

    public virtual Cliente IdClienteNavigation { get; set; } = null!;

    public virtual ParTipoCuentum IdTipoCuentaNavigation { get; set; } = null!;

    public virtual ICollection<Movimiento> Movimientos { get; } = new List<Movimiento>();
}
