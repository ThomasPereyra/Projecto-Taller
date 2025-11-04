using System;
using System.Collections.Generic;

namespace TallerAPI.Models;

public partial class Reparacione
{
    public int IdReparacion { get; set; }

    public int IdVehiculo { get; set; }

    public int IdMecanico { get; set; }

    public int IdSucursal { get; set; }

    public DateTime FechaInicio { get; set; }

    public decimal CostoReparacion { get; set; }

    public DateTime? FechaFinalizacion { get; set; }

    public int IdEstado { get; set; }

    public virtual ICollection<DetallesReparacione> DetallesReparaciones { get; set; } = new List<DetallesReparacione>();

    public virtual Estado IdEstadoNavigation { get; set; } = null!;

    public virtual Mecanico IdMecanicoNavigation { get; set; } = null!;

    public virtual Sucursale IdSucursalNavigation { get; set; } = null!;

    public virtual Vehiculo IdVehiculoNavigation { get; set; } = null!;
}
