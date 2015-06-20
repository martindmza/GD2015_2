------------------------------------------------------------------------------------
---------------------------------DROP TERMPORAL-------------------------------------
------------------------------------------------------------------------------------

USE [GD1C2015]
GO

ALTER TABLE REZAGADOS.FuncionalidadXRol DROP CONSTRAINT FK_FuncionalidadXRol_to_Rol;
ALTER TABLE REZAGADOS.FuncionalidadXRol DROP CONSTRAINT FK_FuncionalidadXRol_to_Funcionalidad;
ALTER TABLE REZAGADOS.UsuarioXRol DROP CONSTRAINT FK_UsuarioXRol_to_Rol;
ALTER TABLE REZAGADOS.UsuarioXRol DROP CONSTRAINT FK_UsuarioXRol_to_Usuario;
ALTER TABLE REZAGADOS.Administrador DROP CONSTRAINT FK_Administrador_to_Usuario;
ALTER TABLE REZAGADOS.Cliente DROP CONSTRAINT FK_Cliente_to_Usuario;
ALTER TABLE REZAGADOS.Cliente DROP CONSTRAINT FK_Cliente_to_TipoDocumento;
ALTER TABLE REZAGADOS.Cliente DROP CONSTRAINT FK_Cliente_to_Pais;
ALTER TABLE REZAGADOS.Cuenta DROP CONSTRAINT FK_Cuenta_to_Usuario;
ALTER TABLE REZAGADOS.Cuenta DROP CONSTRAINT FK_Cuenta_to_TipoCuenta;
ALTER TABLE REZAGADOS.Cuenta DROP CONSTRAINT FK_Cuenta_to_Pais;
ALTER TABLE REZAGADOS.Cuenta DROP CONSTRAINT FK_Cuenta_to_Moneda;
ALTER TABLE REZAGADOS.HistorialCuenta DROP CONSTRAINT FK_Historial_Cuenta_to_Cuenta;
ALTER TABLE REZAGADOS.Deposito DROP CONSTRAINT FK_Deposito_to_Cuenta;
ALTER TABLE REZAGADOS.Deposito DROP CONSTRAINT FK_Deposito_to_Pais;
ALTER TABLE REZAGADOS.Deposito DROP CONSTRAINT FK_Deposito_to_Tarjeta;
ALTER TABLE REZAGADOS.Deposito DROP CONSTRAINT FK_Deposito_to_Moneda;
ALTER TABLE REZAGADOS.Tarjeta DROP CONSTRAINT FK_Tarjeta_to_Usuario;
ALTER TABLE REZAGADOS.Transferencia DROP CONSTRAINT FK_Transferencia_to_Cuenta_Emi;
ALTER TABLE REZAGADOS.Transferencia DROP CONSTRAINT FK_Transferencia_to_Cuenta_Dest;
ALTER TABLE REZAGADOS.Retiro DROP CONSTRAINT FK_Retiro_to_Cuenta;
ALTER TABLE REZAGADOS.Retiro DROP CONSTRAINT FK_Retiro_to_Moneda;
ALTER TABLE REZAGADOS.Cheque DROP CONSTRAINT FK_Cheque_to_Retiro;
ALTER TABLE REZAGADOS.Cheque DROP CONSTRAINT FK_Cheque_to_Banco;
ALTER TABLE REZAGADOS.Cheque DROP CONSTRAINT FK_Cheque_to_Moneda;
ALTER TABLE REZAGADOS.Item DROP CONSTRAINT FK_Item_to_Factura;
ALTER TABLE REZAGADOS.Item DROP CONSTRAINT FK_Item_to_Tipo_Item;
ALTER TABLE REZAGADOS.Item DROP CONSTRAINT FK_Item_to_Cuenta;
ALTER TABLE REZAGADOS.Factura DROP CONSTRAINT FK_Factura_to_Usuario;
ALTER TABLE REZAGADOS.HistorialUsuario DROP CONSTRAINT FK_Historial_Usuario_to_Usuario;

