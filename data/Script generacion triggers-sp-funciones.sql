

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

--rollback
--commit
