
-------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------
------------------------TRABAJO PRACTICO GESTION DE DATOS----------------------------
-------------------------------------------------------------------------------------
-----------------------------ESQUEMA REZAGADOS---------------------------------------
-------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------

USE [GD1C2015]
GO
CREATE SCHEMA [REZAGADOS] AUTHORIZATION [gd]
GO

-------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------
----------------------------------CREATE TABLES--------------------------------------
-------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------

CREATE TABLE REZAGADOS.Rol(
Id_Rol numeric(18,0) IDENTITY(1,1) NOT NULL,
Nombre varchar(255) UNIQUE,
Habilitada bit DEFAULT 1,);
ALTER TABLE REZAGADOS.Rol ADD CONSTRAINT PK_Id_Rol PRIMARY KEY (Id_Rol);

CREATE TABLE REZAGADOS.FuncionalidadXRol (
Id_Rol numeric(18,0) NOT NULL,
Id_Funcionalidad numeric(18,0) NOT NULL);
ALTER TABLE REZAGADOS.FuncionalidadXRol ADD CONSTRAINT PK_Id_Funcionalidad_Rol PRIMARY KEY (Id_Funcionalidad, Id_Rol);

CREATE TABLE REZAGADOS.Funcionalidad (
Id_Funcionalidad numeric(18,0) IDENTITY(1,1) NOT NULL,
Nombre varchar(255) UNIQUE,
Habilitada bit DEFAULT 1,);
ALTER TABLE REZAGADOS.Funcionalidad ADD CONSTRAINT PK_Id_Funcionalidad PRIMARY KEY (Id_Funcionalidad);

CREATE TABLE REZAGADOS.Usuario (
Id_Usuario numeric(18,0) IDENTITY(1,1) NOT NULL,
Nombre varchar(255) UNIQUE, 
Contrasenia varchar(255),
Cantidad_Intentos_Fallidos numeric(18,0) DEFAULT 0,
Contrasenia_Modificada bit DEFAULT 0,
Fecha_Creacion datetime,
Fecha_Ult_Modif datetime,
Pregunta varchar(255),
Respuesta varchar(255),
Habilitada bit DEFAULT 1,);
ALTER TABLE REZAGADOS.Usuario ADD CONSTRAINT PK_Id_Usuario PRIMARY KEY (Id_Usuario);


CREATE TABLE REZAGADOS.HistorialUsuario(
Id_Historial_Usuario numeric (18,0) IDENTITY(1,1) NOT NULL,
Id_Usuario numeric (18,0),
--Usuario varchar(255),
Cantidad_Intentos_Fallidos numeric(18,0) DEFAULT 0,
Fecha datetime,);
ALTER TABLE REZAGADOS.HistorialUsuario ADD CONSTRAINT PK_Id_Historial_Usuario PRIMARY KEY (Id_Historial_Usuario);

CREATE TABLE REZAGADOS.UsuarioXRol (
Id_Usuario numeric(18,0) NOT NULL,
Id_Rol numeric(18,0) NOT NULL,);
ALTER TABLE REZAGADOS.UsuarioXRol ADD CONSTRAINT PK_Id_Usuario_Rol PRIMARY KEY (Id_Rol, Id_Usuario);

CREATE TABLE REZAGADOS.Administrador (
Id_Administrador numeric(18,0) IDENTITY(1,1) NOT NULL,
Id_Usuario numeric(18,0) NOT NULL,
Habilitada bit DEFAULT 1,);
ALTER TABLE REZAGADOS.Administrador ADD CONSTRAINT PK_Id_Administrador PRIMARY KEY (Id_Administrador);

CREATE TABLE REZAGADOS.Cliente (
Id_Cliente numeric(18, 0) IDENTITY(1,1) NOT NULL,
Id_Usuario numeric(18,0),
Nombre varchar(255),
Apellido varchar(255),
Id_Tipo_Documento numeric(18,0),
Nro_Documento numeric(18,0),
Id_Pais numeric(18,0),
Direccion_Calle varchar(255),
Direccion_Numero_Calle numeric(18,0),
Direccion_Piso numeric(18,0),
Direccion_Departamento varchar(10),
Fecha_Nacimiento datetime,
Mail varchar(255),
Localidad varchar(255),
Id_Nacionalidad numeric(18,0),
Habilitada bit DEFAULT 1,);
ALTER TABLE REZAGADOS.Cliente ADD CONSTRAINT PK_Id_Cliente PRIMARY KEY (Id_Cliente);
ALTER TABLE REZAGADOS.Cliente ADD CONSTRAINT UQ_Nro_Documento_Tipo UNIQUE (Nro_Documento,Id_Tipo_Documento);
ALTER TABLE REZAGADOS.Cliente ADD CONSTRAINT UQ_Mail UNIQUE (Mail);
				
CREATE TABLE REZAGADOS.TipoDocumento (
Id_Tipo_Documento numeric(18,0) NOT NULL,
Descripcion varchar(255) UNIQUE,);
ALTER TABLE REZAGADOS.TipoDocumento ADD CONSTRAINT PK_Id_Tipo_Documento PRIMARY KEY (Id_Tipo_Documento);

CREATE TABLE REZAGADOS.Pais (
Id_Pais numeric(18,0) NOT NULL,
Descripcion varchar(250) UNIQUE,);
ALTER TABLE REZAGADOS.Pais ADD CONSTRAINT PK_Id_Pais PRIMARY KEY (Id_Pais);

CREATE TABLE REZAGADOS.Cuenta (
Id_Cuenta numeric (18,0) NOT NULL,
Id_Usuario numeric(18,0) NOT NULL,
Id_Pais numeric(18,0),
Id_Tipo_Cuenta numeric (18,0),
Id_Moneda numeric (18,0) DEFAULT 1,
Id_Estado numeric(18,0) NOT NULL,
Fecha_Creacion datetime,
Fecha_Cierre datetime,
Saldo numeric (18,2) DEFAULT 0.00);
ALTER TABLE REZAGADOS.Cuenta ADD CONSTRAINT PK_Id_Cuenta PRIMARY KEY (Id_Cuenta);

CREATE TABLE REZAGADOS.TipoCuenta (
Id_Tipo_Cuenta numeric (18,0) IDENTITY(1,1) NOT NULL,
Categoria varchar(255),
Costo numeric (18,0),
Dias_Vigencia numeric (18,0),);
ALTER TABLE REZAGADOS.TipoCuenta ADD CONSTRAINT PK_Id_Tipo_Cuenta PRIMARY KEY (Id_Tipo_Cuenta);

CREATE TABLE REZAGADOS.Moneda (
Id_Moneda numeric (18,0) IDENTITY(1,1) NOT NULL,
Descripcion  varchar(255),);
ALTER TABLE REZAGADOS.Moneda ADD CONSTRAINT PK_Id_Moneda PRIMARY KEY (Id_Moneda);

CREATE TABLE REZAGADOS.HistorialCuenta(
Id_Historial_Cuenta numeric (18,0) IDENTITY(1,1) NOT NULL,
Id_Cuenta numeric (18,0),
Fecha datetime,
Id_Estado numeric (18,0),
Estado varchar(255),);
ALTER TABLE REZAGADOS.HistorialCuenta ADD CONSTRAINT PK_Id_Historial_Cuenta PRIMARY KEY (Id_Historial_Cuenta);

CREATE TABLE REZAGADOS.Deposito (
Id_Deposito numeric (18,0) IDENTITY (1,1) NOT NULL,
Codigo numeric (18,0),
Id_Cuenta numeric (18,0) NOT NULL,
Id_Tarjeta  numeric (18,0) NOT NULL,
Id_Pais numeric(18,0),
Id_Moneda numeric (18,0) DEFAULT 1,
Fecha datetime,
Importe numeric (18,2),);
ALTER TABLE REZAGADOS.Deposito ADD CONSTRAINT PK_Id_Deposito PRIMARY KEY (Id_Deposito);

CREATE TABLE REZAGADOS.Tarjeta (
Id_Tarjeta numeric (18,0) IDENTITY (1,1) NOT NULL,
Id_Cliente numeric(18,0) NOT NULL,
Numero varchar(20) NOT NULL,
Id_Emisor NUMERIC (18,0) NOT NULL,
Codigo_Seguridad varchar(255) NOT NULL,
Fecha_Emision datetime,
Vencimiento datetime,
Habilitada bit DEFAULT 1,);
ALTER TABLE REZAGADOS.Tarjeta ADD CONSTRAINT PK_Id_Tarjeta PRIMARY KEY (Id_Tarjeta);
ALTER TABLE REZAGADOS.Tarjeta ADD CONSTRAINT UQ_Num_Tarjeta UNIQUE (Numero);

CREATE TABLE REZAGADOS.Emisor(
Id_Emisor NUMERIC(18,0) IDENTITY(1,1) NOT NULL,
Nombre varchar(255) UNIQUE
);
ALTER TABLE REZAGADOS.Emisor ADD CONSTRAINT PK_Id_Emisor PRIMARY KEY (Id_Emisor);

CREATE TABLE REZAGADOS.Transferencia ( 
Id_Transferencia numeric (18,0) IDENTITY (1,1) NOT NULL,
Id_Cuenta_Emi numeric (18,0) NOT NULL,
Id_Cuenta_Dest numeric (18,0) NOT NULL,
Fecha datetime,
Id_Moneda numeric (18,0) DEFAULT 1,
Importe numeric(18,2) NOT NULL,);
ALTER TABLE REZAGADOS.Transferencia ADD CONSTRAINT PK_Id_Transferencia PRIMARY KEY (Id_Transferencia);

CREATE TABLE REZAGADOS.Retiro ( 
Id_Retiro numeric (18,0) IDENTITY(1,1) NOT NULL,
Id_Cuenta numeric (18,0) NOT NULL,
Fecha datetime,
Id_Moneda numeric (18,0) DEFAULT 1,
Importe numeric(18,2) NOT NULL,);
ALTER TABLE REZAGADOS.Retiro ADD CONSTRAINT PK_Id_Retiro PRIMARY KEY (Id_Retiro);

CREATE TABLE REZAGADOS.Cheque ( 
Id_Cheque numeric (18,0) IDENTITY(1,1) NOT NULL,
Id_Retiro numeric (18,0) NOT NULL,
Id_Banco numeric (18,0) NOT NULL,
Fecha datetime,
Id_Moneda numeric (18,0) DEFAULT 1,
Importe numeric(18,2) NOT NULL,
--Num_Egreso numeric(18,2),
--Num_Item numeric(18,2),
);
ALTER TABLE REZAGADOS.Cheque ADD CONSTRAINT PK_Id_Cheque PRIMARY KEY (Id_Cheque);

CREATE TABLE REZAGADOS.Banco ( 
Id_Banco numeric (18,0) NOT NULL,
Nombre varchar(255),
Direccion varchar(255) NOT NULL,);
ALTER TABLE REZAGADOS.Banco ADD CONSTRAINT PK_Id_Banco PRIMARY KEY (Id_Banco);

CREATE TABLE REZAGADOS.Item (
Id_Item numeric(18,0) IDENTITY(1,1) NOT NULL,
Id_Factura numeric(18,0),
Id_Cuenta numeric(18,0),
Id_Tipo_Item numeric(18,0),
Importe numeric(18,2) NOT NULL, 
Fecha datetime,);
ALTER TABLE REZAGADOS.Item ADD CONSTRAINT PK_Id_Item PRIMARY KEY (Id_Item);

CREATE TABLE REZAGADOS.TipoItem(
Id_Tipo_Item numeric(18,0) IDENTITY(1,1) NOT NULL,
Tipo varchar(255),
Importe numeric(18,0) DEFAULT 0,);
ALTER TABLE REZAGADOS.TipoItem ADD CONSTRAINT PK_Id_Tipo_Item PRIMARY KEY (Id_Tipo_Item);

CREATE TABLE REZAGADOS.Factura (
Id_Factura NUMERIC(18,0) IDENTITY(1,1) NOT NULL,
Id_Usuario numeric(18,0) NOT NULL,
Fecha datetime NOT NULL,);
ALTER TABLE REZAGADOS.Factura ADD CONSTRAINT PK_Id_Factura PRIMARY KEY (Id_Factura);

CREATE TABLE REZAGADOS.Estado_Cuenta(
Id_Estado numeric(18,0) IDENTITY(1,1) NOT NULL,
Nombre varchar(255) UNIQUE,
Habilitada bit DEFAULT 1,);
ALTER TABLE REZAGADOS.Estado_Cuenta ADD CONSTRAINT PK_Id_Estado_Cuenta PRIMARY KEY (Id_Estado);

-------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------
------------------------------------CREAR FKS----------------------------------------
-------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------

ALTER TABLE REZAGADOS.FuncionalidadXRol ADD CONSTRAINT FK_FuncionalidadXRol_to_Rol
FOREIGN KEY (Id_Rol) REFERENCES REZAGADOS.Rol (Id_Rol)
;
ALTER TABLE REZAGADOS.FuncionalidadXRol ADD CONSTRAINT FK_FuncionalidadXRol_to_Funcionalidad
FOREIGN KEY (Id_Funcionalidad) REFERENCES REZAGADOS.Funcionalidad (Id_Funcionalidad)
;
ALTER TABLE REZAGADOS.UsuarioXRol ADD CONSTRAINT FK_UsuarioXRol_to_Rol
FOREIGN KEY (Id_Rol) REFERENCES REZAGADOS.Rol (Id_Rol)
;
ALTER TABLE REZAGADOS.UsuarioXRol ADD CONSTRAINT FK_UsuarioXRol_to_Usuario
FOREIGN KEY (Id_Usuario) REFERENCES REZAGADOS.Usuario (Id_Usuario)
;
ALTER TABLE REZAGADOS.Administrador ADD CONSTRAINT FK_Administrador_to_Usuario
FOREIGN KEY (Id_Usuario) REFERENCES REZAGADOS.Usuario (Id_Usuario)
;
ALTER TABLE REZAGADOS.Cliente ADD CONSTRAINT FK_Cliente_to_Usuario
FOREIGN KEY (Id_Usuario) REFERENCES REZAGADOS.Usuario (Id_Usuario)
;
ALTER TABLE REZAGADOS.Cliente ADD CONSTRAINT FK_Cliente_to_TipoDocumento
FOREIGN KEY (Id_Tipo_Documento) REFERENCES REZAGADOS.TipoDocumento (Id_Tipo_Documento)
;
ALTER TABLE REZAGADOS.Cliente ADD CONSTRAINT FK_Cliente_to_Pais
FOREIGN KEY (Id_Pais) REFERENCES REZAGADOS.Pais (Id_Pais)
;
ALTER TABLE REZAGADOS.Cliente ADD CONSTRAINT FK_Cliente_to_Nacionalidad
FOREIGN KEY (Id_Nacionalidad) REFERENCES REZAGADOS.Pais (Id_Pais)
;
ALTER TABLE REZAGADOS.Cuenta ADD CONSTRAINT FK_Cuenta_to_Usuario
FOREIGN KEY (Id_Usuario) REFERENCES REZAGADOS.Usuario (Id_Usuario)
;
ALTER TABLE REZAGADOS.Cuenta ADD CONSTRAINT FK_Cuenta_to_TipoCuenta
FOREIGN KEY (Id_Tipo_Cuenta) REFERENCES REZAGADOS.TipoCuenta (Id_Tipo_Cuenta)
;
ALTER TABLE REZAGADOS.Cuenta ADD CONSTRAINT FK_Cuenta_to_EstadoCuenta
FOREIGN KEY (Id_Estado) REFERENCES REZAGADOS.Estado_Cuenta (Id_Estado)
;
ALTER TABLE REZAGADOS.Cuenta ADD CONSTRAINT FK_Cuenta_to_Pais
FOREIGN KEY (Id_Pais) REFERENCES REZAGADOS.Pais (Id_Pais)
;
ALTER TABLE REZAGADOS.Cuenta ADD CONSTRAINT FK_Cuenta_to_Moneda
FOREIGN KEY (Id_Moneda) REFERENCES REZAGADOS.Moneda (Id_Moneda)
;
ALTER TABLE REZAGADOS.HistorialCuenta ADD CONSTRAINT FK_Historial_Cuenta_to_Cuenta
FOREIGN KEY (Id_Cuenta) REFERENCES REZAGADOS.Cuenta (Id_Cuenta)
;
ALTER TABLE REZAGADOS.HistorialCuenta ADD CONSTRAINT FK_Historial_Cuenta_to_Estado
FOREIGN KEY (Id_Estado) REFERENCES REZAGADOS.Estado_Cuenta (Id_Estado)
;
ALTER TABLE REZAGADOS.Deposito ADD CONSTRAINT FK_Deposito_to_Cuenta
FOREIGN KEY (Id_Cuenta) REFERENCES REZAGADOS.Cuenta (Id_Cuenta)
;
ALTER TABLE REZAGADOS.Deposito ADD CONSTRAINT FK_Deposito_to_Pais
FOREIGN KEY (Id_Pais) REFERENCES REZAGADOS.Pais (Id_Pais)
;
ALTER TABLE REZAGADOS.Deposito ADD CONSTRAINT FK_Deposito_to_Tarjeta
FOREIGN KEY (Id_Tarjeta) REFERENCES REZAGADOS.Tarjeta (Id_Tarjeta)
;
ALTER TABLE REZAGADOS.Deposito ADD CONSTRAINT FK_Deposito_to_Moneda
FOREIGN KEY (Id_Moneda) REFERENCES REZAGADOS.Moneda (Id_Moneda)
;
ALTER TABLE REZAGADOS.Tarjeta ADD CONSTRAINT FK_Tarjeta_to_Cliente
FOREIGN KEY (Id_Cliente) REFERENCES REZAGADOS.Cliente (Id_Cliente)
;
ALTER TABLE REZAGADOS.Tarjeta ADD CONSTRAINT FK_Tarjeta_to_Emisor
FOREIGN KEY (Id_Emisor) REFERENCES REZAGADOS.Emisor (Id_Emisor)
;
ALTER TABLE REZAGADOS.Transferencia ADD CONSTRAINT FK_Transferencia_to_Cuenta_Emi
FOREIGN KEY (Id_Cuenta_Emi) REFERENCES REZAGADOS.Cuenta (Id_Cuenta)
;
ALTER TABLE REZAGADOS.Transferencia ADD CONSTRAINT FK_Transferencia_to_Cuenta_Dest
FOREIGN KEY (Id_Cuenta_Dest) REFERENCES REZAGADOS.Cuenta (Id_Cuenta)
;
ALTER TABLE REZAGADOS.Retiro ADD CONSTRAINT FK_Retiro_to_Cuenta
FOREIGN KEY (Id_Cuenta) REFERENCES REZAGADOS.Cuenta (Id_Cuenta)
;
ALTER TABLE REZAGADOS.Retiro ADD CONSTRAINT FK_Retiro_to_Moneda
FOREIGN KEY (Id_Moneda) REFERENCES REZAGADOS.Moneda (Id_Moneda)
;
ALTER TABLE REZAGADOS.Cheque ADD CONSTRAINT FK_Cheque_to_Retiro
FOREIGN KEY (Id_Retiro) REFERENCES REZAGADOS.Retiro (Id_Retiro)
;
ALTER TABLE REZAGADOS.Cheque ADD CONSTRAINT FK_Cheque_to_Banco
FOREIGN KEY (Id_Banco) REFERENCES REZAGADOS.Banco (Id_Banco)
;
ALTER TABLE REZAGADOS.Cheque ADD CONSTRAINT FK_Cheque_to_Moneda
FOREIGN KEY (Id_Moneda) REFERENCES REZAGADOS.Moneda (Id_Moneda)
;
ALTER TABLE REZAGADOS.Item ADD CONSTRAINT FK_Item_to_Factura
FOREIGN KEY (Id_Factura) REFERENCES REZAGADOS.Factura (Id_Factura)
;
ALTER TABLE REZAGADOS.Item ADD CONSTRAINT FK_Item_to_Tipo_Item
FOREIGN KEY (Id_Tipo_Item) REFERENCES REZAGADOS.TipoItem (Id_Tipo_Item)
;
ALTER TABLE REZAGADOS.Item ADD CONSTRAINT FK_Item_to_Cuenta
FOREIGN KEY (Id_Cuenta) REFERENCES REZAGADOS.Cuenta (Id_Cuenta)
;
ALTER TABLE REZAGADOS.Factura ADD CONSTRAINT FK_Factura_to_Usuario
FOREIGN KEY (Id_Usuario) REFERENCES REZAGADOS.Usuario (Id_Usuario)
;
ALTER TABLE REZAGADOS.HistorialUsuario ADD CONSTRAINT FK_Historial_Usuario_to_Usuario
FOREIGN KEY (Id_Usuario) REFERENCES REZAGADOS.Usuario (Id_Usuario)
;

