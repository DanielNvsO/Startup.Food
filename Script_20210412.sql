--CREATE DATABASE dbstartupfood


--USE [dbstartupfood]
--GO
/****** Object:  Table [dbo].[tbl_Ingrediente]    Script Date: 12/04/2021 22:49:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Ingrediente](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Codigo] [varchar](10) NULL,
	[Descricao] [varchar](250) NULL,
	[Valor] [decimal](17, 2) NULL,
 CONSTRAINT [PK_tbl_Ingrediente] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_IngredienteLanche]    Script Date: 12/04/2021 22:49:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_IngredienteLanche](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[idLanche] [int] NULL,
	[CodigoLanche] [varchar](10) NULL,
	[DescricaoLanche] [varchar](250) NULL,
	[IdIngrediente] [int] NULL,
	[CodigoIngrediente] [varchar](10) NULL,
	[DescricaoIngrediente] [varchar](250) NULL,
	[Quantidade] [int] NULL,
 CONSTRAINT [PK_tbl_IngredienteLanche] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Lanche]    Script Date: 12/04/2021 22:49:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Lanche](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Codigo] [varchar](10) NULL,
	[Descricao] [varchar](250) NULL,
	[Valor] [decimal](17, 2) NULL,
 CONSTRAINT [PK_tbl_Lanche] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Pedido]    Script Date: 12/04/2021 22:49:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Pedido](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NomeCliente] [varchar](250) NULL,
	[ValorTotal] [decimal](17, 2) NULL,
	[DataPedido] [datetime] NULL,
	[IdPedidoItem] [int] NULL,
 CONSTRAINT [PK_tbl_Pedido] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_PedidoItem]    Script Date: 12/04/2021 22:49:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_PedidoItem](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[IdLanche] [int] NULL,
	[Ingredientes] [varchar](250) NULL,
	[Valor] [nchar](10) NULL,
 CONSTRAINT [PK_tbl_PedidoItem] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[prd_ConIngredientes]    Script Date: 12/04/2021 22:49:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[prd_ConIngredientes] 
AS
BEGIN
	
	SELECT * FROM tbl_Ingrediente


END
GO
/****** Object:  StoredProcedure [dbo].[prd_ConIngredientesLanche]    Script Date: 12/04/2021 22:49:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[prd_ConIngredientesLanche] 
@IdLanche INT
AS
BEGIN
	
	SELECT tb2.*,tb1.Quantidade  FROM tbl_IngredienteLanche tb1 
			INNER JOIN tbl_Ingrediente tb2
			ON tb1.IdIngrediente = tb2.Id WHERE idLanche = @IdLanche


END
GO
/****** Object:  StoredProcedure [dbo].[prd_ConLanches]    Script Date: 12/04/2021 22:49:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[prd_ConLanches] 
	
AS
BEGIN
	
	SELECT * FROM tbl_Lanche

END
GO



BEGIN TRANSACTION


INSERT INTO [dbo].[tbl_Ingrediente]
SELECT 'Alface'	,'Alface'	,0.40 UNION ALL
SELECT 'Bacon'	,'Bacon'	,2.00 UNION ALL
SELECT 'HambCarn'	,'Hambúrguer de carne'	,3.00 UNION ALL
SELECT 'Ovo'	,'Ovo'	,0.80 UNION ALL
SELECT 'Queijo'	,'Queijo'	,1.50;


INSERT INTO [dbo].[tbl_Lanche]
SELECT 'XBacon'	,'X-Bacon'	,6.50 UNION ALL
SELECT 'XBurger'	,'X-Burger'	,4.50 UNION ALL
SELECT 'XEgg'	,'X-Egg'	,5.30 UNION ALL
SELECT 'XEggB'	,'X-Egg Bacon'	,7.30;

INSERT INTO [dbo].[tbl_IngredienteLanche]
SELECT 	'9'	,'X-Bacon'	,'X-Bacon'		,'2'	,'Bacon',	'Bacon','1'                      UNION ALL
SELECT 	'9'	,'X-Bacon'	,'X-Bacon'		,'3'	,'HambCarn',	'Hambúrguer de carne'	,'1'	 UNION ALL
SELECT 	'9'	,'X-Bacon'	,'X-Bacon'		,'5'	,'Queijo',	'Queijo'	,'1'				 UNION ALL
SELECT 	'10','X-Burger'	,'X-Burger'		,'3'	,'HambCarn',	'Hambúrguer de carne'	,'1'	 UNION ALL
SELECT 	'10','X-Burger'	,'X-Burger'		,'5'	,'Queijo',	'Queijo'	,'1'				 UNION ALL
SELECT 	'11','X-Egg'	,'X-Egg'		,'4'	,'Ovo',	'Ovo'	,'1'						 UNION ALL
SELECT 	'11','X-Egg'	,'X-Egg'		,'3'	,'HambCarn',	'Hambúrguer de carne'	,'1'	 UNION ALL
SELECT 	'11','X-Egg'	,'X-Egg'		,'5'	,'Queijo',	'Queijo'	,'1'					 UNION ALL
SELECT 	'12','XEggB'	,'X-Egg Bacon'	,'4',	'Ovo',	'Ovo'	,'1'					 UNION ALL
SELECT 	'12','XEggB'	,'X-Egg Bacon'	,'2',	'Bacon',	'Bacon'	,'1'				 UNION ALL
SELECT 	'12','XEggB'	,'X-Egg Bacon'	,'3',	'HambCarn',	'Hambúrguer de carne'	,'1' UNION ALL
SELECT 	'12','XEggB'	,'X-Egg Bacon'	,'5',	'Queijo',	'Queijo'	,'1';			 

COMMIT TRANSACTION
--ROLLBACK TRANSACTION
