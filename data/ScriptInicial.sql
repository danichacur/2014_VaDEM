
/*
drop procedure vadem.controlPublicacionesGratuitas
drop procedure vadem.insertPublicaciones

drop view vadem.CalificacionesPorVendedorPorTrimestre
drop view vadem.ComprasPorCompradorPorTrimestre
drop view vadem.FacturasPorVendedorPorTrimestre
drop view vadem.PublicacionesPorVendedorPorTrimestre

drop table vadem.empresa
drop table vadem.factura
drop table vadem.itemFactura
drop table vadem.ofertas
drop table vadem.pregunta
drop table vadem.rolesPorUsuario
drop table vadem.rolPorFuncionalidad
drop table vadem.rubrosPublicacion
drop table vadem.tipoVisualizacionPorUsuario
drop table vadem.calificacion
drop table vadem.cliente
drop table vadem.compras
drop table vadem.publicacion
drop table vadem.rol
drop table vadem.rubro
drop table vadem.estado
drop table vadem.funcionalidad
drop table vadem.usuario
drop table vadem.visibilidad
drop table vadem.calificacionesEstandard
*/

-- BEGIN TRANSACTION

USE [GD1C2014]
GO

--CREATE SCHEMA [vadem] AUTHORIZATION [gd]
--GO

