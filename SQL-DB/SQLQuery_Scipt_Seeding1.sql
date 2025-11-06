USE DB_Taller;
GO
-- Todo el archivo de seeding fue hecho con AI.
-- Insertar datos en provincias (todas las provincias de Argentina, incluyendo CABA)
INSERT INTO provincias (provincia) VALUES 
('Buenos Aires'),
('Catamarca'),
('Chaco'),
('Chubut'),
('Córdoba'),
('Corrientes'),
('Entre Ríos'),
('Formosa'),
('Jujuy'),
('La Pampa'),
('La Rioja'),
('Mendoza'),
('Misiones'),
('Neuquén'),
('Río Negro'),
('Salta'),
('San Juan'),
('San Luis'),
('Santa Cruz'),
('Santa Fe'),
('Santiago del Estero'),
('Tierra del Fuego'),
('Tucumán'),
('Ciudad Autónoma de Buenos Aires');

-- Insertar datos en ciudades (al menos 2 por provincia, más para Buenos Aires, Córdoba y Santa Fe)
-- Asumiendo IDs de provincias: 1=Buenos Aires, 2=Catamarca, ..., 24=CABA
INSERT INTO ciudades (id_provincia, ciudad) VALUES 
-- Buenos Aires (más ciudades)
(1, 'La Plata'),
(1, 'Mar del Plata'),
(1, 'Bahía Blanca'),
(1, 'Quilmes'),
(1, 'Lanús'),
(1, 'Tandil'),
(1, 'Luján'),
-- Catamarca
(2, 'San Fernando del Valle de Catamarca'),
(2, 'Valle Viejo'),
-- Chaco
(3, 'Resistencia'),
(3, 'Presidencia Roque Sáenz Peña'),
-- Chubut
(4, 'Rawson'),
(4, 'Comodoro Rivadavia'),
-- Córdoba (más ciudades)
(5, 'Córdoba Capital'),
(5, 'Río Cuarto'),
(5, 'Villa Carlos Paz'),
(5, 'Alta Gracia'),
(5, 'Cosquín'),
(5, 'Villa María'),
-- Corrientes
(6, 'Corrientes'),
(6, 'Goya'),
-- Entre Ríos
(7, 'Paraná'),
(7, 'Concordia'),
-- Formosa
(8, 'Formosa'),
(8, 'Clorinda'),
-- Jujuy
(9, 'San Salvador de Jujuy'),
(9, 'Palpalá'),
-- La Pampa
(10, 'Santa Rosa'),
(10, 'General Pico'),
-- La Rioja
(11, 'La Rioja'),
(11, 'Chilecito'),
-- Mendoza
(12, 'Mendoza Capital'),
(12, 'San Rafael'),
(12, 'Godoy Cruz'),
-- Misiones
(13, 'Posadas'),
(13, 'Oberá'),
-- Neuquén
(14, 'Neuquén Capital'),
(14, 'Cutral Có'),
-- Río Negro
(15, 'Viedma'),
(15, 'San Carlos de Bariloche'),
-- Salta
(16, 'Salta Capital'),
(16, 'San Ramón de la Nueva Orán'),
-- San Juan
(17, 'San Juan Capital'),
(17, 'Rawson'),
-- San Luis
(18, 'San Luis Capital'),
(18, 'Villa Mercedes'),
-- Santa Cruz
(19, 'Río Gallegos'),
(19, 'Caleta Olivia'),
-- Santa Fe (más ciudades)
(20, 'Santa Fe Capital'),
(20, 'Rosario'),
(20, 'Rafaela'),
(20, 'Venado Tuerto'),
(20, 'Reconquista'),
(20, 'Santo Tomé'),
-- Santiago del Estero
(21, 'Santiago del Estero Capital'),
(21, 'La Banda'),
-- Tierra del Fuego
(22, 'Ushuaia'),
(22, 'Río Grande'),
-- Tucumán
(23, 'San Miguel de Tucumán'),
(23, 'Tafí Viejo'),
(23, 'Yerba Buena'),
-- Ciudad Autónoma de Buenos Aires (tratada como provincia, con 'ciudades' como comunas o áreas principales)
(24, 'Buenos Aires'),
(24, 'Palermo'),
(24, 'Recoleta');