-------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------
------------------------------------MIGRACION----------------------------------------
-------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------
---------------------------------------PAIS------------------------------------------

INSERT INTO REZAGADOS.Pais (Id_Pais, Descripcion)(
SELECT Cli_Pais_Codigo, Cli_Pais_Desc
FROM gd_esquema.Maestra
GROUP BY Cli_Pais_Codigo, Cli_Pais_Desc
UNION
SELECT Cuenta_Dest_Pais_Codigo, Cuenta_Dest_Pais_Desc
FROM gd_esquema.Maestra
WHERE Cuenta_Dest_Pais_Codigo IS NOT NULL
GROUP BY Cuenta_Dest_Pais_Codigo, Cuenta_Dest_Pais_Desc
UNION
SELECT Cuenta_Pais_Codigo, Cuenta_Pais_Desc
FROM gd_esquema.Maestra
GROUP BY Cuenta_Pais_Codigo, Cuenta_Pais_Desc
)
----------------------------------------ESTADO CUENTA------------------------------------------------

INSERT INTO REZAGADOS.Estado_Cuenta (Nombre)
VALUES ('Pendiente de activación'), ('Cerrada'), ('Inhabilitada'), ('Habilitada');

--------------------------------------TIPO DOCUMENTO--------------------------------------------

INSERT INTO REZAGADOS.TipoDocumento (Id_Tipo_Documento, Descripcion) (
SELECT Cli_Tipo_Doc_Cod, Cli_Tipo_Doc_Desc
FROM gd_esquema.Maestra
GROUP BY Cli_Tipo_Doc_Cod, Cli_Tipo_Doc_Desc)

-------------------------------------------ROL--------------------------------------------------

INSERT INTO REZAGADOS.Rol (Nombre)
VALUES ('Administrador'),('Cliente')

--------------------------------------FUNCIONALIDAD---------------------------------------------
--TRUNCATE TABLE REZAGADOS.Funcionalidad--------------------------------------------------------

INSERT INTO REZAGADOS.Funcionalidad (Nombre)
VALUES	('ABM de Rol'),
		('Registro de Usuario'),
		('ABM de Cliente'),
		('ABM de Cuenta'),
		('Deposito'),
		('Retiro de Efectivo'),
		('Transferencias entre cuentas'),
		('Facturación de Costos'),
		('Tarjetas'),
		('Consulta de saldos'),
		('Listado Estadístico'),
		('ABMs'),
		('Movimientos')

-------------------------------------ROL X FUNCIONALIDAD------------------------------------------

INSERT INTO REZAGADOS.FuncionalidadXRol (Id_Rol,Id_Funcionalidad)
SELECT R.Id_Rol, F.Id_Funcionalidad
FROM REZAGADOS.Rol R, REZAGADOS.Funcionalidad F
WHERE R.Nombre = 'Administrador'
UNION
SELECT R.Id_Rol, F.Id_Funcionalidad
FROM REZAGADOS.Rol R, REZAGADOS.Funcionalidad F
WHERE	R.Nombre = 'Cliente' AND
		F.Nombre IN ('ABM de Cuenta', 'Deposito', 'Retiro de Efectivo', 'Transferencias entre cuentas', 'Facturación de Costos', 'Consulta de saldos','Tarjetas',
		'ABMs',
		'Movimientos')

------------------------------------------USUARIO--------------------------------------------------
---------------------------------EL-USERNAME-SERA-EL-MAIL------------------------------------------
----------------------LA-PASS-SERA-REZAGADOS-ENCRIPTADA-EN-SHA-256---------------------------------

INSERT INTO REZAGADOS.Usuario (Nombre, Contrasenia, Fecha_Creacion, Fecha_Ult_Modif)
SELECT DISTINCT Cli_Mail, '1E57CBAAA510CD149EE657799EF3EE2D2A2815F98B249AAC81904BF54549F5ED', GETDATE(), GETDATE()
FROM gd_esquema.Maestra
WHERE Cli_Mail IS NOT NULL

INSERT INTO REZAGADOS.Usuario (Nombre, Contrasenia, Fecha_Creacion, Fecha_Ult_Modif)
VALUES ('admin','E6B87050BFCB8143FCB8DB170A4DC9ED0D904DDD3E2A4AD1B1E8DCFDC9BE7', GETDATE(), GETDATE())

----------------------------------------ADMINISTRADOR-----------------------------------------------

INSERT INTO REZAGADOS.Administrador(Id_Usuario)
SELECT DISTINCT Id_Usuario
FROM REZAGADOS.Usuario
WHERE Nombre = 'admin' 

-----------------------------------------CLIENTE-------------------------------------------------

INSERT INTO REZAGADOS.Cliente (Id_Usuario, Nombre, Apellido, Id_Tipo_Documento, Nro_Documento, Id_Pais, Direccion_Calle, Direccion_Numero_Calle, Direccion_Piso, Direccion_Departamento, Fecha_Nacimiento, Mail)
(
SELECT U.Id_Usuario, G.Cli_Nombre, G.Cli_Apellido,T.Id_Tipo_Documento, G.Cli_Nro_Doc, P.Id_Pais, G.Cli_Dom_Calle, G.Cli_Dom_Nro, G.Cli_Dom_Piso, G.Cli_Dom_Depto, G.Cli_Fecha_Nac, G.Cli_Mail
FROM REZAGADOS.Usuario U, gd_esquema.Maestra G, REZAGADOS.TipoDocumento T, REZAGADOS.Pais P
WHERE U.Nombre = G.Cli_Mail AND P.Id_Pais = G.Cli_Pais_Codigo AND T.Id_Tipo_Documento = G.Cli_Tipo_Doc_Cod
GROUP BY U.Id_Usuario, G.Cli_Nombre, G.Cli_Apellido,T.Id_Tipo_Documento, G.Cli_Nro_Doc, P.Id_Pais, G.Cli_Dom_Calle, G.Cli_Dom_Nro, G.Cli_Dom_Piso, G.Cli_Dom_Depto, G.Cli_Fecha_Nac, G.Cli_Mail
)

-----------------------------------------USUARIO X ROL--------------------------------------------------

INSERT INTO REZAGADOS.UsuarioXRol(Id_Usuario,Id_Rol)
SELECT C.Id_Usuario, R.Id_Rol 
FROM REZAGADOS.Cliente C, REZAGADOS.Rol R
WHERE R.Nombre = 'Cliente'
UNION
SELECT A.Id_Usuario, R.Id_Rol 
FROM REZAGADOS.Administrador A, REZAGADOS.Rol R
WHERE R.Nombre = 'Administrador' 

-----------------------------------------MONEDA---------------------------------------------------

INSERT INTO REZAGADOS.Moneda (Descripcion)
VALUES ('Dolar')

------------------------------------------BANCO---------------------------------------------------

INSERT INTO REZAGADOS.Banco (Id_Banco, Nombre, Direccion)
SELECT Banco_Cogido, Banco_Nombre, Banco_Direccion
FROM gd_esquema.Maestra
WHERE Banco_Cogido IS NOT NULL
GROUP BY Banco_Cogido, Banco_Nombre, Banco_Direccion

----------------------------------------TIPO CUENTA------------------------------------------------

INSERT INTO REZAGADOS.TipoCuenta (Categoria, Costo, Dias_Vigencia)
VALUES ('Oro', 10, 10), ('Plata', 5, 20), ('Bronce', 5, 30), ('Gratuita', 0, 0);

-----------------------------------------CUENTA---------------------------------------------------

INSERT INTO REZAGADOS.Cuenta (Id_Cuenta, Id_Usuario, Id_Tipo_Cuenta, Id_Pais, Id_Estado, Fecha_Creacion, Fecha_Cierre)
SELECT g.Cuenta_Numero, u.Id_Usuario, 
	(SELECT Id_Tipo_Cuenta FROM REZAGADOS.TipoCuenta WHERE Categoria='Gratuita') , g.Cuenta_Pais_Codigo, 
	(SELECT e.Id_Estado FROM REZAGADOS.Estado_Cuenta e WHERE e.Nombre like 'Inhabilitada'), 
	g.Cuenta_Fecha_Creacion, g.Cuenta_Fecha_Cierre
FROM gd_esquema.Maestra g, REZAGADOS.Usuario u
WHERE u.Nombre = g.Cli_Mail AND g.Cuenta_Dest_Fecha_Creacion IS NOT NULL
GROUP BY g.Cuenta_Numero, u.Id_Usuario, g.Cuenta_Pais_Codigo, g.Cuenta_Estado, g.Cuenta_Fecha_Creacion, g.Cuenta_Fecha_Cierre

------------------------------------------FACUTRA--------------------------------------------------
SET IDENTITY_INSERT REZAGADOS.Factura ON
INSERT INTO REZAGADOS.Factura (Id_Factura, Id_Usuario, Fecha)
SELECT g.Factura_Numero, u.Id_Usuario, g.Factura_Fecha
FROM gd_esquema.Maestra g, REZAGADOS.Usuario u
WHERE u.Nombre = g.Cli_Mail AND g.Factura_Numero IS NOT NULL
GROUP BY g.Factura_Numero, u.Id_Usuario, g.Factura_Fecha
SET IDENTITY_INSERT REZAGADOS.Factura OFF
DECLARE @Begin_Factura NUMERIC(18,0)
SET @Begin_Factura = (SELECT TOP 1 Id_Factura FROM REZAGADOS.Factura ORDER BY Id_Factura DESC)+ 1
DBCC checkident ('REZAGADOS.Factura', reseed, @Begin_Factura)

--------------------------------------------TIPO ITEM-----------------------------------------------

INSERT INTO REZAGADOS.TipoItem (Tipo, Importe)
VALUES ('Comisión por transferencia.', 10), ('Creacion de cuenta.', 5), ('Cambio de cuenta.', 2)

--------------------------------------------ITEM----------------------------------------------------

INSERT INTO REZAGADOS.Item (Id_Factura, Id_Cuenta, Id_Tipo_Item, Importe, Fecha)
SELECT  Factura_Numero, Cuenta_Numero, 1, CAST(ROUND(Trans_Importe,1)/10 AS NUMERIC (18,2)), Transf_Fecha
FROM gd_esquema.Maestra
WHERE Trans_Importe IS NOT NULL

-----------------------------------------EMISOR---------------------------------------------------

INSERT INTO REZAGADOS.Emisor (Nombre) 
SELECT DISTINCT Tarjeta_Emisor_Descripcion
FROM  GD1C2015.gd_esquema.Maestra
WHERE Tarjeta_Emisor_Descripcion IS NOT NULL

-----------------------------------------TARJETA--------------------------------------------------

INSERT INTO REZAGADOS.Tarjeta ( Numero,Id_Cliente,Id_Emisor,Codigo_Seguridad, Fecha_Emision, Vencimiento)
SELECT  DISTINCT g.Tarjeta_Numero, 
		c.Id_Cliente,
		(	SELECT Id_Emisor FROM REZAGADOS.Emisor 
			WHERE  Nombre = g.Tarjeta_Emisor_Descripcion) AS 'Id_Emisor',
		g.Tarjeta_Codigo_Seg,
		g.Tarjeta_Fecha_Emision,
		g.Tarjeta_Fecha_Vencimiento
FROM	gd_esquema.Maestra g 
JOIN	REZAGADOS.Cliente c ON g.Cli_Mail = c.Mail
WHERE	g.Tarjeta_Numero IS NOT NULL

--------------------------------------------RETIRO----------------------------------------------------

SET IDENTITY_INSERT REZAGADOS.Retiro ON
INSERT INTO REZAGADOS.Retiro (Id_Retiro, Id_Cuenta, Fecha, Importe)
SELECT g.Retiro_Codigo, c.Id_Cuenta, g.Retiro_Fecha, g.Retiro_Importe
FROM gd_esquema.Maestra g, REZAGADOS.Cuenta c
WHERE g.Retiro_Codigo IS NOT NULL AND c.Id_Cuenta = g.Cuenta_Numero
GROUP BY g.Retiro_Codigo, c.Id_Cuenta, g.Retiro_Fecha, g.Retiro_Importe
SET IDENTITY_INSERT REZAGADOS.Retiro OFF
DECLARE @Begin_Retiro NUMERIC(18,0)
SET @Begin_Retiro = (SELECT TOP 1 Id_Retiro FROM REZAGADOS.Retiro ORDER BY Id_Retiro DESC)+ 1
DBCC checkident ('REZAGADOS.Retiro', reseed, @Begin_Retiro)


----------------------------------------TRANSFERENCIA-------------------------------------------------

INSERT INTO REZAGADOS.Transferencia (Id_Cuenta_Emi, Id_Cuenta_Dest, Fecha, Importe)
SELECT Cuenta_Numero, Cuenta_Dest_Numero, Transf_Fecha, Trans_Importe
FROM gd_esquema.Maestra
WHERE Cuenta_Dest_Numero IS NOT NULL

-------------------------------------------DEPOSITO---------------------------------------------------

INSERT INTO REZAGADOS.Deposito (Codigo, Id_Cuenta, Id_Tarjeta, Id_Pais, Fecha, Importe)
SELECT Deposito_Codigo, Cuenta_Numero, Tarjeta.Id_Tarjeta, Cuenta_Pais_Codigo, Deposito_Fecha, Deposito_Importe
FROM gd_esquema.Maestra, REZAGADOS.Tarjeta
WHERE Deposito_Codigo IS NOT NULL
AND Tarjeta.Numero = gd_esquema.Maestra.Tarjeta_Numero

