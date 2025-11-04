using System;
using System.Collections.Generic;

namespace TallerAPI.Models;

public partial class Repuesto
{
    public int IdRepuesto { get; set; }

    public string Descripcion { get; set; } = null!;

    public int Categoria { get; set; }

    public decimal PrecioUnitario { get; set; }

    public virtual CategoriasRepuesto CategoriaNavigation { get; set; } = null!;

    public virtual ICollection<DetallesCompra> DetallesCompras { get; set; } = new List<DetallesCompra>();

    public virtual ICollection<DetallesReparacione> DetallesReparaciones { get; set; } = new List<DetallesReparacione>();

    public virtual ICollection<Stock> Stocks { get; set; } = new List<Stock>();
}
