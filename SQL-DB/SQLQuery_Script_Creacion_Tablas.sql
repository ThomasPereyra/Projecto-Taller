--Creacion de tablas auxiliares

CREATE TABLE provincias (
id_provincia int identity,
provincia varchar(30) NOT NULL
CONSTRAINT pk_provincias PRIMARY KEY (id_provincia)
)

CREATE TABLE ciudades (
id_ciudad int identity,
id_provincia int NOT NULL,
ciudad varchar(30)
CONSTRAINT pk_ciudades PRIMARY KEY (id_ciudad),
CONSTRAINT fk_ciudad_provincias FOREIGN KEY (id_provincia) REFERENCES provincias (id_provincia)
)

CREATE TABLE barrios (
id_barrio int identity,
id_ciudad int NOT NULL,
barrio varchar(30) NOT NULL,
CONSTRAINT pk_barrios PRIMARY KEY (id_barrio),
CONSTRAINT fk_barriso_ciudades FOREIGN KEY (id_ciudad) REFERENCES ciudades (id_ciudad)
)

CREATE TABLE marcas (
id_marca int identity,
marca varchar(30) NOT NULL,
CONSTRAINT pk_marcas PRIMARY KEY (id_marca)
)

CREATE TABLE modelos (
id_modelo int identity,
id_marca int NOT NULL,
modelo varchar(50) NOT NULL,
CONSTRAINT pk_modelos PRIMARY KEY (id_modelo),
CONSTRAINT fk_modelos_marcas FOREIGN KEY (id_marca) REFERENCES marcas (id_marca)
)

CREATE TABLE categorias_repuestos (
id_categoria int identity,
categoria varchar(30) NOT NULL
CONSTRAINT pk_categorias PRIMARY KEY (id_categoria)
)

CREATE TABLE provedores (
id_provedor int identity,
descripcion varchar(50) NOT NULL,
telefono varchar(15) NOT NULL
CONSTRAINT pk_provedores PRIMARY KEY (id_provedor)
)

CREATE TABLE estados (
id_estado int identity,
estado varchar(30) NOT NULL
CONSTRAINT pk_estados PRIMARY KEY (id_estado)
)

--creacion de tablas maestras

CREATE TABLE clientes (
id_cliente int identity,
id_barrio int,
nombre varchar(30) NOT NULL,
apellido varchar(30) NOT NULL,
dni varchar(15) NOT NULL,
fecha_nacimiento date
CONSTRAINT pk_clientes PRIMARY KEY (id_cliente),
CONSTRAINT fk_clientes_barrios FOREIGN KEY (id_barrio) REFERENCES barrios (id_barrio)
)

CREATE TABLE vehiculos (
id_vehiculo int identity,
id_cliente int NOT NULL,
patente varchar(10) UNIQUE,
id_modelo int NOT NULL
CONSTRAINT pk_vehiculos PRIMARY KEY (id_vehiculo)
CONSTRAINT fk_vehiculos_clientes FOREIGN KEY (id_cliente) REFERENCES clientes (id_cliente),
CONSTRAINT fk_vehiculos_modelos FOREIGN KEY (id_modelo) REFERENCES modelos (id_modelo)
)

CREATE TABLE mecanicos (
id_mecanico int identity,
nombre varchar(30) NOT NULL,
apellido varchar(30) NOT NULL,
fecha_nacimiento date NOT NULL,
dni varchar(15) NOT NULL
CONSTRAINT pk_mecanicos PRIMARY KEY (id_mecanico)
)

CREATE TABLE repuestos (
id_repuesto int identity,
descripcion varchar(30) NOT NULL,
categoria int NOT NULL,
precio_unitario decimal(10,2) NOT NULL
CONSTRAINT pk_repuestos PRIMARY KEY (id_repuesto)
CONSTRAINT fk_repuestos_categorias FOREIGN KEY (categoria) REFERENCES categorias_repuestos (id_categoria)
)

