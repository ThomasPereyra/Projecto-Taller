using System;
using System.Collections.Generic;

namespace TallerAPI.Models;

public partial class CategoriasRepuesto
{
    public int IdCategoria { get; set; }

    public string Categoria { get; set; } = null!;

    public virtual ICollection<Repuesto> Repuestos { get; set; } = new List<Repuesto>();
}
