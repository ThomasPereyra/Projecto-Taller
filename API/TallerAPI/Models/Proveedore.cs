using System;
using System.Collections.Generic;

namespace TallerAPI.Models;

public partial class Proveedore
{
    public int IdProveedor { get; set; }

    public string Descripcion { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public virtual ICollection<ComprasRepuesto> ComprasRepuestos { get; set; } = new List<ComprasRepuesto>();
}
