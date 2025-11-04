using System;
using System.Collections.Generic;

namespace TallerAPI.Models;

public partial class Barrio
{
    public int IdBarrio { get; set; }

    public int IdCiudad { get; set; }

    public string Barrio1 { get; set; } = null!;

    public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();

    public virtual Ciudade IdCiudadNavigation { get; set; } = null!;

    public virtual ICollection<Sucursale> Sucursales { get; set; } = new List<Sucursale>();
}
