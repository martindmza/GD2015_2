
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
Id_Funcionalidad numeric(18,0) NOT NULL,
Habilitada bit DEFAULT 1,);
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
Fecha datetime,
Contrasenia varchar(255),);
ALTER TABLE REZAGADOS.HistorialUsuario ADD CONSTRAINT PK_Id_Historial_Usuario PRIMARY KEY (Id_Historial_Usuario);

CREATE TABLE REZAGADOS.UsuarioXRol (
Id_Usuario numeric(18,0) NOT NULL,
Id_Rol numeric(18,0) NOT NULL,
Habilitada bit DEFAULT 1,);
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
Nro_Documento numeric(18,0) UNIQUE,
Id_Pais numeric(18,0),
Direccion_Calle varchar(255),
Direccion_Numero_Calle numeric(18,0),
Direccion_Piso numeric(18,0),
Direccion_Departamento varchar(10),
Fecha_Nacimiento datetime,
Mail varchar(255) UNIQUE,
Localidad varchar(255),
Nacionalidad varchar(255),
Habilitada bit DEFAULT 1,);
ALTER TABLE REZAGADOS.Cliente ADD CONSTRAINT PK_Id_Cliente PRIMARY KEY (Id_Cliente);
				
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
Saldo numeric (18,0) DEFAULT 0,);
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

/*
CREATE TABLE REZAGADOS.HistorialCuenta(
Id_Historial_Cuenta numeric (18,0) IDENTITY(1,1) NOT NULL,
Id_Cuenta numeric (18,0),
Fecha datetime,
Estado varchar(255),);
ALTER TABLE REZAGADOS.HistorialCuenta ADD CONSTRAINT PK_Id_Historial_Cuenta PRIMARY KEY (Id_Historial_Cuenta);
*/

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
Id_Usuario numeric(18,0) NOT NULL,
Numero varchar(255) NOT NULL,
Tipo varchar(255) NOT NULL, 
Codigo_Seguridad varchar(255) NOT NULL,
Fecha_Emision datetime,
Vencimiento datetime,
Habilitada bit DEFAULT 1,);
ALTER TABLE REZAGADOS.Tarjeta ADD CONSTRAINT PK_Id_Tarjeta PRIMARY KEY (Id_Tarjeta);

CREATE TABLE REZAGADOS.Transferencia ( 
Id_Transferencia numeric (18,0) IDENTITY (1,1) NOT NULL,
Id_Cuenta_Emi numeric (18,0) NOT NULL,
Id_Cuenta_Dest numeric (18,0) NOT NULL,
Fecha datetime,
Id_Moneda numeric (18,0) DEFAULT 1,
Importe numeric(18,2) NOT NULL,);
ALTER TABLE REZAGADOS.Transferencia ADD CONSTRAINT PK_Id_Transferencia PRIMARY KEY (Id_Transferencia);

CREATE TABLE REZAGADOS.Retiro ( 
Id_Retiro numeric (18,0) NOT NULL,
Id_Cuenta numeric (18,0) NOT NULL,
Fecha datetime,
Id_Moneda numeric (18,0) DEFAULT 1,
Importe numeric(18,2) NOT NULL,);
ALTER TABLE REZAGADOS.Retiro ADD CONSTRAINT PK_Id_Retiro PRIMARY KEY (Id_Retiro);

CREATE TABLE REZAGADOS.Cheque ( 
Id_Cheque numeric (18,0) NOT NULL,
Id_Retiro numeric (18,0) NOT NULL,
Id_Banco numeric (18,0) NOT NULL,
Fecha datetime,
Id_Moneda numeric (18,0) DEFAULT 1,
Importe numeric(18,2) NOT NULL,
Num_Egreso numeric(18,2),
Num_Item numeric(18,2),);
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
Fecha datetime,
Habilitada bit DEFAULT 1,);
ALTER TABLE REZAGADOS.Item ADD CONSTRAINT PK_Id_Item PRIMARY KEY (Id_Item);

CREATE TABLE REZAGADOS.TipoItem(
Id_Tipo_Item numeric(18,0) IDENTITY(1,1) NOT NULL,
Tipo varchar(255),
Importe numeric(18,0) DEFAULT 0,);
ALTER TABLE REZAGADOS.TipoItem ADD CONSTRAINT PK_Id_Tipo_Item PRIMARY KEY (Id_Tipo_Item);