DROP TABLE REZAGADOS.Rol;
DROP TABLE REZAGADOS.Funcionalidad;
DROP TABLE REZAGADOS.FuncionalidadXRol;
DROP TABLE REZAGADOS.Usuario;
DROP TABLE REZAGADOS.UsuarioXRol;
DROP TABLE REZAGADOS.Administrador;
DROP TABLE REZAGADOS.Cliente;
DROP TABLE REZAGADOS.TipoDocumento;
DROP TABLE REZAGADOS.Tarjeta;
DROP TABLE REZAGADOS.Factura;
DROP TABLE REZAGADOS.Pais;
DROP TABLE REZAGADOS.Cuenta;
DROP TABLE REZAGADOS.Deposito;
DROP TABLE REZAGADOS.Retiro;
DROP TABLE REZAGADOS.Cheque;
DROP TABLE REZAGADOS.Banco;
DROP TABLE REZAGADOS.TipoCuenta;
DROP TABLE REZAGADOS.Transferencia;
DROP TABLE REZAGADOS.HistorialCuenta;
DROP TABLE REZAGADOS.Moneda;
DROP TABLE REZAGADOS.TipoItem;
DROP TABLE REZAGADOS.Item;
DROP TABLE REZAGADOS.HistorialUsuario;

DROP PROCEDURE REZAGADOS.Crear_Cliente;
DROP PROCEDURE REZAGADOS.Modificar_Cliente;
DROP PROCEDURE REZAGADOS.Alta_Cliente;
DROP PROCEDURE REZAGADOS.Baja_Cliente;
DROP PROCEDURE REZAGADOS.Alta_Usuario;
DROP PROCEDURE REZAGADOS.Baja_Usuario;
DROP PROCEDURE REZAGADOS.Crear_Rol;
DROP PROCEDURE REZAGADOS.Borrar_Rol;
DROP PROCEDURE REZAGADOS.Baja_Rol;
DROP PROCEDURE REZAGADOS.Alta_Rol;
DROP PROCEDURE REZAGADOS.Modificar_Nombre_Rol;
DROP PROCEDURE REZAGADOS.Asignar_Rol;
DROP PROCEDURE REZAGADOS.Desasignar_Rol;
DROP PROCEDURE REZAGADOS.Login;
DROP PROCEDURE REZAGADOS.Cambio_Contrasenia;
DROP PROCEDURE REZAGADOS.Modificar_Nombre_Funcionalidad;
DROP PROCEDURE REZAGADOS.Crear_Funcionalidad;
DROP PROCEDURE REZAGADOS.Borrar_Funcionalidad;
DROP PROCEDURE REZAGADOS.Baja_Cuenta;
DROP PROCEDURE REZAGADOS.Alta_Cuenta;
DROP PROCEDURE REZAGADOS.Crear_Cuenta;
DROP PROCEDURE REZAGADOS.Modificar_Costo_Cuenta;
DROP PROCEDURE REZAGADOS.Alta_Tarjeta;
DROP PROCEDURE REZAGADOS.Baja_Tarjeta;
DROP PROCEDURE REZAGADOS.Crear_Tarjeta;
DROP PROCEDURE REZAGADOS.Depositar;
DROP PROCEDURE REZAGADOS.RetiroEfectivo;
DROP PROCEDURE REZAGADOS.TransferenciaEntreCuentas;
DROP PROCEDURE REZAGADOS.Listar_Funcionalidad_Rol;
DROP PROCEDURE REZAGADOS.Listar_Rol_Usuario;
DROP PROCEDURE REZAGADOS.Listar_Rol;
DROP PROCEDURE REZAGADOS.Listar_Pais;
DROP PROCEDURE REZAGADOS.Top5Depositos;
DROP PROCEDURE REZAGADOS.Top5Retiros;
DROP PROCEDURE REZAGADOS.Top10Transferencias;
DROP PROCEDURE REZAGADOS.Buscar_User_ID;
DROP PROCEDURE REZAGADOS.Listar_Cuenta;
DROP PROCEDURE REZAGADOS.Listar_Cuenta_Usuario;
DROP PROCEDURE REZAGADOS.Listar_Cuenta_Cliente;
DROP PROCEDURE REZAGADOS.Listar_Cliente_ID_Usuario;
DROP PROCEDURE REZAGADOS.Listar_Cliente;
DROP PROCEDURE REZAGADOS.Buscar_Pais_Id;
DROP PROCEDURE REZAGADOS.Buscar_Cliente_ID;


USE [GD1C2015]
GO
DROP SCHEMA [REZAGADOS]
GO