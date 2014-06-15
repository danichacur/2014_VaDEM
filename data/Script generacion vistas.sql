USE [GD1C2014]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [vadem].[CalificacionesPorVendedorPorTrimestre]
AS
SELECT	TOP 100000 YEAR(Fecha) as Año, 
		DATEPART(QUARTER,Fecha) AS Trimestre, 
		IdVendedor,
		AVG(Estrellas) as Calificacion
FROM vadem.calificacion
GROUP BY IdVendedor, YEAR(Fecha), DATEPART(QUARTER,Fecha)
ORDER BY YEAR(Fecha), DATEPART(QUARTER,Fecha), Calificacion DESC, IdVendedor


GO

CREATE VIEW [vadem].[ComprasPorCompradorPorTrimestre]
AS
SELECT TOP 100000	YEAR(Fecha) as Año, 
		DATEPART(QUARTER,Fecha) AS Trimestre,
		IdComprador,
		COUNT(Calificada) AS Cantidad
FROM vadem.compras
WHERE Calificada = 0
GROUP BY IdComprador, YEAR(Fecha), DATEPART(QUARTER,Fecha)
ORDER BY Año, Trimestre, Cantidad DESC, IdComprador


GO

CREATE VIEW [vadem].[FacturasPorVendedorPorTrimestre]
AS
SELECT	TOP 100000 YEAR(FechaPago) as Año, 
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
		YEAR(FechaInicio) AS Año, 
		DATEPART(QUARTER, FechaInicio) AS Trimestre, 
		MONTH(FechaInicio) AS Mes,
		IdVisibilidad,
		IdVendedor,  
		SUM(Stock) AS Cantidad
FROM    vadem.publicacion
GROUP BY IdVendedor, YEAR(FechaInicio), DATEPART(QUARTER, FechaInicio), MONTH(FechaInicio), IdVisibilidad
ORDER BY  Año, Trimestre, Mes, IdVisibilidad, Cantidad DESC, IdVendedor

GO

/*
SELECT TOP 5 * FROM vadem.[CalificacionesPorVendedorPorTrimestre]
WHERE Año = 2013 and Trimestre = 2

SELECT TOP 5 * FROM vadem.[ComprasPorCompradorPorTrimestre]
WHERE Año = 2013 and Trimestre = 2

SELECT TOP 5 * FROM vadem.[FacturasPorVendedorPorTrimestre]
WHERE Año = 2013 and Trimestre = 2

SELECT TOP 5 * FROM [vadem].[PublicacionesPorVendedorPorTrimestre]
WHERE Año = 2013 and Trimestre = 2
*/