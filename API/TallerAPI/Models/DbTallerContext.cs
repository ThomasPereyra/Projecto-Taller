using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TallerAPI.Models;

public partial class DbTallerContext : DbContext
{
    public DbTallerContext()
    {
    }

    public DbTallerContext(DbContextOptions<DbTallerContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Barrio> Barrios { get; set; }

    public virtual DbSet<CategoriasRepuesto> CategoriasRepuestos { get; set; }

    public virtual DbSet<Ciudade> Ciudades { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<ComprasRepuesto> ComprasRepuestos { get; set; }

    public virtual DbSet<DetallesCompra> DetallesCompras { get; set; }

    public virtual DbSet<DetallesReparacione> DetallesReparaciones { get; set; }

    public virtual DbSet<Estado> Estados { get; set; }

    public virtual DbSet<Marca> Marcas { get; set; }

    public virtual DbSet<Mecanico> Mecanicos { get; set; }

    public virtual DbSet<Modelo> Modelos { get; set; }

    public virtual DbSet<Proveedore> Proveedores { get; set; }

    public virtual DbSet<Provincia> Provincias { get; set; }

    public virtual DbSet<Reparacione> Reparaciones { get; set; }

    public virtual DbSet<Repuesto> Repuestos { get; set; }

    public virtual DbSet<Stock> Stocks { get; set; }

    public virtual DbSet<Sucursale> Sucursales { get; set; }

    public virtual DbSet<Vehiculo> Vehiculos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Barrio>(entity =>
        {
            entity.HasKey(e => e.IdBarrio).HasName("pk_barrios");

            entity.ToTable("barrios");

            entity.Property(e => e.IdBarrio).HasColumnName("id_barrio");
            entity.Property(e => e.Barrio1)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("barrio");
            entity.Property(e => e.IdCiudad).HasColumnName("id_ciudad");

            entity.HasOne(d => d.IdCiudadNavigation).WithMany(p => p.Barrios)
                .HasForeignKey(d => d.IdCiudad)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_barriso_ciudades");
        });

        modelBuilder.Entity<CategoriasRepuesto>(entity =>
        {
            entity.HasKey(e => e.IdCategoria).HasName("pk_categorias");

            entity.ToTable("categorias_repuestos");

            entity.Property(e => e.IdCategoria).HasColumnName("id_categoria");
            entity.Property(e => e.Categoria)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("categoria");
        });

        modelBuilder.Entity<Ciudade>(entity =>
        {
            entity.HasKey(e => e.IdCiudad).HasName("pk_ciudades");

            entity.ToTable("ciudades");

            entity.Property(e => e.IdCiudad).HasColumnName("id_ciudad");
            entity.Property(e => e.Ciudad)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("ciudad");
            entity.Property(e => e.IdProvincia).HasColumnName("id_provincia");

            entity.HasOne(d => d.IdProvinciaNavigation).WithMany(p => p.Ciudades)
                .HasForeignKey(d => d.IdProvincia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_ciudad_provincias");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("pk_clientes");

            entity.ToTable("clientes");

            entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
            entity.Property(e => e.Apellido)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("apellido");
            entity.Property(e => e.Dni)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("dni");
            entity.Property(e => e.FechaNacimiento).HasColumnName("fecha_nacimiento");
            entity.Property(e => e.IdBarrio).HasColumnName("id_barrio");
            entity.Property(e => e.Nombre)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("nombre");

            entity.HasOne(d => d.IdBarrioNavigation).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.IdBarrio)
                .HasConstraintName("fk_clientes_barrios");
        });

        modelBuilder.Entity<ComprasRepuesto>(entity =>
        {
            entity.HasKey(e => e.IdCompra).HasName("pk_compras");

            entity.ToTable("compras_repuestos");

            entity.Property(e => e.IdCompra).HasColumnName("id_compra");
            entity.Property(e => e.FechaCompra).HasColumnName("fecha_compra");
            entity.Property(e => e.IdProveedor).HasColumnName("id_proveedor");
            entity.Property(e => e.IdSucursal).HasColumnName("id_sucursal");
            entity.Property(e => e.TotalCompra)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("total_compra");

            entity.HasOne(d => d.IdProveedorNavigation).WithMany(p => p.ComprasRepuestos)
                .HasForeignKey(d => d.IdProveedor)
                .HasConstraintName("fk_compras_proveedores");

            entity.HasOne(d => d.IdSucursalNavigation).WithMany(p => p.ComprasRepuestos)
                .HasForeignKey(d => d.IdSucursal)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_compras_sucursales");
        });

        modelBuilder.Entity<DetallesCompra>(entity =>
        {
            entity.HasKey(e => e.IdDetalle).HasName("pk_detalle_com");

            entity.ToTable("detalles_compras");

            entity.Property(e => e.IdDetalle).HasColumnName("id_detalle");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.IdCompra).HasColumnName("id_compra");
            entity.Property(e => e.IdRepuesto).HasColumnName("id_repuesto");
            entity.Property(e => e.PrecioUnitario)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("precio_unitario");

            entity.HasOne(d => d.IdCompraNavigation).WithMany(p => p.DetallesCompras)
                .HasForeignKey(d => d.IdCompra)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_detalle_compras");

            entity.HasOne(d => d.IdRepuestoNavigation).WithMany(p => p.DetallesCompras)
                .HasForeignKey(d => d.IdRepuesto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_detalle_compras_repuestos");
        });

        modelBuilder.Entity<DetallesReparacione>(entity =>
        {
            entity.HasKey(e => e.IdDetalle).HasName("pk_detalles_rep");

            entity.ToTable("detalles_reparaciones");

            entity.Property(e => e.IdDetalle).HasColumnName("id_detalle");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.IdReparacion).HasColumnName("id_reparacion");
            entity.Property(e => e.IdRepuesto).HasColumnName("id_repuesto");
            entity.Property(e => e.PrecioUnitario)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("precio_unitario");

            entity.HasOne(d => d.IdReparacionNavigation).WithMany(p => p.DetallesReparaciones)
                .HasForeignKey(d => d.IdReparacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_detalles_reparacion");

            entity.HasOne(d => d.IdRepuestoNavigation).WithMany(p => p.DetallesReparaciones)
                .HasForeignKey(d => d.IdRepuesto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_detalles_reparacion_repuestos");
        });

        modelBuilder.Entity<Estado>(entity =>
        {
            entity.HasKey(e => e.IdEstado).HasName("pk_estados");

            entity.ToTable("estados");

            entity.Property(e => e.IdEstado).HasColumnName("id_estado");
            entity.Property(e => e.Estado1)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("estado");
        });

        modelBuilder.Entity<Marca>(entity =>
        {
            entity.HasKey(e => e.IdMarca).HasName("pk_marcas");

            entity.ToTable("marcas");

            entity.Property(e => e.IdMarca).HasColumnName("id_marca");
            entity.Property(e => e.Marca1)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("marca");
        });

        modelBuilder.Entity<Mecanico>(entity =>
        {
            entity.HasKey(e => e.IdMecanico).HasName("pk_mecanicos");

            entity.ToTable("mecanicos");

            entity.Property(e => e.IdMecanico).HasColumnName("id_mecanico");
            entity.Property(e => e.Apellido)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("apellido");
            entity.Property(e => e.Dni)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("dni");
            entity.Property(e => e.FechaNacimiento).HasColumnName("fecha_nacimiento");
            entity.Property(e => e.Nombre)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Modelo>(entity =>
        {
            entity.HasKey(e => e.IdModelo).HasName("pk_modelos");

            entity.ToTable("modelos");

            entity.Property(e => e.IdModelo).HasColumnName("id_modelo");
            entity.Property(e => e.IdMarca).HasColumnName("id_marca");
            entity.Property(e => e.Modelo1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("modelo");

            entity.HasOne(d => d.IdMarcaNavigation).WithMany(p => p.Modelos)
                .HasForeignKey(d => d.IdMarca)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_modelos_marcas");
        });

        modelBuilder.Entity<Proveedore>(entity =>
        {
            entity.HasKey(e => e.IdProveedor).HasName("pk_proveedores");

            entity.ToTable("proveedores");

            entity.Property(e => e.IdProveedor).HasColumnName("id_proveedor");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.Telefono)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<Provincia>(entity =>
        {
            entity.HasKey(e => e.IdProvincia).HasName("pk_provincias");

            entity.ToTable("provincias");

            entity.Property(e => e.IdProvincia).HasColumnName("id_provincia");
            entity.Property(e => e.Provincia1)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("provincia");
        });

        modelBuilder.Entity<Reparacione>(entity =>
        {
            entity.HasKey(e => e.IdReparacion).HasName("pk_reparaciones");

            entity.ToTable("reparaciones");

            entity.Property(e => e.IdReparacion).HasColumnName("id_reparacion");
            entity.Property(e => e.CostoReparacion)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("costo_reparacion");
            entity.Property(e => e.FechaFinalizacion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_finalizacion");
            entity.Property(e => e.FechaInicio)
                .HasColumnType("datetime")
                .HasColumnName("fecha_inicio");
            entity.Property(e => e.IdEstado).HasColumnName("id_estado");
            entity.Property(e => e.IdMecanico).HasColumnName("id_mecanico");
            entity.Property(e => e.IdSucursal).HasColumnName("id_sucursal");
            entity.Property(e => e.IdVehiculo).HasColumnName("id_vehiculo");

            entity.HasOne(d => d.IdEstadoNavigation).WithMany(p => p.Reparaciones)
                .HasForeignKey(d => d.IdEstado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_reparaciones_estados");

            entity.HasOne(d => d.IdMecanicoNavigation).WithMany(p => p.Reparaciones)
                .HasForeignKey(d => d.IdMecanico)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_reparaciones_mecanicos");

            entity.HasOne(d => d.IdSucursalNavigation).WithMany(p => p.Reparaciones)
                .HasForeignKey(d => d.IdSucursal)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_reparaciones_sucursales");

            entity.HasOne(d => d.IdVehiculoNavigation).WithMany(p => p.Reparaciones)
                .HasForeignKey(d => d.IdVehiculo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_reparaciones_vehiculos");
        });

        modelBuilder.Entity<Repuesto>(entity =>
        {
            entity.HasKey(e => e.IdRepuesto).HasName("pk_repuestos");

            entity.ToTable("repuestos");

            entity.Property(e => e.IdRepuesto).HasColumnName("id_repuesto");
            entity.Property(e => e.Categoria).HasColumnName("categoria");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.PrecioUnitario)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("precio_unitario");

            entity.HasOne(d => d.CategoriaNavigation).WithMany(p => p.Repuestos)
                .HasForeignKey(d => d.Categoria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_repuestos_categorias");
        });

        modelBuilder.Entity<Stock>(entity =>
        {
            entity.HasKey(e => e.IdStock).HasName("pk_stocks");

            entity.ToTable("stocks");

            entity.Property(e => e.IdStock).HasColumnName("id_stock");
            entity.Property(e => e.IdRepuesto).HasColumnName("id_repuesto");
            entity.Property(e => e.IdSucursal).HasColumnName("id_sucursal");
            entity.Property(e => e.StockActual).HasColumnName("stock_actual");
            entity.Property(e => e.StockMinimo).HasColumnName("stock_minimo");

            entity.HasOne(d => d.IdRepuestoNavigation).WithMany(p => p.Stocks)
                .HasForeignKey(d => d.IdRepuesto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_stocks_repuestos");

            entity.HasOne(d => d.IdSucursalNavigation).WithMany(p => p.Stocks)
                .HasForeignKey(d => d.IdSucursal)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_stocks_sucursales");
        });

        modelBuilder.Entity<Sucursale>(entity =>
        {
            entity.HasKey(e => e.IdSucursal).HasName("pk_sucursales");

            entity.ToTable("sucursales");

            entity.Property(e => e.IdSucursal).HasColumnName("id_sucursal");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.Direccion).HasColumnName("direccion");
            entity.Property(e => e.Email)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Telefono)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("telefono");

            entity.HasOne(d => d.DireccionNavigation).WithMany(p => p.Sucursales)
                .HasForeignKey(d => d.Direccion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_sucursales_barrios");
        });

        modelBuilder.Entity<Vehiculo>(entity =>
        {
            entity.HasKey(e => e.IdVehiculo).HasName("pk_vehiculos");

            entity.ToTable("vehiculos");

            entity.HasIndex(e => e.Patente, "UQ__vehiculo__40228D087CA85302").IsUnique();

            entity.Property(e => e.IdVehiculo).HasColumnName("id_vehiculo");
            entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
            entity.Property(e => e.IdModelo).HasColumnName("id_modelo");
            entity.Property(e => e.Patente)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("patente");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Vehiculos)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_vehiculos_clientes");

            entity.HasOne(d => d.IdModeloNavigation).WithMany(p => p.Vehiculos)
                .HasForeignKey(d => d.IdModelo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_vehiculos_modelos");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
