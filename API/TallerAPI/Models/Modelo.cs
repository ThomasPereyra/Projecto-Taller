using System;
using System.Collections.Generic;

namespace TallerAPI.Models;

public partial class Modelo
{
    public int IdModelo { get; set; }

    public int IdMarca { get; set; }

    public string Modelo1 { get; set; } = null!;

    public virtual Marca IdMarcaNavigation { get; set; } = null!;

    public virtual ICollection<Vehiculo> Vehiculos { get; set; } = new List<Vehiculo>();
}