--------------------------------------------CHEQUE----------------------------------------------------
SET IDENTITY_INSERT REZAGADOS.Cheque ON
INSERT INTO REZAGADOS.Cheque (Id_Cheque, Id_Retiro, Id_Banco, Fecha, Importe)
SELECT Cheque_Numero, Retiro_Codigo, Banco_Cogido, Cheque_Fecha, Cheque_Importe
FROM gd_esquema.Maestra
WHERE Cheque_Numero IS NOT NULL
GROUP BY Cheque_Numero, Retiro_Codigo, Banco_Cogido, Cheque_Fecha, Cheque_Importe
SET IDENTITY_INSERT REZAGADOS.Cheque OFF
DECLARE @Begin_Cheque NUMERIC(18,0)
SET @Begin_Cheque = (SELECT TOP 1 Id_Cheque FROM REZAGADOS.Cheque ORDER BY Id_Cheque DESC)+ 1
DBCC checkident ('REZAGADOS.Retiro', reseed, @Begin_Cheque)

------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------
--------------------------------------------PROCESOS--------------------------------------------------
------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------
-----------------------------------------CREAR TIPO LISTA---------------------------------------------

USE [GD1C2015]
GO
CREATE TYPE REZAGADOS.IdLista AS TABLE 
( Id_Fila NUMERIC(18,0) );
GO

------------------------------------------CREAR CLIENTE------------------------------------------------

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[REZAGADOS].[Crear_Cliente]') AND type in (N'P', N'PC'))
	DROP PROCEDURE REZAGADOS.Crear_Cliente;
USE [GD1C2015]
GO
CREATE PROCEDURE REZAGADOS.Crear_Cliente(
					@Nombre VARCHAR(255),
					@Apellido VARCHAR(255),
					@Id_Tipo_Documento NUMERIC(18, 0),
					@Nro_Documento NUMERIC(18, 0),
					@Id_Pais NUMERIC(18, 0),
					@Direccion_Calle VARCHAR (255),
					@Direccion_Numero_Calle NUMERIC(18, 0),
					@Direccion_Piso NUMERIC(18,0),
					@Direccion_Departamento VARCHAR(10),
					@Fecha_Nacimiento DATETIME,
					@Mail VARCHAR(255),
					@Localidad VARCHAR(255),
					@Id_Nacionalidad NUMERIC(18, 0),
					@Usuario_Nombre VARCHAR(255),
					@Usuario_Pass VARCHAR(255),
					@Usuario_Preg VARCHAR(255),
					@Usuario_Resp VARCHAR(255),
					@Usuario_Id_Rol  NUMERIC(18, 0),
					@RespuestaMensaje VARCHAR(255) OUTPUT,
					@Respuesta NUMERIC(18,0) OUTPUT)
AS 
BEGIN

	IF (EXISTS(SELECT 1 FROM REZAGADOS.Usuario  WHERE Nombre = @Usuario_Nombre ))
		BEGIN
		SET @RespuestaMensaje = 'Ya Existe ese Usuario'
		SET @Respuesta = -1
		RETURN
	END


	IF (EXISTS(SELECT 1 FROM REZAGADOS.Cliente  WHERE Id_Tipo_Documento = @Id_Tipo_Documento 
												AND Nro_Documento = @Nro_Documento) )
		BEGIN
		SET @RespuestaMensaje = 'Ya Existe un Cliente con ese tipo y número de Documento'
		SET @Respuesta = -1
		RETURN
	END
	ELSE IF (EXISTS(SELECT 1 FROM REZAGADOS.Cliente  WHERE @Mail = Mail) )
		BEGIN
		SET @RespuestaMensaje = 'El e-mail ya existe.'
		SET @Respuesta = -1
		RETURN
	END
	ELSE
		BEGIN TRY
			BEGIN TRANSACTION
				INSERT INTO REZAGADOS.Usuario (Nombre,Contrasenia,Pregunta,Respuesta) 
							VALUES (@Usuario_Nombre,@Usuario_Pass,@Usuario_Preg,@Usuario_Resp)
				DECLARE @Id_Usuario NUMERIC(18,0) = @@IDENTITY
				
				INSERT INTO REZAGADOS.UsuarioXRol VALUES (@Id_Usuario,@Usuario_Id_Rol)
				
				INSERT INTO REZAGADOS.Cliente (Id_Usuario, Nombre, Apellido, Id_Tipo_Documento, Nro_Documento, Id_Pais, Direccion_Calle, Direccion_Numero_Calle, Direccion_Piso, Direccion_Departamento, Fecha_Nacimiento, Mail, Localidad, Id_Nacionalidad)
				VALUES (@Id_Usuario, @Nombre, @Apellido, @Id_Tipo_Documento, @Nro_Documento, @Id_Pais, @Direccion_Calle, @Direccion_Numero_Calle, @Direccion_Piso, @Direccion_Departamento, @Fecha_Nacimiento, @Mail, @Localidad, @Id_Nacionalidad) 		
				SET @Respuesta = @@IDENTITY
			COMMIT TRANSACTION
			SET @RespuestaMensaje = 'Los datos se guardaron exitosamente'
		END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION
			SET @Respuesta = -1
			SET @RespuestaMensaje = ERROR_MESSAGE()
		END CATCH
	END
GO

-----------------------------------------MODIFICAR CLIENTE------------------------------------------------

USE [GD1C2015]
GO
CREATE PROCEDURE REZAGADOS.Modificar_Cliente (
								@Id_Cliente NUMERIC(18,0),
								@Nombre VARCHAR(255),
								@Apellido VARCHAR(255),
								@Id_Tipo_Documento NUMERIC(18, 0),
								@Nro_Documento NUMERIC(18, 0),
								@Id_Pais NUMERIC(18, 0),
								@Direccion_Calle VARCHAR (255),
								@Direccion_Numero_Calle NUMERIC(18, 0),
								@Direccion_Piso NUMERIC(18,0),
								@Direccion_Departamento VARCHAR(10),
								@Fecha_Nacimiento DATETIME,
								@Mail VARCHAR(255),
								@Localidad VARCHAR(255),
								@Id_Nacionalidad NUMERIC(18, 0),
								@RespuestaMensaje VARCHAR(255) OUTPUT,
								@Respuesta NUMERIC(18,0) OUTPUT)
AS
BEGIN
BEGIN TRY
	BEGIN TRANSACTION
		IF (EXISTS(SELECT Mail FROM REZAGADOS.Cliente  WHERE @Mail = Mail AND Id_Cliente <> @Id_Cliente) )
			BEGIN
			SET @RespuestaMensaje = 'El e-mail ya existe.'
			SET @Respuesta = -1
		END
		ELSE
			BEGIN
			 UPDATE	REZAGADOS.Cliente
				SET	Nombre = @Nombre,
					Apellido = @Apellido,
					Id_Tipo_Documento = @Id_Tipo_Documento,
					Nro_Documento = @Nro_Documento,
					Id_Pais = @Id_Pais,
					Direccion_Calle = @Direccion_Calle,
					Direccion_Numero_Calle = @Direccion_Numero_Calle,
					Direccion_Piso = @Direccion_Piso,
					Direccion_Departamento = @Direccion_Departamento,
					Fecha_Nacimiento = @Fecha_Nacimiento,
					Mail = @Mail,
					Localidad = @Localidad,
					Id_Nacionalidad = @Id_Nacionalidad
			  WHERE Id_Cliente = @Id_Cliente

			SET @RespuestaMensaje = 'El cliente ha sido modificado!'
			SET @Respuesta = 1
		END
	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	SET @Respuesta = -1
	SET @RespuestaMensaje = 'El Cliente no se pudo guardar por datos duplicados o porque no especificó bien los datos'
	ROLLBACK TRANSACTION
END CATCH
END
GO

-----------------------------------------ALTA CLIENTE------------------------------------------------

USE [GD1C2015]
GO
CREATE PROCEDURE REZAGADOS.Alta_Cliente (	@Id_Cliente NUMERIC(18,0),
											@RespuestaMensaje VARCHAR(255) OUTPUT,
											@Respuesta NUMERIC(18,0) OUTPUT)
AS
	BEGIN
		UPDATE REZAGADOS.Cliente SET Habilitada=1 WHERE Id_Cliente=@Id_Cliente
		SET @Respuesta = 1
		SET @RespuestaMensaje = 'Alta exitosa'
	END
GO

-----------------------------------------BAJA CLIENTE------------------------------------------------

USE [GD1C2015]
GO
CREATE PROCEDURE REZAGADOS.Baja_Cliente  (	@Id_Cliente NUMERIC(18,0),
											@RespuestaMensaje VARCHAR(255) OUTPUT,
											@Respuesta NUMERIC(18,0) OUTPUT)
AS
	BEGIN
		UPDATE REZAGADOS.Cliente SET Habilitada=0  WHERE Id_Cliente=@Id_Cliente
		SET @Respuesta = 1
		SET @RespuestaMensaje = 'Baja exitosa'
	END
GO

-----------------------------------------ALTA USUARIO------------------------------------------------

USE [GD1C2015]
GO
CREATE PROCEDURE REZAGADOS.Alta_Usuario (	@Id_Usuario NUMERIC(18,0),
											@RespuestaMensaje VARCHAR(255) OUTPUT,
											@Respuesta NUMERIC(18,0) OUTPUT)
AS
	BEGIN
		DECLARE @Contrasenia VARCHAR(255) = (SELECT Contrasenia FROM REZAGADOS.Usuario WHERE Id_Usuario=@Id_Usuario)
		UPDATE REZAGADOS.Usuario SET Habilitada=1 WHERE Id_Usuario=@Id_Usuario
		UPDATE REZAGADOS.Usuario SET Cantidad_Intentos_Fallidos = 0 WHERE Id_Usuario = @Id_Usuario
		SET @RespuestaMensaje = 'Usuario dado de alta, contraseña: ' + (@Contrasenia);
		SET @Respuesta = 1
		END
GO

-----------------------------------------BAJA USUARIO------------------------------------------------

USE [GD1C2015]
GO
CREATE PROCEDURE REZAGADOS.Baja_Usuario (	@Id_Usuario NUMERIC(18,0),
											@RespuestaMensaje VARCHAR(255) OUTPUT,
											@Respuesta NUMERIC(18,0) OUTPUT)
AS
	BEGIN
		UPDATE REZAGADOS.Usuario SET Habilitada=0 WHERE Id_Usuario=@Id_Usuario
		SET @Respuesta = 1
		SET @RespuestaMensaje = 'Baja exitosa'
	END
GO

-----------------------------------------LOGIN------------------------------------------------
USE [GD1C2015]
GO

CREATE PROCEDURE [REZAGADOS].[Login] (		@Usuario NVARCHAR(255),
											@Pass NVARCHAR(255),
											@RespuestaMensaje VARCHAR(255) OUTPUT,
											@Respuesta NUMERIC(18,0) OUTPUT)
AS 
BEGIN                  
	DECLARE @Existe_Usuario INT = (SELECT COUNT(*) FROM REZAGADOS.Usuario WHERE Nombre = @Usuario);                                     
	IF (@Existe_Usuario = 1)
	BEGIN
		DECLARE @Id_Usuario NUMERIC (18,0) = (SELECT Id_Usuario FROM REZAGADOS.Usuario WHERE Nombre = @Usuario);
		INSERT INTO HistorialUsuario (Id_Usuario, Fecha) VALUES (@Id_Usuario, GETDATE())           
		DECLARE @Habilitado INT = (SELECT COUNT(*) FROM REZAGADOS.Usuario WHERE Nombre = @Usuario AND Habilitada = 1);
		IF(@Habilitado = 1)
		BEGIN                            
			DECLARE @Cantidad_Intentos_Fallidos INT = (SELECT Cantidad_Intentos_Fallidos FROM REZAGADOS.Usuario WHERE Nombre = @Usuario); 
			IF (@Cantidad_Intentos_Fallidos < 3)
			BEGIN
				DECLARE @Existe_Usuario_Contrasenia INT = (SELECT COUNT(*) FROM REZAGADOS.Usuario WHERE Nombre = @Usuario and Contrasenia = @Pass);
				IF (@Existe_Usuario_Contrasenia = 1)
				BEGIN
					UPDATE REZAGADOS.Usuario SET Cantidad_Intentos_Fallidos=0 WHERE Nombre = @Usuario;
					DECLARE @Existe_Rol INT = (SELECT COUNT(R.Id_Rol) FROM REZAGADOS.Usuario U, REZAGADOS.UsuarioXRol R WHERE U.Nombre = @Usuario AND U.Id_Usuario = R.Id_Usuario)				
					IF (@Existe_Rol = 0)
					BEGIN
						SET @RespuestaMensaje = 'El usuario no tiene asignado un rol, o el rol ha sido inhabilitado'
						SET @Respuesta = -1
						END
					ELSE
					BEGIN								
						SET @RespuestaMensaje = 'Abrir Sesion'
						SET @Respuesta = (SELECT U.Id_Usuario FROM REZAGADOS.Usuario U WHERE U.Nombre = @Usuario)	
						RETURN
					END
				END
				ELSE
				BEGIN
					UPDATE REZAGADOS.Usuario SET Cantidad_Intentos_Fallidos=(Cantidad_Intentos_Fallidos+1) WHERE Nombre = @Usuario;
					SET @Cantidad_Intentos_Fallidos = (@Cantidad_Intentos_Fallidos + 1);
					DECLARE @Cantidad_Intentos_Fallidos_String NVARCHAR(255) = @Cantidad_Intentos_Fallidos;
					SET @RespuestaMensaje = 'Contraseña incorrecta, vuelva a intentarlo. Cantidad de intentos fallidos: ' + (@Cantidad_Intentos_Fallidos_String);
					SET @Respuesta = -1
					PRINT @RespuestaMensaje	
				END
			END
			ELSE
			BEGIN
				DECLARE @Id_User NUMERIC(18,0) = (SELECT Id_Usuario FROM REZAGADOS.Usuario WHERE Nombre = @Usuario)
				UPDATE REZAGADOS.Usuario SET Habilitada = 0 WHERE @Id_User = Id_Usuario
				SET @RespuestaMensaje = 'Su usuario esta bloqueado, por sobrepasar la cantidad de logueos incorrectos';
				SET @Respuesta = -1
				PRINT @RespuestaMensaje	
			END  
		END
		ELSE
		SET @RespuestaMensaje = 'El Usuario se encuentra inhabilitado'
		SET @Respuesta = -1
		PRINT @RespuestaMensaje	
	END
	ELSE 
		SET @RespuestaMensaje = 'No existe el usuario, vuelva a intentarlo'; 
		SET @Respuesta = -1 	                       
END
GO

-----------------------------------------CAMBIO CONTRASEÑA------------------------------------------------

USE [GD1C2015]
GO
CREATE PROCEDURE REZAGADOS.Cambio_Contrasenia (	@Id_Usuario NUMERIC(18,0),
												@ContraseniaNueva VARCHAR(255),
												@RespuestaMensaje VARCHAR(255) OUTPUT,
												@Respuesta NUMERIC(18,0) OUTPUT)
AS
BEGIN
	UPDATE REZAGADOS.Usuario SET Contrasenia = @ContraseniaNueva	WHERE Id_Usuario = @Id_Usuario;
	UPDATE REZAGADOS.Usuario SET Contrasenia_Modificada = 1 WHERE Id_Usuario = @Id_Usuario;
	SET @RespuestaMensaje = 'Contraseña cambiada correctamente!'
	SET @Respuesta = 1
END
GO

-----------------------------------------MODIFICAR NOMBRE FUNCIONALIDAD--------------------------------------------

USE [GD1C2015]
GO
CREATE PROCEDURE REZAGADOS.Modificar_Nombre_Funcionalidad(	@Nombre_Func VARCHAR(255),
															@Id_Func NUMERIC(18,0),
															@RespuestaMensaje VARCHAR(255) OUTPUT,
															@Respuesta NUMERIC(18,0) OUTPUT)
AS
BEGIN
	UPDATE REZAGADOS.Funcionalidad SET Nombre = @Nombre_Func WHERE Id_Funcionalidad=@Id_Func
END
GO

-----------------------------------------BAJA CUENTA------------------------------------------------

USE [GD1C2015]
GO
CREATE PROCEDURE REZAGADOS.Baja_Cuenta(		@Nro_Cuenta VARCHAR(255),
											@RespuestaMensaje VARCHAR(255) OUTPUT,
											@Respuesta NUMERIC(18,0) OUTPUT)
AS
BEGIN
UPDATE REZAGADOS.Cuenta 
SET Id_Estado=
	(SELECT e.Id_Estado 
	 FROM REZAGADOS.Estado_Cuenta e 
	 WHERE e.Nombre LIKE 'Inhabilitada') 
WHERE Cuenta.Id_Cuenta = @Nro_Cuenta
		SET @Respuesta = 1
		SET @RespuestaMensaje = 'Baja exitosa'
END
GO

-----------------------------------------ALTA CUENTA------------------------------------------------

