using System;
using System.Collections.Generic;

namespace TallerAPI.Models;

public partial class Stock
{
    public int IdStock { get; set; }

    public int IdRepuesto { get; set; }

    public int IdSucursal { get; set; }

    public int StockActual { get; set; }

    public int StockMinimo { get; set; }

    public virtual Repuesto IdRepuestoNavigation { get; set; } = null!;

    public virtual Sucursale IdSucursalNavigation { get; set; } = null!;
}
