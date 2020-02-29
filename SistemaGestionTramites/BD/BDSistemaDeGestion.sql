USE master;


IF EXISTS (
	SELECT *
	FROM sysdatabases
	WHERE name ='SistemaGestion'
)
BEGIN
	DROP DATABASE SistemaGestion;
END

CREATE DATABASE SistemaGestion;
GO

USE SistemaGestion;
GO

CREATE TABLE Entidades (
	Nombre VARCHAR (80),
	Direccion VARCHAR (80) NOT NULL,
	PRIMARY KEY (Nombre)
)
GO

CREATE TABLE Telefonos (
	Nombre VARCHAR (80),
	Numero VARCHAR (20) NOT NULL,
	PRIMARY KEY (Nombre, Numero),
	FOREIGN KEY (Nombre) REFERENCES Entidades(Nombre) 
)
GO

CREATE TABLE Tramites (
	Codigo VARCHAR(6),
	NombreEntidad VARCHAR (80),
	NombreTramite VARCHAR (100) NOT NULL,
	Descripcion VARCHAR (MAX) NOT NULL,
	PRIMARY KEY (Codigo, NombreEntidad),
	FOREIGN KEY (NombreEntidad) REFERENCES Entidades(Nombre) 
)
GO


CREATE TABLE Empleados (
	Cedula INT,
	Contrasena VARCHAR (20) NOT NULL,
	Nombre VARCHAR (80) NOT NULL,
	PRIMARY KEY (Cedula)
)
GO



CREATE TABLE SolicitudesTramites (
	NumeroSolicitud INT IDENTITY (1,1),
	CedulaEmpleado INT NOT NULL,
	CodigoTramite VARCHAR (6) NOT NULL,
	NombreEntidad VARCHAR (80) NOT NULL,
	NombreSolicitante VARCHAR (80) NOT NULL,
	FechaHora DATETIME NOT NULL,
	Estado VARCHAR (30) NOT NULL DEFAULT 'Alta'  
	CHECK (Estado IN ('Alta','Ejecutada','Anulada')),
	PRIMARY KEY (NumeroSolicitud),
	FOREIGN KEY (CedulaEmpleado) REFERENCES Empleados(Cedula),
    FOREIGN KEY (CodigoTramite, NombreEntidad) REFERENCES Tramites(Codigo, NombreEntidad)
)
GO


---INSERCIÓN DE DATOS DE PRUEBA


INSERT INTO Entidades VALUES ('Ministerio de Salud Publica', 'Casinnoni 1058'),
('Banco Hipodecario del Uruguay', 'Fernandez Crespo 2087'),
('Ministerio de Vivienda', 'Rincon 1005'),
('Instituto Nacional de Colonizacion', 'Camino Corrales 3397')

INSERT INTO Telefonos VALUES ('Ministerio de Salud Publica', '4035877'),
('Ministerio de Salud Publica', '4038787'),
('Ministerio de Salud Publica', '4039521'),
('Ministerio de Salud Publica', '4039982'),
('Banco Hipodecario del Uruguay', '1950'),
('Banco Hipodecario del Uruguay', '09002525'),
('Banco Hipodecario del Uruguay', '4058997'),
('Ministerio de Vivienda', '9036559'),
('Ministerio de Vivienda', '9038998'),
('Ministerio de Vivienda', '9037443'),
('Ministerio de Vivienda', '9038889'),
('Instituto Nacional de Colonizacion', '2045858'),
('Instituto Nacional de Colonizacion', '2044342'),
('Instituto Nacional de Colonizacion', '2044344'),
('Instituto Nacional de Colonizacion', '2044345')

