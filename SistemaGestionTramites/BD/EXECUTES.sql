USE SistemaGestion
GO

-- 1-
EXEC sp_listarEntidades  
GO

-- 2- 
EXEC sp_listarTramitesPorEntidades 'Banco Hipodecario del Uruguay'
GO

-- 3- 

EXEC sp_consultaEspadoDeSolicitud 1
go

-- 4- LOGIN


DECLARE @r int
EXEC @r = sp_corroborarUsryPwr 40088371 , 'admin12'
SELECT @r 'Retorno', 
	CASE @r
	WHEN 1 THEN 'Se ha logeado con exito'
	WHEN -1 THEN 'No existe ese usuario y contraseña'	
END 'Mensaje'
GO

-- 5 - Mostrar entidad

EXEC sp_mostrarEntidad 'Banco Hipodecario del Uruguay'

-- 6 - Eliminar entidad
SELECT * from Telefonos where Nombre = 'MAM'

DECLARE @r int
EXEC @r = sp_eliminarEntidad 'Banco Hipodecario del Uruguay'
SELECT @r 'Retorno', 
	CASE @r
	WHEN -1 THEN 'No se puede eliminar ya que tiene solicitudes asociadas'
	WHEN -2 THEN 'Error al eliminar entidades y tramites asociados'	
	WHEN  1 THEN 'Entidad eliminada con exito'
	WHEN  -3 THEN 'Entidad no existe'
END 'Mensaje'
GO

select * from Entidades


use SistemaGestion

select * from Entidades
select * from Tramites
select * from SolicitudesTramites

Insert into Entidades values ('MAM', 'No recuerdo 2585')
Insert into Telefonos values ('MAM', '5458787')
Insert into Tramites values ('MAM001', 'MAM', 'Reserva hora', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.')
Insert into SolicitudesTramites (CedulaEmpleado, CodigoTramite, NombreEntidad, NombreSolicitante, FechaHora) values (40088371, 'MAM001', 'MAM', 'Albert Galarga', '2020-03-30T00:00:00')


--7 - MODIFICAR ENTIDAD

DECLARE @r int
EXEC @r = sp_modificarEntidad 'MAM', 'Jardines 887'
	SELECT @r 'Retorno', 
	CASE @r
	WHEN 1 THEN 'Entidad modificada con éxito'
	WHEN -1 THEN 'No existe esa entidad'
	WHEN -2 THEN 'Error'
END 'Mensaje'
GO

select * from Entidades


--8 ALTA ENTIDAD

DECLARE @r int
EXEC @r = sp_altaEntidad 'MAM', 'Larrañaga 983' 
SELECT @r 'Retorno', 
	CASE @r
	WHEN 1 THEN 'Entidad creada con éxito'
	WHEN -1 THEN 'Ya existe esa entidad'
END 'Mensaje'
GO

--9


EXEC sp_altaTelefono 'MAM', '0545878787'
GO


EXEC sp_mostrarTelefonosPorEntidad 'Banco Hipodecario del Uruguay'
GO

SELECT * FROM Telefonos

DECLARE @ret int
EXEC @ret =  sp_eliminarTelefonosPorEntidad 'Ministerio de Vivienda', '9038889'
SELECT @ret 'Retorno', 
	CASE @ret
	WHEN 1 THEN 'Telefono eliminado con éxito'
	WHEN -1 THEN 'No existe ese telefono'
	WHEN -2 THEN 'ERROR'
END 'Mensaje'
GO

DECLARE @ret int
EXEC @ret =  sp_modificarTelefono  'MAM', '9038889'
SELECT @ret 'Retorno', 
	CASE @ret
	WHEN 1 THEN 'Telefono modificado con éxito'
	WHEN -1 THEN 'No existen telefonos con ese nombre'
	WHEN -2 THEN 'ERROR EN LA TRANSACCION'
END 'Mensaje'
GO

EXEC sp_mostrarTramite 'BHU001'
GO

SELECT * FROM Tramites
SELECT * FROM SolicitudesTramites WHERE CodigoTramite = 'MSP001'



DECLARE @ret int
EXEC @ret =  sp_eliminarTramite 'MV0002', 'Ministerio de Vivienda'
SELECT @ret 'Retorno', 
	CASE @ret
	WHEN 1 THEN 'Tramite eliminado con éxito'
	WHEN -1 THEN 'No existen tramites con ese nombre'
END 'Mensaje'
GO

SELECT * FROM Tramites

DECLARE @ret int
EXEC @ret =  sp_modificarTramite 'MSP003', 'Ministerio de Salud Publica', 'Registro medicamento nuevo', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.'
SELECT @ret 'Retorno', 
	CASE @ret
	WHEN 1 THEN 'Tramite modificado con éxito'
	WHEN -1 THEN 'No existe el tramites'
	WHEN -2 THEN 'Ha habido un error'
END 'Mensaje'
GO

select * from Tramites
DECLARE @ret int
EXEC @ret = sp_altaTramite 'MSP003', 'Ministerio de Salud Publica', 'Registro medicamento nuevo', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.'
SELECT @ret 'Retorno', 
	CASE @ret
	WHEN 1 THEN 'Tramite creado con éxito'
	WHEN -1 THEN 'yA EXISTE EL TRAMITE'
	WHEN -1 THEN 'ERROR'
END 'Mensaje'
GO

EXEC sp_buscarEmpleado 40088371
GO


SELECT * FROM Empleados


INSERT INTO Empleados VALUES (48787781, 'QUESO', 'jaIEN')


DECLARE @ret int
EXEC @ret = sp_eliminarEmpleado 40088371
SELECT @ret 'Retorno', 
	CASE @ret
	WHEN 1 THEN 'éxito'
	WHEN -1 THEN 'tIENE SOLIcitudes asociadas'
	WHEN -2 THEN 'No existe'
END 'Mensaje'
GO


DECLARE @ret int
EXEC @ret = sp_modificarEmpleado 54545454545454, 'dkjjklfj', 'Juan Perez'
SELECT @ret 'Retorno', 
	CASE @ret
	WHEN 1 THEN 'éxito'
	WHEN -1 THEN 'No existe el empleado'
	WHEN -2 THEN 'Error'
END 'Mensaje'
GO

DECLARE @ret int
EXEC @ret = sp_altaEmpleado 37210054, 'titi', 'Serrana Merlo'
SELECT @ret 'Retorno', 
	CASE @ret
	WHEN 1 THEN 'éxito'
	WHEN -1 THEN 'Ya existe el empleado'
	WHEN -2 THEN 'Error'
END 'Mensaje'
GO

select * from Tramites

DECLARE @ret int
EXEC @ret =  sp_altaSolicitud 40088371, 'MAM001', 'MAM','Serrana Perez Doldan', '2020-03-30T00:00:00' 
SELECT @ret 'Retorno', 
	CASE @ret
	WHEN 1 THEN 'éxito'
	WHEN 0 THEN 'ERROR'
END 'Mensaje'
GO

select * from Tramites
exec sp_mostrarSolicitudesDeTramite 'BHU001', 'Reserva hora'



