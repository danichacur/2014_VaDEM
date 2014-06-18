USE [GD1C2014]
GO

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



/****** Object:  Trigger [vadem].[insertCalificacion]    Script Date: 06/13/2014 18:51:21 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER [vadem].[insertCalificacion]
ON [vadem].[calificacion]
AFTER INSERT
AS  
BEGIN
SET NOCOUNT ON;

	--CALCULA REPUTACION
	DECLARE @IdVendedor AS INT
	DECLARE @nuevaReputacion AS numeric(3,2)

	SELECT @IdVendedor = IdVendedor FROM INSERTED 

	SELECT @nuevaReputacion = AVG(Estrellas) 
	FROM vadem.calificacion
	WHERE IdVendedor = @IdVendedor

	UPDATE vadem.usuario SET Reputacion = @nuevaReputacion
	WHERE IdUsuario = @IdVendedor
	
	
	--CAMBIA ESTADO CALIFICADA
	DECLARE @IdCompra AS INT
	SELECT @IdCompra = IdCompra FROM INSERTED 

	UPDATE vadem.compras SET Calificada = 1 
	WHERE IdCompra = @IdCompra

END


GO


/****** Object:  Trigger [vadem].[altaPublicacion]    Script Date: 05/20/2014 16:58:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [vadem].[altaPublicacion]
ON [vadem].[publicacion]
AFTER INSERT, UPDATE
AS
BEGIN

DECLARE @ESTADO INT
SET @ESTADO = (SELECT IdEstado FROM INSERTED) 

DECLARE @ESTADO_ANTERIOR INT
SET @ESTADO_ANTERIOR = (SELECT IdEstado FROM DELETED)

DECLARE @VISIBILIDAD INT
SELECT @VISIBILIDAD = IdVisibilidad FROM INSERTED 

DECLARE @CANTIDAD INT
SET @CANTIDAD = (SELECT CantPublicacionesAcumuladas 
					FROM vadem.tipoVisualizacionPorUsuario
					WHERE IdUsuario = (SELECT IdVendedor FROM INSERTED) 
					AND IdVisibilidad = @VISIBILIDAD
					) 


IF ((@ESTADO_ANTERIOR = 3) OR (@ESTADO_ANTERIOR = 2))
	SET @ESTADO = 3

-- SI LA PUBLICACION SE ESTA FINALIZANDO --
IF (@ESTADO = 4)
BEGIN
		-- ACTUALIZA LA TABLA DE TIPO PUBLICACION POR USUARIO -- 
		UPDATE vadem.tipoVisualizacionPorUsuario
			SET CantPublicacionesAcumuladas = @CANTIDAD - 1
		WHERE IdUsuario = (SELECT IdVendedor FROM INSERTED) 
		AND IdVisibilidad = @VISIBILIDAD
END

-- SI LA PUBLICACION SE ESTA ACTIVANDO -- 
IF (@ESTADO = 2)
BEGIN

	SET @CANTIDAD = @CANTIDAD + 1

	DECLARE @COSTO INT
	SET @COSTO = (SELECT CostoFijo FROM vadem.visibilidad
					  WHERE IdVisibilidad = @VISIBILIDAD)
					
		-- CONTROLO SI LLEGUE AL LIMITE DONDE HAY QUE BONIFICARLA -- 

		-- PREGUNTO SI NO ES GRATUITA --
		IF (@VISIBILIDAD <> 10006)
		BEGIN
			IF ((@CANTIDAD + 1) = 10)
				BEGIN
					SET @COSTO = 0
					SET @CANTIDAD = 0
				END		
		END

		-- ACTUALIZA LA TABLA DE TIPO PUBLICACION POR USUARIO -- 

		UPDATE vadem.tipoVisualizacionPorUsuario
			SET CantPublicacionesAcumuladas = (@CANTIDAD + 1)
		WHERE IdUsuario = (SELECT IdVendedor FROM INSERTED) 
		AND IdVisibilidad = @VISIBILIDAD

		-- INSERTA EL COSTO POR LA PUBLICACION EN LOS ITEM FACTURA --

		INSERT vadem.itemFactura 
		SELECT IdPublicacion, IdVendedor, @COSTO, 1, 0 FROM INSERTED
		
END 
	
END

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


/****** Object:  StoredProcedure [vadem].[controlPublicacionesGratuitas]    Script Date: 06/14/2014 01:33:56 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [vadem].[controlPublicacionesGratuitas]

@USUARIO INT 

AS
DECLARE @CANTIDAD INT

BEGIN

 SELECT @CANTIDAD = CantPublicacionesAcumuladas FROM vadem.tipoVisualizacionPorUsuario
 WHERE IdUsuario = @USUARIO
 AND IdVisibilidad = 10006
 
 IF (@CANTIDAD = 3)
	SELECT 0
 ELSE 
	SELECT 1

END

GO

--rollback
--commit