USE [GD1C2015]
GO
CREATE PROCEDURE REZAGADOS.Alta_Cuenta(		@Nro_Cuenta VARCHAR(255),
											@RespuestaMensaje VARCHAR(255) OUTPUT,
											@Respuesta NUMERIC(18,0) OUTPUT)
AS
BEGIN
UPDATE REZAGADOS.Cuenta 
 SET Id_Estado=
	(SELECT e.Id_Estado 
	 FROM REZAGADOS.Estado_Cuenta e 
	 WHERE e.Nombre LIKE 'Habilitada')
 WHERE Cuenta.Id_Cuenta = @Nro_Cuenta
 		SET @Respuesta = 1
		SET @RespuestaMensaje = 'Alta exitosa'
END
GO

----------------------------------------CREAR CUENTA------------------------------------------------

USE [GD1C2015]
GO
CREATE PROCEDURE [REZAGADOS].[Crear_Cuenta](
										@Pais VARCHAR(255),
										@Moneda VARCHAR(255),
										@Fecha DATETIME,
										@Tipo VARCHAR(255),
										@Propietario NUMERIC(18,0),
										@RespuestaMensaje VARCHAR(255) OUTPUT,
										@Respuesta NUMERIC(18,0) OUTPUT)
AS
BEGIN
IF (@Tipo = 'Gratuito')
	BEGIN
		INSERT INTO REZAGADOS.Cuenta(Id_Cuenta, Id_Pais, Id_Tipo_Cuenta, Id_Usuario ,Id_Moneda, Id_Estado, Fecha_Creacion)
		VALUES ( (SELECT MAX(c1.Id_Cuenta)+1 FROM REZAGADOS.Cuenta c1 ),	
					@Pais,
					@Tipo,
					@Propietario,
					@Moneda,
					(SELECT e.Id_Estado FROM REZAGADOS.Estado_Cuenta e	WHERE e.Nombre LIKE 'Habilitada'),
					@Fecha)
	SET @Respuesta = 1
	SET @RespuestaMensaje = 'Creación exitosa'
	END
ELSE
INSERT INTO REZAGADOS.Cuenta(Id_Cuenta, Id_Pais, Id_Tipo_Cuenta, Id_Usuario,Id_Moneda, Id_Estado, Fecha_Creacion)
VALUES ((SELECT MAX(c1.Id_Cuenta)+1 FROM REZAGADOS.Cuenta c1 ),
@Pais, 
@Tipo, 
@Propietario,
@Moneda, 
(SELECT e.Id_Estado 
	 FROM REZAGADOS.Estado_Cuenta e 
	 WHERE e.Nombre LIKE 'Pendiente de activación'), @Fecha)
SET @RespuestaMensaje = 'Creación exitosa'
SET @Respuesta =  (SELECT Max(c1.Id_Cuenta) FROM REZAGADOS.Cuenta c1)
END
GO

----------------------------------------MODIFICAR COSTO CUENTA------------------------------------------------

USE [GD1C2015]
GO
CREATE PROCEDURE REZAGADOS.Modificar_Costo_Cuenta (	@Categoria VARCHAR(255),
													@Costo NUMERIC (18,0),
													@RespuestaMensaje VARCHAR(255) OUTPUT,
													@Respuesta NUMERIC(18,0) OUTPUT)
AS
BEGIN
IF EXISTS (SELECT Id_Tipo_Cuenta FROM REZAGADOS.TipoCuenta WHERE Categoria=@Categoria)
UPDATE REZAGADOS.TipoCuenta SET Costo = @Costo WHERE Categoria=@Categoria
SET @RespuestaMensaje = 'Modifición exitosa'
SET @Respuesta = 1
END
GO

----------------------------------------ESTADO CUENTA------------------------------------------

USE [GD1C2015]
GO
CREATE PROCEDURE [REZAGADOS].[Listar_Estado]
AS
BEGIN
	SET NOCOUNT ON;
	SELECT e.Id_Estado ID, e.Nombre DESCRIPCION, e.Habilitada HABILITADA
	FROM [REZAGADOS].Estado_Cuenta e
END
GO

--------------------------------------BUSCAR ESTADO ID---------------------------------------------

USE [GD1C2015]
GO
CREATE PROCEDURE [REZAGADOS].[Buscar_Estado_Id]
@id int
AS
BEGIN
	SET NOCOUNT ON;
	SELECT e.Id_Estado ID, e.Nombre NOMBRE, e.Habilitada HABILITADA
	FROM [REZAGADOS].Estado_Cuenta e
	WHERE e.Id_Estado = @id
END
GO

----------------------------------------------ALTA TARJETAS---------------------------------------------------

USE [GD1C2015]
GO
CREATE PROCEDURE REZAGADOS.Alta_Tarjeta(	@Nro_Tarjeta NUMERIC(18,0),
											@RespuestaMensaje VARCHAR(255) OUTPUT,
											@Respuesta NUMERIC(18,0) OUTPUT)
AS
BEGIN
UPDATE REZAGADOS.Tarjeta SET Habilitada=1 WHERE Tarjeta.Id_Tarjeta = @Nro_Tarjeta
SET @RespuestaMensaje = 'Alta exitosa'
SET @Respuesta = 1
END
GO

----------------------------------------------BAJA TARJETAS---------------------------------------------------

USE [GD1C2015]
GO
CREATE PROCEDURE REZAGADOS.Baja_Tarjeta(	@Id_Tarjeta NUMERIC(18,0),
											@RespuestaMensaje VARCHAR(255) OUTPUT,
											@Respuesta NUMERIC(18,0) OUTPUT)
AS
BEGIN
UPDATE REZAGADOS.Tarjeta SET Habilitada=0 WHERE Tarjeta.Id_Tarjeta = @Id_Tarjeta
SET @RespuestaMensaje = 'Baja exitosa'
SET @Respuesta = 1
END
GO

-------------------------------------------CREAR TARJETA-------------------------------------------------------

USE [GD1C2015]
GO
CREATE PROCEDURE REZAGADOS.Crear_Tarjeta(	@Id_Cliente NUMERIC(18,0),
											@Nro_Tarjeta VARCHAR(20),
											@Id_Emisor NUMERIC(18,0),
											@Fecha DATETIME,
											@Fecha_Venc DATETIME,
											@Codigo VARCHAR(255),
											@RespuestaMensaje VARCHAR(255) OUTPUT,
											@Respuesta NUMERIC(18,0) OUTPUT)
AS
BEGIN

	IF EXISTS (SELECT 1 FROM REZAGADOS.Tarjeta WHERE Numero=@Nro_Tarjeta)
	BEGIN
		SET @RespuestaMensaje = 'Ya existe la tarjeta'
		SET @Respuesta = -1
	END
	ELSE
		BEGIN TRY
			BEGIN TRANSACTION
				INSERT INTO REZAGADOS.Tarjeta (Id_Cliente, Numero, Id_Emisor ,Codigo_Seguridad, Fecha_Emision, Vencimiento)
				VALUES (@Id_Cliente, @Nro_Tarjeta, @Id_Emisor ,@Codigo, @Fecha, @Fecha_Venc)
				SET @Respuesta = (SELECT @@IDENTITY)
				SET @RespuestaMensaje = 'Se ingresó Exitosamente'
			COMMIT
		END TRY
		BEGIN CATCH
			SET @Respuesta = 1
			SET @RespuestaMensaje = ERROR_MESSAGE()
			ROLLBACK TRANSACTION
		END CATCH
	END
GO

-------------------------------------------MODIFICAR TARJETA----------------------------------------------------

USE [GD1C2015]
GO
CREATE PROCEDURE REZAGADOS.Modificar_Tarjeta(	@Id_Tarjeta NUMERIC(18,0),
												@Nro_Tarjeta VARCHAR(255),
												@Id_Emisor NUMERIC(18,0),
												@Fecha DATETIME,
												@Fecha_Venc DATETIME,
												@RespuestaMensaje VARCHAR(255) OUTPUT,
												@Respuesta NUMERIC(18,0) OUTPUT)
AS
BEGIN
	IF EXISTS (SELECT 1 FROM REZAGADOS.Tarjeta WHERE Numero=@Nro_Tarjeta AND Id_Tarjeta <> @Id_Tarjeta)
	BEGIN
		SET @RespuestaMensaje = 'Ya existe la tarjeta'
		SET @Respuesta = -1
	END
	ELSE
		BEGIN TRY
			BEGIN TRANSACTION
				PRINT @Nro_Tarjeta
				UPDATE REZAGADOS.Tarjeta SET	Numero = @Nro_Tarjeta,
												Fecha_Emision = @Fecha,
												Vencimiento = @Fecha_Venc,
												Id_Emisor = @Id_Emisor
				WHERE Id_Tarjeta = @Id_Tarjeta
				SET @Respuesta = 1
				SET @RespuestaMensaje = 'Datos Modificados Exitosamente'
			COMMIT
		END TRY
		BEGIN CATCH
			SET @Respuesta = 1
			SET @RespuestaMensaje = ERROR_MESSAGE()
			ROLLBACK TRANSACTION
		END CATCH
	END
GO

---------------------------------------DEPOSITAR---------------------------------------------------------------

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[REZAGADOS].[Depositar]') 
AND type in (N'P', N'PC'))
	DROP PROCEDURE REZAGADOS.Depositar;

USE [GD1C2015]
GO
CREATE PROCEDURE REZAGADOS.Depositar(
@Id_Cuenta NUMERIC(18,0),
@Importe NUMERIC(18,0),
@Id_Moneda NUMERIC(18,0),
@Id_Tarjeta NUMERIC(18,0), 
@Fecha DATETIME,
@Respuesta NUMERIC(18,0) OUTPUT,
@RespuestaMensaje VARCHAR(255) OUTPUT)
AS
BEGIN

	DECLARE @Id_Usuario NUMERIC(18,0) = (SELECT Id_Usuario FROM Cuenta WHERE @Id_Cuenta=Id_Cuenta)
	DECLARE @Id_Cliente NUMERIC(18,0) = (SELECT Id_Cliente FROM Cliente WHERE @Id_Usuario=Id_Usuario)

	IF (SELECT Habilitada FROM Cliente WHERE Id_Cliente=@Id_Cliente) = 0
	BEGIN
		SET @Respuesta = -1
		SET @RespuestaMensaje = 'Cliente Inhabilitado'
		RETURN
	END

	IF ((SELECT Id_Estado FROM Cuenta WHERE Id_Cuenta = @Id_Cuenta) = 3)
	BEGIN
		SET @Respuesta = -1
		SET @RespuestaMensaje = 'Cuenta Inhabilitada'
		RETURN
	END
	
	DECLARE @Vencimiento DATETIME
	DECLARE @Habiltiada BIT
	DECLARE @Id_Cliente_Tarjeta NUMERIC (18,0)
	 SELECT	@Vencimiento = Vencimiento,
			@Habiltiada = Habilitada,
			@Id_Cliente_Tarjeta = Id_Cliente
	   FROM Tarjeta WHERE @Id_Tarjeta=Id_Tarjeta

	IF (@Fecha > @Vencimiento)
	BEGIN
		SET @Respuesta = -1
		SET @RespuestaMensaje = 'Tarjeta Vencida'
		RETURN
	END
	
	IF (@Habiltiada = 0)
	BEGIN
		SET @Respuesta = -1
		SET @RespuestaMensaje = 'Tarjeta Inhabilitada'
		RETURN
	END

	IF (DATEADD(day, (SELECT Dias_Vigencia FROM REZAGADOS.TipoCuenta,REZAGADOS.Cuenta 
						WHERE	@Id_Cuenta=Cuenta.Id_Cuenta 
						AND		Cuenta.Id_Tipo_Cuenta=TipoCuenta.Id_Tipo_Cuenta), 
						(SELECT Fecha_Creacion FROM REZAGADOS.Cuenta WHERE Id_Cuenta=@Id_Cuenta))) > GETDATE()
	BEGIN
		UPDATE Cuenta SET Id_Estado = (SELECT Id_Estado FROM REZAGADOS.Estado_Cuenta WHERE Nombre = 'Cerrada')
		UPDATE Cuenta SET Fecha_Cierre = GETDATE()
		SET @Respuesta = -1
		SET @RespuestaMensaje = 'Cuenta Cerrada'
		RETURN
	END
	
	IF (@Id_Cliente_Tarjeta <> @Id_cliente)
		BEGIN
		SET @Respuesta = -1
		SET @RespuestaMensaje = 'La tarjeta seleccionada no pertenece al cliente'
		RETURN
	END
	
	IF (@Importe < 1)
		BEGIN
		SET @Respuesta = -1
		SET @RespuestaMensaje = 'El importe a depositar no puede ser menor a uno'
		RETURN
	END

	BEGIN TRY
		BEGIN TRANSACTION
			
			--Inserto la transaccion
			INSERT INTO REZAGADOS.Deposito (Id_Cuenta, Id_Tarjeta, Id_Moneda, Fecha, Importe)
			VALUES (@Id_Cuenta, @Id_Tarjeta , @Id_Moneda, @Fecha, @Importe)
			
			--Modifico el Saldo
			DECLARE @Saldo NUMERIC(18,2)
			SET @Saldo = (SELECT Saldo FROM Cuenta WHERE Id_Cuenta = @Id_Cuenta) + @Importe
			UPDATE REZAGADOS.Cuenta SET Saldo = @Saldo WHERE Id_Cuenta = @Id_Cuenta
								
			SET @Respuesta = @@IDENTITY
			SET @RespuestaMensaje = 'Deposito realizado'
		COMMIT
	END TRY
	BEGIN CATCH
		SET @Respuesta = -1
		SET @RespuestaMensaje = ERROR_MESSAGE()
		ROLLBACK TRANSACTION
	END CATCH
END
GO

-----------------------------------------RETIRO EFECTIVO--------------------------------------------------------------

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[REZAGADOS].[RetiroEfectivo]') 
AND type in (N'P', N'PC'))
	DROP PROCEDURE REZAGADOS.RetiroEfectivo;

USE [GD1C2015]
GO

CREATE PROCEDURE REZAGADOS.RetiroEfectivo(	@Id_Cuenta NUMERIC(18,0),
											@Id_Tipo_Documento NUMERIC(18,0),
											@Nro_Documento NUMERIC(18,0),
											@Importe NUMERIC(18,0),
											@Id_Moneda NUMERIC(18,0),
											@Fecha DATETIME,
											@Respuesta NUMERIC(18,0) OUTPUT,
											@RespuestaMensaje VARCHAR(255) OUTPUT)
AS
BEGIN
	
	DECLARE @Id_Cliente NUMERIC(18,0)
	DECLARE @Cliente_Id_Tipo_Documento NUMERIC (18,0)
	DECLARE @Cliente_Nro_Documento NUMERIC(18,0)
	 SELECT @Id_Cliente = c.Id_Cliente,
			@Cliente_Id_Tipo_Documento = c.Id_Tipo_Documento,
			@Cliente_Nro_Documento = c.Nro_Documento
	   FROM [REZAGADOS].[Cliente] c
	   JOIN REZAGADOS.Usuario u ON c.Id_Usuario = u.Id_Usuario
	   JOIN REZAGADOS.Cuenta cu ON u.Id_Usuario = cu.Id_Usuario
	   WHERE cu.Id_Cuenta = @Id_cuenta
					
	DECLARE @Id_Estado NUMERIC(18,0)
	DECLARE @Saldo NUMERIC(18,2)
	DECLARE @Id_Tipo_Cuenta NUMERIC(18,0)
	 SELECT	@Id_Estado = Id_Estado,
			@Saldo = Saldo,
			@Id_Tipo_Cuenta = Id_Tipo_Cuenta
	   FROM Cuenta WHERE @Id_Cuenta = Id_Cuenta
	   
	   
	
	IF (@Id_Tipo_Cuenta <> 4)
	BEGIN
		IF (DATEADD(day, (SELECT Dias_Vigencia FROM REZAGADOS.TipoCuenta, REZAGADOS.Cuenta 
							WHERE @Id_Cuenta=Cuenta.Id_Cuenta 
							AND Cuenta.Id_Tipo_Cuenta=TipoCuenta.Id_Tipo_Cuenta), 
							(SELECT Fecha_Creacion FROM REZAGADOS.Cuenta WHERE Id_Cuenta=@Id_Cuenta))) > GETDATE()
		BEGIN
			UPDATE Cuenta SET Id_Estado = (SELECT Id_Estado FROM REZAGADOS.Estado_Cuenta WHERE Nombre = 'Cerrada')
			UPDATE Cuenta SET Fecha_Cierre = GETDATE()
			SET @Respuesta = -1
			SET @RespuestaMensaje = 'Cuenta Cerrada'
			RETURN
		END
	END

	IF ((SELECT Habilitada FROM Cliente WHERE Id_Cliente=@Id_Cliente) = 0)
	BEGIN
		SET @Respuesta = -1
		SET @RespuestaMensaje = 'Cliente Inhabilitado'
		RETURN
	END

	IF (@Id_Tipo_Documento <> @Cliente_Id_Tipo_Documento OR @Nro_Documento <> @Cliente_Nro_Documento)
	BEGIN
		SET @Respuesta = -1
	    SET @RespuestaMensaje = 'Documento ingresado diferente al documento del usuario logueado'
	    RETURN
	END

	IF (@Id_Estado <> 4 )
	BEGIN
		SET @Respuesta = -1
		SET @RespuestaMensaje = 'Cuenta Inhabilitada o pendente de pago'
		RETURN
	END

	IF (@Saldo<=0)
	BEGIN
		SET @Respuesta = -1
		SET @RespuestaMensaje = 'Cuenta sin saldo'
		RETURN
	END

	IF (@Importe > @Saldo)
	BEGIN
		SET @Respuesta = -1
		SET @RespuestaMensaje = 'Importe mayor al saldo'
		RETURN
	END
	
	IF (@Id_Moneda <> 1)
	BEGIN
		SET @Respuesta = -1
		SET @RespuestaMensaje = 'Importe no expresado en dolares'
		RETURN
	END
	
	BEGIN TRY
		BEGIN TRANSACTION
			
			-- Inserto el retiro
			INSERT INTO REZAGADOS.Retiro (Id_Cuenta, Fecha, Id_Moneda, Importe)
			VALUES (@Id_Cuenta, @Fecha, @Id_Moneda, @Importe)
			SET @Respuesta = @@IDENTITY

			-- Creo el cheque
			INSERT INTO REZAGADOS.Cheque (Id_Retiro,Fecha, Id_Moneda, Importe)
			VALUES ( @@IDENTITY,@Fecha, @Id_Moneda, @Importe)
			
			--Modifico el saldo
			SET @Saldo = (SELECT Saldo FROM Cuenta WHERE Id_Cuenta = @Id_Cuenta) - @Importe
			UPDATE REZAGADOS.Cuenta SET Saldo = @Saldo WHERE Id_Cuenta = @Id_Cuenta 
			
			SET @RespuestaMensaje = 'Retiro realizado y Cheque generado'
		COMMIT
	END TRY
	BEGIN CATCH
		SET @Respuesta = -1
		SET @RespuestaMensaje = ERROR_MESSAGE()
		ROLLBACK TRANSACTION
	END CATCH
