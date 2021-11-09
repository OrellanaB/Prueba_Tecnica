
---Prodecimientos de Area
CREATE PROCEDURE [dbo].[INSERTAREA]
	@Nombre varchar(100),
	@Descripcion varchar(2000)
AS
BEGIN
	INSERT INTO [dbo].[Area] (Nombre, Descripcion) VALUES (@Nombre, @Descripcion)
END
GO

CREATE PROCEDURE [dbo].[READAREA]
	@IdArea int
AS
BEGIN
	SELECT * FROM [dbo].[Area] WHERE IdArea = @IdArea
END
GO

CREATE PROCEDURE [dbo].[SEARCHAREA]
AS
BEGIN
	SELECT * FROM [dbo].[Area]
END
GO

CREATE PROCEDURE [dbo].[UPDATEAREA]
	@IdArea int,
	@Nombre varchar(100),
	@Description varchar(200)
AS
BEGIN
	UPDATE [dbo].[Area] SET Nombre = @Nombre, Descripcion = @Description WHERE IdArea = @IdArea
END
GO

CREATE PROCEDURE [dbo].[DELETEAREA]
	@IdArea int
AS
BEGIN
	DELETE FROM [dbo].[Area] WHERE IdArea = @IdArea
END
GO


--Procedimientos de Empleados
CREATE PROCEDURE [dbo].[INSERTEMPLEADO]
	@NombreCompleto varchar(100),
	@Cedula varchar(50),
	@Correo varchar(100),
	@FechaNacimiento date,
	@FechaIngreso date,
	@IdJefe int,
	@IdArea int,
	@Foto varbinary(max)
AS
BEGIN
	INSERT INTO [dbo].[Empleado] (NombreCompleto, Cedula, Correo, FechaNacimiento, FechaIngreso, IdJefe, IdArea, Foto) 
	VALUES (@NombreCompleto, @Cedula, @Correo, @FechaNacimiento, @FechaIngreso, @IdJefe, @IdArea, @Foto)
END
GO

CREATE PROCEDURE [dbo].[READEMPLEADO]
	@IdEmpleado int
AS
BEGIN
	SELECT * FROM [dbo].[Empleado] WHERE IdEmpleado = @IdEmpleado
END
GO

CREATE PROCEDURE [dbo].[SEARCHEMPLEADO]
AS
BEGIN
	SELECT * FROM [dbo].[Empleado]
END
GO

CREATE PROCEDURE [dbo].[UPDATEEMPLEADO]
	@IdEmpleado int,
	@NombreCompleto varchar(100),
	@Cedula varchar(50),
	@Correo varchar(100),
	@FechaNacimiento date,
	@FechaIngreso date,
	@IdJefe int,
	@IdArea int,
	@Foto varbinary(max)
AS
BEGIN
	UPDATE [dbo].[Empleado] SET NombreCompleto = @NombreCompleto, Cedula = @Cedula, Correo = @Correo,
	FechaNacimiento = @FechaNacimiento, FechaIngreso = @FechaIngreso, IdJefe = @IdJefe, IdArea = @IdArea,
	Foto = @Foto WHERE IdEmpleado = @IdEmpleado
END
GO

CREATE PROCEDURE [dbo].[DELETEMPLEADO]
	@IdEmpleado int
AS
BEGIN
	DELETE FROM [dbo].[Empleado] WHERE IdEmpleado = @IdEmpleado
END
GO


---Prodecimientos Empleado Habilidad
CREATE PROCEDURE [dbo].[INSERTEMPLEADOHABILIDAD]
	@IdEmpleado int,
	@NombreHabilidad varchar(100)
AS
BEGIN
	INSERT INTO [dbo].[Empleado_Habilidad] (IdEmpleado, NombreHabilidad ) VALUES (@IdEmpleado, @NombreHabilidad)
END
GO

CREATE PROCEDURE [dbo].[READEMPLEADOHABILIDAD]
	@IdHabilidad int
AS
BEGIN
	SELECT * FROM [dbo].[Empleado_Habilidad] WHERE IdHabilidad = @IdHabilidad
END
GO

CREATE PROCEDURE [dbo].[SEARCHEMPLEADOHABILIDAD]
AS
BEGIN
	SELECT * FROM [dbo].[Empleado_Habilidad]
END
GO

CREATE PROCEDURE [dbo].[UPDATEEMPLEADOHABILIDAD]
	@IdHabilidad int,
	@IdEmpleado int,
	@NombreHabilidad varchar(100)
AS
BEGIN
	UPDATE [dbo].[Empleado_Habilidad] SET IdEmpleado = @IdEmpleado, NombreHabilidad = @NombreHabilidad
	WHERE IdHabilidad = @IdHabilidad
END
GO

CREATE PROCEDURE [dbo].[DELETEMPLEADOHABILIDAD]
	@IdHabilidad int
AS
BEGIN
	DELETE FROM [dbo].[Empleado_Habilidad] WHERE IdHabilidad = @IdHabilidad
END
GO