/****** Object:  Table [vadem].[rol]    Script Date: 04/21/2014 23:30:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [vadem].[rol](
	[IdRol] [int] NOT NULL,
	[Descripcion] [varchar](20) NOT NULL,
	[Habilitado] [bit] NOT NULL,
 CONSTRAINT [PK_rol] PRIMARY KEY CLUSTERED 
(
	[IdRol] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [vadem].[estado]    Script Date: 04/21/2014 23:30:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [vadem].[estado](
	[IdEstado] [int] NOT NULL IDENTITY(1,1),
	[Descripcion] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_estado] PRIMARY KEY CLUSTERED 
(
	[IdEstado] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [vadem].[empresa]    Script Date: 04/21/2014 23:30:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [vadem].[empresa](
	[IdEmpresa] [int] NOT NULL,
	[RazonSocial] [nvarchar](255) NOT NULL,
	[CUIT] [nvarchar](50) NOT NULL,
	[Telefono] [nchar](10) NULL,
	[Direccion] [nvarchar](100) NOT NULL,
	[Numero] [numeric](18, 0) NOT NULL,
	[Piso] [numeric](18, 0) NULL,
	[Dpto] [nvarchar](50) NULL,
	[Localidad] [nvarchar](100) NULL,
	[CodPostal] [nvarchar](50) NOT NULL,
	[Ciudad] [nvarchar](100) NULL,
	[Mail] [nvarchar](50) NULL,
	[NombreContacto] [varchar](50) NULL,
	[FechaCreacion] [datetime] NOT NULL,
 CONSTRAINT [PK_empresa] PRIMARY KEY CLUSTERED 
(
	[IdEmpresa] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [vadem].[funcionalidad]    Script Date: 04/21/2014 23:30:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [vadem].[funcionalidad](
	[IdFuncion] [int] NOT NULL,
	[Descripcion] [varchar](50) NOT NULL,
 CONSTRAINT [PK_funcionalidad] PRIMARY KEY CLUSTERED 
(
	[IdFuncion] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [vadem].[visibilidad]    Script Date: 04/21/2014 23:30:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [vadem].[visibilidad](
	[IdVisibilidad] [numeric] (18,0) NOT NULL,
	[Descripcion] [nvarchar](255) NOT NULL,
	[CostoFijo] [numeric] (18,2) NOT NULL,
	[Comision] [numeric] (18,2) NOT NULL,
	[LimiteSinBonificar] [numeric](18, 0) NOT NULL,
	[DiasVigencia] [numeric](3, 0) NOT NULL,
	[Habilitado] [bit] NOT NULL,
 CONSTRAINT [PK_visibilidad] PRIMARY KEY CLUSTERED 
(
	[IdVisibilidad] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [vadem].[rubro]    Script Date: 04/21/2014 23:30:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [vadem].[rubro](
	[IdRubro] [int] NOT NULL IDENTITY(1,1),
	[Descripcion] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_rubro] PRIMARY KEY CLUSTERED 
(
	[IdRubro] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [vadem].[rolPorFuncionalidad]    Script Date: 04/21/2014 23:30:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [vadem].[rolPorFuncionalidad](
	[IdRol] [int] NOT NULL,
	[IdFuncion] [int] NOT NULL,
 CONSTRAINT [PK_rolPorFuncionalidad] PRIMARY KEY CLUSTERED 
(
	[IdRol] ASC,
	[IdFuncion] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [vadem].[usuario]    Script Date: 04/21/2014 23:30:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [vadem].[usuario](
	[IdUsuario] [int] NOT NULL IDENTITY(1,1),
	[Username] [varchar](50) NOT NULL,
	[Password] [nvarchar](255) NOT NULL,
	--[IdRol] [int] NOT NULL,
	[IntentosFallidos] [int] NOT NULL,
	[Bloqueado] [bit] NOT NULL,
	[Habilitado] [bit] NOT NULL,
	[Reputacion] [numeric](3, 2) NOT NULL,
	[ComprasPorRendir] [int] NULL, -- cambio de Junio
	[CantidadLoggeos] [int] NULL, 
 CONSTRAINT [PK_usuario] PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [vadem].[rolesPorUsuario]    Script Date: 04/21/2014 23:30:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [vadem].[rolesPorUsuario](
	[IdUsuario] [int] NOT NULL,
	[IdRol] [int] NOT NULL,
 CONSTRAINT [PK_rolesPorUsuario] PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC,
	[IdRol] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [vadem].[tipoVisualizacionPorUsuario]    Script Date: 04/21/2014 23:30:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [vadem].[tipoVisualizacionPorUsuario](
	[IdUsuario] [int] NOT NULL,
	[IdVisibilidad] [numeric] (18,0) NOT NULL,
	[CantPublicacionesAcumuladas] [int] NOT NULL,
 CONSTRAINT [PK_tipoVisualizacionPorUsuario] PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC,
	[IdVisibilidad] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [vadem].[factura]    Script Date: 04/21/2014 23:30:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [vadem].[factura](
	[IdFactura] [numeric](18, 0) NOT NULL,
	[IdVendedor] [int] NOT NULL,
	[FechaPago] [datetime] NOT NULL,
	[FormaPago] [nvarchar](255) NOT NULL,
	[DatosTarjeta] [numeric](18, 0) NULL,
	[Total] [numeric](18, 2) NOT NULL,
 CONSTRAINT [PK_factura] PRIMARY KEY CLUSTERED 
(
	[IdFactura] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [vadem].[cliente]    Script Date: 04/21/2014 23:30:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [vadem].[cliente](
	[IdCliente] [int] NOT NULL,
	[Documento] [numeric](18, 0) NOT NULL,
	[TipoDocumento] [nvarchar](10) NOT NULL,
	[Nombre] [nvarchar](255) NOT NULL,
	[Apellido] [nvarchar](255) NOT NULL,
	[Mail] [nvarchar](255) NOT NULL,
	[Telefono] [nchar](10) NULL,
	[Direccion] [nvarchar](255) NOT NULL,
	[Numero] [numeric](18, 0) NOT NULL,
	[Piso] [numeric](18, 0) NULL,
	[Dpto] [nvarchar](50) NULL,
	[Localidad] [varchar](50) NULL,
	[CodPostal] [nvarchar](50) NOT NULL,
	[FechaNacimiento] [datetime] NULL,
	[CUIL] [numeric](11, 0) NULL,
 CONSTRAINT [PK_cliente] PRIMARY KEY CLUSTERED 
(
	[IdCliente] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [vadem].[publicacion]    Script Date: 04/21/2014 23:30:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [vadem].[publicacion](
	[IdPublicacion] [numeric](18, 0) NOT NULL,
	[Stock] [numeric](18, 0) NOT NULL,
	[IdEstado] [int] NOT NULL,
	[Descripcion] [nvarchar](255) NOT NULL,
	[IdVisibilidad] [numeric] (18,0) NOT NULL,
	[FechaInicio] [datetime] NOT NULL,
	[FechaFin] [datetime] NOT NULL,
	[PrecioInicial] [numeric](18, 2) NOT NULL,
	[IdVendedor] [int] NOT NULL,
	[Tipo] [nvarchar](255) NOT NULL,
	[AdmitePreguntas] [bit] NOT NULL,
 CONSTRAINT [PK_publicacion] PRIMARY KEY CLUSTERED 
(
	[IdPublicacion] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [vadem].[rubrosPublicacion]    Script Date: 04/21/2014 23:30:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [vadem].[rubrosPublicacion](
	[IdPublicacion] [numeric] (18,0) NOT NULL,
	[IdRubro] [int] NOT NULL,
CONSTRAINT [PK_rubrosPublicacion] PRIMARY KEY CLUSTERED 
(
	[IdPublicacion] ASC,
	[IdRubro] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [vadem].[pregunta]    Script Date: 04/21/2014 23:30:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [vadem].[pregunta](
	[IdPregunta] [int] NOT NULL,
	[IdPublicacion] [numeric] (18,0) NOT NULL,
	[UsuarioPregunta] [int] NOT NULL,
	[FechaPregunta] [smalldatetime] NOT NULL,
	[Pregunta] [varchar](50) NOT NULL,
	[FechaRespuesta] [smalldatetime] NULL,
	[Respuesta] [varchar](50) NULL,
 CONSTRAINT [PK_pregunta] PRIMARY KEY CLUSTERED 
(
	[IdPregunta] ASC,
	[IdPublicacion] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [vadem].[ofertas]    Script Date: 04/21/2014 23:30:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [vadem].[ofertas](
	[IdOferta] [int] NOT NULL IDENTITY(1,1),
	[IdPublicacion] [numeric] (18,0) NOT NULL,
	[IdOfertante] [int] NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Importe] [numeric] (18,2)  NOT NULL,
 CONSTRAINT [PK_ofertas] PRIMARY KEY CLUSTERED 
(
	[IdOferta] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [vadem].[itemFactura]    Script Date: 04/21/2014 23:30:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [vadem].[itemFactura](
	[IdItem] [int] NOT NULL IDENTITY(1,1),
	[IdPublicacion] [numeric] (18,0) NOT NULL,
	[IdVendedor] [int] NOT NULL,
	--[Fecha] [smalldatetime] NOT NULL,
	[Costo] [numeric] (18,2) NOT NULL,
	[Cantidad] [numeric] (18,0) NOT NULL,
	--[EsCompra] [bit] NOT NULL, --lo sacamos porque agregamos el campo ComprasPorRendir en Usuarios
	[IdFactura] [int] NULL,
 CONSTRAINT [PK_itemFactura] PRIMARY KEY CLUSTERED 
(
	[IdItem] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [vadem].[compras]    Script Date: 04/21/2014 23:30:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [vadem].[compras](
	[IdCompra] [int] NOT NULL IDENTITY(1,1),
	[IdPublicacion] [numeric] (18,0) NOT NULL,
	[IdComprador] [int] NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Cantidad] [numeric](18, 0) NOT NULL,
	[Calificada] [bit] NOT NULL,
 CONSTRAINT [PK_compras] PRIMARY KEY CLUSTERED 
(
	[IdCompra] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [vadem].[calificacion]    Script Date: 04/21/2014 23:30:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [vadem].[calificacion](
	[IdCalificacion] [numeric] (18,0) NOT NULL,
	[IdCompra] [int] NOT NULL, -- Para que se linkee con las compras
	[IdVendedor] [int] NOT NULL,
	[IdCalificador] [int] NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Estrellas] [numeric](18, 0) NOT NULL,
	[Detalle] [nvarchar](255) NULL,
 CONSTRAINT [PK_calificacion] PRIMARY KEY CLUSTERED 
(
	[IdCalificacion] ASC,
	[IdCompra] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [vadem].[calificacionesEstandard]    Script Date: 04/21/2014 23:30:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [vadem].[calificacionesEstandard](
	[Id] [int] NOT NULL IDENTITY(1,1),
	[Descripcion] [nvarchar](255) NOT NULL,
CONSTRAINT [PK_calificacionesEstandard] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  ForeignKey [FK_calificacion_cliente]    Script Date: 04/21/2014 23:30:23 ******/
ALTER TABLE [vadem].[calificacion]  WITH CHECK ADD  CONSTRAINT [FK_calificacion_cliente] FOREIGN KEY([IdCalificador])
REFERENCES [vadem].[cliente] ([IdCliente])
GO
ALTER TABLE [vadem].[calificacion] CHECK CONSTRAINT [FK_calificacion_cliente]
GO
/****** Object:  ForeignKey [FK_calificacion_usuario]    Script Date: 04/21/2014 23:30:23 ******/
ALTER TABLE [vadem].[calificacion]  WITH CHECK ADD  CONSTRAINT [FK_calificacion_usuario] FOREIGN KEY([IdVendedor])
REFERENCES [vadem].[usuario] ([IdUsuario])
GO
ALTER TABLE [vadem].[calificacion] CHECK CONSTRAINT [FK_calificacion_usuario]
GO
/****** Object:  ForeignKey [FK_cliente_usuario]    Script Date: 04/21/2014 23:30:23 ******/
ALTER TABLE [vadem].[cliente]  WITH CHECK ADD  CONSTRAINT [FK_cliente_usuario] FOREIGN KEY([IdCliente])
REFERENCES [vadem].[usuario] ([IdUsuario])
GO
ALTER TABLE [vadem].[cliente] CHECK CONSTRAINT [FK_cliente_usuario]
GO
/****** Object:  ForeignKey [FK_compras_publicacion]    Script Date: 04/21/2014 23:30:23 ******/
ALTER TABLE [vadem].[compras]  WITH CHECK ADD  CONSTRAINT [FK_compras_publicacion] FOREIGN KEY([IdPublicacion])
REFERENCES [vadem].[publicacion] ([IdPublicacion])
GO
ALTER TABLE [vadem].[compras] CHECK CONSTRAINT [FK_compras_publicacion]
GO
/****** Object:  ForeignKey [FK_compras_usuario]    Script Date: 04/21/2014 23:30:23 ******/
ALTER TABLE [vadem].[compras]  WITH CHECK ADD  CONSTRAINT [FK_compras_usuario] FOREIGN KEY([IdComprador])
REFERENCES [vadem].[usuario] ([IdUsuario])
GO
ALTER TABLE [vadem].[compras] CHECK CONSTRAINT [FK_compras_usuario]
GO
/****** Object:  ForeignKey [FK_calificacion_compra]    Script Date: 04/21/2014 23:30:23 ******/ -- actualiza la FK con compras en vez de publicacion
ALTER TABLE [vadem].[calificacion]  WITH CHECK ADD  CONSTRAINT [FK_calificacion_compra] FOREIGN KEY([IdCompra])
REFERENCES [vadem].[compras] ([IdCompra])
GO
ALTER TABLE [vadem].[calificacion] CHECK CONSTRAINT [FK_calificacion_compra]
GO
/****** Object:  ForeignKey [FK_factura_usuario]    Script Date: 04/21/2014 23:30:23 ******/
ALTER TABLE [vadem].[factura]  WITH CHECK ADD  CONSTRAINT [FK_factura_usuario] FOREIGN KEY([IdVendedor])
REFERENCES [vadem].[usuario] ([IdUsuario])
GO
ALTER TABLE [vadem].[factura] CHECK CONSTRAINT [FK_factura_usuario]
GO
/****** Object:  ForeignKey [FK_itemFactura_publicacion]    Script Date: 04/21/2014 23:30:23 ******/
ALTER TABLE [vadem].[itemFactura]  WITH CHECK ADD  CONSTRAINT [FK_itemFactura_publicacion] FOREIGN KEY([IdPublicacion])
REFERENCES [vadem].[publicacion] ([IdPublicacion])
GO
ALTER TABLE [vadem].[itemFactura] CHECK CONSTRAINT [FK_itemFactura_publicacion]
GO
/****** Object:  ForeignKey [FK_itemFactura_usuario]    Script Date: 04/21/2014 23:30:23 ******/
ALTER TABLE [vadem].[itemFactura]  WITH CHECK ADD  CONSTRAINT [FK_itemFactura_usuario] FOREIGN KEY([IdVendedor])
REFERENCES [vadem].[usuario] ([IdUsuario])
GO
ALTER TABLE [vadem].[itemFactura] CHECK CONSTRAINT [FK_itemFactura_usuario]
GO
/****** Object:  ForeignKey [FK_ofertas_publicacion]    Script Date: 04/21/2014 23:30:23 ******/
ALTER TABLE [vadem].[ofertas]  WITH CHECK ADD  CONSTRAINT [FK_ofertas_publicacion] FOREIGN KEY([IdPublicacion])
REFERENCES [vadem].[publicacion] ([IdPublicacion])
GO
ALTER TABLE [vadem].[ofertas] CHECK CONSTRAINT [FK_ofertas_publicacion]
GO
/****** Object:  ForeignKey [FK_ofertas_usuario]    Script Date: 04/21/2014 23:30:23 ******/
ALTER TABLE [vadem].[ofertas]  WITH CHECK ADD  CONSTRAINT [FK_ofertas_usuario] FOREIGN KEY([IdOfertante])
REFERENCES [vadem].[usuario] ([IdUsuario])
GO
ALTER TABLE [vadem].[ofertas] CHECK CONSTRAINT [FK_ofertas_usuario]
GO
/****** Object:  ForeignKey [FK_pregunta_publicacion]    Script Date: 04/21/2014 23:30:23 ******/
ALTER TABLE [vadem].[pregunta]  WITH CHECK ADD  CONSTRAINT [FK_pregunta_publicacion] FOREIGN KEY([IdPublicacion])
REFERENCES [vadem].[publicacion] ([IdPublicacion])
GO
ALTER TABLE [vadem].[pregunta] CHECK CONSTRAINT [FK_pregunta_publicacion]
GO
/****** Object:  ForeignKey [FK_pregunta_usuario]    Script Date: 04/21/2014 23:30:23 ******/
ALTER TABLE [vadem].[pregunta]  WITH CHECK ADD  CONSTRAINT [FK_pregunta_usuario] FOREIGN KEY([UsuarioPregunta])
REFERENCES [vadem].[usuario] ([IdUsuario])
GO
ALTER TABLE [vadem].[pregunta] CHECK CONSTRAINT [FK_pregunta_usuario]
GO
/****** Object:  ForeignKey [FK_publicacion_estado]    Script Date: 04/21/2014 23:30:23 ******/
ALTER TABLE [vadem].[publicacion]  WITH CHECK ADD  CONSTRAINT [FK_publicacion_estado] FOREIGN KEY([IdEstado])
REFERENCES [vadem].[estado] ([IdEstado])
GO
ALTER TABLE [vadem].[publicacion] CHECK CONSTRAINT [FK_publicacion_estado]
/****** Object:  ForeignKey [FK_publicacion_usuario]    Script Date: 04/21/2014 23:30:23 ******/
ALTER TABLE [vadem].[publicacion]  WITH CHECK ADD  CONSTRAINT [FK_publicacion_usuario] FOREIGN KEY([IdVendedor])
REFERENCES [vadem].[usuario] ([IdUsuario])
GO
ALTER TABLE [vadem].[publicacion] CHECK CONSTRAINT [FK_publicacion_usuario]
GO
/****** Object:  ForeignKey [FK_publicacion_visibilidad]    Script Date: 04/21/2014 23:30:23 ******/
ALTER TABLE [vadem].[publicacion]  WITH CHECK ADD  CONSTRAINT [FK_publicacion_visibilidad] FOREIGN KEY([IdVisibilidad])
REFERENCES [vadem].[visibilidad] ([IdVisibilidad])
GO
ALTER TABLE [vadem].[publicacion] CHECK CONSTRAINT [FK_publicacion_visibilidad]
GO
/****** Object:  ForeignKey [FK_rubrosPublicacion_publicacion]    Script Date: 04/21/2014 23:30:23 ******/
ALTER TABLE [vadem].[rubrosPublicacion]  WITH CHECK ADD  CONSTRAINT [FK_rubrosPublicacion_publicacion] FOREIGN KEY([IdPublicacion])
REFERENCES [vadem].[publicacion] ([IdPublicacion])
GO
ALTER TABLE [vadem].[rubrosPublicacion] CHECK CONSTRAINT [FK_rubrosPublicacion_publicacion]
GO
/****** Object:  ForeignKey [FK_rubrosPublicacion_rubro]    Script Date: 04/21/2014 23:30:23 ******/
ALTER TABLE [vadem].[rubrosPublicacion]  WITH CHECK ADD  CONSTRAINT [FK_rubrosPublicacion_rubro] FOREIGN KEY([IdRubro])
REFERENCES [vadem].[rubro] ([IdRubro])
GO
ALTER TABLE [vadem].[rubrosPublicacion] CHECK CONSTRAINT [FK_rubrosPublicacion_rubro]
GO
/****** Object:  ForeignKey [FK_rolPorFuncionalidad_funcionalidad]    Script Date: 04/21/2014 23:30:23 ******/
ALTER TABLE [vadem].[rolPorFuncionalidad]  WITH CHECK ADD  CONSTRAINT [FK_rolPorFuncionalidad_funcionalidad] FOREIGN KEY([IdFuncion])
REFERENCES [vadem].[funcionalidad] ([IdFuncion])
GO
ALTER TABLE [vadem].[rolPorFuncionalidad] CHECK CONSTRAINT [FK_rolPorFuncionalidad_funcionalidad]
GO
/****** Object:  ForeignKey [FK_rolPorFuncionalidad_rol]    Script Date: 04/21/2014 23:30:23 ******/
ALTER TABLE [vadem].[rolPorFuncionalidad]  WITH CHECK ADD  CONSTRAINT [FK_rolPorFuncionalidad_rol] FOREIGN KEY([IdRol])
REFERENCES [vadem].[rol] ([IdRol])
GO
ALTER TABLE [vadem].[rolPorFuncionalidad] CHECK CONSTRAINT [FK_rolPorFuncionalidad_rol]
GO
/****** Object:  ForeignKey [FK_tipoVisualizacionPorUsuario_usuario]    Script Date: 04/21/2014 23:30:23 ******/
ALTER TABLE [vadem].[tipoVisualizacionPorUsuario]  WITH CHECK ADD  CONSTRAINT [FK_tipoVisualizacionPorUsuario_usuario] FOREIGN KEY([IdUsuario])
REFERENCES [vadem].[usuario] ([IdUsuario])
GO
ALTER TABLE [vadem].[tipoVisualizacionPorUsuario] CHECK CONSTRAINT [FK_tipoVisualizacionPorUsuario_usuario]
GO
/****** Object:  ForeignKey [FK_tipoVisualizacionPorUsuario_visibilidad]    Script Date: 04/21/2014 23:30:23 ******/
ALTER TABLE [vadem].[tipoVisualizacionPorUsuario]  WITH CHECK ADD  CONSTRAINT [FK_tipoVisualizacionPorUsuario_visibilidad] FOREIGN KEY([IdVisibilidad])
REFERENCES [vadem].[visibilidad] ([IdVisibilidad])
GO
ALTER TABLE [vadem].[tipoVisualizacionPorUsuario] CHECK CONSTRAINT [FK_tipoVisualizacionPorUsuario_visibilidad]
GO
/****** Object:  ForeignKey [FK_usuario_empresa]    Script Date: 04/21/2014 23:30:23 ******/
ALTER TABLE [vadem].[empresa]  WITH CHECK ADD  CONSTRAINT [FK_empresa_usuario] FOREIGN KEY([IdEmpresa])
REFERENCES [vadem].[usuario] ([IdUsuario])
GO
ALTER TABLE [vadem].[empresa] CHECK CONSTRAINT [FK_empresa_usuario]
GO
/****** Object:  ForeignKey [FK_usuario_rol]    Script Date: 04/21/2014 23:30:23 ******/
ALTER TABLE [vadem].[rolesPorUsuario]  WITH CHECK ADD  CONSTRAINT [FK_rolesPorUsuario_rol] FOREIGN KEY([IdRol])
REFERENCES [vadem].[rol] ([IdRol])
GO
ALTER TABLE [vadem].[rolesPorUsuario] CHECK CONSTRAINT [FK_rolesPorUsuario_rol]
GO
/****** Object:  ForeignKey [FK_usuario_rol]    Script Date: 04/21/2014 23:30:23 ******/
ALTER TABLE [vadem].[rolesPorUsuario]  WITH CHECK ADD  CONSTRAINT [FK_rolesPorUsuario_usuario] FOREIGN KEY([IdUsuario])
REFERENCES [vadem].[usuario] ([IdUsuario])
GO
ALTER TABLE [vadem].[rolesPorUsuario] CHECK CONSTRAINT [FK_rolesPorUsuario_usuario]
GO

