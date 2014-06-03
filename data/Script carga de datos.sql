-- BEGIN TRANSACTION

USE [GD1C2014]
GO

/*
DELETE FROM vadem.rubro
DELETE FROM vadem.pregunta
DELETE FROM vadem.compras
DELETE FROM vadem.ofertas
DELETE FROM vadem.calificacion
DELETE FROM vadem.itemFactura
DELETE FROM vadem.publicacion
DELETE FROM vadem.rubrosPublicacion
DELETE FROM vadem.estado	
DELETE FROM vadem.tipoVisualizacionPorUsuario
DELETE FROM vadem.factura
DELETE FROM vadem.visibilidad
DELETE FROM vadem.cliente
DELETE FROM vadem.empresa
DELETE FROM vadem.usuario
DELETE FROM vadem.rolPorFuncionalidad
DELETE FROM vadem.rol
DELETE FROM vadem.funcionalidad
*/


SELECT 'COMIENZO'

/************************/ SELECT 'ROLES' /************************/
INSERT INTO vadem.rol VALUES(1,'Administrador',1),
							(2,'Cliente',1),
							(3,'Empresa',1),
							(4,'Administrativo',1)
GO


/************************/ SELECT 'FUNCIONALIDADES' /************************/
INSERT INTO vadem.funcionalidad VALUES	(1,'AMB_ROLES'), 
										(2,'REGISTRO_USUARIO'),
										(3,'ABM_CLIENTE'),
										(4,'AMB_EMPRESA'),
										(5,'AMB_RUBRO'),
										(6,'AMB_VISIBILIDAD'),
										(7,'GENERA_PUBLICACION'),
										(8,'EDITA_PUBLICACION'),
										(9,'GESTIONA_PREGUNTAS'),
										(10,'COMPRA_OFERTA'),
										(11,'HISTORIA_CLIENTE'),
										(12,'CALIFICAR'),
										(13,'FACTURAR'),
										(14,'LISTADO_ESTADISTICO')
GO


/************************/ SELECT 'ROL POR FUNCIONALIDAD' /************************/
INSERT INTO vadem.rolPorFuncionalidad VALUES(1,1),(1,2),(1,3),(1,4),(1,5),(1,6),(1,7),(1,8),(1,9),(1,10),(1,11),(1,12),(1,13),(1,14),
											(2,7), (2,8), (2,9), (2,10), (2,12),
											(2,3), (3,8), (3,9)
GO

/************************/ SELECT 'USUARIO ADMINISTRADOR' /************************/
INSERT INTO vadem.usuario 
	VALUES ('admin', 'e6b87050bfcb8143fcb8db0170a4dc9ed00d904ddd3e2a4ad1b1e8dc0fdc9be7',0,0,1,0,NULL) -- campo ComprasPorRendir	
GO

/************************/ SELECT 'USUARIOS TIPO CLIENTE' /************************/
INSERT INTO vadem.usuario 
	SELECT  CONVERT(VARCHAR,cli_dni) + '-' + Cli_Apeliido, 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3',0,0,1,0,0 -- campo ComprasPorRendir
	FROM 	(SELECT DISTINCT TOP 100 Cli_Dni, Cli_Apeliido
		FROM         gd_esquema.Maestra
		WHERE     (Cli_Dni IS NOT NULL)
		ORDER BY Cli_Dni
		) E
GO


/************************/ SELECT 'CLIENTES' /************************/
INSERT INTO vadem.cliente
	SELECT (SELECT IdUsuario FROM vadem.usuario U WHERE U.username = CONVERT(VARCHAR,E.cli_dni) + '-' + E.Cli_Apeliido),
		E.cli_dni,'DNI',E.Cli_Nombre,E.Cli_Apeliido, E.Cli_Mail, NULL, E.Cli_Dom_Calle, E.Cli_Nro_Calle, E.Cli_Piso, E.Cli_Depto, NULL, E.Cli_Cod_Postal, E.Cli_Fecha_Nac,NULL
	FROM (	SELECT DISTINCT TOP 100 Cli_Dni, Cli_Apeliido, Cli_Nombre, Cli_Fecha_Nac, Cli_Mail, Cli_Dom_Calle, Cli_Nro_Calle, Cli_Piso, Cli_Depto, Cli_Cod_Postal
			FROM         gd_esquema.Maestra
			WHERE     (Cli_Dni IS NOT NULL)
			ORDER BY Cli_Dni
		  ) E
GO


