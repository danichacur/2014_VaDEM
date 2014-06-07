
/*
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
	[Telefono] [numeric](18, 0) NULL,
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
	[IdPublicacion] ASC
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