END
GO

----------------------------------------------TRANSFERENCIA ENTRE CUENTAS-------------------------------------------------------

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[REZAGADOS].[TransferenciaEntreCuentas]') AND type in (N'P', N'PC'))
	DROP PROCEDURE REZAGADOS.TransferenciaEntreCuentas;

USE [GD1C2015]
GO
CREATE PROCEDURE REZAGADOS.TransferenciaEntreCuentas (	@Cuenta_Origen NUMERIC(18,0),
														@Cuenta_Destino NUMERIC(18,0),
														@Importe NUMERIC(18,0),
														@Fecha DATETIME,
														@Respuesta NUMERIC(18,0) OUTPUT,
														@RespuestaMensaje VARCHAR(255) OUTPUT)
AS
BEGIN

	DECLARE @Id_Cliente NUMERIC(18,0) 
	DECLARE @Habilitado BIT
	SELECT  @Id_Cliente = c.Id_Cliente,
			@Habilitado = c.HAbilitada
	   FROM [REZAGADOS].[Cliente] c
	   JOIN REZAGADOS.Usuario u ON c.Id_Usuario = u.Id_Usuario
	   JOIN REZAGADOS.Cuenta cu ON u.Id_Usuario = cu.Id_Usuario
	   WHERE cu.Id_Cuenta = @Cuenta_Origen
	   
	DECLARE @Cuenta_Origen_Id_Tipo NUMERIC(18,0)
	DECLARE @Cuenta_Origen_Id_Estado NUMERIC(18,0)
	DECLARE @Cuenta_Origen_Saldo NUMERIC(18,2)
	DECLARE @Cuenta_Origen_Habilitada NUMERIC(18,0)
	SELECT  @Cuenta_Origen_Id_Estado = Id_Estado,
			@Cuenta_Origen_Id_Tipo = Id_Tipo_Cuenta,
			@Cuenta_Origen_Saldo = Saldo,
			@Cuenta_Origen_Habilitada = Id_Estado	
	   FROM REZAGADOS.Cuenta WHERE Id_Cuenta = @Cuenta_Origen
	
	DECLARE @Cuenta_Destino_Id_Estado NUMERIC(18,0)
	SELECT  @Cuenta_Destino_Id_Estado = Id_Estado FROM REZAGADOS.Cuenta WHERE Id_Cuenta = @Cuenta_Destino

	IF (@Cuenta_Origen_Id_Tipo <> 4)
	BEGIN
		IF (DATEADD(day, (SELECT Dias_Vigencia FROM REZAGADOS.TipoCuenta, REZAGADOS.Cuenta WHERE @Cuenta_Origen=Cuenta.Id_Cuenta AND Cuenta.Id_Tipo_Cuenta=TipoCuenta.Id_Tipo_Cuenta), (SELECT Fecha_Creacion FROM REZAGADOS.Cuenta WHERE Id_Cuenta=@Cuenta_Origen))) > GETDATE()
		BEGIN
			UPDATE Cuenta SET Id_Estado = (SELECT Id_Estado FROM REZAGADOS.Estado_Cuenta WHERE Nombre = 'Cerrada')
			UPDATE Cuenta SET Fecha_Cierre = GETDATE()
			SET @Respuesta = -1
			SET @RespuestaMensaje = 'Cuenta Cerrada'
			RETURN
		END
	END

	IF (@Cuenta_Origen_Habilitada = 3 )
	BEGIN
		SET @Respuesta = -1
		SET @RespuestaMensaje = 'Cuenta Inhabilitada'
		RETURN
	END
	
		IF (@Habilitado = 0 )
	BEGIN
		SET @Respuesta = -1
		SET @RespuestaMensaje = 'Cliente Inhabilitado'
		RETURN
	END
	
	-- si la cuenta destino esta cerrada o pendiente de activacion
	IF ( @Cuenta_Destino_Id_Estado = 1 OR @Cuenta_Destino_Id_Estado = 2 )
	BEGIN
		SET @Respuesta = -1		
		SET @RespuestaMensaje = 'Cuenta destino cerrada o pendiente de activacion'
		RETURN
	END

	IF (@Importe<=0)
	BEGIN
		SET @Respuesta = -1			
		SET @RespuestaMensaje = 'El Importe no puede ser menor o igual a cero'
		RETURN
	END
	
	IF (@Importe > @Cuenta_Origen_Saldo )
	BEGIN
		SET @Respuesta = -1			
		SET @RespuestaMensaje = 'El Importe a transferir no puede ser mayor al saldo'
		RETURN
	END
	

	BEGIN TRY
		BEGIN TRANSACTION
		
			UPDATE REZAGADOS.Cuenta SET
			Saldo=Saldo-@Importe
			WHERE Id_Cuenta=@Cuenta_Origen	
				
			UPDATE REZAGADOS.Cuenta SET
			Saldo=Saldo+@Importe
			WHERE Id_Cuenta=@Cuenta_Destino						
		
			INSERT INTO REZAGADOS.Transferencia (Id_Cuenta_Emi, Id_Cuenta_Dest, Fecha, Importe)
			VALUES (@Cuenta_Origen, @Cuenta_Destino, @Fecha, @Importe) 		

		COMMIT TRANSACTION
		
		IF ((SELECT Id_Usuario from Cuenta WHERE @Cuenta_Origen=Id_Cuenta)=(SELECT Id_Usuario from Cuenta WHERE @Cuenta_Destino=Id_Cuenta))
		BEGIN
			SET @Respuesta = @@IDENTITY
			SET @RespuestaMensaje = 'Transferencia realizada sin costo'
		END
		ELSE
			BEGIN
				SET @Respuesta = @@IDENTITY
				SET @RespuestaMensaje = 'Transferencia realizada con costo'
			END
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
		SET @Respuesta = -1
		SET @RespuestaMensaje = ERROR_MESSAGE()
	END CATCH
END
GO

----------------------------------------------LISTAR ROL-------------------------------------------------------

USE [GD1C2015]
GO
CREATE PROCEDURE [REZAGADOS].[Listar_Rol]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT r.Id_Rol ID, r.Nombre NOMBRE, r.Habilitada HABILITADO
	FROM [REZAGADOS].Rol r 
END
GO

----------------------------------------------LISTAR PAIS-------------------------------------------------------

USE [GD1C2015]
GO
CREATE PROCEDURE [REZAGADOS].[Listar_Pais]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT p.Id_Pais ID, p.Descripcion NOMBRE
	FROM [REZAGADOS].Pais p 
END
GO

----------------------------------------------TOP 5 DEPOSITOS-------------------------------------------------------

USE [GD1C2015]
GO
CREATE PROCEDURE REZAGADOS.Top5Depositos (@Cuenta NUMERIC(18,0))
AS
BEGIN
   SELECT TOP 5 D.Id_Deposito ID,cli.Id_Cliente DEPOSITANTE, 
D.Codigo NOMBRE, D.Id_Cuenta CUENTA_DESTINO, D.Id_Tarjeta TARJETA, 
D. Id_Pais PAIS,
 D.Id_Moneda MONEDA, D.Fecha FECHA, D.Importe IMPORTE, 
 T.Numero TARJETA 
    FROM REZAGADOS.Deposito d
    JOIN REZAGADOS.Moneda m ON d.Id_Moneda = m.Id_Moneda
    JOIN REZAGADOS.Tarjeta t ON d.Id_Tarjeta = t.Id_Tarjeta
    JOIN REZAGADOS.Cuenta cu ON d.Id_Cuenta = cu.Id_Cuenta
    JOIN REZAGADOS.Usuario u ON u.Id_Usuario = cu.Id_Usuario
    JOIN REZAGADOS.Cliente cli ON cli.Id_Usuario = u.Id_Usuario
    WHERE d.Id_Cuenta = @Cuenta
    ORDER BY Fecha DESC, Id_Deposito DESC
END
GO

----------------------------------------------TOP 5 RETIROS-------------------------------------------------------

USE [GD1C2015]
GO
CREATE PROCEDURE REZAGADOS.Top5Retiros ( @Cuenta NUMERIC(18,0))
AS
BEGIN

SELECT TOP 5 R.Id_Retiro ID, R.Id_Cuenta CUENTA, R.Fecha FECHA, R.Importe IMPORTE, Che.Id_Cheque CHEQUE, Che.Id_Banco BANCO, Che.Id_Moneda MONEDA
FROM REZAGADOS.Retiro R, REZAGADOS.Cliente C, REZAGADOS.Cuenta cu, REZAGADOS.Usuario u, REZAGADOS.Cheque che
WHERE Cu.Id_Cuenta = @Cuenta
AND R.Id_Cuenta = Cu.Id_Cuenta
AND Cu.Id_Usuario = u.Id_Usuario
AND u.Id_Usuario = C.Id_Usuario
AND che.Id_Retiro = r.Id_Retiro
ORDER BY R.Fecha DESC, R.Id_Retiro DESC

END
GO

----------------------------------------------TOP 10 TRANSFERENCIAS-------------------------------------------------------

USE [GD1C2015]
GO
CREATE PROCEDURE REZAGADOS.Top10Transferencias (@Cuenta NUMERIC(18,0))
AS
BEGIN
   SELECT TOP 10 T.Id_Transferencia ID, T.Id_Cuenta_Emi CUENTA_ORIGEN, T.Id_Cuenta_Dest CUENTA_DESTINO,
    T.Fecha FECHA, T.Id_Moneda MONEDA, T.Importe IMPORTE
    FROM REZAGADOS.Transferencia T, REZAGADOS.Cliente C, REZAGADOS.Cuenta cu, REZAGADOS.Usuario u
	WHERE Cu.Id_Cuenta = @Cuenta
	AND T.Id_Cuenta_Emi = Cu.Id_Cuenta
	AND Cu.Id_Usuario = u.Id_Usuario
	AND u.Id_Usuario = C.Id_Usuario
	ORDER BY T.Fecha DESC, T.Id_Transferencia DESC

END
GO

-------------------------------------------------BUSCAR USER ID----------------------------------------------

USE [GD1C2015]
GO

CREATE PROCEDURE [REZAGADOS].[Buscar_User_ID]
@Id numeric(18, 0) = null
AS
BEGIN
	SET NOCOUNT ON;

	SELECT u.Id_Usuario ID, u.Nombre NOMBRE, u.Contrasenia PASS, u.Cantidad_Intentos_Fallidos INTENTOS_FALLIDOS, 
			u.contrasenia_modificada PASS_MODIFICADA, u.fecha_creacion FECHA_CREACION, u.fecha_ult_modif FECHA_ULT_MODIFICACION,
			u.pregunta PREGUNTA, u.respuesta RESPUESTA, u.habilitada HABILITADA
	FROM [REZAGADOS].Usuario u 
	WHERE u.Id_usuario = @Id
END
GO

-------------------------------------------------LISTAR CUENTA-------------------------------------------------

USE [GD1C2015]
GO

CREATE PROCEDURE [REZAGADOS].[Listar_Cuenta]
AS
BEGIN
	SET NOCOUNT ON;
	SELECT c.Id_Cuenta ID, c.Id_Usuario PROPIETARIO_ID, c.Id_Pais PAIS,c.Id_Tipo_Cuenta TIPO_CUENTA,
	c.Id_Moneda MONEDA, c.Id_Estado ESTADO, c.Fecha_Cierre FECHA_CIERRE, c.Fecha_Creacion FECHA_CREACION,
	cl.Nombre PROPIETARIO_NOMBRE, cl.Apellido PROPIETARIO_APELLIDO
	FROM  [REZAGADOS].Cuenta c 
	JOIN [REZAGADOS].Usuario u ON c.Id_Usuario = u.Id_Usuario
	JOIN [REZAGADOS].Cliente cl ON u.Id_Usuario = cl.Id_Usuario
END
GO

----------------------------------------------LISTAR CUENTA USUARIO------------------------------------------

USE [GD1C2015]
GO

CREATE PROCEDURE [REZAGADOS].[Listar_Cuenta_Usuario]
@Id_Usuario int
AS
BEGIN
	SET NOCOUNT ON;
	SELECT c.Id_Cuenta ID, c.Id_Usuario PROPIETARIO_ID, c.Id_Pais PAIS,c.Id_Tipo_Cuenta TIPO_CUENTA,
	c.Id_Moneda MONEDA, c.Id_Estado ESTADO, c.Fecha_Cierre FECHA_CIERRE, c.Fecha_Creacion FECHA_CREACION,
	cl.Nombre PROPIETARIO_NOMBRE, cl.Apellido PROPIETARIO_APELLIDO
	FROM  [REZAGADOS].Cuenta c 
	JOIN [REZAGADOS].Usuario u ON c.Id_Usuario = u.Id_Usuario
	JOIN [REZAGADOS].Cliente cl ON u.Id_Usuario = cl.Id_Usuario
	WHERE c.Id_Usuario = @Id_Usuario
END
GO

---------------------------------------------LISTAR CUENTA CLIENTE--------------------------------------------

USE [GD1C2015]
GO

CREATE PROCEDURE [REZAGADOS].[Listar_Cuenta_Cliente]
@Id_Cliente NUMERIC(18,0)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT	c.Id_Cuenta ID,
			c.Id_Usuario PROPIETARIO_ID,
			c.Id_Pais PAIS,
			c.Id_Tipo_Cuenta TIPO_CUENTA,
			c.Id_Moneda MONEDA,
			c.Id_Estado ESTADO,
			c.Fecha_Cierre FECHA_CIERRE, 
			c.Saldo SALDO,
			c.Fecha_Creacion FECHA_CREACION,
			cl.Nombre PROPIETARIO_NOMBRE,
			cl.Apellido PROPIETARIO_APELLIDO
	FROM  [REZAGADOS].Cuenta c 
	JOIN [REZAGADOS].Usuario u ON c.Id_Usuario = u.Id_Usuario
	JOIN [REZAGADOS].Cliente cl ON u.Id_Usuario = cl.Id_Usuario
	WHERE cl.Id_Cliente = @Id_Cliente
END
GO

-----------------------------------------LISTAR CLIENTE ID USUARIO-------------------------------------

USE [GD1C2015]
GO

CREATE PROCEDURE [REZAGADOS].[Listar_Cliente_ID_Usuario]
@Id_Usuario NUMERIC(18,0)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT c.Id_Cliente ID, c.Nombre NOMBRE, c.Apellido APELLIDO,
	c.Id_Usuario USUARIO, c.Id_Tipo_Documento DOCUMENTO, c.Nro_Documento NRO_DOCUMENTO,
	c.Id_Pais PAIS,	c.Direccion_Calle DIRECCION_CALLE, c.Direccion_Numero_Calle DIRECCION_NRO,
	c.Direccion_Piso DIRECCION_PISO, c.Direccion_Departamento DIRECCION_DEPTO, 
	c.Fecha_Nacimiento FECHA_NACIMIENTO, c.Mail EMAIL, c.Localidad LOCALIDAD,
	c.Habilitada HABILITADA,c.Id_Nacionalidad NACIONALIDAD
	FROM  [REZAGADOS].Cliente c 
	JOIN [REZAGADOS].Usuario u ON c.Id_Usuario = u.Id_Usuario
	WHERE c.Id_Usuario = @Id_Usuario
	AND c.Habilitada = 1