-- BEGIN TRANSACTION

USE [GD1C2014]
GO

/*
DELETE FROM vadem.rubrosPublicacion
DELETE FROM vadem.rubro
DELETE FROM vadem.pregunta
DELETE FROM vadem.compras
DELETE FROM vadem.ofertas
DELETE FROM vadem.calificacion
DELETE FROM vadem.itemFactura
DELETE FROM vadem.publicacion
DELETE FROM vadem.estado	
DELETE FROM vadem.tipoVisualizacionPorUsuario
DELETE FROM vadem.factura
DELETE FROM vadem.visibilidad
DELETE FROM vadem.cliente
DELETE FROM vadem.empresa
DELETE FROM vadem.rolesPorUsuario
DELETE FROM vadem.usuario
DELETE FROM vadem.rolPorFuncionalidad
DELETE FROM vadem.rol
DELETE FROM vadem.funcionalidad
*/


SELECT 'COMIENZO'

/************************/ SELECT 'ROLES' /************************/
INSERT INTO vadem.rol VALUES(1,'Administrador',1),
							(2,'Cliente',1),
							(3,'Empresa',1)
GO


/************************/ SELECT 'FUNCIONALIDADES' /************************/
INSERT INTO vadem.funcionalidad VALUES	(1,'AMB_ROLES'), 
										(2,'REGISTRO_USUARIO'),
										(3,'ABM_CLIENTE'),
										(4,'AMB_EMPRESA'),
										(5,'AMB_RUBRO'),
										(6,'AMB_VISIBILIDAD'),
										(7,'PUBLICACIONES'),
										(8,'GESTIONA_PREGUNTAS'),
										(9,'COMPRA_OFERTA'),
										(10,'HISTORIA_CLIENTE'),
										(11,'CALIFICAR'),
										(12,'FACTURAR'),
										(13,'LISTADO_ESTADISTICO')