/************************/ SELECT 'USUARIOS TIPO EMPRESA' /************************/
INSERT INTO vadem.usuario 
	SELECT  Publ_Empresa_Cuit, 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3',0,0,1,0,NULL -- Campo ComprasPorRendir
	FROM (	SELECT DISTINCT TOP 100 Publ_Empresa_Cuit
			FROM         gd_esquema.Maestra
			WHERE     (Publ_Empresa_Cuit IS NOT NULL)
			ORDER BY Publ_Empresa_Cuit
		) E
GO

/************************/ SELECT 'EMPRESA' /************************/
INSERT INTO vadem.empresa
	SELECT (SELECT IdUsuario FROM vadem.usuario U WHERE U.username = E.Publ_Empresa_Cuit),
		E.Publ_Empresa_Razon_Social,E.Publ_Empresa_Cuit,NULL,E.Publ_Empresa_Dom_Calle, E.Publ_Empresa_Nro_Calle, 
		E.Publ_Empresa_Piso, E.Publ_Empresa_Depto,NULL, E.Publ_Empresa_Cod_Postal, NULL, E.Publ_Empresa_Mail, NULL, GETDATE()
	FROM (SELECT DISTINCT TOP 100 Publ_Empresa_Cuit, Publ_Empresa_Razon_Social, 
							Publ_Empresa_Dom_Calle, Publ_Empresa_Nro_Calle, Publ_Empresa_Piso, 
							Publ_Empresa_Depto, Publ_Empresa_Cod_Postal, Publ_Empresa_Mail
			FROM         gd_esquema.Maestra
			WHERE     (Publ_Empresa_Cuit IS NOT NULL)
			ORDER BY Publ_Empresa_Cuit) E
GO

/************************/ SELECT 'ROLES POR USUARIO' /************************/
-- carga los roles empresa --
INSERT INTO vadem.rolesPorUsuario
	SELECT (SELECT IdUsuario FROM vadem.usuario U WHERE U.username = E.Publ_Empresa_Cuit), 3
	FROM (SELECT DISTINCT TOP 100 Publ_Empresa_Cuit	
			FROM   gd_esquema.Maestra
			WHERE  (Publ_Empresa_Cuit IS NOT NULL)
			ORDER BY Publ_Empresa_Cuit) E

-- carga los roles usuario -- 
INSERT INTO vadem.rolesPorUsuario
	SELECT (SELECT IdUsuario FROM vadem.usuario U WHERE U.username = CONVERT(VARCHAR,E.cli_dni) + '-' + E.Cli_Apeliido), 2
	FROM (	SELECT DISTINCT TOP 100 Cli_Dni, Cli_Apeliido
			FROM         gd_esquema.Maestra
			WHERE     (Cli_Dni IS NOT NULL)
			ORDER BY Cli_Dni
		  ) E

-- carga el rol administrador -- 
INSERT INTO vadem.rolesPorUsuario
	SELECT IdUsuario, 1 FROM vadem.usuario U 
	WHERE Username = 'admin'
GO



/************************/ SELECT 'FACTURAS' /************************/
INSERT INTO vadem.factura
	SELECT DISTINCT E.Factura_Nro, U.IdUsuario, E.Factura_Fecha, E.Forma_Pago_Desc, NULL AS Tarjeta, E.Factura_Total
	FROM gd_esquema.Maestra E
	LEFT JOIN vadem.usuario U
		ON U.Username = (ISNULL(E.Publ_Empresa_Cuit, CONVERT(VARCHAR,E.Publ_Cli_DNI) + '-' + E.Publ_Cli_Apeliido))
	WHERE E.Factura_Nro IS NOT NULL
GO


/************************/ SELECT 'ESTADOS' /************************/
INSERT INTO vadem.estado
	SELECT DISTINCT Publicacion_Estado
	FROM gd_esquema.Maestra
GO

/************************/ SELECT 'VISIBILIDAD' /************************/
INSERT INTO vadem.visibilidad
	SELECT DISTINCT Publicacion_Visibilidad_Cod,Publicacion_Visibilidad_Desc,Publicacion_Visibilidad_Porcentaje,Publicacion_Visibilidad_Precio,
		10,7,1
	FROM gd_esquema.Maestra
	WHERE Publicacion_Visibilidad_Cod <> 10006
INSERT INTO vadem.visibilidad
	SELECT DISTINCT Publicacion_Visibilidad_Cod,Publicacion_Visibilidad_Desc,Publicacion_Visibilidad_Porcentaje,Publicacion_Visibilidad_Precio,
		3,7,1
	FROM gd_esquema.Maestra
	WHERE Publicacion_Visibilidad_Cod = 10006
GO