INSERT INTO Tramites VALUES ('MSP001', 'Ministerio de Salud Publica', 'Reserva hora', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.'),
('MSP002', 'Ministerio de Salud Publica', 'Registro nuevo medicamento', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.'),
('BHU001', 'Banco Hipodecario del Uruguay', 'Reserva hora', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.'),
('BHU002', 'Banco Hipodecario del Uruguay', 'Solicitud préstamo', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.'),
('MV0001', 'Ministerio de Vivienda', 'Registro vivienda', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.'),
('MV0002', 'Ministerio de Vivienda', 'Registro Plan Nacional de Vivienda', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.'),
('INC001', 'Instituto Nacional de Colonizacion', 'Registro', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.'),
('INC002', 'Instituto Nacional de Colonizacion', 'Pago de haberes', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.')

INSERT INTO Empleados VALUES (40088371, 'admin1234', 'Juan Negris'),
(50018196, 'admin4321', 'Cristian Carro'),
(52865595, 'admin0001', 'Antonella Silva')

INSERT INTO SolicitudesTramites (CedulaEmpleado, CodigoTramite, NombreEntidad, NombreSolicitante, FechaHora, Estado) VALUES (40088371, 'MSP001', 'Ministerio de Salud Publica','Pedro Perez', '2020-03-30T00:00:00', default),
( 50018196, 'MSP002', 'Ministerio de Salud Publica','Dario Perez',  '2020-03-30T00:00:00', default),
( 52865595, 'BHU001', 'Banco Hipodecario del Uruguay','Juan Perez', '2020-03-30T00:00:00', default),
( 40088371, 'BHU002', 'Banco Hipodecario del Uruguay','Roberto Perez', '2020-03-30T00:00:00', default),
( 40088371, 'BHU002', 'Banco Hipodecario del Uruguay','Javier Perez', '2020-03-30T00:00:00', default),
( 52865595, 'MV0001', 'Ministerio de Vivienda','Ana Perez', '2020-03-30T00:00:00', default), 
( 52865595, 'MV0001', 'Ministerio de Vivienda','Clara Perez', '2020-03-30T00:00:00', default),
( 50018196, 'MV0002', 'Ministerio de Vivienda','Maria Perez', '2020-03-30T00:00:00', default),
( 50018196, 'INC001', 'Instituto Nacional de Colonizacion','Estela Perez', '2020-03-30T00:00:00', default),
( 40088371, 'INC002', 'Instituto Nacional de Colonizacion','Antonia Perez', '2020-03-30T00:00:00', default),
( 52865595, 'INC002', 'Instituto Nacional de Colonizacion','Mario Perez', '2020-03-30T00:00:00', default)


GO

--STORED PROCEDUREDS

-- 1- Listar entidades

CREATE PROCEDURE sp_listarEntidades
AS
	SELECT * FROM Entidades;	 
GO

-- 2- Listar trámites por entidad

CREATE PROCEDURE sp_listarTramitesPorEntidades @NombreEntidad AS VARCHAR (80)
AS
	SELECT * FROM Tramites WHERE NombreEntidad = @NombreEntidad;	 
GO

-- 3- Mostrar estado de una solicitud

CREATE PROCEDURE sp_consultaEspadoDeSolicitud @NumeroSolicitud AS INT
AS
 SELECT * FROM SolicitudesTramites WHERE NumeroSolicitud = @NumeroSolicitud
GO

--Update SolicitudesTramites Set Estado = 'Anulada' where NumeroSolicitud = 11
-- 4- login


CREATE PROCEDURE sp_corroborarUseryPwr @Cedula AS INT, @Contrasena AS VARCHAR (20) 
AS
SELECT * FROM Empleados WHERE Cedula = @Cedula AND  Contrasena = @Contrasena	
GO



-- 5 - Mostrar entidad

CREATE PROCEDURE sp_mostrarEntidad @Nombre AS VARCHAR (80)
AS
	SELECT * FROM Entidades WHERE Nombre = @Nombre;	 
GO


-- 6 - Eliminar Entidad

CREATE PROCEDURE sp_eliminarEntidad @NombreEntidad AS VARCHAR (80)
AS
	IF EXISTS (SELECT * FROM SolicitudesTramites WHERE NombreEntidad = @NombreEntidad)
	RETURN -1
	ELSE
	 BEGIN
		IF EXISTS (SELECT * FROM Entidades WHERE Nombre = @NombreEntidad)	
		BEGIN TRY
				BEGIN TRAN
						DELETE FROM Tramites WHERE NombreEntidad = @NombreEntidad
						DELETE FROM Telefonos WHERE Nombre = @NombreEntidad
						DELETE FROM Entidades WHERE Nombre = @NombreEntidad
						COMMIT TRAN
						RETURN 1  --Eliminado entidades y trámites asociados 
		END TRY
					BEGIN CATCH
						ROLLBACK TRAN
						RETURN -2 -- Error eliminado entidades y trámites asociados
					END CATCH
		ELSE
			RETURN -3
		END
GO

-- 7- Modificar Entidad

CREATE PROCEDURE sp_modificarEntidad @Nombre AS VARCHAR (80), @Direccion AS VARCHAR (80)
AS
	IF NOT EXISTS (SELECT * FROM Entidades WHERE Nombre = @Nombre)
	RETURN -1
   ELSE 
    UPDATE Entidades SET Direccion = @Direccion WHERE  Nombre = @Nombre
	RETURN 1
	IF @@ERROR <> 0
	 RETURN -2
GO


-- 8- Alta entidad

CREATE proc sp_altaEntidad @Nom VARCHAR(80), @Direccion VARCHAR(80)
AS
 IF EXISTS (SELECT * FROM Entidades WHERE Nombre = @Nom)
 RETURN -1
 ELSE 
	INSERT INTO Entidades VALUES (@Nom, @Direccion)
	RETURN 1
GO


-- 9 Alta teléfonos

CREATE PROCEDURE sp_altaTelefono @Nombre AS VARCHAR (80), @Numero AS VARCHAR (20)
AS
	IF NOT EXISTS ( SELECT * FROM Entidades WHERE Nombre = @Nombre)
	RETURN -1
	IF EXISTS (SELECT * FROM Telefonos WHERE Nombre = @Nombre AND Numero = @Numero)
	RETURN -2
		
	INSERT INTO  Telefonos VALUES ( @Nombre, @Numero ) 
	RETURN 1 
GO

-- 10 Buscar telefonos de entidad

CREATE PROCEDURE sp_mostrarTelefonosPorEntidad @Nombre AS VARCHAR (80)
AS
	SELECT Numero FROM Telefonos WHERE Nombre = @Nombre;	 
GO


-- 11 Modificar teléfonos

CREATE PROC  sp_eliminarTelefonosPorEntidad @Nombre AS VARCHAR (80)
AS
	IF NOT EXISTS (SELECT * FROM Telefonos WHERE Nombre = @Nombre)
	RETURN -1
	DELETE FROM Telefonos WHERE Nombre = @Nombre 
	RETURN 1
GO

--12 Buscar/mostrar trámite
GO

CREATE PROCEDURE sp_mostrarTramite @Codigo AS VARCHAR (6), @NombreEntidad AS VARCHAR (80)
AS
	SELECT * FROM Tramites WHERE Codigo = @Codigo AND NombreEntidad = @NombreEntidad;	 
GO


CREATE PROCEDURE sp_eliminarTramite @Codigo AS VARCHAR (6),  @NombreEntidad AS VARCHAR (80)
AS
 IF NOT EXISTS (SELECT * FROM Tramites WHERE Codigo = @Codigo AND NombreEntidad = @NombreEntidad)
	RETURN -1
ELSE
	BEGIN
		BEGIN TRY
		BEGIN TRAN
			DELETE FROM SolicitudesTramites WHERE CodigoTramite = @Codigo AND NombreEntidad = @NombreEntidad
			DELETE FROM Tramites WHERE Codigo = @Codigo AND NombreEntidad = @NombreEntidad
		COMMIT TRAN 
		RETURN 1
		END TRY
 	BEGIN CATCH
		ROLLBACK TRAN
		Return -2
	END CATCH
    END	

GO





--14 Modificar trámite

CREATE PROCEDURE sp_modificarTramite @Codigo AS VARCHAR (6), @NombreEntidad AS VARCHAR (80), @NombreTramite AS VARCHAR (100), @Descripcion AS VARCHAR (MAX)
AS
	IF NOT EXISTS (SELECT * FROM Tramites WHERE Codigo = @Codigo AND NombreEntidad = @NombreEntidad)
	RETURN -1
   ELSE 
    UPDATE Tramites SET NombreTramite = @NombreTramite, Descripcion = @Descripcion WHERE Codigo = @Codigo AND NombreEntidad = @NombreEntidad
	RETURN 1
	IF @@ERROR <> 0
	RETURN -2
GO

-- 15 Alta trámite 

CREATE PROCEDURE sp_altaTramite @Codigo AS VARCHAR (6), @NombreEntidad AS VARCHAR (80), @NombreTramite AS VARCHAR (100), @Descripcion AS VARCHAR (MAX)
	AS
	IF NOT EXISTS (SELECT * FROM Entidades WHERE Nombre = @NombreEntidad)
	RETURN -1
	IF EXISTS (SELECT * FROM Tramites WHERE Codigo = @Codigo AND NombreEntidad = @NombreEntidad)
	RETURN -2
	INSERT INTO Tramites VALUES (@Codigo, @NombreEntidad, @NombreTramite, @Descripcion)
	RETURN 1
	IF @@ERROR <> 0
	RETURN -3
GO

--16 Buscar empleado

CREATE PROCEDURE sp_buscarEmpleado @Cedula AS INT
AS
	SELECT * FROM Empleados WHERE Cedula = @Cedula;	 
GO

-- 17 Eliminar empleado

CREATE PROCEDURE sp_eliminarEmpleado @Cedula AS INT
AS
	IF EXISTS (SELECT * FROM SolicitudesTramites WHERE CedulaEmpleado = @Cedula)
	RETURN -1
	
	IF NOT EXISTS  (SELECT * FROM Empleados WHERE Cedula = @Cedula)
	RETURN -2

	DELETE Empleados WHERE Cedula = @Cedula
	RETURN 1
GO


--18 Modificar empleado

CREATE PROCEDURE sp_modificarEmpleado @Cedula AS INT, @Contrasena AS VARCHAR (20), @Nombre AS VARCHAR (80)
AS
	IF NOT EXISTS (SELECT * FROM Empleados WHERE Cedula = @Cedula)
	RETURN -1
	UPDATE Empleados SET Contrasena = @Contrasena, Nombre = @Nombre WHERE Cedula = @Cedula
	RETURN 1
	IF @@ERROR <> 0
	RETURN -2
GO

--19 Alta empleado

CREATE PROCEDURE sp_altaEmpleado @Cedula AS INT, @Contrasena AS VARCHAR (20), @Nombre AS VARCHAR (80)
AS
		IF NOT EXISTS (SELECT * FROM Empleados WHERE Cedula = @Cedula)
		BEGIN
			INSERT INTO Empleados VALUES (@Cedula, @Contrasena, @Nombre)
			RETURN 1
		END
		ELSE
		RETURN -1
		IF @@ERROR <> 0
		RETURN -2
GO

--Formulario Registrar una solicitud

-- 20 Mostrar la lista de trámites ordenados por nombre

CREATE PROCEDURE sp_mostrarTramitesOrdenPorNombre 
	AS
	SELECT * FROM Tramites ORDER BY NombreTramite ASC
GO

--22 - Insertar una solicitud

CREATE PROCEDURE sp_altaSolicitud  @CedulaEmpleado AS INT, @CodigoTramite AS VARCHAR (6), @NombreEntidad AS VARCHAR (80), @NombreSolicitante AS VARCHAR (80), @FechaHora AS DATETIME
	AS
	IF NOT EXISTS (SELECT * FROM Tramites WHERE Codigo = @CodigoTramite AND NombreEntidad = @NombreEntidad)
	RETURN -1

	IF NOT EXISTS (SELECT * FROM Empleados WHERE Cedula = @CedulaEmpleado)
	RETURN -2
	INSERT INTO SolicitudesTramites (CedulaEmpleado, CodigoTramite, NombreEntidad, NombreSolicitante, FechaHora) VALUES (@CedulaEmpleado, @CodigoTramite, @NombreEntidad, @NombreSolicitante, @FechaHora) 
	return @@rowcount
GO

--23 - Mostrar solicitudes en estado Alta

CREATE PROCEDURE sp_mostrarSolicitudesEstadoAlta
AS 
	SELECT * FROM SolicitudesTramites WHERE Estado = 'Alta'
GO


--24 - Actualizar estado de solicitud

CREATE PROCEDURE sp_actualizarEstadoSolicitudes @Estado AS VARCHAR (30), @NumeroSolicitud AS INT 
AS
	IF NOT EXISTS (SELECT * FROM SolicitudesTramites WHERE NumeroSolicitud = @NumeroSolicitud)
	RETURN -1

	DECLARE @es AS VARCHAR (30)
	SET @es = (SELECT Estado FROM SolicitudesTramites WHERE NumeroSolicitud = @NumeroSolicitud)
	IF @es = 'Alta' 
	BEGIN
			IF @Estado = 'Ejecutada' 
			BEGIN
				UPDATE SolicitudesTramites SET Estado = 'Ejecutada' WHERE NumeroSolicitud = @NumeroSolicitud
				RETURN 1
			END
			ELSE	
			BEGIN 
				UPDATE SolicitudesTramites SET Estado = 'Anulada' WHERE NumeroSolicitud = @NumeroSolicitud
				RETURN 2
			END
	END
	ELSE
		RETURN - 2	
GO




--25 - Mostrar solicitud de un trámite seleccionado ordenadas cronologicamente
CREATE PROCEDURE sp_mostrarSolicitudesDeTramite @Codigo AS VARCHAR (6),  @Nombreentidad AS VARCHAR (80)  
AS
SELECT * FROM SolicitudesTramites 
WHERE NombreEntidad = @Nombreentidad AND CodigoTramite = @Codigo 
ORDER BY FechaHora ASC
GO  

-- 26 - Listar solicitudes estado “alta” y por fecha ordenado por hora
CREATE PROCEDURE sp_listarSolicitudesAltaPorPeriodo @Fecha AS DATETIME
AS
	SELECT * FROM SolicitudesTramites WHERE DATEPART(year,FechaHora) = DATEPART(year,@Fecha) AND DATEPART(month,FechaHora) = DATEPART(month,@Fecha) AND DATEPART(dayofyear,FechaHora) = DATEPART(dayofyear,@Fecha) AND Estado = 'Alta'
	ORDER BY DATEPART(HOUR,FechaHora) ASC, DATEPART(MINUTE,FechaHora) ASC   
GO

-- 27 - Listar todos los datos de una solicitud, todos los datos del tipo de trámite asociado y de la entidad asociada a ese tipo de trámite.

CREATE PROCEDURE sp_listarTodosLosDatosSolicitud @NumeroSolicitud AS INT
AS
	SELECT s.NumeroSolicitud, s.NombreSolicitante, s.Estado, s.FechaHora, s.NombreEntidad, e.Direccion AS 'Dirección de la Entidad', t.NombreTramite AS 'Nombre del Trámite' ,s.CodigoTramite AS 'Código del trámite' , s.CedulaEmpleado, t.Descripcion FROM SolicitudesTramites AS s INNER JOIN Tramites AS t on s.CodigoTramite = t.Codigo 
	INNER JOIN Entidades AS e ON t.NombreEntidad = e.Nombre
	WHERE s.NumeroSolicitud = @NumeroSolicitud	
GO