GO


/************************/ SELECT 'ROL POR FUNCIONALIDAD' /************************/
INSERT INTO vadem.rolPorFuncionalidad VALUES(1,1),(1,2),(1,3),(1,4),(1,5),(1,6),(1,7),(1,8),(1,9),(1,10),(1,11),(1,12),(1,13),
											(2,7), (2,8), (2,9), (2,11),
											(3,7), (3,8)
GO

/************************/ SELECT 'USUARIO ADMINISTRADOR' /************************/
INSERT INTO vadem.usuario 
	VALUES ('admin', 'e6b87050bfcb8143fcb8db0170a4dc9ed00d904ddd3e2a4ad1b1e8dc0fdc9be7',0,0,1,0,NULL,0)
GO

/************************/ SELECT 'USUARIOS TIPO CLIENTE' /************************/
INSERT INTO vadem.usuario 
	SELECT  CONVERT(VARCHAR,cli_dni) + '-' + Cli_Apeliido, 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3',0,0,1,0,0,0
	FROM 	(SELECT DISTINCT TOP 100 Cli_Dni, Cli_Apeliido
		FROM         gd_esquema.Maestra
		WHERE     (Cli_Dni IS NOT NULL)
		ORDER BY Cli_Dni
		) E
GO


/************************/ SELECT 'CLIENTES' /************************/
INSERT INTO vadem.cliente
	SELECT (SELECT IdUsuario FROM vadem.usuario U WHERE U.username = CONVERT(VARCHAR,E.cli_dni) + '-' + E.Cli_Apeliido),
		E.cli_dni,'DNI',E.Cli_Nombre,E.Cli_Apeliido, E.Cli_Mail, NULL, E.Cli_Dom_Calle, E.Cli_Nro_Calle, E.Cli_Piso, E.Cli_Depto, '', E.Cli_Cod_Postal, E.Cli_Fecha_Nac,0
	FROM (	SELECT DISTINCT TOP 100 Cli_Dni, Cli_Apeliido, Cli_Nombre, Cli_Fecha_Nac, Cli_Mail, Cli_Dom_Calle, Cli_Nro_Calle, Cli_Piso, Cli_Depto, Cli_Cod_Postal
			FROM         gd_esquema.Maestra
			WHERE     (Cli_Dni IS NOT NULL)
			ORDER BY Cli_Dni
		  ) E
