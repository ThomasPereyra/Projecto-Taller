using System;
using System.Collections.Generic;

namespace TallerAPI.Models;

public partial class DetallesReparacione
{
    public int IdDetalle { get; set; }

    public int IdReparacion { get; set; }

    public int IdRepuesto { get; set; }

    public int Cantidad { get; set; }

    public decimal PrecioUnitario { get; set; }

    public virtual Reparacione IdReparacionNavigation { get; set; } = null!;

    public virtual Repuesto IdRepuestoNavigation { get; set; } = null!;
}
