using System;
using System.Collections.Generic;

namespace TallerAPI.Models;

public partial class Cliente
{
    public int IdCliente { get; set; }

    public int? IdBarrio { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Dni { get; set; } = null!;

    public DateOnly? FechaNacimiento { get; set; }

    public virtual Barrio? IdBarrioNavigation { get; set; }

    public virtual ICollection<Vehiculo> Vehiculos { get; set; } = new List<Vehiculo>();
}
