using System;
using System.Collections.Generic;

namespace TallerAPI.Models;

public partial class ComprasRepuesto
{
    public int IdCompra { get; set; }

    public int? IdProveedor { get; set; }

    public int IdSucursal { get; set; }

    public DateOnly FechaCompra { get; set; }

    public decimal TotalCompra { get; set; }

    public virtual ICollection<DetallesCompra> DetallesCompras { get; set; } = new List<DetallesCompra>();

    public virtual Proveedore? IdProveedorNavigation { get; set; }

    public virtual Sucursale IdSucursalNavigation { get; set; } = null!;
}