/************************/ SELECT 'TIPO VISIBILIDAD POR USUARIO' /************************/
INSERT INTO vadem.tipoVisualizacionPorUsuario
	SELECT U.IdUsuario,E.Publicacion_Visibilidad_Cod,COUNT(1) AS Cant
	FROM gd_esquema.Maestra E
	LEFT JOIN vadem.usuario U
		ON U.Username = (ISNULL(E.Publ_Empresa_Cuit, CONVERT(VARCHAR,E.Publ_Cli_DNI) + '-' + E.Publ_Cli_Apeliido))
	GROUP BY U.IdUsuario,E.Publicacion_Visibilidad_Cod
	ORDER BY U.IdUsuario,E.Publicacion_Visibilidad_Cod
GO


/************************/ SELECT 'RUBRO' /************************/
INSERT INTO vadem.rubro
	SELECT DISTINCT Publicacion_Rubro_Descripcion
	FROM gd_esquema.Maestra
GO


/************************/ SELECT 'PUBLICACION' /************************/
INSERT INTO vadem.publicacion
	SELECT DISTINCT Publicacion_Cod, Publicacion_Stock, 1, Publicacion_Descripcion, Publicacion_Visibilidad_Cod, Publicacion_Fecha,
			Publicacion_Fecha_Venc, Publicacion_Precio, U.IdUsuario, Publicacion_Tipo, 1
	FROM gd_esquema.Maestra E
	LEFT JOIN vadem.usuario U
		ON U.Username = (ISNULL(E.Publ_Empresa_Cuit, CONVERT(VARCHAR,E.Publ_Cli_DNI) + '-' + E.Publ_Cli_Apeliido))
GO


/************************/ SELECT 'RUBROS PUBLICACION' /************************/
INSERT INTO vadem.rubrosPublicacion
	SELECT	R.IdRubro, E.Publicacion_Cod
	FROM gd_esquema.Maestra E
	LEFT JOIN vadem.rubro R
		ON R.Descripcion = E.Publicacion_Rubro_Descripcion
	GROUP BY R.IdRubro, E.Publicacion_Cod
	ORDER BY R.IdRubro, E.Publicacion_Cod
GO


/************************/ SELECT 'OFERTAS' /************************/
INSERT INTO vadem.ofertas
	SELECT Publicacion_Cod, U.IdUsuario,Oferta_Fecha, Oferta_Monto 
	FROM gd_esquema.Maestra E
		LEFT JOIN vadem.usuario U
		ON U.Username = CONVERT(VARCHAR,E.Cli_Dni) + '-' + E.Cli_Apeliido
	WHERE Oferta_Fecha IS NOT NULL
GO


/************************/ SELECT 'COMPRAS' /************************/
INSERT INTO vadem.compras
	SELECT  Publicacion_Cod, U.IdUsuario, Compra_Fecha, Compra_Cantidad, 1 AS calificada
	FROM gd_esquema.Maestra E
	LEFT JOIN vadem.usuario U
	ON U.Username = CONVERT(VARCHAR,E.Cli_Dni) + '-' + E.Cli_Apeliido
	WHERE Compra_Cantidad IS NOT NULL
		AND Calificacion_Codigo IS NULL
GO

/************************/ SELECT 'CALIFICACIONES' /************************/
INSERT INTO vadem.calificacion
	SELECT	DISTINCT Calificacion_Codigo, C.IdCompra, U1.IdUsuario, U2.IdUsuario,Calificacion_Cant_Estrellas, Calificacion_Descripcion
	FROM gd_esquema.Maestra E
	LEFT JOIN vadem.usuario U1
		ON U1.Username = (ISNULL(E.Publ_Empresa_Cuit, CONVERT(VARCHAR,E.Publ_Cli_DNI) + '-' + E.Publ_Cli_Apeliido))
	LEFT JOIN vadem.usuario U2
		ON U2.Username = CONVERT(VARCHAR,E.Cli_Dni) + '-' + E.Cli_Apeliido
	LEFT JOIN vadem.compras C
		ON C.IdPublicacion = E.Publicacion_Cod
	WHERE Calificacion_Codigo IS NOT NULL
GO


/************************/ SELECT 'ITEM FACTURA' /************************/
INSERT INTO vadem.itemFactura
	SELECT DISTINCT Publicacion_Cod, U.IdUsuario,  Item_Factura_Monto, Item_Factura_Cantidad, Factura_Nro
	FROM gd_esquema.Maestra E
	LEFT JOIN vadem.usuario U
		ON U.Username = (ISNULL(E.Publ_Empresa_Cuit, CONVERT(VARCHAR,E.Publ_Cli_DNI) + '-' + E.Publ_Cli_Apeliido))
	WHERE Item_Factura_Cantidad IS NOT NULL
GO	

--COMMIT


-- preguntar por este problema!! porque es cero?
--SELECT * from gd_esquema.Maestra
--where Publicacion_Cod = 35038




