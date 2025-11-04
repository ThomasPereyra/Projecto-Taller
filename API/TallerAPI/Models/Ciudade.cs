using System;
using System.Collections.Generic;

namespace TallerAPI.Models;

public partial class Ciudade
{
    public int IdCiudad { get; set; }

    public int IdProvincia { get; set; }

    public string? Ciudad { get; set; }

    public virtual ICollection<Barrio> Barrios { get; set; } = new List<Barrio>();

    public virtual Provincia IdProvinciaNavigation { get; set; } = null!;
}
