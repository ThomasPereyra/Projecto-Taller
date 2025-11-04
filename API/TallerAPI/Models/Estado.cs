using System;
using System.Collections.Generic;

namespace TallerAPI.Models;

public partial class Estado
{
    public int IdEstado { get; set; }

    public string Estado1 { get; set; } = null!;

    public virtual ICollection<Reparacione> Reparaciones { get; set; } = new List<Reparacione>();
}
