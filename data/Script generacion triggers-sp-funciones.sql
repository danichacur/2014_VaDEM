

/****** Object:  Trigger [vadem].[bajaRol]    Script Date: 05/20/2014 16:58:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [vadem].[bajaRol]
ON [vadem].[rol]
FOR UPDATE
AS
BEGIN

	DELETE RU FROM vadem.rolesPorUsuario RU
	LEFT JOIN INSERTED I ON RU.IdRol = I.IdRol
	WHERE I.Habilitado = 0
	
END


/****** Object:  Trigger [vadem].[deleteRoles]    Script Date: 05/20/2014 16:58:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [vadem].[deleteRoles]
ON [vadem].[rol]
INSTEAD OF DELETE
AS
BEGIN

     DELETE FROM vadem.rolPorFuncionalidad
     WHERE IdRol IN (SELECT IdRol FROM DELETED)

     DELETE vadem.rol
     WHERE IdRol IN (SELECT IdRol FROM DELETED)
	 
END



/****** Object:  Procedure [vadem].[insertPublicaciones]    Script Date: 06/11/2014 21:08:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [vadem].[insertPublicaciones]

@STOCK INT,
@ESTADO INT,
@DESCRIPCION VARCHAR(255),
@VISIBILIDAD INT,
@FECHA_INI DATETIME,
@PRECIO INT,
@VENDEDOR INT,
@TIPO VARCHAR(20),
@PREGUNTAS CHAR

AS
DECLARE @VIGENCIA INT
DECLARE @PUBLICACION INT

BEGIN

SET @VIGENCIA = (SELECT DiasVigencia FROM vadem.visibilidad
					WHERE @VISIBILIDAD = IdVisibilidad)

SET @PUBLICACION = (SELECT MAX(IdPublicacion)+1 FROM vadem.publicacion) 

INSERT INTO vadem.publicacion
SELECT  @PUBLICACION,
		@STOCK, @ESTADO, @DESCRIPCION, @VISIBILIDAD, @FECHA_INI,
		DATEADD(D,@VIGENCIA,@FECHA_INI), @PRECIO, @VENDEDOR, @TIPO, @PREGUNTAS


SELECT @PUBLICACION

END

GO


/****** Object:  Procedure [vadem].[editarActivarPublicaciones]    Script Date: 06/11/2014 21:08:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [vadem].[editarActivarPublicaciones]

@PUBLICACION INT,
@STOCK INT,
@DESCRIPCION VARCHAR(255),
@VISIBILIDAD INT,
@FECHA_INI DATETIME,
@PRECIO INT,
@TIPO VARCHAR(20),
@PREGUNTAS CHAR

AS
DECLARE @VIGENCIA INT

BEGIN

SET @VIGENCIA = (SELECT DiasVigencia FROM vadem.visibilidad
					WHERE @VISIBILIDAD = IdVisibilidad)


UPDATE vadem.publicacion
SET
	Stock =	@STOCK, 
	IdEstado = 2,
	Descripcion = @DESCRIPCION,
	IdVisibilidad = @VISIBILIDAD, 
	FechaInicio = @FECHA_INI,
	FechaFin = DATEADD(D,@VIGENCIA,@FECHA_INI),
	PrecioInicial = @PRECIO, 
	AdmitePreguntas = @PREGUNTAS


WHERE IdPublicacion = @PUBLICACION

END

GO

--rollback
--commit