END
GO

----------------------------------------------LISTAR CLIENTE----------------------------------------------------

USE [GD1C2015]
GO

CREATE PROCEDURE [REZAGADOS].[Listar_Cliente]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT c.Id_Cliente ID, c.Nombre NOMBRE, c.Apellido APELLIDO,
	c.Id_Usuario USUARIO, c.Id_Tipo_Documento DOCUMENTO, c.Nro_Documento NRO_DOCUMENTO,
	c.Id_Pais PAIS,	c.Direccion_Calle DIRECCION_CALLE, c.Direccion_Numero_Calle DIRECCION_NRO,
	c.Direccion_Piso DIRECCION_PISO, c.Direccion_Departamento DIRECCION_DEPTO, 
	c.Fecha_Nacimiento FECHA_NACIMIENTO, c.Mail EMAIL, c.Localidad LOCALIDAD,
	c.Habilitada HABILITADA,c.Id_Nacionalidad NACIONALIDAD
	FROM  [REZAGADOS].Cliente c 
END
GO

---------------------------------------------BUSCAR CLIENTE ID----------------------------------------------------

USE [GD1C2015]
GO

CREATE PROCEDURE [REZAGADOS].[Buscar_Cliente_ID]
@Id int
AS
BEGIN
	SET NOCOUNT ON;

SELECT c.Id_Cliente ID, c.Nombre NOMBRE, c.Apellido APELLIDO,
	c.Id_Usuario USUARIO, c.Id_Tipo_Documento DOCUMENTO, c.Nro_Documento NRO_DOCUMENTO,
	c.Id_Pais PAIS,	c.Direccion_Calle DIRECCION_CALLE, c.Direccion_Numero_Calle DIRECCION_NRO,
	c.Direccion_Piso DIRECCION_PISO, c.Direccion_Departamento DIRECCION_DEPTO, 
	c.Fecha_Nacimiento FECHA_NACIMIENTO, c.Mail EMAIL, c.Localidad LOCALIDAD,
	c.Habilitada HABILITADA,c.Id_Nacionalidad NACIONALIDAD
	FROM  [REZAGADOS].Cliente c 
	WHERE c.Id_Cliente = @Id
	AND	  c.Habilitada = 1
END
GO

--------------------------------------------BUSCAR PAIS ID-------------------------------------------

USE [GD1C2015]
GO

CREATE PROCEDURE [REZAGADOS].[Buscar_Pais_Id]
@Id int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT p.Id_Pais ID, p.Descripcion NOMBRE
	FROM [REZAGADOS].Pais p 
	WHERE p.Id_Pais = @Id
END
GO

-------------------------------------------------------------
USE [GD1C2015]
GO

CREATE PROCEDURE [REZAGADOS].[Listar_Tarjeta]
@Id decimal 
AS
BEGIN

SELECT	t.Id_Tarjeta ID,
t.Id_Cliente		ID_CLIENTE,
t.Numero			NUMERO,
t.Id_Emisor			EMISOR_ID,
e.Nombre			EMISOR_NOMBRE,
t.Codigo_Seguridad	CODIGO,
t.Fecha_Emision		EMISION,
t.Vencimiento		VENCIMIENTO,
t.Habilitada		HABILITADA
FROM REZAGADOS.Tarjeta t
JOIN REZAGADOS.Emisor e ON t.Id_Emisor = e.ID_Emisor

END

GO
----------------------------------------------------------
USE [GD1C2015]
GO

CREATE PROCEDURE [REZAGADOS].[Buscar_Tarjeta_ID]
@Id decimal 
AS
BEGIN

SELECT	t.Id_Tarjeta ID,
t.Id_Cliente		ID_CLIENTE,
t.Numero			NUMERO,
t.Id_Emisor			EMISOR_ID,
e.Nombre			EMISOR_NOMBRE,
t.Codigo_Seguridad	CODIGO,
t.Fecha_Emision		EMISION,
t.Vencimiento		VENCIMIENTO,
t.Habilitada		HABILITADA
FROM REZAGADOS.Tarjeta t
JOIN REZAGADOS.Emisor e ON t.Id_Emisor = e.ID_Emisor
WHERE t.Id_Tarjeta = @Id   
END

GO

------------------------------------------------ROLES--------------------------------------------------------------------
----------------------------------------------LISTAR ROLES USUARIO-------------------------------------------------------

IF OBJECT_ID ('REZAGADOS.[Listar_Rol_Usuario]') IS NOT NULL
    DROP PROCEDURE REZAGADOS.[Listar_Rol_Usuario]

USE [GD1C2015]
GO
CREATE PROCEDURE [REZAGADOS].[Listar_Rol_Usuario]
@Id NUMERIC(18,0),
@Habilitados BIT =NULL
AS
BEGIN
	SET NOCOUNT ON;
	
	DECLARE @SqlCommand VARCHAR(MAX)

	SET @SqlCommand = '
	SELECT r.Id_Rol ID, r.Nombre NOMBRE , r.Habilitada HABILITADO
	FROM [REZAGADOS].Rol r 
	JOIN [REZAGADOS].UsuarioXRol ur ON r.Id_Rol = ur.Id_Rol
	WHERE ur.Id_Usuario = '+ CAST(@Id AS VARCHAR(MAX))
	
	IF(@Habilitados IS NOT NULL)
	BEGIN
		SET @SqlCommand = @SqlCommand + ' AND r.Habilitada = 1'
	END
	
	EXEC(@sqlCommand)	
END
GO

----------------------------------------------CREAR ROL------------------------------------------------------

IF OBJECT_ID ('REZAGADOS.Crear_Rol') IS NOT NULL
    DROP PROCEDURE REZAGADOS.Crear_Rol

USE [GD1C2015]
GO
CREATE PROCEDURE REZAGADOS.Crear_Rol(	@Nombre_Rol NVARCHAR(255),
										@Respuesta NUMERIC(18,0) OUTPUT,
										@RespuestaMensaje VARCHAR(255) OUTPUT)
AS
BEGIN
	IF EXISTS(SELECT * FROM REZAGADOS.Rol WHERE Rol.Nombre = @Nombre_Rol)
	BEGIN
		SET @Respuesta = -1
		SET @RespuestaMensaje = 'Ya existe un Rol con ese Nombre'
	END
	ELSE
	BEGIN
		BEGIN TRY
			INSERT INTO REZAGADOS.Rol VALUES (@Nombre_Rol, 1)
			SET @Respuesta = (SELECT Id_Rol FROM REZAGADOS.Rol WHERE Rol.Nombre = @Nombre_Rol)
			SET @RespuestaMensaje = 'Rol Creado exitosamente'
		END TRY
		BEGIN CATCH
			SET @Respuesta = -1
		SET @RespuestaMensaje = 'No se pudo crear el rol'
		END CATCH
	END
END
GO

----------------------------------------------BAJA ROL------------------------------------------------

IF OBJECT_ID ('REZAGADOS.Baja_Rol') IS NOT NULL
    DROP PROCEDURE REZAGADOS.Baja_Rol

USE [GD1C2015]
GO
CREATE PROCEDURE REZAGADOS.Baja_Rol(@Id_Rol NUMERIC(18,09),
									@Respuesta NUMERIC(18,0) OUTPUT,
									@RespuestaMensaje VARCHAR(255) OUTPUT)
AS
BEGIN
	BEGIN TRY
		UPDATE REZAGADOS.Rol SET Habilitada=0 WHERE Id_Rol=@Id_Rol
		SET @Respuesta = 1
		SET @RespuestaMensaje = 'Rol Dado de Baja'
	END TRY
	BEGIN CATCH
		SET @Respuesta = -1
		SET @RespuestaMensaje = 'El Rol no se pudo dar de baja'
	END CATCH
END
GO

-----------------------------------------------ALTA ROL------------------------------------------------

IF OBJECT_ID ('REZAGADOS.Alta_Rol') IS NOT NULL
    DROP PROCEDURE REZAGADOS.Alta_Rol

USE [GD1C2015]
GO
CREATE PROCEDURE REZAGADOS.Alta_Rol(	@Id_Rol NUMERIC(18,09),
										@Respuesta NUMERIC(18,0) OUTPUT,
										@RespuestaMensaje VARCHAR(255) OUTPUT)
AS
BEGIN
	BEGIN TRY
			UPDATE REZAGADOS.Rol SET Habilitada=1 WHERE Id_Rol=@Id_Rol
			SET @Respuesta = 1
			SET @RespuestaMensaje = 'Rol Dado de Alta'
		END TRY
		BEGIN CATCH
			SET @Respuesta = -1
			SET @RespuestaMensaje = 'El Rol no se pudo dar de Alta'
		END CATCH
	END
GO

---------------------------------------------MODIFICAR ROL------------------------------------------------

IF OBJECT_ID ('REZAGADOS.Modificar_Rol') IS NOT NULL
    DROP PROCEDURE REZAGADOS.Modificar_Rol

GO
CREATE PROCEDURE REZAGADOS.Modificar_Rol (
	@Id_Rol NUMERIC(18,0),
	@Nombre_Rol VARCHAR(255),
	@Funcionalidades IdLista READONLY,
	@Respuesta NUMERIC(18,0) OUTPUT,
	@RespuestaMensaje VARCHAR(255) OUTPUT)
AS
SET NOCOUNT ON
BEGIN TRY
	BEGIN TRANSACTION
		BEGIN	
			-- quito todas las funcionalidades del rol
			DELETE FROM REZAGADOS.FuncionalidadXRol WHERE Id_Rol = @Id_Rol
			
			-- asigno las funcionalidaes enviadas
			INSERT INTO REZAGADOS.FuncionalidadXRol (Id_Rol,Id_Funcionalidad) 
				SELECT @Id_Rol,Id_Fila FROM @Funcionalidades;
			
			-- modifico el nombre del Rol
			UPDATE REZAGADOS.Rol SET Nombre = @Nombre_Rol WHERE Id_Rol = @Id_Rol
			
			SET @Respuesta = 1
			SET @RespuestaMensaje = 'Rol Modificado exitosamente'
		END
	COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
		SET @Respuesta = - 1
		SET @RespuestaMensaje =  'No se pudo modificar el Rol'
	END CATCH
GO

--------------------------------------------------ASIGNAR ROL------------------------------------------------

USE [GD1C2015]
IF OBJECT_ID ('REZAGADOS.Asignar_Rol') IS NOT NULL
    DROP PROCEDURE REZAGADOS.Asignar_Rol

GO
CREATE PROCEDURE REZAGADOS.Asignar_Rol (	@Id_Usuario NUMERIC(18,0),
											@Id_Rol NUMERIC(18,0),
											@Respuesta NUMERIC(18,0) OUTPUT,
											@RespuestaMensaje VARCHAR(255) OUTPUT)
AS 
BEGIN 
	BEGIN TRY
		BEGIN TRANSACTION      
			INSERT INTO REZAGADOS.UsuarioXRol(Id_Usuario,Id_Rol) 
			VALUES (@Id_Usuario,@Id_Rol)
		COMMIT TRANSACTION
		SET @Respuesta = 1
		SET @RespuestaMensaje = 'Rol Asignado exitosamente'
	END TRY
	BEGIN CATCH 
		ROLLBACK TRANSACTION
		SET @Respuesta = -1
		SET @RespuestaMensaje = 'Ese Rol ya se encuentra asignado a ese usuario'
	END CATCH   
END
GO

------------------------------------------------DESASIGNAR ROL------------------------------------------------

USE [GD1C2015]
IF OBJECT_ID ('REZAGADOS.Desasignar_Rol') IS NOT NULL
    DROP PROCEDURE REZAGADOS.Desasignar_Rol
    
GO
CREATE PROCEDURE REZAGADOS.Desasignar_Rol(	@Id_Usuario NUMERIC(18,0),
											@Id_Rol NUMERIC(18,0),
											@Respuesta NUMERIC(18,0) OUTPUT,
											@RespuestaMensaje VARCHAR(255) OUTPUT)
AS
	BEGIN TRY
		BEGIN TRANSACTION
			BEGIN
				DELETE FROM REZAGADOS.UsuarioXRol WHERE Id_Rol= @Id_Rol  AND Id_Usuario = @Id_Usuario
				SET @Respuesta = 1
				SET @RespuestaMensaje = 'Rol Desasignado exitosamente'
			END
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		SET @Respuesta = -1
		SET @RespuestaMensaje = 'El Rol no se pudo desasignar'
		ROLLBACK TRANSACTION
	END CATCH
GO


--------------------------------------------------BUSCAR ROL ID-------------------------------------------

USE [GD1C2015]
GO
CREATE PROCEDURE [REZAGADOS].[Buscar_Rol_Id]
@Id NUMERIC(18,0)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT r.Id_Rol ID, r.Nombre NOMBRE, r.Habilitada HABILITADO
	FROM [REZAGADOS].Rol r 
	WHERE r.Id_Rol = @Id
END
GO

--------------------------------------------------BUSCAR ROL FILTROS-------------------------------------------

USE [GD1C2015]
IF OBJECT_ID ('REZAGADOS.Buscar_Rol_Filtros') IS NOT NULL
    DROP PROCEDURE REZAGADOS.Buscar_Rol_Filtros

GO
CREATE PROCEDURE [REZAGADOS].[Buscar_Rol_Filtros] (@Nombre VARCHAR(MAX)=NULL, @Id_Rol NUMERIC(18,0)=NULL)
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @sqlCommand VARCHAR(MAX)
	DECLARE @sqlWhere VARCHAR(MAX)

	SET @sqlCommand = '	SELECT r.Id_Rol ID, r.Nombre NOMBRE, r.Habilitada HABILITADO
						FROM [REZAGADOS].Rol r '
	SET @sqlWhere = ''
	
	IF(@Id_Rol IS NOT NULL)
	BEGIN
		SET @sqlWhere = @sqlWhere + ' AND Id_Rol = ' + CAST(@Id_Rol AS VARCHAR(MAX))
	END
	
	IF(@Nombre IS NOT NULL)
	BEGIN
		SET @sqlWhere = @sqlWhere + ' AND Nombre LIKE  ''%'+@Nombre+'%'''
	END
	
	IF (@sqlWhere <> '')
	BEGIN
		SET @sqlWhere = ' WHERE ' + SUBSTRING (@sqlWhere, 5, Len(@sqlWhere)  )
		SET @sqlCommand = @sqlCommand + @sqlWhere
	END
	EXEC(@sqlCommand)
END
GO

----------------------------------------------LISTAR FUNCIONALIDAD ROL-------------------------------------------------------

USE [GD1C2015]
IF OBJECT_ID ('REZAGADOS.Listar_Funcionalidad_Rol') IS NOT NULL
    DROP PROCEDURE REZAGADOS.Listar_Funcionalidad_Rol

GO
CREATE PROCEDURE [REZAGADOS].[Listar_Funcionalidad_Rol]
@id NUMERIC(18,0),
@Habilitados BIT=NULL
AS
BEGIN
	SET NOCOUNT ON;
	
	DECLARE @SqlCommand VARCHAR(MAX)
	
	SET @SqlCommand = 'SELECT f.Id_Funcionalidad ID, f.Nombre NOMBRE , f.Habilitada HABILITADA
						 FROM [REZAGADOS].Funcionalidad f 
						 JOIN [REZAGADOS].FuncionalidadXRol rf ON f.Id_Funcionalidad = rf.Id_Funcionalidad
						WHERE rf.Id_Rol = '+ CAST(@Id AS VARCHAR(MAX))

	IF(@Habilitados IS NOT NULL)
	BEGIN
		SET @SqlCommand = @SqlCommand + ' AND f.Habilitada = 1'
	END
	
	EXEC(@sqlCommand)
	
END
GO

----------------------------------------------LISTAR FUNCIONALIDAD-------------------------------------------------------

USE [GD1C2015]
GO
CREATE PROCEDURE [REZAGADOS].[Listar_Funcionalidad]
AS
BEGIN
SELECT	f.Id_Funcionalidad ID,
		f.Nombre NOMBRE ,
		f.Habilitada HABILITADA
	FROM [REZAGADOS].Funcionalidad f 
END
GO

-----------------------------------------LISTAR CUENTA TIPO----------------------------------------------------

USE [GD1C2015]
GO
CREATE PROCEDURE [REZAGADOS].Listar_CuentaTipo 
AS
BEGIN
SELECT	ct.Id_Tipo_Cuenta ID,
		ct.Categoria NOMBRE,
		ct.Costo COSTO		,
		ct.Dias_Vigencia VIGENCIA
	FROM [REZAGADOS].TipoCuenta ct 
END
GO
---------------------------------------Buscar_Cuenta_ID---------------------------------------------------------------
USE [GD1C2015]
GO