GO


/************************/ SELECT 'USUARIOS TIPO EMPRESA' /************************/
INSERT INTO vadem.usuario 
	SELECT  Publ_Empresa_Cuit, 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3',0,0,1,0,NULL,0
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
INSERT INTO vadem.estado VALUES ('Borrador') , ('Publicada'), ('Pausada'), ('Finalizada')
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
	SELECT DISTINCT U.IdUsuario,E.Publicacion_Visibilidad_Cod,0
	FROM gd_esquema.Maestra E
	LEFT JOIN vadem.usuario U
		ON U.Username = (ISNULL(E.Publ_Empresa_Cuit, CONVERT(VARCHAR,E.Publ_Cli_DNI) + '-' + E.Publ_Cli_Apeliido))
GO


/************************/ SELECT 'RUBRO' /************************/
INSERT INTO vadem.rubro
	SELECT DISTINCT Publicacion_Rubro_Descripcion
	FROM gd_esquema.Maestra
GO


/************************/ SELECT 'PUBLICACION' /************************/
INSERT INTO vadem.publicacion
	SELECT DISTINCT Publicacion_Cod, Publicacion_Stock, 4, Publicacion_Descripcion, Publicacion_Visibilidad_Cod, Publicacion_Fecha,
			Publicacion_Fecha_Venc, Publicacion_Precio, U.IdUsuario, Publicacion_Tipo, 1
	FROM gd_esquema.Maestra E
	LEFT JOIN vadem.usuario U
		ON U.Username = (ISNULL(E.Publ_Empresa_Cuit, CONVERT(VARCHAR,E.Publ_Cli_DNI) + '-' + E.Publ_Cli_Apeliido))
