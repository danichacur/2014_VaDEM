

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


USE [GD1C2014]
GO

/****** Object:  StoredProcedure [vadem].[insertPublicaciones]    Script Date: 06/14/2014 01:33:56 ******/
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
@PREGUNTAS BIT

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

SET @PUBLICACION = (SELECT MAX(IdPublicacion) FROM vadem.publicacion)

SELECT @PUBLICACION, FechaFin FROM vadem.publicacion
WHERE IdPublicacion = @PUBLICACION

END

GO



--rollback
--commit