CREATE PROCEDURE [REZAGADOS].[Buscar_Cuenta_ID]
@Id numeric(18, 0) = null
AS
BEGIN
	SET NOCOUNT ON;
	SELECT c.Id_Cuenta ID, c.Id_Usuario PROPIETARIO_ID, c.Id_Pais PAIS,c.Id_Tipo_Cuenta TIPO_CUENTA,
	c.Id_Moneda MONEDA, c.Id_Estado ESTADO, c.Fecha_Cierre FECHA_CIERRE, c.Fecha_Creacion FECHA_CREACION,
	cl.Nombre PROPIETARIO_NOMBRE, cl.Apellido PROPIETARIO_APELLIDO
	FROM  [REZAGADOS].Cuenta c 
	JOIN [REZAGADOS].Usuario u ON c.Id_Usuario = u.Id_Usuario
	JOIN [REZAGADOS].Cliente cl ON u.Id_Usuario = cl.Id_Usuario
	WHERE c.Id_Cuenta = @Id
END

GO
----------------------------------------BUSCAR CUENTA TIPO ID---------------------------------------------------------

USE [GD1C2015]
GO

CREATE PROCEDURE [REZAGADOS].[Buscar_CuentaTipo_ID] 
@Id NUMERIC(18,0)
AS
BEGIN
SELECT	ct.Id_Tipo_Cuenta ID,
		ct.Categoria NOMBRE,
		ct.Costo COSTO		,
		ct.Dias_Vigencia VIGENCIA
	FROM [REZAGADOS].TipoCuenta ct 
	WHERE ct.Id_Tipo_Cuenta = @Id
END
GO

-----------------------------------------LISTAR DOCUMENTO------------------------------------------------------

USE [GD1C2015]
GO
CREATE PROCEDURE [REZAGADOS].Listar_Documento 
AS
BEGIN
SELECT	td.Id_Tipo_Documento ID,
		td.Descripcion NOMBRE
	FROM [REZAGADOS].TipoDocumento td 
END
GO

-----------------------------------------BUSCAR DOCUMENTO ID---------------------------------------------------

USE [GD1C2015]
GO
CREATE PROCEDURE [REZAGADOS].Buscar_Documento_ID 
@Id NUMERIC(18,0)
AS
BEGIN
SELECT	td.Id_Tipo_Documento ID,
		td.Descripcion NOMBRE
	FROM [REZAGADOS].TipoDocumento td 
	WHERE td.Id_Tipo_Documento = @Id
END
GO

-----------------------------------------LISTAR MONEDA---------------------------------------------------------

USE [GD1C2015]
GO
CREATE PROCEDURE [REZAGADOS].Listar_Moneda 
AS
BEGIN
SELECT	m.Id_Moneda ID,
		m.Descripcion NOMBRE
	FROM [REZAGADOS].Moneda m 
END
GO

-----------------------------------------BUSCAR MONEDA ID------------------------------------------------------

USE [GD1C2015]
GO
CREATE PROCEDURE [REZAGADOS].Buscar_Moneda_ID 
@Id NUMERIC(18,0)
AS
BEGIN
SELECT	m.Id_Moneda ID,
		m.Descripcion NOMBRE
	FROM [REZAGADOS].Moneda m 
	WHERE m.Id_Moneda = @Id
END
GO

-----------------------------------------LISTAR BANCO----------------------------------------------------------

USE [GD1C2015]
GO
CREATE PROCEDURE [REZAGADOS].Listar_Banco 
AS
BEGIN
SELECT	b.Id_Banco ID,
		b.Nombre NOMBRE,
		b.Direccion DIRECCION
	FROM [REZAGADOS].Banco b 
END
GO

-----------------------------------------BUSCAR BANCO ID-------------------------------------------------------

USE [GD1C2015]
GO
CREATE PROCEDURE [REZAGADOS].Buscar_Banco_ID 
@Id NUMERIC(18,0)
AS
BEGIN
SELECT	b.Id_Banco ID,
		b.Nombre NOMBRE,
		b.Direccion DIRECCION
	FROM [REZAGADOS].Banco b 
	WHERE b.Id_Banco = @Id
END
GO

----------------------------------------------------FACTURACION DE COSTOS------------------------------------------

--------------------------------------------------------LISTAR TIPO ITEMS---------------------------------------
USE [GD1C2015]
IF OBJECT_ID ('[REZAGADOS].[Listar_Tipo_Items]') IS NOT NULL
    DROP PROCEDURE [REZAGADOS].Listar_Tipo_Items

USE [GD1C2015]
GO
CREATE PROCEDURE [REZAGADOS].Listar_Tipo_Items
AS
BEGIN
	
	 SELECT	Id_Tipo_Item	ID,
			Tipo			NOMBRE,
			Importe			IMPORTE
	   FROM REZAGADOS.TipoItem	   
END
GO

--------------------------------------------------------LISTAR TIPO ITEMS---------------------------------------
USE [GD1C2015]
IF OBJECT_ID ('[REZAGADOS].[Buscar_Tipo_Item_ID]') IS NOT NULL
    DROP PROCEDURE [REZAGADOS].Buscar_Tipo_Item_ID

USE [GD1C2015]
GO
CREATE PROCEDURE [REZAGADOS].Buscar_Tipo_Item_ID (@Id NUMERIC(18,0))
AS
BEGIN
	
	 SELECT	Id_Tipo_Item	ID,
			Tipo			NOMBRE,
			Importe			IMPORTE
	   FROM REZAGADOS.TipoItem
	   WHERE Id_Tipo_Item = @Id
END
GO


--------------------------------------------------------LISTAR ITEMS A PAGAR---------------------------------------
USE [GD1C2015]
IF OBJECT_ID ('[REZAGADOS].[Listar_Items_Deuda]') IS NOT NULL
    DROP PROCEDURE [REZAGADOS].Listar_Items_Deuda

USE [GD1C2015]
GO
CREATE PROCEDURE [REZAGADOS].Listar_Items_Deuda ( @Id_Cuentas IdLista READONLY )
AS
BEGIN
	
	 SELECT	Id_Item			ID,
			Id_Cuenta		CUENTA_ID,
			Id_Tipo_Item	TIPO_ID,
			Importe			IMPORTE,
			Fecha			FECHA
	   FROM REZAGADOS.Item
	   WHERE Id_Cuenta IN (SELECT * FROM @Id_Cuentas)
	     AND Id_Factura IS NULL
END
GO

--------------------------------------------------------FACTURAR---------------------------------------------------

USE [GD1C2015]
IF OBJECT_ID ('[REZAGADOS].[Facturar]') IS NOT NULL
    DROP PROCEDURE [REZAGADOS].[Facturar]

