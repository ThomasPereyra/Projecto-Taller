using System;
using System.Collections.Generic;

namespace TallerAPI.Models;

public partial class Marca
{
    public int IdMarca { get; set; }

    public string Marca1 { get; set; } = null!;

    public virtual ICollection<Modelo> Modelos { get; set; } = new List<Modelo>();
}
