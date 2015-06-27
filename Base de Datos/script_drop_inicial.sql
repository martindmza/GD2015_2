------------------------------------------------------------------------------------
---------------------------------DROP TERMPORAL-------------------------------------
------------------------------------------------------------------------------------

USE [GD1C2015]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[REZAGADOS].[FK_FuncionalidadXRol_to_Rol]') 
	AND parent_object_id = OBJECT_ID(N'[REZAGADOS].[FuncionalidadXRol]'))
	ALTER TABLE REZAGADOS.FuncionalidadXRol DROP CONSTRAINT FK_FuncionalidadXRol_to_Rol;

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[REZAGADOS].[FK_FuncionalidadXRol_to_Funcionalidad]') 
	AND parent_object_id = OBJECT_ID(N'[REZAGADOS].[FuncionalidadXRol]'))
	ALTER TABLE REZAGADOS.FuncionalidadXRol DROP CONSTRAINT FK_FuncionalidadXRol_to_Funcionalidad;

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[REZAGADOS].[FK_UsuarioXRol_to_Rol]') 
	AND parent_object_id = OBJECT_ID(N'[REZAGADOS].[UsuarioXRol]'))
	ALTER TABLE REZAGADOS.UsuarioXRol DROP CONSTRAINT FK_UsuarioXRol_to_Rol;
	
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[REZAGADOS].[FK_UsuarioXRol_to_Usuario]') 
	AND parent_object_id = OBJECT_ID(N'[REZAGADOS].[UsuarioXRol]'))
	ALTER TABLE REZAGADOS.UsuarioXRol DROP CONSTRAINT FK_UsuarioXRol_to_Usuario;
	
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[REZAGADOS].[FK_Administrador_to_Usuario]') 
	AND parent_object_id = OBJECT_ID(N'[REZAGADOS].[Administrador]'))
	ALTER TABLE REZAGADOS.Administrador DROP CONSTRAINT FK_Administrador_to_Usuario;
	
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[REZAGADOS].[FK_Cliente_to_Usuario]') 
	AND parent_object_id = OBJECT_ID(N'[REZAGADOS].[Cliente]'))
	ALTER TABLE REZAGADOS.Cliente DROP CONSTRAINT FK_Cliente_to_Usuario;
	
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[REZAGADOS].[FK_Cliente_to_TipoDocumento]') 
	AND parent_object_id = OBJECT_ID(N'[REZAGADOS].[Cliente]'))
	ALTER TABLE REZAGADOS.Cliente DROP CONSTRAINT FK_Cliente_to_TipoDocumento;

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[REZAGADOS].[FK_Cliente_to_Pais]') 
	AND parent_object_id = OBJECT_ID(N'[REZAGADOS].[Cliente]'))
	ALTER TABLE REZAGADOS.Cliente DROP CONSTRAINT FK_Cliente_to_Pais;
	
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[REZAGADOS].[FK_Cuenta_to_Usuario]') 
	AND parent_object_id = OBJECT_ID(N'[REZAGADOS].[Cuenta]'))
	ALTER TABLE REZAGADOS.Cuenta DROP CONSTRAINT FK_Cuenta_to_Usuario;
	
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[REZAGADOS].[FK_Cuenta_to_TipoCuenta]') 
	AND parent_object_id = OBJECT_ID(N'[REZAGADOS].[Cuenta]'))
	ALTER TABLE REZAGADOS.Cuenta DROP CONSTRAINT FK_Cuenta_to_TipoCuenta;
	
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[REZAGADOS].[FK_Cuenta_to_Pais]') 
	AND parent_object_id = OBJECT_ID(N'[REZAGADOS].[Cuenta]'))
	ALTER TABLE REZAGADOS.Cuenta DROP CONSTRAINT FK_Cuenta_to_Pais;
	
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[REZAGADOS].[FK_Cuenta_to_Moneda]') 
	AND parent_object_id = OBJECT_ID(N'[REZAGADOS].[Cuenta]'))
	ALTER TABLE REZAGADOS.Cuenta DROP CONSTRAINT FK_Cuenta_to_Moneda;
	
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[REZAGADOS].[FK_Cuenta_to_EstadoCuenta]') 
	AND parent_object_id = OBJECT_ID(N'[REZAGADOS].[Cuenta]'))
	ALTER TABLE REZAGADOS.Cuenta DROP CONSTRAINT FK_Cuenta_to_EstadoCuenta;
	
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[REZAGADOS].[FK_Historial_Cuenta_to_Cuenta]') 
	AND parent_object_id = OBJECT_ID(N'[REZAGADOS].[HistorialCuenta]'))
	ALTER TABLE REZAGADOS.HistorialCuenta DROP CONSTRAINT FK_Historial_Cuenta_to_Cuenta;
	
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[REZAGADOS].[FK_Deposito_to_Cuenta]') 
	AND parent_object_id = OBJECT_ID(N'[REZAGADOS].[Deposito]'))
	ALTER TABLE REZAGADOS.Deposito DROP CONSTRAINT FK_Deposito_to_Cuenta;
	
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[REZAGADOS].[FK_Deposito_to_Pais]') 
	AND parent_object_id = OBJECT_ID(N'[REZAGADOS].[Deposito]'))
	ALTER TABLE REZAGADOS.Deposito DROP CONSTRAINT FK_Deposito_to_Pais;

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[REZAGADOS].[FK_Deposito_to_Tarjeta]') 
	AND parent_object_id = OBJECT_ID(N'[REZAGADOS].[Deposito]'))
	ALTER TABLE REZAGADOS.Deposito DROP CONSTRAINT FK_Deposito_to_Tarjeta;

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[REZAGADOS].[FK_Deposito_to_Moneda]') 
	AND parent_object_id = OBJECT_ID(N'[REZAGADOS].[Deposito]'))
	ALTER TABLE REZAGADOS.Deposito DROP CONSTRAINT FK_Deposito_to_Moneda;
	
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[REZAGADOS].[FK_Tarjeta_to_Usuario]') 
	AND parent_object_id = OBJECT_ID(N'[REZAGADOS].[Tarjeta]'))
	ALTER TABLE REZAGADOS.Tarjeta DROP CONSTRAINT FK_Tarjeta_to_Usuario;

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[REZAGADOS].[FK_Transferencia_to_Cuenta_Emi]') 
	AND parent_object_id = OBJECT_ID(N'[REZAGADOS].[Transferencia]'))
	ALTER TABLE REZAGADOS.Transferencia DROP CONSTRAINT FK_Transferencia_to_Cuenta_Emi;
	
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[REZAGADOS].[FK_Transferencia_to_Cuenta_Dest]') 
	AND parent_object_id = OBJECT_ID(N'[REZAGADOS].[Transferencia]'))
	ALTER TABLE REZAGADOS.Transferencia DROP CONSTRAINT FK_Transferencia_to_Cuenta_Dest;
	
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[REZAGADOS].[FK_Retiro_to_Cuenta]') 
	AND parent_object_id = OBJECT_ID(N'[REZAGADOS].[Retiro]'))
	ALTER TABLE REZAGADOS.Retiro DROP CONSTRAINT FK_Retiro_to_Cuenta;
	
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[REZAGADOS].[FK_Retiro_to_Moneda]') 
	AND parent_object_id = OBJECT_ID(N'[REZAGADOS].[Retiro]'))
	ALTER TABLE REZAGADOS.Retiro DROP CONSTRAINT FK_Retiro_to_Moneda;
	
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[REZAGADOS].[FK_Cheque_to_Retiro]') 
	AND parent_object_id = OBJECT_ID(N'[REZAGADOS].[Cheque]'))
	ALTER TABLE REZAGADOS.Cheque DROP CONSTRAINT FK_Cheque_to_Retiro;
	
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[REZAGADOS].[FK_Cheque_to_Banco]') 
	AND parent_object_id = OBJECT_ID(N'[REZAGADOS].[Cheque]'))
	ALTER TABLE REZAGADOS.Cheque DROP CONSTRAINT FK_Cheque_to_Banco;
	
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[REZAGADOS].[FK_Cheque_to_Moneda]') 
	AND parent_object_id = OBJECT_ID(N'[REZAGADOS].[Cheque]'))
	ALTER TABLE REZAGADOS.Cheque DROP CONSTRAINT FK_Cheque_to_Moneda;
	
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[REZAGADOS].[FK_Item_to_Factura]') 
	AND parent_object_id = OBJECT_ID(N'[REZAGADOS].[Item]'))
	ALTER TABLE REZAGADOS.Item DROP CONSTRAINT FK_Item_to_Factura;
	
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[REZAGADOS].[FK_Item_to_Tipo_Item]') 
	AND parent_object_id = OBJECT_ID(N'[REZAGADOS].[Item]'))
	ALTER TABLE REZAGADOS.Item DROP CONSTRAINT FK_Item_to_Tipo_Item;
	
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[REZAGADOS].[FK_Item_to_Cuenta]') 
	AND parent_object_id = OBJECT_ID(N'[REZAGADOS].[Item]'))
	ALTER TABLE REZAGADOS.Item DROP CONSTRAINT FK_Item_to_Cuenta;
	
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[REZAGADOS].[FK_Factura_to_Usuario]') 
	AND parent_object_id = OBJECT_ID(N'[REZAGADOS].[Factura]'))
	ALTER TABLE REZAGADOS.Factura DROP CONSTRAINT FK_Factura_to_Usuario;

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[REZAGADOS].[FK_Historial_Usuario_to_Usuario]') 
	AND parent_object_id = OBJECT_ID(N'[REZAGADOS].[HistorialUsuario]'))
	ALTER TABLE REZAGADOS.HistorialUsuario DROP CONSTRAINT FK_Historial_Usuario_to_Usuario;


IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[REZAGADOS].[Rol]') AND type in (N'U'))
	DROP TABLE REZAGADOS.Rol;
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[REZAGADOS].[Funcionalidad]') AND type in (N'U'))	
	DROP TABLE REZAGADOS.Funcionalidad;
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[REZAGADOS].[FuncionalidadXRol]') AND type in (N'U'))
	DROP TABLE REZAGADOS.FuncionalidadXRol;
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[REZAGADOS].[Usuario]') AND type in (N'U'))	
	DROP TABLE REZAGADOS.Usuario;
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[REZAGADOS].[UsuarioXRol]') AND type in (N'U'))
	DROP TABLE REZAGADOS.UsuarioXRol;
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[REZAGADOS].[Administrador]') AND type in (N'U'))
	DROP TABLE REZAGADOS.Administrador;
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[REZAGADOS].[Cliente]') AND type in (N'U'))	
	DROP TABLE REZAGADOS.Cliente;
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[REZAGADOS].[TipoDocumento]') AND type in (N'U'))
	DROP TABLE REZAGADOS.TipoDocumento;
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[REZAGADOS].[Tarjeta]') AND type in (N'U'))
	DROP TABLE REZAGADOS.Tarjeta;
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[REZAGADOS].[Factura]') AND type in (N'U'))
	DROP TABLE REZAGADOS.Factura;
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[REZAGADOS].[Pais]') AND type in (N'U'))
	DROP TABLE REZAGADOS.Pais;
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[REZAGADOS].[Cuenta]') AND type in (N'U'))
	DROP TABLE REZAGADOS.Cuenta;
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[REZAGADOS].[Estado_Cuenta]') AND type in (N'U'))
	DROP TABLE REZAGADOS.Estado_Cuenta;
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[REZAGADOS].[Deposito]') AND type in (N'U'))
	DROP TABLE REZAGADOS.Deposito;
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[REZAGADOS].[Retiro]') AND type in (N'U'))
	DROP TABLE REZAGADOS.Retiro;
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[REZAGADOS].[Cheque]') AND type in (N'U'))
	DROP TABLE REZAGADOS.Cheque;
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[REZAGADOS].[Banco]') AND type in (N'U'))
	DROP TABLE REZAGADOS.Banco;
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[REZAGADOS].[TipoCuenta]') AND type in (N'U'))
	DROP TABLE REZAGADOS.TipoCuenta;
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[REZAGADOS].[Transferencia]') AND type in (N'U'))
	DROP TABLE REZAGADOS.Transferencia;
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[REZAGADOS].[HistorialCuenta]') AND type in (N'U'))
	DROP TABLE REZAGADOS.HistorialCuenta;
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[REZAGADOS].[Moneda]') AND type in (N'U'))
	DROP TABLE REZAGADOS.Moneda;
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[REZAGADOS].[TipoItem]') AND type in (N'U'))
	DROP TABLE REZAGADOS.TipoItem;
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[REZAGADOS].[Item]') AND type in (N'U'))
	DROP TABLE REZAGADOS.Item;
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[REZAGADOS].[HistorialUsuario]') AND type in (N'U'))
	DROP TABLE REZAGADOS.HistorialUsuario;
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[REZAGADOS].[Crear_Cliente]') AND type in (N'P', N'PC'))
	DROP PROCEDURE REZAGADOS.Crear_Cliente;
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[REZAGADOS].[Modificar_Cliente]') AND type in (N'P', N'PC'))	
	DROP PROCEDURE REZAGADOS.Modificar_Cliente;
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[REZAGADOS].[Alta_Cliente]') AND type in (N'P', N'PC'))
	DROP PROCEDURE REZAGADOS.Alta_Cliente;
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[REZAGADOS].[Baja_Cliente]') AND type in (N'P', N'PC'))
	DROP PROCEDURE REZAGADOS.Baja_Cliente;
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[REZAGADOS].[Alta_Usuario]') AND type in (N'P', N'PC'))
	DROP PROCEDURE REZAGADOS.Alta_Usuario;
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[REZAGADOS].[Baja_Usuario]') AND type in (N'P', N'PC'))
	DROP PROCEDURE REZAGADOS.Baja_Usuario;
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[REZAGADOS].[Crear_Rol]') AND type in (N'P', N'PC'))
	DROP PROCEDURE REZAGADOS.Crear_Rol;
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[REZAGADOS].[Baja_Rol]') AND type in (N'P', N'PC'))
	DROP PROCEDURE REZAGADOS.Baja_Rol;
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[REZAGADOS].[Alta_Rol]') AND type in (N'P', N'PC'))
	DROP PROCEDURE REZAGADOS.Alta_Rol;
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[REZAGADOS].[Modificar_Rol]') AND type in (N'P', N'PC'))
	DROP PROCEDURE REZAGADOS.Modificar_Rol
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[REZAGADOS].[Asignar_Rol]') AND type in (N'P', N'PC'))
	DROP PROCEDURE REZAGADOS.Asignar_Rol;
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[REZAGADOS].[Desasignar_Rol]') AND type in (N'P', N'PC'))
	DROP PROCEDURE REZAGADOS.Desasignar_Rol;
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[REZAGADOS].[Login]') AND type in (N'P', N'PC'))
	DROP PROCEDURE REZAGADOS.Login;
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[REZAGADOS].[Cambio_Contrasenia]') AND type in (N'P', N'PC'))
	DROP PROCEDURE REZAGADOS.Cambio_Contrasenia;
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[REZAGADOS].[Modificar_Nombre_Funcionalidad]') AND type in (N'P', N'PC'))
	DROP PROCEDURE REZAGADOS.Modificar_Nombre_Funcionalidad;
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[REZAGADOS].[Baja_Cuenta]') AND type in (N'P', N'PC'))
	DROP PROCEDURE REZAGADOS.Baja_Cuenta;
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[REZAGADOS].[Alta_Cuenta]') AND type in (N'P', N'PC'))
	DROP PROCEDURE REZAGADOS.Alta_Cuenta;
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[REZAGADOS].[Crear_Cuenta]') AND type in (N'P', N'PC'))
	DROP PROCEDURE REZAGADOS.Crear_Cuenta;
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[REZAGADOS].[Modificar_Costo_Cuenta]') AND type in (N'P', N'PC'))
	DROP PROCEDURE REZAGADOS.Modificar_Costo_Cuenta;
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[REZAGADOS].[Alta_Tarjeta]') AND type in (N'P', N'PC'))
	DROP PROCEDURE REZAGADOS.Alta_Tarjeta;
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[REZAGADOS].[Baja_Tarjeta]') AND type in (N'P', N'PC'))
	DROP PROCEDURE REZAGADOS.Baja_Tarjeta;
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[REZAGADOS].[Crear_Tarjeta]') AND type in (N'P', N'PC'))
	DROP PROCEDURE REZAGADOS.Crear_Tarjeta;
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[REZAGADOS].[Depositar]') AND type in (N'P', N'PC'))
	DROP PROCEDURE REZAGADOS.Depositar;
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[REZAGADOS].[RetiroEfectivo]') AND type in (N'P', N'PC'))
	DROP PROCEDURE REZAGADOS.RetiroEfectivo;
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[REZAGADOS].[TransferenciaEntreCuentas]') AND type in (N'P', N'PC'))
	DROP PROCEDURE REZAGADOS.TransferenciaEntreCuentas;
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[REZAGADOS].[Listar_Funcionalidad_Rol]') AND type in (N'P', N'PC'))
	DROP PROCEDURE REZAGADOS.Listar_Funcionalidad_Rol;
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[REZAGADOS].[Listar_Funcionalidad]') AND type in (N'P', N'PC'))
	DROP PROCEDURE REZAGADOS.Listar_Funcionalidad;
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[REZAGADOS].[Listar_Rol_Usuario]') AND type in (N'P', N'PC'))
	DROP PROCEDURE REZAGADOS.Listar_Rol_Usuario;
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[REZAGADOS].[Listar_Rol]') AND type in (N'P', N'PC'))
	DROP PROCEDURE REZAGADOS.Listar_Rol;
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[REZAGADOS].[Listar_Pais]') AND type in (N'P', N'PC'))
	DROP PROCEDURE REZAGADOS.Listar_Pais;
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[REZAGADOS].[Top5Depositos]') AND type in (N'P', N'PC'))
	DROP PROCEDURE REZAGADOS.Top5Depositos;
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[REZAGADOS].[Top5Retiros]') AND type in (N'P', N'PC'))
	DROP PROCEDURE REZAGADOS.Top5Retiros;
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[REZAGADOS].[Top10Transferencias]') AND type in (N'P', N'PC'))
	DROP PROCEDURE REZAGADOS.Top10Transferencias;
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[REZAGADOS].[Buscar_User_ID]') AND type in (N'P', N'PC'))
	DROP PROCEDURE REZAGADOS.Buscar_User_ID;
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[REZAGADOS].[Listar_Cuenta]') AND type in (N'P', N'PC'))
	DROP PROCEDURE REZAGADOS.Listar_Cuenta;
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[REZAGADOS].[Listar_Cuenta_Usuario]') AND type in (N'P', N'PC'))
	DROP PROCEDURE REZAGADOS.Listar_Cuenta_Usuario;
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[REZAGADOS].[Listar_Cuenta_Cliente]') AND type in (N'P', N'PC'))
	DROP PROCEDURE REZAGADOS.Listar_Cuenta_Cliente;
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[REZAGADOS].[Listar_Cliente_ID_Usuario]') AND type in (N'P', N'PC'))
	DROP PROCEDURE REZAGADOS.Listar_Cliente_ID_Usuario;
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[REZAGADOS].[Listar_Cliente]') AND type in (N'P', N'PC'))
	DROP PROCEDURE REZAGADOS.Listar_Cliente;
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[REZAGADOS].[Buscar_Pais_Id]') AND type in (N'P', N'PC'))
	DROP PROCEDURE REZAGADOS.Buscar_Pais_Id;
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[REZAGADOS].[Buscar_Cliente_ID]') AND type in (N'P', N'PC'))
	DROP PROCEDURE REZAGADOS.Buscar_Cliente_ID;
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[REZAGADOS].[Buscar_Rol_Id]') AND type in (N'P', N'PC'))
	DROP PROCEDURE REZAGADOS.Buscar_Rol_Id;
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[REZAGADOS].[Buscar_Rol_Filtros]') AND type in (N'P', N'PC'))
	DROP PROCEDURE REZAGADOS.Buscar_Rol_Filtros;
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[REZAGADOS].[Buscar_Estado_Id]') AND type in (N'P', N'PC'))
	DROP PROCEDURE REZAGADOS.Buscar_Estado_Id;
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[REZAGADOS].[Listar_Estado]') AND type in (N'P', N'PC'))
	DROP PROCEDURE REZAGADOS.Listar_Estado;
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[REZAGADOS].[Modificar_Tipo_Cuenta]') AND type in (N'P', N'PC'))
	DROP PROCEDURE REZAGADOS.[Modificar_Tipo_Cuenta];



DROP TYPE REZAGADOS.FuncionalidadesLista;

USE [GD1C2015]
GO
IF  EXISTS (SELECT * FROM sys.schemas WHERE name = N'REZAGADOS')
	DROP SCHEMA [REZAGADOS]
GO