USE [GD1C2015]
GO
CREATE PROCEDURE [REZAGADOS].[Facturar] (	@Id_Items IdLista READONLY,
											@Id_Cliente NUMERIC(18,0),
											@Fecha DATETIME,
											@Respuesta NUMERIC(18,0) OUTPUT,
											@RespuestaMensaje VARCHAR(255) OUTPUT)
 AS
	SET NOCOUNT ON
	
	DECLARE @Id_Usuario NUMERIC(18,0)
	SELECT TOP 1 @Id_Usuario = Id_Usuario FROM REZAGADOS.Cliente WHERE @Id_Cliente = Id_Cliente
	
	BEGIN TRY
		BEGIN TRANSACTION
			--DECLARE @TOTAL INT SET SELECT SUM(Importe) FROM REZAGADOS.Item WHERE Id_Item IN (SELECT * FROM @Id_Items)
			--INSERT INTO REZAGADOS.Factura (Id_Usuario, Fecha) VALUES (SELECT Id_Usuario FROM REZAGADOS.Item, REZAGADOS.Cuenta WHERE Cuenta.Id_Cuenta=Item.Id_Cuenta 
			INSERT INTO REZAGADOS.Factura (Id_Usuario, Fecha) VALUES (@Id_Usuario, @Fecha)
			DECLARE @Id_Factura NUMERIC(18,0) = (SELECT @@IDENTITY)
			UPDATE REZAGADOS.Item SET Id_Factura=@Id_Factura WHERE Id_Item IN (SELECT * FROM @Id_Items)
			SET @Respuesta = @Id_Factura
			SET @RespuestaMensaje = 'Items pagados exitosamente'
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
		SET @Respuesta = - 1
		SET @RespuestaMensaje =  ERROR_MESSAGE()
	END CATCH
GO 

---------------------------------------------------MODIFICAR TIPO CUENTA----------------------------------------

USE [GD1C2015]
GO
CREATE PROCEDURE [REZAGADOS].[Modificar_Tipo_Cuenta] (		@Numero_Cuenta NUMERIC(18,0),
															@Id_Tipo NUMERIC(18,0),
															@RespuestaMensaje VARCHAR(255) OUTPUT,
															@Respuesta NUMERIC(18,0) OUTPUT)
AS
	UPDATE REZAGADOS.Cuenta SET Id_Tipo_Cuenta = @Id_Tipo WHERE Id_Cuenta=@Numero_Cuenta
	SET @RespuestaMensaje = 'Modifición exitosa'
	SET @Respuesta = 1
GO
---------------------------------------------------MODIFICAR CUENTA----------------------------------------

USE [GD1C2015]
GO
CREATE PROCEDURE [REZAGADOS].[Modificar_Cuenta] (
								@Id NUMERIC(18, 0),
								@Tipo NUMERIC(18, 0),
								@Estado NUMERIC(18, 0),
								@RespuestaMensaje VARCHAR(255) OUTPUT,
								@Respuesta NUMERIC(18,0) OUTPUT)
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION
			UPDATE	REZAGADOS.Cuenta
			SET	Id_Tipo_Cuenta = @Tipo,
					Id_Estado = @Estado
			WHERE Id_Cuenta = @Id
			SET @RespuestaMensaje = 'La cuenta ha sido modificado!'
			SET @Respuesta = 1
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		SET @Respuesta = -1
		SET @RespuestaMensaje = 'La Cuenta no se pudo modificar'
		ROLLBACK TRANSACTION
	END CATCH
END
GO

--------------------------------------------------------------------------------------------------------------------
USE [GD1C2015]
GO

CREATE PROCEDURE [REZAGADOS].[Listar_Retiro_ID_Cliente] (	@Id_Cliente NUMERIC(18,0))
AS
BEGIN

SELECT R.Id_Retiro ID, R.Id_Cuenta CUENTA, R.Fecha FECHA, R.Importe IMPORTE, Che.Id_Cheque CHEQUE, Che.Id_Banco BANCO, Che.Id_Moneda MONEDA
FROM REZAGADOS.Retiro R, REZAGADOS.Cliente C, REZAGADOS.Cuenta cu, REZAGADOS.Usuario u, REZAGADOS.Cheque che
WHERE C.Id_Cliente = @Id_Cliente
AND R.Id_Cuenta = Cu.Id_Cuenta
AND Cu.Id_Usuario = u.Id_Usuario
AND u.Id_Usuario = C.Id_Usuario
AND che.Id_Retiro = r.Id_Retiro
ORDER BY R.Fecha DESC, R.Id_Retiro DESC
END

GO

---------------------------------------------------------------------------------------
USE [GD1C2015]
GO

CREATE PROCEDURE [REZAGADOS].[Listar_Deposito_ID_Cliente] (	@Id_Cliente NUMERIC(18,0))
AS
BEGIN

SELECT D.Id_Deposito ID,C.Id_Cliente DEPOSITANTE, D.Codigo NOMBRE, D.Id_Cuenta CUENTA_DESTINO, D.Id_Tarjeta TARJETA, D. Id_Pais PAIS,
 D.Id_Moneda MONEDA, D.Fecha FECHA, D.Importe IMPORTE, T.Numero TARJETA 
FROM REZAGADOS.Deposito D, REZAGADOS.Tarjeta T, REZAGADOS.Cliente C, REZAGADOS.Cuenta cu, REZAGADOS.Usuario u
WHERE C.Id_Cliente = @Id_Cliente
AND D.Id_Cuenta = Cu.Id_Cuenta
AND Cu.Id_Usuario = u.Id_Usuario
AND u.Id_Usuario = C.Id_Usuario
AND t.Id_Tarjeta = d.Id_Tarjeta
ORDER BY D.Fecha DESC, D.Id_Deposito DESC
END
GO
---------------------------------------------------------------------------------------------------

USE [GD1C2015]
GO

CREATE PROCEDURE [REZAGADOS].[Listar_Transferencia_ID_Cliente] (	@Id_Cliente NUMERIC(18,0))
AS
BEGIN

   SELECT T.Id_Transferencia ID, T.Id_Cuenta_Emi CUENTA_ORIGEN, T.Id_Cuenta_Dest CUENTA_DESTINO,
    T.Fecha FECHA, T.Id_Moneda MONEDA, T.Importe IMPORTE
    FROM REZAGADOS.Transferencia T, REZAGADOS.Cliente C, REZAGADOS.Cuenta cu, REZAGADOS.Usuario u
WHERE C.Id_Cliente = @Id_Cliente
AND T.Id_Cuenta_Emi = Cu.Id_Cuenta
AND Cu.Id_Usuario = u.Id_Usuario
AND u.Id_Usuario = C.Id_Usuario
ORDER BY T.Fecha DESC, T.Id_Transferencia DESC
END
GO

--------------------------------------------------BUSCAR CLIENTES FILTROS-------------------------------------------

--USE [GD1C2015]
IF OBJECT_ID ('REZAGADOS.Buscar_Cliente_Filtros') IS NOT NULL
    DROP PROCEDURE REZAGADOS.Buscar_Cliente_Filtros
GO
CREATE PROCEDURE [REZAGADOS].[Buscar_Cliente_Filtros] (
@Id_Cliente NUMERIC(18,0)=NULL,
@Apellido VARCHAR(MAX)=NULL,
@Nombre VARCHAR(MAX)=NULL,
@Email VARCHAR(MAX)=NULL,
@Id_Tipo_Documento NUMERIC(18,0)=NULL, 
@Nro_Documento NUMERIC(18,0)=NULL,
@Habilitada BIT=NULL)
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @sqlCommand VARCHAR(MAX)
	DECLARE @sqlWhere VARCHAR(MAX)

	SET @sqlCommand = '		SELECT c.Id_Cliente ID, 
							c.Nombre NOMBRE, 
							c.Apellido APELLIDO,
							c.Id_Usuario USUARIO, 
							c.Id_Tipo_Documento DOCUMENTO, 
							c.Nro_Documento NRO_DOCUMENTO,
							c.Id_Pais PAIS,	
							c.Direccion_Calle DIRECCION_CALLE, 
							c.Direccion_Numero_Calle DIRECCION_NRO,
							c.Direccion_Piso DIRECCION_PISO, 
							c.Direccion_Departamento DIRECCION_DEPTO, 
							c.Fecha_Nacimiento FECHA_NACIMIENTO, 
							c.Mail EMAIL, 
							c.Localidad LOCALIDAD,
							c.Habilitada HABILITADA,
							c.Id_Nacionalidad NACIONALIDAD
							FROM [REZAGADOS].Cliente c '
	SET @sqlWhere = ''

	IF(@Id_Cliente IS NOT NULL)
	BEGIN
		SET @sqlWhere = @sqlWhere + ' AND Id_Cliente = ' + CAST(@Id_Cliente AS VARCHAR(MAX))
	END
	
	IF(@Apellido IS NOT NULL)
	BEGIN
		SET @sqlWhere = @sqlWhere + ' AND Apellido LIKE  ''%'+@Apellido+'%'''
	END

	IF(@Nombre IS NOT NULL)
	BEGIN
		SET @sqlWhere = @sqlWhere + ' AND Nombre LIKE  ''%'+@Nombre+'%'''
	END

	IF(@Email IS NOT NULL)
	BEGIN
		SET @sqlWhere = @sqlWhere + ' AND Mail LIKE  ''%'+@Email+'%'''
	END

	IF(@Id_Tipo_Documento IS NOT NULL)
	BEGIN
		SET @sqlWhere = @sqlWhere + ' AND Id_Tipo_Documento = ' + CAST(@Id_Tipo_Documento AS VARCHAR(MAX))
	END
	
	IF(@Nro_Documento IS NOT NULL)
	BEGIN
		SET @sqlWhere = @sqlWhere + ' AND Nro_Documento = ' + CAST(@Nro_Documento AS VARCHAR(MAX))
	END

	IF(@Habilitada IS NOT NULL)
	BEGIN
		SET @sqlWhere = @sqlWhere + ' AND Habilitada = ' + CAST(@Habilitada AS VARCHAR(MAX))
	END
	
	IF (@sqlWhere <> '')
	BEGIN
		SET @sqlWhere = ' WHERE ' + SUBSTRING (@sqlWhere, 5, Len(@sqlWhere) )
		SET @sqlCommand = @sqlCommand + @sqlWhere
	END
	EXEC(@sqlCommand)
END
GO

-----------------------------------------------LISTADOS ESTADISTICOS----------------------------------------------
---------------------------------CLIENTES CON ALGUNA CUENTA INHABILITADA POR TRIMESTRE----------------------------

USE [GD1C2015]
GO
CREATE PROCEDURE [REZAGADOS].[Clientes_Cuentas_Inhabilitadas] (@FechaInic DATETIME, @FechaFin DATETIME)
AS
BEGIN
	SELECT TOP 5 SubSelect2.Id_Cliente
	FROM   (SELECT SubSelect.Id_Cuenta, Cliente.Id_Cliente
			FROM   (SELECT Id_Cuenta
					FROM REZAGADOS.Item
					WHERE Id_Factura IS NULL
					AND Fecha > @FechaInic
					AND Fecha < @FechaFin
					GROUP BY Id_Cuenta
					HAVING COUNT(Id_Cuenta) > 5 ) AS SubSelect,	
			REZAGADOS.Cuenta,	
			REZAGADOS.Cliente	
			WHERE SubSelect.Id_Cuenta = Cuenta.Id_Cuenta
			AND Cliente.Id_Usuario = Cuenta.Id_Usuario) AS SubSelect2
	GROUP BY SubSelect2.Id_Cliente
	HAVING COUNT(SubSelect2.Id_Cliente) > 0
	ORDER BY COUNT(SubSelect2.Id_Cliente) DESC
END
GO

-------------------------CLIENTE CON MAYOR CANTIDAD DE ITEMS FACTURADOS-------------------------------------------

USE [GD1C2015]
GO
CREATE PROCEDURE [REZAGADOS].[Clientes_Mayor_Facturados] (@FechaInic DATETIME, @FechaFin DATETIME)
AS
BEGIN
SELECT TOP 5 Id_Cliente, SUM(cantidad) cant
FROM (
		SELECT Id_Cuenta, COUNT(Id_Cuenta) cantidad
		FROM REZAGADOS.Item
		WHERE Id_Factura IS NOT NULL
		AND Fecha > @FechaInic
		AND Fecha < @FechaFin
		GROUP BY Id_Cuenta) AS SubSelect,
		REZAGADOS.Cuenta,
		REZAGADOS.Cliente
WHERE Cuenta.Id_Cuenta = SubSelect.Id_Cuenta
AND Cuenta.Id_Usuario = Cliente.Id_Usuario
GROUP BY Id_Cliente
ORDER BY cant DESC
END
GO

-------------------------CLIENTES MAYOR TRANSACCION ENTRE SUS CUENTAS-----------------------------------------------------

USE [GD1C2015]
GO
CREATE PROCEDURE [REZAGADOS].[Clientes_Mayor_Transacciones] (@FechaInic DATETIME, @FechaFin DATETIME)
AS
BEGIN
SELECT TOP 5 Cliente.Id_Cliente
FROM REZAGADOS.Transferencia, REZAGADOS.Cuenta AS C1, REZAGADOS.Cuenta AS C2, REZAGADOS.Cliente
WHERE C1.Id_Usuario = Cliente.Id_Usuario
AND C2.Id_Usuario = Cliente.Id_Usuario
AND Transferencia.Id_Cuenta_Emi = C1.Id_Cuenta
AND Transferencia.Id_Cuenta_Dest = C2.Id_Cuenta
AND C1.Id_Usuario = C2.Id_Usuario
AND Transferencia.Fecha > @FechaInic
AND Transferencia.Fecha < @FechaFin
GROUP BY Cliente.Id_Cliente
ORDER BY COUNT(Cliente.Id_Cliente) DESC
END
GO

------------------------------------PAISES CON MAYOR MOVIMIENTO----------------------------------------------------------------------

USE [GD1C2015]
GO
CREATE PROCEDURE [REZAGADOS].[Paises_Mayor_Movimiento] (@FechaInic DATETIME, @FechaFin DATETIME)
AS
BEGIN
SELECT TOP 5 C1.Id_Pais
FROM(
	SELECT Id_Pais, COUNT(Id_Pais) AS Cantidad
	FROM REZAGADOS.Deposito
	WHERE Deposito.Fecha > @FechaInic
	AND Deposito.Fecha < @FechaFin
	GROUP BY Id_Pais) AS C1
FULL OUTER JOIN(
	SELECT Id_Pais, COUNT(Id_Pais) AS Cantidad
	FROM REZAGADOS.Retiro, REZAGADOS.Cuenta
	WHERE Cuenta.Id_Cuenta=Retiro.Id_Cuenta
	AND Retiro.Fecha > @FechaInic
	AND Retiro.Fecha < @FechaFin
	GROUP BY Id_Pais) AS C2
ON C1.Id_Pais =  C2.Id_Pais
FULL OUTER JOIN(
	SELECT Id_Pais, COUNT(Id_Pais) AS Cantidad
	FROM REZAGADOS.Transferencia, REZAGADOS.Cuenta
	WHERE Cuenta.Id_Cuenta=Transferencia.Id_Cuenta_Dest
	AND Transferencia.Fecha > @FechaInic
	AND Transferencia.Fecha < @FechaFin
	GROUP BY Id_Pais) AS C3
ON C2.Id_Pais = C3.Id_Pais
FULL OUTER JOIN(
	SELECT Id_Pais, COUNT(Id_Pais) AS Cantidad
	FROM REZAGADOS.Transferencia, REZAGADOS.Cuenta
	WHERE Cuenta.Id_Cuenta=Transferencia.Id_Cuenta_Emi
	AND Transferencia.Fecha > @FechaInic
	AND Transferencia.Fecha < @FechaFin
	GROUP BY Id_Pais) AS C4
ON C3.Id_Pais=C4.Id_Pais
ORDER BY C1.Cantidad+C2.Cantidad+C3.Cantidad+C4.Cantidad DESC
END
GO

------------------------------------TOTAL FACTURADO DISTINTAS CUENTAS--------------------------------------------------

USE [GD1C2015]
GO
CREATE PROCEDURE [REZAGADOS].[Total_Facturado_Cuentas] (@FechaInic DATETIME, @FechaFin DATETIME)
AS
BEGIN
SELECT Categoria, SUM(Item.Importe) Cantidad
FROM REZAGADOS.Item, REZAGADOS.Cuenta, REZAGADOS.TipoCuenta
WHERE Cuenta.Id_Cuenta=Item.Id_Cuenta
AND Item.Id_Factura IS NOT NULL
AND TipoCuenta.Id_Tipo_Cuenta=Cuenta.Id_Tipo_Cuenta
AND Item.Fecha > @FechaInic
AND Item.Fecha < @FechaFin
GROUP BY Categoria
END
GO

----------------------------------------------BUSCAR TARJETAS CLIENTE ID---------------------------------------------------

USE [GD1C2015]
GO
CREATE PROCEDURE [REZAGADOS].[Buscar_Tarjeta_Cliente_Id] (@Id_Cliente NUMERIC(18,0),@Numero VARCHAR(20)=NULL )
AS
BEGIN
	SET NOCOUNT ON
	
	DECLARE @SqlQuery VARCHAR(MAX)

	SET @SqlQuery =	'SELECT	t.Id_Tarjeta		ID,
							t.Id_Cliente		ID_CLIENTE,
							t.Numero			NUMERO,
							t.Id_Emisor			EMISOR_ID,
							e.Nombre			EMISOR_NOMBRE,
							t.Codigo_Seguridad	CODIGO,
							t.Fecha_Emision		EMISION,
							t.Vencimiento		VENCIMIENTO,
							t.Habilitada		HABILITADA
					   FROM [GD1C2015].[REZAGADOS].[Tarjeta] t
					   JOIN REZAGADOS.Emisor e ON t.Id_Emisor = e.ID_Emisor
					  WHERE Id_Cliente = ' + CAST(@Id_Cliente AS VARCHAR(MAX)) +
					    'AND t.Habilitada = 1 '

	IF(@Numero IS NOT NULL)
	BEGIN
		SET @SqlQuery = @SqlQuery + ' AND t.Numero LIKE  ''%'+@Numero+'%'''
	END
	EXEC(@SqlQuery)

END
GO

----------------------------------------------LISTAR EMISOR--------------------------------------------------

USE [GD1C2015]
GO
CREATE PROCEDURE [REZAGADOS].[Listar_Emisores]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT Id_Emisor ID, Nombre NOMBRE
	FROM [REZAGADOS].Emisor
END
GO

----------------------------------------------BUSCAR EMISOR ID-------------------------------------------------

USE [GD1C2015]
GO
CREATE PROCEDURE [REZAGADOS].[Buscar_Emisor_Id] (@Id_Emisor NUMERIC(18,0))
AS
BEGIN
	SET NOCOUNT ON;

	SELECT Id_Emisor ID, Nombre NOMBRE
	FROM [REZAGADOS].Emisor
	WHERE Id_Emisor = @Id_Emisor
END
GO
---------------------------------------------------------------------------------------------------------------
USE [GD1C2015]
GO

CREATE PROCEDURE [REZAGADOS].[Listar_Transferencia] (	@Id_Cliente NUMERIC(18,0))
AS
BEGIN

   SELECT T.Id_Transferencia ID, T.Id_Cuenta_Emi CUENTA_ORIGEN, T.Id_Cuenta_Dest CUENTA_DESTINO,
    T.Fecha FECHA, T.Id_Moneda MONEDA, T.Importe IMPORTE
    FROM REZAGADOS.Transferencia T
END
GO
--------------------------------------------------------------------
USE [GD1C2015]
GO

CREATE PROCEDURE [REZAGADOS].[Buscar_Transferencia_ID] 
@Id decimal 
AS
BEGIN

   SELECT T.Id_Transferencia ID, T.Id_Cuenta_Emi CUENTA_ORIGEN, T.Id_Cuenta_Dest CUENTA_DESTINO,
    T.Fecha FECHA, T.Id_Moneda MONEDA, T.Importe IMPORTE
    FROM REZAGADOS.Transferencia T
    WHERE T.Id_Transferencia = @Id;
END
GO

----------------------------------------------TRIGGERS---------------------------------------------------------
---------------------------------------------------------------------------------------------------------------

---------------------------------------HISTORIAL ACCESOS-------------------------------------------------------

IF OBJECT_ID ('[REZAGADOS].[Trig_Historial_Cuentas]') IS NOT NULL
    DROP TRIGGER [REZAGADOS].[Trig_Historial_Cuentas]
    
USE [GD1C2015]
GO
CREATE TRIGGER [REZAGADOS].[Trig_Historial_Cuentas]
ON [REZAGADOS].[Cuenta]
AFTER UPDATE
AS
IF UPDATE(Id_Estado)
BEGIN TRAN
	DECLARE A CURSOR
	FOR SELECT i.Id_Cuenta, i.Id_Estado, e.Nombre FROM INSERTED i JOIN REZAGADOS.Estado_Cuenta e ON i.Id_Estado = e.Id_Estado
	DECLARE @Cuenta NUMERIC(18,0)
	DECLARE @Id_Estado NUMERIC(18,0)
	DECLARE @Estado VARCHAR(255)
		OPEN A
		FETCH A INTO @Cuenta, @Id_Estado, @Estado
		WHILE @@FETCH_STATUS = 0
			BEGIN
				PRINT CAST(@Cuenta as varchar) +' - '+ @Estado 
				INSERT INTO HistorialCuenta (Id_Cuenta, Fecha, Id_Estado,Estado) VALUES (@Cuenta, GETDATE(),@Id_Estado, @Estado)
				FETCH A INTO @Cuenta, @Id_Estado, @Estado
			END

	CLOSE A
	DEALLOCATE A
	COMMIT TRAN
GO
----------------------------------------5 TRANSACCIONES---------------------------------------------------------

IF OBJECT_ID ('[REZAGADOS].[Trig_5_Transacciones]') IS NOT NULL
    DROP TRIGGER [REZAGADOS].[Trig_5_Transacciones]

USE [GD1C2015]
GO
CREATE TRIGGER [REZAGADOS].[Trig_5_Transacciones]
ON [REZAGADOS].[Item]
AFTER UPDATE, INSERT
AS
BEGIN TRANSACTION
	DECLARE B CURSOR
	FOR SELECT Id_Cuenta FROM INSERTED
	DECLARE @Cuenta NUMERIC(18,0)
		OPEN B
		FETCH B INTO @Cuenta
		WHILE @@FETCH_STATUS = 0
			BEGIN --Si la cuenta esta cancelada, no debería pasarla a Habilitada o Inhabilitada!
				IF (SELECT COUNT(*) FROM REZAGADOS.Item WHERE Item.Id_Factura IS NULL AND @Cuenta = Item.Id_Cuenta GROUP BY Item.Id_Cuenta) < 5
				UPDATE Cuenta SET Id_Estado = (SELECT Id_Estado FROM REZAGADOS.Estado_Cuenta WHERE Nombre = 'Habilitada')
				ELSE
				UPDATE Cuenta SET Id_Estado = (SELECT Id_Estado FROM REZAGADOS.Estado_Cuenta WHERE Nombre = 'Inhabilitada')
				FETCH B INTO @Cuenta
			END
	CLOSE B
	DEALLOCATE B
	COMMIT
GO

----------------------------------------TIPO CUENTA TRANSACCION---------------------------------------------------------

IF OBJECT_ID ('[REZAGADOS].[Trig_Tipo_Cuenta_Transaccion]') IS NOT NULL
    DROP TRIGGER [REZAGADOS].[Trig_Tipo_Cuenta_Transaccion]
    
USE [GD1C2015]
GO
CREATE TRIGGER [REZAGADOS].[Trig_Tipo_Cuenta_Transaccion]
ON [REZAGADOS].[Cuenta]
AFTER INSERT, UPDATE
AS
BEGIN TRANSACTION
	DECLARE C CURSOR
	FOR SELECT Id_Cuenta, Id_Tipo_Cuenta FROM INSERTED
	DECLARE @Cuenta NUMERIC(18,0)
	DECLARE @Tipo NUMERIC(18,0)
		OPEN C
		FETCH C INTO @Cuenta, @Tipo
		WHILE @@FETCH_STATUS = 0
			BEGIN
				PRINT 'Controlar'
				IF EXISTS(select Id_Tipo_Cuenta from REZAGADOS.TipoCuenta where NOT Categoria like 'Gratuita' and Id_Tipo_Cuenta = @Tipo)
				BEGIN
					PRINT 'TRIGGER Tipo CUenta TRansaccion'+CAST(@Cuenta as varchar) +' - '+ CAST(@Tipo as varchar)
					INSERT INTO Item (Id_Cuenta, Id_Tipo_Item, Importe, Fecha)
					VALUES (@Cuenta, (SELECT Id_Tipo_Item FROM REZAGADOS.TipoItem WHERE Tipo = 'Cambio de cuenta.'), 
					(SELECT Costo FROM REZAGADOS.TipoCuenta t WHERE t.Id_Tipo_Cuenta=@Tipo), GETDATE())
				END
				FETCH C INTO @Cuenta, @Tipo
			END
  CLOSE C
  DEALLOCATE C
 COMMIT
GO

----------------------------------------INSERTA ITEM TRANSFERENCIA---------------------------------------------------------

USE [GD1C2015]
IF OBJECT_ID ('[REZAGADOS].[Trig_Inserta_Item_Transf]') IS NOT NULL 
	DROP TRIGGER [REZAGADOS].[Trig_Inserta_Item_Transf]
GO
CREATE TRIGGER [REZAGADOS].[Trig_Inserta_Item_Transf]
ON [REZAGADOS].[Transferencia]
AFTER INSERT
AS
BEGIN TRANSACTION
	DECLARE D CURSOR
	FOR SELECT Id_Cuenta_Emi, Id_Cuenta_Dest, Importe, Fecha FROM INSERTED
	DECLARE @Id_Cuenta_Emi NUMERIC(18,0)
	DECLARE @Id_Cuenta_Dest NUMERIC(18,0)
	DECLARE @Importe NUMERIC(18,2)
	DECLARE @Fecha DATETIME
	OPEN D
		FETCH D INTO @Id_Cuenta_Emi, @Id_Cuenta_Dest, @Importe, @Fecha
		
		WHILE @@FETCH_STATUS = 0
			IF ((SELECT Id_Usuario from Cuenta WHERE Id_Cuenta = @Id_Cuenta_Emi) <> (SELECT Id_Usuario from Cuenta WHERE Id_Cuenta = @Id_Cuenta_Dest))
			BEGIN
				-- IF (SELECT Categoria FROM REZAGADOS.TipoCuenta JOIN Cuenta ON Cuenta.Id_Tipo_Cuenta = TipoCuenta.Id_Tipo_Cuenta WHERE Cuenta.Id_Cuenta=@Id_Cuenta_Emi ) <> 'Gratuita'
				INSERT INTO Item (Id_Cuenta, Id_Tipo_Item, Importe, Fecha)
				VALUES (@Id_Cuenta_Emi, (SELECT Id_Tipo_Item FROM REZAGADOS.TipoItem WHERE Tipo = 'Comisión por transferencia.'), CAST(ROUND(@Importe,1)/(SELECT Costo FROM TipoCuenta JOIN Cuenta ON TipoCuenta.Id_Tipo_Cuenta = Cuenta.Id_Tipo_Cuenta WHERE Cuenta.Id_Cuenta=@Id_Cuenta_Emi) AS NUMERIC (18,2)), GETDATE())
				FETCH C INTO @Id_Cuenta_Emi, @Id_Cuenta_Dest, @Importe, @Fecha

			END
	CLOSE D
	DEALLOCATE D
	COMMIT
GO