CREATE TABLE sucursales (
id_sucursal int identity,
direccion int NOT NULL,
telefono varchar(15) NOT NULL,
descripcion varchar(100) NOT NULL,
email varchar(30) NOT NULL
CONSTRAINT pk_sucursales PRIMARY KEY (id_sucursal)
CONSTRAINT fk_sucursales_barrios FOREIGN KEY (direccion) REFERENCES barrios (id_barrio)
)

--creacion tablas intermedias

CREATE TABLE stocks (
id_stock int identity,
id_repuesto int NOT NULL,
id_sucursal int NOT NULL,
stock_actual int NOT NULL,
stock_minimo int NOT NULL
CONSTRAINT pk_stocks PRIMARY KEY (id_stock)
CONSTRAINT fk_stocks_repuestos FOREIGN KEY (id_repuesto) REFERENCES repuestos (id_repuesto),
CONSTRAINT fk_stocks_sucursales FOREIGN KEY (id_sucursal) REFERENCES sucursales (id_sucursal)
)

--creacion tablas transaccionales y sus tablas detalle

CREATE TABLE reparaciones (
id_reparacion int identity,
id_vehiculo int NOT NULL,
id_mecanico int NOT NULL,
id_sucursal int NOT NULL,
fecha_inicio datetime NOT NULL,
costo_reparacion decimal(10,2) NOT NULL,
fecha_finalizacion datetime,
id_estado int NOT NULL
CONSTRAINT pk_reparaciones PRIMARY KEY (id_reparacion)
CONSTRAINT fk_reparaciones_vehiculos FOREIGN KEY (id_vehiculo) REFERENCES vehiculos (id_vehiculo),
CONSTRAINT fk_reparaciones_mecanicos FOREIGN KEY (id_mecanico) REFERENCES mecanicos (id_mecanico),
CONSTRAINT fk_reparaciones_sucursales FOREIGN KEY (id_sucursal) REFERENCES sucursales (id_sucursal),
CONSTRAINT fk_reparaciones_estados FOREIGN KEY (id_estado) REFERENCES estados (id_estado)
)

CREATE TABLE detalles_reparaciones (
id_detalle int identity,
id_reparacion int NOT NULL,
id_repuesto int NOT NULL,
cantidad int NOT NULL,
precio_unitario decimal(10,2) NOT NULL
CONSTRAINT pk_detalles_rep PRIMARY KEY (id_detalle)
CONSTRAINT fk_detalles_reparacion FOREIGN KEY (id_reparacion) REFERENCES reparaciones (id_reparacion),
CONSTRAINT fk_detalles_reparacion_repuestos FOREIGN KEY (id_repuesto) REFERENCES repuestos (id_repuesto)
)

CREATE TABLE compras_repuestos (
id_compra int identity,
id_provedor int,
id_sucursal int NOT NULL,
fecha_compra date NOT NULL,
total_compra decimal(10,2) NOT NULL
CONSTRAINT pk_compras PRIMARY KEY (id_compra)
CONSTRAINT fk_compras_provedores FOREIGN KEY (id_provedor) REFERENCES provedores (id_provedor),
CONSTRAINT fk_compras_sucursales FOREIGN KEY (id_sucursal) REFERENCES sucursales (id_sucursal)
)

CREATE TABLE detalles_compras (
id_detalle int identity,
id_compra int NOT NULL,
id_repuesto int NOT NULL,
cantidad int NOT NULL,
precio_unitario decimal(10,2) NOT NULL
CONSTRAINT pk_detalle_com PRIMARY KEY (id_detalle)
CONSTRAINT fk_detalle_compras FOREIGN KEY (id_compra) REFERENCES compras_repuestos (id_compra),
CONSTRAINT fk_detalle_compras_repuestos FOREIGN KEY (id_repuesto) REFERENCES repuestos (id_repuesto)
)