GO


/************************/ SELECT 'RUBROS PUBLICACION' /************************/
INSERT INTO vadem.rubrosPublicacion
	SELECT	E.Publicacion_Cod, R.IdRubro
	FROM gd_esquema.Maestra E
	LEFT JOIN vadem.rubro R
		ON R.Descripcion = E.Publicacion_Rubro_Descripcion
	GROUP BY R.IdRubro, E.Publicacion_Cod
	ORDER BY E.Publicacion_Cod, R.IdRubro
GO


/************************/ SELECT 'OFERTAS' /************************/
INSERT INTO vadem.ofertas
	SELECT Publicacion_Cod, U.IdUsuario,Oferta_Fecha, Oferta_Monto 
	FROM gd_esquema.Maestra E
		LEFT JOIN vadem.usuario U
		ON U.Username = CONVERT(VARCHAR,E.Cli_Dni) + '-' + E.Cli_Apeliido
	WHERE Oferta_Fecha IS NOT NULL
	ORDER BY Publicacion_Cod, Oferta_Fecha
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
	SELECT	DISTINCT Calificacion_Codigo, C.IdCompra, U1.IdUsuario, U2.IdUsuario,Compra_Fecha,Calificacion_Cant_Estrellas, Calificacion_Descripcion
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


/************************/ SELECT 'REPUTACION POR USUARIO' /************************/
UPDATE vadem.usuario 
	SET Reputacion = (SELECT ISNULL (AVG(C.Estrellas),0)
						FROM vadem.calificacion C 
						WHERE C.IdVendedor = IdUsuario)
