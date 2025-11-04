using System;
using System.Collections.Generic;

namespace TallerAPI.Models;

public partial class Vehiculo
{
    public int IdVehiculo { get; set; }

    public int IdCliente { get; set; }

    public string? Patente { get; set; }

    public int IdModelo { get; set; }

    public virtual Cliente IdClienteNavigation { get; set; } = null!;

    public virtual Modelo IdModeloNavigation { get; set; } = null!;

    public virtual ICollection<Reparacione> Reparaciones { get; set; } = new List<Reparacione>();
}
