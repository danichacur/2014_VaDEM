

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
	DECLARE @Habilitado AS BIT
	SELECT @Habilitado = Habilitado FROM INSERTED
	
	IF(@Habilitado = 0)
	BEGIN
		DELETE FROM vadem.rolesPorUsuario
		WHERE IdRol = (SELECT IdRol FROM INSERTED)
	END
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
     WHERE IdRol = (SELECT IdRol FROM DELETED)

     DELETE vadem.rol
     WHERE IdRol = (SELECT IdRol FROM DELETED)
END

--rollback
--commit
