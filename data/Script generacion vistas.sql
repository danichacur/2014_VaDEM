USE [GD1C2014]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [vadem].[CalificacionesPorVendedorPorTrimestre]
AS
SELECT	TOP 100000 YEAR(Fecha) as A�o, 
		DATEPART(QUARTER,Fecha) AS Trimestre, 
		IdVendedor,
		AVG(Estrellas) as Calificacion
FROM vadem.calificacion
GROUP BY IdVendedor, YEAR(Fecha), DATEPART(QUARTER,Fecha)
ORDER BY YEAR(Fecha), DATEPART(QUARTER,Fecha), Calificacion DESC, IdVendedor


GO

CREATE VIEW [vadem].[ComprasPorCompradorPorTrimestre]
AS
SELECT TOP 100000	YEAR(Fecha) as A�o, 
		DATEPART(QUARTER,Fecha) AS Trimestre,
		IdComprador,
		COUNT(Calificada) AS Cantidad
FROM vadem.compras
WHERE Calificada = 0
GROUP BY IdComprador, YEAR(Fecha), DATEPART(QUARTER,Fecha)
ORDER BY A�o, Trimestre, Cantidad DESC, IdComprador


GO

CREATE VIEW [vadem].[FacturasPorVendedorPorTrimestre]
AS
SELECT	TOP 100000 YEAR(FechaPago) as A�o, 
		DATEPART(QUARTER,FechaPago) AS Trimestre, 
		IdVendedor,
		SUM(Total) as Total
FROM vadem.factura
GROUP BY IdVendedor, YEAR(FechaPago), DATEPART(QUARTER,FechaPago)
ORDER BY YEAR(FechaPago), DATEPART(QUARTER,FechaPago), Total DESC, IdVendedor


GO

CREATE VIEW [vadem].[PublicacionesPorVendedorPorTrimestre]
AS
SELECT TOP 100000 
		YEAR(FechaInicio) AS A�o, 
		DATEPART(QUARTER, FechaInicio) AS Trimestre, 
		MONTH(FechaInicio) AS Mes,
		IdVisibilidad,
		IdVendedor,  
		SUM(Stock) AS Cantidad
FROM    vadem.publicacion
GROUP BY IdVendedor, YEAR(FechaInicio), DATEPART(QUARTER, FechaInicio), MONTH(FechaInicio), IdVisibilidad
ORDER BY  A�o, Trimestre, Mes, IdVisibilidad, Cantidad DESC, IdVendedor

GO

/*
SELECT TOP 5 * FROM vadem.[CalificacionesPorVendedorPorTrimestre]
WHERE A�o = 2013 and Trimestre = 2

SELECT TOP 5 * FROM vadem.[ComprasPorCompradorPorTrimestre]
WHERE A�o = 2013 and Trimestre = 2

SELECT TOP 5 * FROM vadem.[FacturasPorVendedorPorTrimestre]
WHERE A�o = 2013 and Trimestre = 2

SELECT TOP 5 * FROM [vadem].[PublicacionesPorVendedorPorTrimestre]
WHERE A�o = 2013 and Trimestre = 2
*/