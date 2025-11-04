using System;
using System.Collections.Generic;

namespace TallerAPI.Models;

public partial class Sucursale
{
    public int IdSucursal { get; set; }

    public int Direccion { get; set; }

    public string Telefono { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public string Email { get; set; } = null!;

    public virtual ICollection<ComprasRepuesto> ComprasRepuestos { get; set; } = new List<ComprasRepuesto>();

    public virtual Barrio DireccionNavigation { get; set; } = null!;

    public virtual ICollection<Reparacione> Reparaciones { get; set; } = new List<Reparacione>();

    public virtual ICollection<Stock> Stocks { get; set; } = new List<Stock>();
}
