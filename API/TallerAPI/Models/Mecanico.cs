using System;
using System.Collections.Generic;

namespace TallerAPI.Models;

public partial class Mecanico
{
    public int IdMecanico { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public DateOnly FechaNacimiento { get; set; }

    public string Dni { get; set; } = null!;

    public virtual ICollection<Reparacione> Reparaciones { get; set; } = new List<Reparacione>();
}
