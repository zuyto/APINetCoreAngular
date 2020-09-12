CREATE DATABASE PRUEBAIFX;
GO
USE PRUEBAIFX;
GO
CREATE TABLE Entidades (
		id					INT IDENTITY(1,1) NOT NULL,
		nombre				VARCHAR(50),
		pais				VARCHAR(200),
		departamento		VARCHAR(200),
		ciudad				VARCHAR(200),
		direccion			VARCHAR(100),
		telefono			VARCHAR(15),
		correo				VARCHAR(20)
);

CREATE TABLE Empleados (
		id					INT IDENTITY(1,1) NOT NULL,
		nombres				VARCHAR(50),
		apellidos			VARCHAR(200),
		genero				VARCHAR(200),
		edad				VARCHAR(200),
		direccion			VARCHAR(100),
		telefono			VARCHAR(15),
		correo				VARCHAR(20),
		cargo				VARCHAR(100),
		salario				DECIMAL(18),
		documento			VARCHAR(20),
		tipoDcumento		VARCHAR(4),
		idEntidad			INT,
		idUsuario			INT
);

CREATE TABLE Usuarios (
		id					INT IDENTITY(1,1) NOT NULL,
		usuario				VARCHAR(20),
		idRol				INT		
);

CREATE TABLE Roles (
		id					INT IDENTITY(1,1) NOT NULL,
		nombre				VARCHAR(50),
		apellidos			VARCHAR(200),
		usuario				VARCHAR(20),
		idRol				INT		
);

ALTER TABLE Entidades ADD CONSTRAINT Entidades_pk PRIMARY KEY ( id );
ALTER TABLE Empleados ADD CONSTRAINT Empleados_pk PRIMARY KEY ( id );
ALTER TABLE Usuarios ADD CONSTRAINT Usuarios_pk PRIMARY KEY ( id );
ALTER TABLE Roles ADD CONSTRAINT Roles_pk PRIMARY KEY ( id );

ALTER TABLE Empleados
    ADD CONSTRAINT Empleados_Entidades_fk FOREIGN KEY ( idEntidad )REFERENCES Entidades ( id );
ALTER TABLE Empleados
    ADD CONSTRAINT Empleados_Usuarios_fk FOREIGN KEY ( idUsuario )REFERENCES Usuarios ( id );
ALTER TABLE Usuarios
    ADD CONSTRAINT Usuarios_Roles_fk FOREIGN KEY ( idRol )REFERENCES Roles ( id );

GO


CREATE PROCEDURE SpGetEntidades
AS
BEGIN
SELECT * FROM Entidades
END
GO


CREATE PROCEDURE SpGetObjEntidad 
@id nvarchar(30)
AS
BEGIN
SELECT * FROM Entidades WHERE id = @id
END
GO

CREATE PROCEDURE SpGetEmpleados
AS
BEGIN
SELECT * FROM Empleados
END
GO


CREATE PROCEDURE SpGetObjEmpleado 
@id nvarchar(30)
AS
BEGIN
SELECT * FROM Empleados WHERE id = @id;
END
GO

CREATE PROCEDURE SpInsertEntidad 
		@nombre				VARCHAR(50),
		@pais				VARCHAR(200),
		@departamento		VARCHAR(200),
		@ciudad				VARCHAR(200),
		@direccion			VARCHAR(100),
		@telefono			VARCHAR(15),
		@correo				VARCHAR(20),
		@OutIdEntidad		INT OUTPUT

AS
BEGIN
INSERT INTO Entidades 
				(nombre,pais,departamento,ciudad,direccion,telefono,correo) 
		VALUES (@nombre,@pais,@departamento,@ciudad,@direccion,@telefono,@correo)
SELECT @OutIdEntidad = SCOPE_IDENTITY()
END
GO

CREATE PROCEDURE SpUpdateEntidad 
		@id					INT,
		@nombre				VARCHAR(50),
		@pais				VARCHAR(200),
		@departamento		VARCHAR(200),
		@ciudad				VARCHAR(200),
		@direccion			VARCHAR(100),
		@telefono			VARCHAR(15),
		@correo				VARCHAR(20),
		@OutIdEntidad		INT OUTPUT

AS
BEGIN
		UPDATE Entidades
			SET nombre = @nombre,
				pais = @pais, 
				departamento = @departamento,
				ciudad = @ciudad,
				direccion = @direccion,
				telefono = @telefono,
				correo = @correo
		WHERE  id = @id
END
GO

CREATE PROCEDURE SpInsertEmpleado 
		@nombre				VARCHAR(50),
		@pais				VARCHAR(200),
		@departamento		VARCHAR(200),
		@ciudad				VARCHAR(200),
		@direccion			VARCHAR(100),
		@telefono			VARCHAR(15),
		@correo				VARCHAR(20),
		@OutIdEntidad		INT OUTPUT

AS
BEGIN
INSERT INTO Entidades 
				(nombre,pais,departamento,ciudad,direccion,telefono,correo) 
		VALUES (@nombre,@pais,@departamento,@ciudad,@direccion,@telefono,@correo)
SELECT @OutIdEntidad = SCOPE_IDENTITY()
END
GO

CREATE PROCEDURE SpUpdateEmpleado 
		@id					INT,
		@nombre				VARCHAR(50),
		@pais				VARCHAR(200),
		@departamento		VARCHAR(200),
		@ciudad				VARCHAR(200),
		@direccion			VARCHAR(100),
		@telefono			VARCHAR(15),
		@correo				VARCHAR(20),
		@OutIdEntidad		INT OUTPUT

AS
BEGIN
		UPDATE Entidades
			SET nombre = @nombre,
				pais = @pais, 
				departamento = @departamento,
				ciudad = @ciudad,
				direccion = @direccion,
				telefono = @telefono,
				correo = @correo
		WHERE  id = @id
END
GO