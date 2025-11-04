using System;
using System.Collections.Generic;

namespace TallerAPI.Models;

public partial class DetallesCompra
{
    public int IdDetalle { get; set; }

    public int IdCompra { get; set; }

    public int IdRepuesto { get; set; }

    public int Cantidad { get; set; }

    public decimal PrecioUnitario { get; set; }

    public virtual ComprasRepuesto IdCompraNavigation { get; set; } = null!;

    public virtual Repuesto IdRepuestoNavigation { get; set; } = null!;
}
