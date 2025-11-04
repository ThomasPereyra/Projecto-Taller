using System;
using System.Collections.Generic;

namespace TallerAPI.Models;

public partial class Provincia
{
    public int IdProvincia { get; set; }

    public string Provincia1 { get; set; } = null!;

    public virtual ICollection<Ciudade> Ciudades { get; set; } = new List<Ciudade>();
}