-- Insertar datos en barrios (al menos 2 por ciudad)
-- Asumiendo IDs de ciudades comenzando desde 1 en orden de inserción
-- Buenos Aires province cities: 1=La Plata, 2=Mar del Plata, 3=Bahía Blanca, 4=Quilmes, 5=Lanús, 6=Tandil, 7=Luján
INSERT INTO barrios (id_ciudad, barrio) VALUES 
(1, 'Centro'), (1, 'Los Hornos'),
(2, 'Centro'), (2, 'Punta Mogotes'),
(3, 'Centro'), (3, 'Villa Mitre'),
(4, 'Centro'), (4, 'Bernal'),
(5, 'Centro'), (5, 'Lanús Este'),
(6, 'Centro'), (6, 'Villa Italia'),
(7, 'Centro'), (7, 'Universidad'),
-- Catamarca: 8=San Fernando..., 9=Valle Viejo
(8, 'Centro'), (8, 'Alto'),
(9, 'Centro'), (9, 'Sur'),
-- Chaco: 10=Resistencia, 11=Presidencia...
(10, 'Centro'), (10, 'Villa Centenario'),
(11, 'Centro'), (11, 'Barrio Norte'),
-- Chubut: 12=Rawson, 13=Comodoro Rivadavia
(12, 'Centro'), (12, 'Playa Unión'),
(13, 'Centro'), (13, 'Km 3'),
-- Córdoba: 14=Córdoba Capital, 15=Río Cuarto, 16=Villa Carlos Paz, 17=Alta Gracia, 18=Cosquín, 19=Villa María
(14, 'Centro'), (14, 'Nueva Córdoba'),
(14, 'Alberdi'), (14, 'Güemes'),  -- más para metrópolis
(15, 'Centro'), (15, 'Banda Norte'),
(16, 'Centro'), (16, 'Villa del Lago'),
(17, 'Centro'), (17, 'Alta Gracia Centro'),
(18, 'Centro'), (18, 'San Martín'),
(19, 'Centro'), (19, 'Ameghino'),
-- Corrientes: 20=Corrientes, 21=Goya
(20, 'Centro'), (20, 'Punta Taitalo'),
(21, 'Centro'), (21, 'Sur'),
-- Entre Ríos: 22=Paraná, 23=Concordia
(22, 'Centro'), (22, 'San Agustín'),
(23, 'Centro'), (23, 'Villa Adela'),
-- Formosa: 24=Formosa, 25=Clorinda
(24, 'Centro'), (24, 'San Francisco'),
(25, 'Centro'), (25, 'Porteño'),
-- Jujuy: 26=San Salvador..., 27=Palpalá
(26, 'Centro'), (26, 'Cuyaya'),
(27, 'Centro'), (27, 'Alto Comedero'),
-- La Pampa: 28=Santa Rosa, 29=General Pico
(28, 'Centro'), (28, 'Villa Alonso'),
(29, 'Centro'), (29, 'Indios Ranqueles'),
-- La Rioja: 30=La Rioja, 31=Chilecito
(30, 'Centro'), (30, 'Evita'),
(31, 'Centro'), (31, 'Panamericano'),
-- Mendoza: 32=Mendoza Capital, 33=San Rafael, 34=Godoy Cruz
(32, 'Centro'), (32, 'Quinta Sección'),
(33, 'Centro'), (33, 'Cuadro Nacional'),
(34, 'Centro'), (34, 'Trapiche'),
-- Misiones: 35=Posadas, 36=Oberá
(35, 'Centro'), (35, 'Villa Cabello'),
(36, 'Centro'), (36, 'Yerbal Viejo'),
-- Neuquén: 37=Neuquén Capital, 38=Cutral Có
(37, 'Centro'), (37, 'Confluencia'),
(38, 'Centro'), (38, 'Parque Oeste'),
-- Río Negro: 39=Viedma, 40=San Carlos de Bariloche
(39, 'Centro'), (39, 'El Cóndor'),
(40, 'Centro'), (40, 'Llao Llao'),
-- Salta: 41=Salta Capital, 42=San Ramón...
(41, 'Centro'), (41, 'Villa San Lorenzo'),
(42, 'Centro'), (42, 'Barrio Norte'),
-- San Juan: 43=San Juan Capital, 44=Rawson
(43, 'Centro'), (43, 'Concepción'),
(44, 'Centro'), (44, 'Villa Krause'),
-- San Luis: 45=San Luis Capital, 46=Villa Mercedes
(45, 'Centro'), (45, 'La Punta'),
(46, 'Centro'), (46, 'Las Mirandas'),
-- Santa Cruz: 47=Río Gallegos, 48=Caleta Olivia
(47, 'Centro'), (47, 'Barrio del Carmen'),
(48, 'Centro'), (48, 'Zona Norte'),
-- Santa Fe: 49=Santa Fe Capital, 50=Rosario, 51=Rafaela, 52=Venado Tuerto, 53=Reconquista, 54=Santo Tomé
(49, 'Centro'), (49, 'Candioti'),
(49, 'Sur'), (49, 'Norte'),  -- más para metrópolis
(50, 'Centro'), (50, 'Fisherton'),
(50, 'Echesortu'), (50, 'Pichincha'),
(51, 'Centro'), (51, '9 de Julio'),
(52, 'Centro'), (52, 'San Vicente'),
(53, 'Centro'), (53, 'Guadalupe'),
(54, 'Centro'), (54, 'Siete Soles'),
-- Santiago del Estero: 55=Santiago..., 56=La Banda
(55, 'Centro'), (55, 'Huaico Hondo'),
(56, 'Centro'), (56, 'Tablada'),
-- Tierra del Fuego: 57=Ushuaia, 58=Río Grande
(57, 'Centro'), (57, 'Barrio Felipe Varela'),
(58, 'Centro'), (58, 'Chacra II'),
-- Tucumán: 59=San Miguel..., 60=Tafí Viejo, 61=Yerba Buena
(59, 'Centro'), (59, 'Barrio Norte'),
(60, 'Centro'), (60, 'Villa Obrera'),
(61, 'Centro'), (61, 'San Javier'),
-- CABA: 62=Buenos Aires, 63=Palermo, 64=Recoleta
(62, 'Microcentro'), (62, 'San Telmo'),
(62, 'La Boca'), (62, 'Puerto Madero'),  -- más para metrópolis
(63, 'Palermo Soho'), (63, 'Palermo Hollywood'),
(64, 'Barrio Norte'), (64, 'Retiro');