CREATE TABLE REZAGADOS.Factura (
Id_Factura numeric(18,0) NOT NULL,
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
/*
ALTER TABLE REZAGADOS.HistorialCuenta ADD CONSTRAINT FK_Historial_Cuenta_to_Cuenta
FOREIGN KEY (Id_Cuenta) REFERENCES REZAGADOS.Cuenta (Id_Cuenta)
;
*/
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
ALTER TABLE REZAGADOS.Tarjeta ADD CONSTRAINT FK_Tarjeta_to_Usuario
FOREIGN KEY (Id_Usuario) REFERENCES REZAGADOS.Usuario (Id_Usuario)
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
		F.Nombre IN ('ABM de Cliente', 'ABM de Cuenta', 'Deposito', 'Retiro de Efectivo', 'Transferencias entre cuentas', 'Facturación de Costos', 'Consulta de saldos','Tarjetas',
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
VALUES ('admin','83725956498A914502C515217D3310E5E7FA4DE8083DFAD999B63EED48EE6', GETDATE(), GETDATE())

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
	(SELECT e.Id_Estado FROM REZAGADOS.Estado_Cuenta e WHERE e.Nombre like 'Habilitada'), 
	g.Cuenta_Fecha_Creacion, g.Cuenta_Fecha_Cierre
FROM gd_esquema.Maestra g, REZAGADOS.Usuario u
WHERE u.Nombre = g.Cli_Mail AND g.Cuenta_Dest_Fecha_Creacion IS NOT NULL
GROUP BY g.Cuenta_Numero, u.Id_Usuario, g.Cuenta_Pais_Codigo, g.Cuenta_Estado, g.Cuenta_Fecha_Creacion, g.Cuenta_Fecha_Cierre

-----------------------------------------TARJETA--------------------------------------------------

INSERT INTO REZAGADOS.Tarjeta (Id_Usuario, Numero, Tipo, Codigo_Seguridad, Fecha_Emision, Vencimiento)
SELECT u.Id_Usuario, Tarjeta_Numero, Tarjeta_Emisor_Descripcion, Tarjeta_Codigo_Seg, Tarjeta_Fecha_Emision, Tarjeta_Fecha_Vencimiento
FROM gd_esquema.Maestra g, REZAGADOS.Usuario u
WHERE Tarjeta_Numero IS NOT NULL  AND u.Nombre = g.Cli_Mail
GROUP BY u.Id_Usuario, Tarjeta_Numero, Tarjeta_Emisor_Descripcion, Tarjeta_Codigo_Seg, Tarjeta_Fecha_Emision, Tarjeta_Fecha_Vencimiento

--------------------------------------------TIPO ITEM-----------------------------------------------

INSERT INTO REZAGADOS.TipoItem (Tipo)
VALUES ('Comisión por transferencia.'), ('Creacion de cuenta.'), ('Cambio de cuenta.')

------------------------------------------FACUTRA--------------------------------------------------

INSERT INTO REZAGADOS.Factura (Id_Factura, Id_Usuario, Fecha)
SELECT g.Factura_Numero, u.Id_Usuario, g.Factura_Fecha
FROM gd_esquema.Maestra g, REZAGADOS.Usuario u
WHERE u.Nombre = g.Cli_Mail AND g.Factura_Numero IS NOT NULL
GROUP BY g.Factura_Numero, u.Id_Usuario, g.Factura_Fecha

--------------------------------------------ITEM----------------------------------------------------

INSERT INTO REZAGADOS.Item (Id_Factura, Id_Cuenta, Id_Tipo_Item, Importe, Fecha)
SELECT f.Id_Factura, c.Id_Cuenta, t.Id_Tipo_Item, g.Trans_Importe, g.Transf_Fecha
FROM gd_esquema.Maestra g, REZAGADOS.Factura f, REZAGADOS.Usuario u, REZAGADOS.Cuenta c, REZAGADOS.TipoItem t
WHERE f.Id_Factura = g.Factura_Numero AND u.Nombre = g.Cli_Mail AND c.Id_Usuario = u.Id_Usuario AND t.Tipo = g.Item_Factura_Descr
UNION
SELECT g.Factura_Numero, c.Id_Cuenta, 1, CAST(ROUND(g.Trans_Importe,1)/10 as Numeric (18,2)), g.Transf_Fecha
FROM gd_esquema.Maestra g, REZAGADOS.Usuario u, REZAGADOS.Cuenta c
WHERE u.Nombre = g.Cli_Mail AND c.Id_Usuario = u.Id_Usuario AND Item_Factura_Descr IS NULL AND Cuenta_Dest_Numero is not null AND Trans_Importe != 0.00

--------------------------------------------RETIRO----------------------------------------------------

INSERT INTO REZAGADOS.Retiro (Id_Retiro, Id_Cuenta, Fecha, Importe)
SELECT g.Retiro_Codigo, c.Id_Cuenta, g.Retiro_Fecha, g.Retiro_Importe
FROM gd_esquema.Maestra g, REZAGADOS.Cuenta c
WHERE g.Retiro_Codigo IS NOT NULL AND c.Id_Cuenta = g.Cuenta_Numero
GROUP BY g.Retiro_Codigo, c.Id_Cuenta, g.Retiro_Fecha, g.Retiro_Importe

----------------------------------------TRANSFERENCIA-------------------------------------------------

INSERT INTO REZAGADOS.Transferencia (Id_Cuenta_Emi, Id_Cuenta_Dest, Fecha, Importe)
SELECT Cuenta_Numero, Cuenta_Dest_Numero, Transf_Fecha, Trans_Importe
FROM gd_esquema.Maestra
WHERE Cuenta_Dest_Numero IS NOT NULL

-------------------------------------------DEPOSITO---------------------------------------------------

INSERT INTO REZAGADOS.Deposito (Codigo, Id_Cuenta, Id_Tarjeta, Id_Pais, Fecha, Importe)
SELECT g.Deposito_Codigo, g.Cuenta_Numero, t.Id_Tarjeta, g.Cuenta_Pais_Codigo, g.Deposito_Fecha, g.Deposito_Importe
FROM gd_esquema.Maestra g, REZAGADOS.Usuario u, REZAGADOS.Tarjeta t
WHERE g.Deposito_Codigo IS NOT NULL AND u.Nombre = g.Cli_Mail AND t.Id_Usuario = u.Id_Usuario
GROUP BY g.Deposito_Codigo, g.Cuenta_Numero, t.Id_Tarjeta, g.Cuenta_Pais_Codigo, g.Deposito_Fecha, g.Deposito_Importe

--------------------------------------------CHEQUE----------------------------------------------------

INSERT INTO REZAGADOS.Cheque (Id_Cheque, Id_Retiro, Id_Banco, Fecha, Importe)
SELECT Cheque_Numero, Retiro_Codigo, Banco_Cogido, Cheque_Fecha, Cheque_Importe
FROM gd_esquema.Maestra
WHERE Cheque_Numero IS NOT NULL
GROUP BY Cheque_Numero, Retiro_Codigo, Banco_Cogido, Cheque_Fecha, Cheque_Importe

------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------
--------------------------------------------PROCESOS--------------------------------------------------
------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------
-----------------------------------------CREAR TIPO LISTA---------------------------------------------

USE [GD1C2015]
GO
CREATE TYPE REZAGADOS.IdLista AS TABLE 
( Id_Funcionalidad NUMERIC(18,0) );
GO

------------------------------------------CREAR CLIENTE------------------------------------------------

USE [GD1C2015]
GO
CREATE PROCEDURE REZAGADOS.Crear_Cliente(
					@Nombre VARCHAR(255),
					@Apellido VARCHAR(255),
					@Tipo_Documento NUMERIC(18, 0),
					@Nro_Documento NUMERIC(18, 0),
					@Pais VARCHAR(255),
					@Direccion_Calle VARCHAR (255),
					@Direccion_Numero_Calle NUMERIC(18, 0),
					@Direccion_Piso NUMERIC(18,0),
					@Direccion_Departamento VARCHAR(10),
					@Fecha_Nacimiento DATETIME,
					@Mail VARCHAR(255),
					@Localidad VARCHAR(255),
					@Nacionalidad VARCHAR(255),
					@Username VARCHAR (255),
					@Password VARCHAR(255),
					@RespuestaMensaje VARCHAR(255) OUTPUT,
					@Respuesta NUMERIC(18,0) OUTPUT)
AS 
BEGIN TRY
BEGIN TRANSACTION
BEGIN
IF (EXISTS(SELECT Mail FROM REZAGADOS.Cliente  WHERE @Mail = Mail) )
	BEGIN
	SET @RespuestaMensaje = 'El e-mail ya existe.'
	SET @Respuesta = -1
	END
ELSE
BEGIN
	INSERT INTO REZAGADOS.Usuario (Nombre, Contrasenia) VALUES (@Username, @Password)
	DECLARE @Id_Usuario NUMERIC(18,0)
	DECLARE @Id_Tipo_Documento NUMERIC(18,0)
	DECLARE @Id_Pais NUMERIC (18,0)
	SET @Id_Pais = (SELECT DISTINCT Id_Pais FROM REZAGADOS.Pais WHERE REZAGADOS.Pais.Descripcion = @Pais)
	SET @Id_Tipo_Documento = (SELECT DISTINCT Id_Tipo_Documento FROM REZAGADOS.TipoDocumento WHERE REZAGADOS.TipoDocumento.Descripcion = @Tipo_Documento)
	SET @Id_Usuario = (SELECT DISTINCT Id_Usuario FROM REZAGADOS.Usuario WHERE REZAGADOS.Usuario.Nombre = @Username)
	INSERT INTO REZAGADOS.Cliente (Id_Usuario, Nombre, Apellido, Id_Tipo_Documento, Nro_Documento, Id_Pais, Direccion_Calle, Direccion_Numero_Calle, Direccion_Piso, Direccion_Departamento, Fecha_Nacimiento, Mail, Localidad, Nacionalidad)
	VALUES (@Id_Usuario, @Nombre, @Apellido, @Id_Tipo_Documento, @Nro_Documento, @Id_Pais, @Direccion_Calle, @Direccion_Numero_Calle, @Direccion_Piso, @Direccion_Departamento, @Fecha_Nacimiento, @Mail, @Localidad, @Nacionalidad) 		
	INSERT INTO REZAGADOS.UsuarioXRol(Id_Usuario, Id_Rol) VALUES (@Id_Usuario, 2)
	SET @Respuesta = (SELECT Id_Cliente FROM Cliente WHERE Nombre = @Nombre AND Apellido = @Apellido AND Nro_Documento = @Nro_Documento)			
	SET @RespuestaMensaje = 'Los datos se guardaron exitosamente!'
	END
END
COMMIT TRANSACTION
END TRY
BEGIN CATCH
ROLLBACK TRANSACTION
END CATCH
GO

-----------------------------------------MODIFICAR CLIENTE------------------------------------------------

USE [GD1C2015]
GO
CREATE PROCEDURE REZAGADOS.Modificar_Cliente (
								@Id_Cliente NUMERIC(18,0),
								@Direccion_Calle VARCHAR (255),
								@Direccion_Numero_Calle NUMERIC(18, 0),
								@Direccion_Piso NUMERIC(18,0),
								@Direccion_Departamento VARCHAR(10),
								@Fecha_Nacimiento DATETIME,
								@Mail VARCHAR(255),
								@Localidad VARCHAR(255),
								@Nacionalidad VARCHAR(255),
								@RespuestaMensaje VARCHAR(255) OUTPUT,
								@Respuesta NUMERIC(18,0) OUTPUT)
AS
BEGIN
	IF (EXISTS(SELECT Mail FROM REZAGADOS.Cliente  WHERE @Mail = Mail) )
	BEGIN
	SET @RespuestaMensaje = 'El e-mail ya existe.'
	SET @Respuesta = -1
	END
ELSE
	BEGIN
	UPDATE REZAGADOS.Cliente
	SET
	[Direccion_Calle] = @Direccion_Calle,
	[Direccion_Numero_Calle] = @Direccion_Numero_Calle,
	[Direccion_Piso] = @Direccion_Piso,
	[Direccion_Departamento] = @Direccion_Departamento,
	[Fecha_Nacimiento] = @Fecha_Nacimiento,
	[Mail] = @Mail,
	[Localidad] = @Localidad,
	[Nacionalidad] = @Nacionalidad
	WHERE
   [Id_Cliente] = @Id_Cliente
  SET @RespuestaMensaje = 'El cliente ha sido modificado!'
  SET @Respuesta = 1
  END
END
GO

-----------------------------------------ALTA CLIENTE------------------------------------------------

USE [GD1C2015]
GO
CREATE PROCEDURE REZAGADOS.Alta_Cliente (	@Id_Cliente varchar(255),
											@RespuestaMensaje VARCHAR(255) OUTPUT,
											@Respuesta NUMERIC(18,0) OUTPUT)
AS
	BEGIN
		DECLARE @Id_Usuario NUMERIC(18,0) = (SELECT Id_Usuario FROM REZAGADOS.Cliente WHERE Id_Cliente = CAST(@Id_Cliente AS NUMERIC(18,0)))
		UPDATE REZAGADOS.Cliente SET Habilitada=1 WHERE Id_Usuario=@Id_Usuario
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
		DECLARE @Id_Usuario NUMERIC(18,0) = (SELECT Id_Usuario FROM REZAGADOS.Cliente WHERE Id_Cliente = @Id_Cliente)
		UPDATE REZAGADOS.Cliente SET Habilitada=0 WHERE Id_Usuario=@Id_Usuario
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
					END
				END
				ELSE
				BEGIN
					UPDATE REZAGADOS.Usuario SET Cantidad_Intentos_Fallidos=(Cantidad_Intentos_Fallidos+1) WHERE Nombre = @Usuario;
					SET @Cantidad_Intentos_Fallidos = (@Cantidad_Intentos_Fallidos + 1);
					DECLARE @Cantidad_Intentos_Fallidos_String NVARCHAR(255) = @Cantidad_Intentos_Fallidos;
					SET @RespuestaMensaje = 'Contraseña incorrecta, vuelva a intentarlo. Cantidad de intentos fallidos: ' + (@Cantidad_Intentos_Fallidos_String);
					SET @Respuesta = -1
				END
			END
			ELSE
			BEGIN
				DECLARE @Id_User NUMERIC(18,0) = (SELECT Id_Usuario FROM REZAGADOS.Usuario WHERE Nombre = @Usuario)
				UPDATE REZAGADOS.Usuario SET Habilitada = 0 WHERE @Id_User = Id_Usuario
				SET @RespuestaMensaje = 'Su usuario esta bloqueado, por sobrepasar la cantidad de logueos incorrectos';
				SET @Respuesta = -1
			END  
		END
		ELSE
		SET @RespuestaMensaje = 'El Usuario se encuentra inhabilitado'
		SET @Respuesta = -1
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
CREATE PROCEDURE REZAGADOS.Crear_Cuenta(@Id_Usuario NUMERIC(18,0),
										@Pais VARCHAR(255),
										@Moneda VARCHAR(255),
										@Fecha DATETIME,
										@Tipo VARCHAR(255),
										@RespuestaMensaje VARCHAR(255) OUTPUT,
										@Respuesta NUMERIC(18,0) OUTPUT)
AS
BEGIN
IF (@Tipo = 'Gratuito')
	BEGIN
		INSERT INTO REZAGADOS.Cuenta(Id_Usuario, Id_Pais, Id_Tipo_Cuenta, Id_Moneda, Id_Estado, Fecha_Creacion)
		VALUES (	@Id_Usuario,
					(SELECT Id_Pais FROM REZAGADOS.Pais WHERE Id_Pais=@Pais),
					(SELECT Id_Tipo_Cuenta FROM REZAGADOS.TipoCuenta WHERE Categoria=@Tipo),
					(SELECT Id_Moneda FROM REZAGADOS.Moneda WHERE Descripcion=@Moneda),
					(SELECT e.Id_Estado FROM REZAGADOS.Estado_Cuenta e	WHERE e.Nombre LIKE 'Habilitada'),
					@Fecha)
	SET @Respuesta = 1
	SET @RespuestaMensaje = 'Creación exitosa'
	END
ELSE
INSERT INTO REZAGADOS.Cuenta(Id_Usuario, Id_Pais, Id_Tipo_Cuenta, Id_Moneda, Id_Estado, Fecha_Creacion)
VALUES (@Id_Usuario, (SELECT Id_Pais FROM REZAGADOS.Pais WHERE Id_Pais=@Pais), (SELECT Id_Tipo_Cuenta FROM REZAGADOS.TipoCuenta WHERE Categoria=@Tipo), (SELECT Id_Moneda FROM REZAGADOS.Moneda WHERE Descripcion=@Moneda), 
(SELECT e.Id_Estado 
	 FROM REZAGADOS.Estado_Cuenta e 
	 WHERE e.Nombre LIKE 'Pendiente de activación'), @Fecha)
SET @RespuestaMensaje = 'Creación exitosa'
SET @Respuesta = (SELECT @@IDENTITY)
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
CREATE PROCEDURE REZAGADOS.Baja_Tarjeta(	@Nro_Tarjeta NUMERIC(18,0),
											@RespuestaMensaje VARCHAR(255) OUTPUT,
											@Respuesta NUMERIC(18,0) OUTPUT)
AS
BEGIN
UPDATE REZAGADOS.Tarjeta SET Habilitada=0 WHERE Tarjeta.Id_Tarjeta = @Nro_Tarjeta
SET @RespuestaMensaje = 'Baja exitosa'
SET @Respuesta = 1
END
GO

-------------------------------------------CREAR TARJETA-------------------------------------------------------

USE [GD1C2015]
GO
CREATE PROCEDURE REZAGADOS.Crear_Tarjeta(	@Usuario NUMERIC(18,0),
											@Nro_Tarjeta NUMERIC(18,0),
											@Tipo VARCHAR (255),
											@Fecha DATETIME,
											@Fecha_Venc DATETIME,
											@Codigo VARCHAR(255),
											@RespuestaMensaje VARCHAR(255) OUTPUT,
											@Respuesta NUMERIC(18,0) OUTPUT)
AS
BEGIN
IF EXISTS (SELECT Id_Tarjeta FROM REZAGADOS.Tarjeta WHERE Numero=@Nro_Tarjeta)
BEGIN
SET @RespuestaMensaje = 'Ya existe la tarjeta'
SET @Respuesta = -1
END
ELSE
INSERT INTO REZAGADOS.Tarjeta (Id_Usuario, Numero, Tipo, Codigo_Seguridad, Fecha_Emision, Vencimiento)
VALUES (@Usuario, @Nro_Tarjeta, @Tipo, @Codigo, @Fecha, @Fecha_Venc)
SET @Respuesta = (SELECT @@IDENTITY)
SET @RespuestaMensaje = 'Exito'
END
GO

---------------------------------------DEPOSITAR---------------------------------------------------------------

USE [GD1C2015]
IF OBJECT_ID ('REZAGADOS.Depositar') IS NOT NULL
    DROP PROCEDURE REZAGADOS.Depositar
GO

USE [GD1C2015]
GO
CREATE PROCEDURE REZAGADOS.Depositar(
@Cuenta NUMERIC(18,0),
@Importe NUMERIC(18,0),
@Moneda NUMERIC(18,0),
@Nro_Tarjeta NUMERIC(18,0), 
@Fecha DATETIME,
@Respuesta NUMERIC(18,0) OUTPUT,
@RespuestaMensaje VARCHAR(255) OUTPUT)
AS
BEGIN
DECLARE @Usuario NUMERIC(18,0) = (SELECT Id_Usuario FROM Cuenta WHERE @Cuenta=Id_Cuenta)
DECLARE @Cliente NUMERIC(18,0) = (SELECT Id_Cliente FROM Cliente WHERE @Usuario=Id_Usuario)
DECLARE @Pais NUMERIC(18,0) = (SELECT Id_Pais FROM Cliente WHERE @Cliente=Id_Cliente)
	IF (@Fecha > (SELECT Vencimiento FROM Tarjeta WHERE @Nro_Tarjeta=Numero))
	BEGIN
		SET @Respuesta = -1
		SET @RespuestaMensaje = 'Tarjeta Vencida'
		END
	ELSE
		IF (0=(SELECT habilitada FROM Tarjeta WHERE @Nro_Tarjeta=Numero))
			BEGIN
			SET @Respuesta = -1
			SET @RespuestaMensaje = 'Tarjeta Inhabilitada'
			END
		ELSE
			BEGIN
			INSERT INTO REZAGADOS.Deposito (Id_Cuenta, Id_Tarjeta, Id_Pais, Id_Moneda, Fecha, Importe)
			VALUES (@Cuenta, (SELECT Id_Tarjeta FROM Tarjeta WHERE Id_Usuario=@Usuario), @Pais, (SELECT Id_Moneda FROM Moneda WHERE @Moneda=Descripcion), @Fecha, @Importe)
			SET @Respuesta = @@IDENTITY
			SET @RespuestaMensaje = 'Deposito realizado'
			END
END
GO

-----------------------------------------RETIRO EFECTIVO--------------------------------------------------------------

USE [GD1C2015]
GO
CREATE PROCEDURE REZAGADOS.RetiroEfectivo(	@Usuario VARCHAR(255),
											@Tipo_Documento NUMERIC(18,0),
											@Nro_Documento NUMERIC(18,0),
											@Cuenta NUMERIC(18,0),
											@Importe NUMERIC(18,0),
											@Moneda VARCHAR(255),
											@Fecha DATETIME,
											@Respuesta NUMERIC(18,0) OUTPUT,
											@RespuestaMensaje VARCHAR(255) OUTPUT)
AS
BEGIN
	IF ((@Tipo_Documento <> (SELECT Id_Tipo_Documento FROM Cliente WHERE Id_Usuario = @Usuario)) OR (@Nro_Documento <> (SELECT Nro_Documento FROM Cliente WHERE Id_Usuario = @Usuario)))
	BEGIN
		SET @Respuesta = -1
	    SET @RespuestaMensaje = 'Documento ingresado diferente al documento del usuario logueado'
	END
	ELSE
		IF ((SELECT e.Nombre FROM Cuenta c INNER JOIN Estado_Cuenta e ON e.Id_Estado = c.Id_Estado WHERE @Usuario=Id_Usuario) = 'Inhabilitado')
		BEGIN
			SET @Respuesta = -1
			SET @RespuestaMensaje = 'Cuenta inhabilitada'
		END
		ELSE
			IF ((SELECT Saldo from Cuenta WHERE @Cuenta=Id_Cuenta)<=0)
			BEGIN
				SET @Respuesta = -1
				SET @RespuestaMensaje = 'Cuenta sin saldo'
			END
			ELSE
				IF ((SELECT Saldo from Cuenta WHERE @Cuenta=Id_Cuenta)>=@Importe)
				BEGIN
					SET @Respuesta = -1
					SET @RespuestaMensaje = 'Importe mayor al saldo'
				END
				ELSE
					IF (@Moneda <> 'Dolar')
					BEGIN
						SET @Respuesta = -1
						SET @RespuestaMensaje = 'Importe no expresado en dolares'
					END
					ELSE
						BEGIN
							INSERT INTO REZAGADOS.Retiro (Id_Cuenta, Fecha, Id_Moneda, Importe)
							VALUES (@Cuenta, @Fecha, (SELECT Id_Moneda FROM Moneda WHERE @Moneda=Descripcion), @Importe)

							INSERT INTO REZAGADOS.Cheque (Fecha, Id_Moneda, Importe)
							VALUES (@Fecha, (SELECT Id_Moneda FROM Moneda WHERE @Moneda=Descripcion), @Importe)
							SET @Respuesta = 1
							SET @RespuestaMensaje = 'Retiro realizado y Cheque generado'
						END
END
GO

----------------------------------------------TRANSFERENCIA ENTRE CUENTAS-------------------------------------------------------

USE [GD1C2015]
GO
CREATE PROCEDURE REZAGADOS.TransferenciaEntreCuentas (	@Usuario VARCHAR(255),
														@Tipo_Documento NUMERIC(18,0),
														@Cuenta_Origen NUMERIC(18,0),
														@Cuenta_Destino NUMERIC(18,0),
														@Importe NUMERIC(18,0),
														@Moneda VARCHAR(255),
														@Fecha DATETIME,
														@Respuesta NUMERIC(18,0) OUTPUT,
														@RespuestaMensaje VARCHAR(255) OUTPUT)
AS
BEGIN
	IF (@Cuenta_Origen NOT IN (SELECT Id_Cuenta from Cuenta WHERE @Usuario=Id_Usuario))
	BEGIN
		SET @Respuesta = -1	
		SET @RespuestaMensaje = 'Cuenta origen no pertenece al cliente'
	END
	ELSE
		IF (((SELECT e.Nombre FROM Cuenta c INNER JOIN Estado_Cuenta e ON e.Id_Estado = c.Id_Estado WHERE @Usuario=Id_Usuario) = 'Cerrada') OR
			((SELECT e.Nombre FROM Cuenta c INNER JOIN Estado_Cuenta e ON e.Id_Estado = c.Id_Estado WHERE @Usuario=Id_Usuario) = 'Pendiente de activación'))
		BEGIN
			SET @Respuesta = -1		
			SET @RespuestaMensaje = 'Cuenta destino cerrada o pendiente de activacion'
		END
		ELSE
			IF (@Importe<=0)
			BEGIN
				SET @Respuesta = -1			
				SET @RespuestaMensaje = 'Importe menor o igual a cero'
			END
			ELSE
				IF ((SELECT Saldo from Cuenta WHERE @Cuenta_Origen=Id_Cuenta)>=@Importe)
				BEGIN
					SET @Respuesta = -1			
					SET @RespuestaMensaje = 'Importe mayor al saldo'
				END
				ELSE
						UPDATE REZAGADOS.Cuenta SET
						Saldo=Saldo-@Importe
						WHERE Id_Cuenta=@Cuenta_Origen	
						UPDATE REZAGADOS.Cuenta SET
						Saldo=Saldo+@Importe
						WHERE Id_Cuenta=@Cuenta_Destino						
						
						IF ((SELECT Id_Usuario from Cuenta WHERE @Cuenta_Origen=Id_Cuenta)=(SELECT Id_Usuario from Cuenta WHERE @Cuenta_Destino=Id_Cuenta))
						BEGIN
							SET @Respuesta = 1						
							SET @RespuestaMensaje = 'Transferencia realizada sin costo'
						END
						ELSE
							BEGIN
								SET @Respuesta = 1						
								SET @RespuestaMensaje = 'Transferencia realizada con costo'
							END
END
GO

----------------------------------------------TRANSFERENCIA ROL-------------------------------------------------------

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
CREATE PROCEDURE REZAGADOS.Top5Depositos (	@Cuenta NUMERIC(18,0),
											@RespuestaMensaje VARCHAR(255) OUTPUT,
											@Respuesta NUMERIC(18,0) OUTPUT)
AS
BEGIN
    SELECT TOP 5 D.Id_Deposito, D.Codigo, D.Id_Cuenta, D.Id_Tarjeta, D. Id_Pais, D.Id_Moneda, D.Fecha, D.Importe, T.Numero AS 'Numero Tjta'
    FROM REZAGADOS.Deposito D, REZAGADOS.Tarjeta T
    WHERE D.Id_Cuenta = @Cuenta
    AND D.Id_Tarjeta = T.Id_Tarjeta
    ORDER BY Fecha DESC, Id_Deposito DESC
SET @RespuestaMensaje = 'Listado exitoso'
SET @Respuesta = 1
END
GO

----------------------------------------------TOP 5 RETIROS-------------------------------------------------------

USE [GD1C2015]
GO
CREATE PROCEDURE REZAGADOS.Top5Retiros (	@Cuenta NUMERIC(18,0),
											@RespuestaMensaje VARCHAR(255) OUTPUT,
											@Respuesta NUMERIC(18,0) OUTPUT)
AS
BEGIN

SELECT TOP 5 R.Id_Retiro, R.Id_Cuenta, R.Fecha, R.Id_Cuenta, R.Importe, C.Id_Cheque, C.Id_Retiro, C.Id_Banco, C.Fecha, C.Id_Moneda, C.Importe, C.Num_Egreso, C.Num_Item
FROM REZAGADOS.Retiro R, REZAGADOS.Cheque C
WHERE R.Id_Cuenta = @Cuenta
AND R.Id_Retiro = C.Id_Retiro
ORDER BY R.Fecha DESC, C.Id_Retiro DESC
SET @RespuestaMensaje = 'Listado exitoso'
SET @Respuesta = 1
END
GO

----------------------------------------------TOP 10 TRANSFERENCIAS-------------------------------------------------------

USE [GD1C2015]
GO
CREATE PROCEDURE REZAGADOS.Top10Transferencias (@Cuenta_Emi NUMERIC(18,0),
												@RespuestaMensaje VARCHAR(255) OUTPUT,
												@Respuesta NUMERIC(18,0) OUTPUT)
AS
BEGIN
    SELECT TOP 10 T.Id_Transferencia, T.Id_Cuenta_Emi, T.Id_Cuenta_Dest, T.Fecha, T.Id_Moneda, T.Importe
    FROM REZAGADOS.Transferencia T
    WHERE T.Id_Cuenta_Emi = @Cuenta_Emi
    ORDER BY T.Fecha DESC, T.Id_Transferencia DESC
    SET @RespuestaMensaje = 'Listado exitoso'
	SET @Respuesta = 1
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
	SELECT c.Id_Cuenta ID, c.Id_Usuario PROPIETARIO, c.Id_Pais PAIS,c.Id_Tipo_Cuenta TIPO_CUENTA,
	c.Id_Moneda MONEDA, c.Id_Estado ESTADO, c.Fecha_Cierre FECHA_CIERRE, c.Fecha_Creacion FECHA_CREACION,
	c.Saldo SALDO
	FROM  [REZAGADOS].Cuenta c 
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
	SELECT c.Id_Cuenta ID, c.Id_Usuario PROPIETARIO, c.Id_Pais PAIS,c.Id_Tipo_Cuenta TIPO_CUENTA,
	c.Id_Moneda MONEDA, c.Id_Estado ESTADO, c.Fecha_Cierre FECHA_CIERRE, c.Fecha_Creacion FECHA_CREACION,
	c.Saldo SALDO
	FROM  [REZAGADOS].Cuenta c 
	WHERE c.Id_Usuario = @Id_Usuario
END
GO

---------------------------------------------LISTAR CUENTA CLIENTE--------------------------------------------

USE [GD1C2015]
GO

CREATE PROCEDURE [REZAGADOS].[Listar_Cuenta_Cliente]
@Id_Cliente int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT c.Id_Cuenta ID, c.Id_Usuario PROPIETARIO, c.Id_Pais PAIS,c.Id_Tipo_Cuenta TIPO_CUENTA,
	c.Id_Moneda MONEDA, c.Id_Estado ESTADO, c.Fecha_Cierre FECHA_CIERRE, c.Fecha_Creacion FECHA_CREACION,
	c.Saldo SALDO
	FROM  [REZAGADOS].Cuenta c INNER JOIN Usuario u on c.Id_Usuario = u.Id_Usuario INNER JOIN Cliente cli on u.Id_Usuario = cli.Id_Usuario
	WHERE cli.Id_Cliente = @Id_Cliente
END
GO

-----------------------------------------LISTAR CLIENTE ID USUARIO-------------------------------------

USE [GD1C2015]
GO

CREATE PROCEDURE [REZAGADOS].[Listar_Cliente_ID_Usuario]
@Id_Usuario int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT c.Id_Cliente ID, c.Nombre NOMBRE, c.Apellido APELLIDO,
	c.Id_Usuario USUARIO, c.Id_Tipo_Documento DOCUMENTO, c.Nro_Documento NRO_DOCUMENTO,
	c.Id_Pais PAIS,	c.Direccion_Calle DIRECCION_CALLE, c.Direccion_Numero_Calle DIRECCION_NRO,
	c.Direccion_Piso DIRECCION_PISO, c.Direccion_Departamento DIRECCION_DEPTO, 
	c.Fecha_Nacimiento FECHA_NACIMIENTO, c.Mail EMAIL, c.Localidad LOCALIDAD,
	c.Habilitada HABILITADA
	FROM  [REZAGADOS].Cliente c 
	WHERE c.Id_Usuario = @Id_Usuario
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
	c.Habilitada HABILITADA
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
	c.Habilitada HABILITADA
	FROM  [REZAGADOS].Cliente c 
	WHERE c.Id_Cliente = @Id;
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
				SELECT @Id_Rol,Id_Funcionalidad FROM @Funcionalidades;
			
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

-----------------------------------------LISTAR CUENTA TIPO----------------------------------------

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

----------------------------------------BUSCAR CUENTA TIPO ID---------------------------------------------------------

USE [GD1C2015]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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

-----------------------------------------LISTAR DOCUMENTO----------------------------------------

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

-----------------------------------------BUSCAR DOCUMENTO ID----------------------------------------

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

----------------------------------------------------FACTURACION DE COSTOS------------------------------------------
--------------------------------------------------------FACTURAR---------------------------------------------------

USE [GD1C2015]
IF OBJECT_ID ('[REZAGADOS].[Facturar]') IS NOT NULL
    DROP PROCEDURE [REZAGADOS].[Facturar]

USE [GD1C2015]
GO
CREATE PROCEDURE [REZAGADOS].[Facturar] (	@Id_Items IdLista READONLY,
											@Id_Usuario NUMERIC(18,0),
											@Respuesta NUMERIC(18,0) OUTPUT,
											@RespuestaMensaje VARCHAR(255) OUTPUT)
 AS
SET NOCOUNT ON
BEGIN TRY
BEGIN TRANSACTION
	BEGIN	
		--DECLARE @TOTAL INT SET SELECT SUM(Importe) FROM REZAGADOS.Item WHERE Id_Item IN (SELECT * FROM @Id_Items)
		--INSERT INTO REZAGADOS.Factura (Id_Usuario, Fecha) VALUES (SELECT Id_Usuario FROM REZAGADOS.Item, REZAGADOS.Cuenta WHERE Cuenta.Id_Cuenta=Item.Id_Cuenta 
		INSERT INTO REZAGADOS.Factura (Id_Usuario, Fecha) VALUES (@Id_Usuario, GETDATE())
		DECLARE @Id_Factura NUMERIC(18,0) = (SELECT @@IDENTITY)
		UPDATE REZAGADOS.Item SET Id_Factura=@Id_Factura WHERE Id_Item IN (SELECT * FROM @Id_Items)
		SET @Respuesta = 1
		SET @RespuestaMensaje = 'Items pagados exitosamente'
	END
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

-----------------------------------------------LISTADOS ESTADISTICOS----------------------------------------------
---------------------------------CLIENTES CON ALGUNA CUENTA INHABILITADA POR TRIMESTRE----------------------------

/*

SELECT TOP 5 Id_Cliente
FROM REZAGADOS.Cuenta, REZAGADOS.Cliente
WHERE Cuenta.Id_Usuario = Cliente.Id_Usuario
AND (SELECT COUNT(Item.Id_Cuenta)
	FROM REZAGADOS.Item
	WHERE Id_Factura IS NULL AND Item.Fecha > GETDATE()
	GROUP BY Item.Id_Cuenta) > 5
	
*/