GO

/************************/ SELECT 'CALIFICACIONES STANDARD' /************************/
INSERT INTO vadem.calificacionesEstandard VALUES	('Excelente atención')
INSERT INTO vadem.calificacionesEstandard VALUES	('Excelente producto')
INSERT INTO vadem.calificacionesEstandard VALUES	('Buena atención')
INSERT INTO vadem.calificacionesEstandard VALUES	('Buen producto')
INSERT INTO vadem.calificacionesEstandard VALUES	('Mala atención')
INSERT INTO vadem.calificacionesEstandard VALUES	('Mal producto')
INSERT INTO vadem.calificacionesEstandard VALUES	('Muy mala atención')
INSERT INTO vadem.calificacionesEstandard VALUES	('Muy mal producto')
											
GO

--COMMIT

/************************/ SELECT 'VISTAS' /************************/
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

USE [GD1C2014]
GO

/************************/ SELECT 'TRIGGERS' /************************/
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

IF (@ESTADO = 2)
BEGIN
	DECLARE @VISIBILIDAD INT
	SELECT @VISIBILIDAD = IdVisibilidad FROM INSERTED 

	DECLARE @CANTIDAD INT
	SET @CANTIDAD = (SELECT CantPublicacionesAcumuladas 
					FROM vadem.tipoVisualizacionPorUsuario
					WHERE IdUsuario = (SELECT IdVendedor FROM INSERTED) 
					AND IdVisibilidad = @VISIBILIDAD
					) + 1

	DECLARE @COSTO INT
	SET @COSTO = (SELECT Comision FROM vadem.visibilidad
					  WHERE IdVisibilidad = @VISIBILIDAD)
					
		-- CONTROLO SI LLEGUE AL LIMITE DONDE HAY QUE BONIFICARLA -- 

		-- PREGUNTO SI NO ES GRATUITA --
		IF (@VISIBILIDAD <> 10006)
		BEGIN
			IF (@CANTIDAD = 10)
				BEGIN
					SET @COSTO = 0
					SET @CANTIDAD = 0
				END		
		END

		-- ACTUALIZA LA TABLA DE TIPO PUBLICACION POR USUARIO -- 

		UPDATE vadem.tipoVisualizacionPorUsuario
			SET CantPublicacionesAcumuladas = @CANTIDAD
		WHERE IdUsuario = (SELECT IdVendedor FROM INSERTED) 
		AND IdVisibilidad = @VISIBILIDAD

		-- INSERTA EL COSTO POR LA PUBLICACION EN LOS ITEM FACTURA --

		INSERT vadem.itemFactura 
		SELECT IdPublicacion, IdVendedor, @COSTO, 1, NULL FROM INSERTED
		
END 
	
END

GO

/************************/ SELECT 'STORED PROCEDURES' /************************/
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