-- El resto permanece igual
-- Insertar datos en marcas (marcas de vehículos comunes)
INSERT INTO marcas (marca) VALUES 
('Toyota'),
('Ford'),
('Volkswagen'),
('Chevrolet'),
('Renault');

-- Insertar datos en modelos (asociados a marcas)
-- Asumiendo IDs: 1=Toyota, 2=Ford, etc.
INSERT INTO modelos (id_marca, modelo) VALUES 
(1, 'Corolla'),
(1, 'Hilux'),
(2, 'Fiesta'),
(2, 'Ranger'),
(3, 'Gol'),
(3, 'Amarok'),
(4, 'Onix'),
(4, 'Tracker'),
(5, 'Clio'),
(5, 'Duster');

-- Insertar datos en categorias_repuestos (categorías de repuestos)
INSERT INTO categorias_repuestos (categoria) VALUES 
('Motor'),
('Frenos'),
('Suspensión'),
('Eléctrico'),
('Transmisión'),
('Carrocería');

-- Insertar datos en proveedores (proveedores ficticios)
INSERT INTO proveedores (descripcion, telefono) VALUES 
('AutoPartes SA', '011-1234-5678'),
('Repuestos Norte', '0351-8765-4321'),
('Proveedor Central', '0341-1122-3344'),
('Distribuidora Oeste', '0261-4455-6677'),
('Suministros Sur', '0381-9988-7766');

-- Insertar datos en estados (estados de reparaciones)
INSERT INTO estados (estado) VALUES 
('Pendiente'),
('En Progreso'),
('Completado'),
('Cancelado'),
('En Espera de Piezas');