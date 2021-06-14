-- ============================================================= 
-- Criado por : Renato Cavalcante
-- Finalidade : Script para criar DB, tabelas e inserir dados 
-- Data : 2021-jun-14
-- =============================================================
--
IF EXISTS (SELECT [name] FROM sys.databases WHERE [name] = 'Spotify_DB' ) 
DROP DATABASE [Spotify_DB];
GO 

CREATE DATABASE [Spotify_DB];
GO

USE [Spotify_DB]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Genero](
	[GeneroId] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_Genero] PRIMARY KEY CLUSTERED 
(
	[GeneroId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

INSERT INTO [dbo].[Genero] VALUES('POP');
INSERT INTO [dbo].[Genero] VALUES('MPB');
INSERT INTO [dbo].[Genero] VALUES('CLASSIC');
INSERT INTO [dbo].[Genero] VALUES('ROCK');


CREATE TABLE [dbo].[Album](
	[AlbumId] [int] IDENTITY(1,1) NOT NULL,
	[Titulo] [nvarchar](200) NOT NULL,
	[Preco] [decimal](18, 2) NOT NULL,
	[GeneroId] [int] NOT NULL,
 CONSTRAINT [PK_Album] PRIMARY KEY CLUSTERED 
(
	[AlbumId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Album]  WITH CHECK ADD  CONSTRAINT [FK_Album_Genero_GeneroId] FOREIGN KEY([GeneroId])
REFERENCES [dbo].[Genero] ([GeneroId])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Album] CHECK CONSTRAINT [FK_Album_Genero_GeneroId]
GO

INSERT INTO [dbo].[Album] VALUES('ARIANA GRANDE', 19.99, (SELECT GENEROID FROM [dbo].[Genero] WHERE NOME='POP'));
INSERT INTO [dbo].[Album] VALUES('PHARREL WILLIAMS', 19.99, (SELECT GENEROID FROM [dbo].[Genero] WHERE NOME='POP'));
INSERT INTO [dbo].[Album] VALUES('SEAL CRAZY', 19.99, (SELECT GENEROID FROM [dbo].[Genero] WHERE NOME='POP'));

INSERT INTO [dbo].[Album] VALUES('AS QUATRO ESTAÇÕES - LEGIÃO URBANA', 19.99, (SELECT GENEROID FROM [dbo].[Genero] WHERE NOME='MPB'));
INSERT INTO [dbo].[Album] VALUES('EXAGERADO - CAZUZA', 19.99, (SELECT GENEROID FROM [dbo].[Genero] WHERE NOME='MPB'));
INSERT INTO [dbo].[Album] VALUES('MARISA MONTE', 19.99, (SELECT GENEROID FROM [dbo].[Genero] WHERE NOME='MPB'));

INSERT INTO [dbo].[Album] VALUES('BEETHOVEN', 19.99, (SELECT GENEROID FROM [dbo].[Genero] WHERE NOME='CLASSIC'));
INSERT INTO [dbo].[Album] VALUES('CHOPIN', 19.99, (SELECT GENEROID FROM [dbo].[Genero] WHERE NOME='CLASSIC'));
INSERT INTO [dbo].[Album] VALUES('BRAHMS', 19.99, (SELECT GENEROID FROM [dbo].[Genero] WHERE NOME='CLASSIC'));

INSERT INTO [dbo].[Album] VALUES('RAUL SEIXAS', 19.99, (SELECT GENEROID FROM [dbo].[Genero] WHERE NOME='ROCK'));
INSERT INTO [dbo].[Album] VALUES('LENNY KRAVITZ', 19.99, (SELECT GENEROID FROM [dbo].[Genero] WHERE NOME='ROCK'));
INSERT INTO [dbo].[Album] VALUES('PINK FLOYD', 19.99, (SELECT GENEROID FROM [dbo].[Genero] WHERE NOME='ROCK'));




CREATE TABLE [dbo].[Cashback](
	[CashbackId] [int] IDENTITY(1,1) NOT NULL,
	[GeneroId] [int] NOT NULL,
	[DiaSemana] [int] NOT NULL,
	[Percentual] [decimal](6, 2) NOT NULL,
 CONSTRAINT [PK_Cashback] PRIMARY KEY CLUSTERED 
(
	[CashbackId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Cashback]  WITH CHECK ADD  CONSTRAINT [FK_Cashback_Genero_GeneroId] FOREIGN KEY([GeneroId])
REFERENCES [dbo].[Genero] ([GeneroId])
ON DELETE CASCADE
GO

-- UNIQUE KEY AlbumId + DiaSemana
ALTER TABLE [dbo].[Cashback] ADD CONSTRAINT [UNIQUE_GeneroId_DiaSemana] UNIQUE ([GeneroId], [DiaSemana])
GO

ALTER TABLE [dbo].[Cashback] CHECK CONSTRAINT [FK_Cashback_Genero_GeneroId]
GO

/* POPULATE Cashback */
INSERT INTO [dbo].[Cashback] VALUES((SELECT GENEROID FROM [dbo].[Genero] WHERE NOME='POP'), 1, 25);
INSERT INTO [dbo].[Cashback] VALUES((SELECT GENEROID FROM [dbo].[Genero] WHERE NOME='POP'), 2, 7);
INSERT INTO [dbo].[Cashback] VALUES((SELECT GENEROID FROM [dbo].[Genero] WHERE NOME='POP'), 3, 6);
INSERT INTO [dbo].[Cashback] VALUES((SELECT GENEROID FROM [dbo].[Genero] WHERE NOME='POP'), 4, 2);
INSERT INTO [dbo].[Cashback] VALUES((SELECT GENEROID FROM [dbo].[Genero] WHERE NOME='POP'), 5, 10);
INSERT INTO [dbo].[Cashback] VALUES((SELECT GENEROID FROM [dbo].[Genero] WHERE NOME='POP'), 6, 15);
INSERT INTO [dbo].[Cashback] VALUES((SELECT GENEROID FROM [dbo].[Genero] WHERE NOME='POP'), 7, 20);

INSERT INTO [dbo].[Cashback] VALUES((SELECT GENEROID FROM [dbo].[Genero] WHERE NOME='MPB'), 1, 30);
INSERT INTO [dbo].[Cashback] VALUES((SELECT GENEROID FROM [dbo].[Genero] WHERE NOME='MPB'), 2, 5);
INSERT INTO [dbo].[Cashback] VALUES((SELECT GENEROID FROM [dbo].[Genero] WHERE NOME='MPB'), 3, 10);
INSERT INTO [dbo].[Cashback] VALUES((SELECT GENEROID FROM [dbo].[Genero] WHERE NOME='MPB'), 4, 15);
INSERT INTO [dbo].[Cashback] VALUES((SELECT GENEROID FROM [dbo].[Genero] WHERE NOME='MPB'), 5, 20);
INSERT INTO [dbo].[Cashback] VALUES((SELECT GENEROID FROM [dbo].[Genero] WHERE NOME='MPB'), 6, 25);
INSERT INTO [dbo].[Cashback] VALUES((SELECT GENEROID FROM [dbo].[Genero] WHERE NOME='MPB'), 7, 30);

INSERT INTO [dbo].[Cashback] VALUES((SELECT GENEROID FROM [dbo].[Genero] WHERE NOME='CLASSIC'), 1, 35);
INSERT INTO [dbo].[Cashback] VALUES((SELECT GENEROID FROM [dbo].[Genero] WHERE NOME='CLASSIC'), 2, 3);
INSERT INTO [dbo].[Cashback] VALUES((SELECT GENEROID FROM [dbo].[Genero] WHERE NOME='CLASSIC'), 3, 5);
INSERT INTO [dbo].[Cashback] VALUES((SELECT GENEROID FROM [dbo].[Genero] WHERE NOME='CLASSIC'), 4, 8);
INSERT INTO [dbo].[Cashback] VALUES((SELECT GENEROID FROM [dbo].[Genero] WHERE NOME='CLASSIC'), 5, 13);
INSERT INTO [dbo].[Cashback] VALUES((SELECT GENEROID FROM [dbo].[Genero] WHERE NOME='CLASSIC'), 6, 18);
INSERT INTO [dbo].[Cashback] VALUES((SELECT GENEROID FROM [dbo].[Genero] WHERE NOME='CLASSIC'), 7, 25);

INSERT INTO [dbo].[Cashback] VALUES((SELECT GENEROID FROM [dbo].[Genero] WHERE NOME='ROCK'), 1, 40);
INSERT INTO [dbo].[Cashback] VALUES((SELECT GENEROID FROM [dbo].[Genero] WHERE NOME='ROCK'), 2, 10);
INSERT INTO [dbo].[Cashback] VALUES((SELECT GENEROID FROM [dbo].[Genero] WHERE NOME='ROCK'), 3, 15);
INSERT INTO [dbo].[Cashback] VALUES((SELECT GENEROID FROM [dbo].[Genero] WHERE NOME='ROCK'), 4, 15);
INSERT INTO [dbo].[Cashback] VALUES((SELECT GENEROID FROM [dbo].[Genero] WHERE NOME='ROCK'), 5, 15);
INSERT INTO [dbo].[Cashback] VALUES((SELECT GENEROID FROM [dbo].[Genero] WHERE NOME='ROCK'), 6, 20);
INSERT INTO [dbo].[Cashback] VALUES((SELECT GENEROID FROM [dbo].[Genero] WHERE NOME='ROCK'), 7, 40);



/* CREATE TABLE VENDA */
CREATE TABLE [dbo].[Venda](
	[VendaId] [int] IDENTITY(1,1) NOT NULL,
	[DataVenda] [datetime2](7) NOT NULL,
	[NomeCliente] [nvarchar](max) NULL,
	[TotalVenda] [decimal](18, 2) NOT NULL,
	[TotalCashback] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Venda] PRIMARY KEY CLUSTERED 
(
	[VendaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO



/* CREATE TABLE VENDAITENS */
CREATE TABLE [dbo].[VendaItem](
	[VendaItemId] [int] IDENTITY(1,1) NOT NULL,
	[Quantidade] [decimal](18, 2) NOT NULL,
	[ValorUnitario] [decimal](18, 2) NOT NULL,
	[AlbumId] [int] NOT NULL,
	[VendaId] [int] NOT NULL,
 CONSTRAINT [PK_VendaItem] PRIMARY KEY CLUSTERED 
(
	[VendaItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[VendaItem]  WITH CHECK ADD  CONSTRAINT [FK_VendaItem_Album_AlbumId] FOREIGN KEY([AlbumId])
REFERENCES [dbo].[Album] ([AlbumId])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[VendaItem] CHECK CONSTRAINT [FK_VendaItem_Album_AlbumId]
GO

ALTER TABLE [dbo].[VendaItem]  WITH CHECK ADD  CONSTRAINT [FK_VendaItem_Venda_VendaId] FOREIGN KEY([VendaId])
REFERENCES [dbo].[Venda] ([VendaId])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[VendaItem] CHECK CONSTRAINT [FK_VendaItem_Venda_VendaId]
GO


/* POPULATE VENDA e VENDAITEM */
declare @minimo as integer = 0;
select @minimo = MIN(AlbumId) FROM [dbo].[Album];
declare @maximo as integer = 0;
select @maximo = MAX(AlbumId) FROM [dbo].[Album];

INSERT INTO [dbo].[Venda] VALUES (GETDATE(), 'Jonas Batista', 2 * 19.99, 0);
INSERT INTO [dbo].[VendaItem] VALUES (1, 19.99, ABS(CHECKSUM(NEWID()) % (@maximo - @minimo - 1)) + @minimo, (SELECT MAX(VendaId) FROM [dbo].[Venda]))
INSERT INTO [dbo].[VendaItem] VALUES (1, 19.99, ABS(CHECKSUM(NEWID()) % (@maximo - @minimo - 1)) + @minimo, (SELECT MAX(VendaId) FROM [dbo].[Venda]))
UPDATE [dbo].[Venda] SET TotalCashback = (
SELECT SUM(Cashback) from (
SELECT (Quantidade*ValorUnitario)*(Percentual/100) 'Cashback' FROM [dbo].[Venda]
LEFT JOIN [dbo].[VendaItem] ON [dbo].[VendaItem].VendaId = [dbo].[Venda].VendaId 
LEFT JOIN [dbo].[Album] ON [dbo].[Album].AlbumId = [dbo].[VendaItem].AlbumId 
LEFT JOIN [dbo].[Cashback] ON [dbo].[Cashback].GeneroId = [dbo].[Album].GeneroId AND DiaSemana = DATEPART(dw,[dbo].[Venda].DataVenda)
WHERE [dbo].[Venda].VendaId = (SELECT MAX(VendaId) FROM [dbo].[Venda])
) result
) WHERE VendaId = (SELECT MAX(VendaId) FROM [dbo].[Venda])

INSERT INTO [dbo].[Venda] VALUES (GETDATE()-1, 'Aline Soares', 4 * 19.99, 0);
INSERT INTO [dbo].[VendaItem] VALUES (1, 19.99, ABS(CHECKSUM(NEWID()) % (@maximo - @minimo - 1)) + @minimo, (SELECT MAX(VendaId) FROM [dbo].[Venda]))
INSERT INTO [dbo].[VendaItem] VALUES (1, 19.99, ABS(CHECKSUM(NEWID()) % (@maximo - @minimo - 1)) + @minimo, (SELECT MAX(VendaId) FROM [dbo].[Venda]))
INSERT INTO [dbo].[VendaItem] VALUES (1, 19.99, ABS(CHECKSUM(NEWID()) % (@maximo - @minimo - 1)) + @minimo, (SELECT MAX(VendaId) FROM [dbo].[Venda]))
INSERT INTO [dbo].[VendaItem] VALUES (1, 19.99, ABS(CHECKSUM(NEWID()) % (@maximo - @minimo - 1)) + @minimo, (SELECT MAX(VendaId) FROM [dbo].[Venda]))
UPDATE [dbo].[Venda] SET TotalCashback = (
SELECT SUM(Cashback) from (
SELECT (Quantidade*ValorUnitario)*(Percentual/100) 'Cashback' FROM [dbo].[Venda]
LEFT JOIN [dbo].[VendaItem] ON [dbo].[VendaItem].VendaId = [dbo].[Venda].VendaId 
LEFT JOIN [dbo].[Album] ON [dbo].[Album].AlbumId = [dbo].[VendaItem].AlbumId 
LEFT JOIN [dbo].[Cashback] ON [dbo].[Cashback].GeneroId = [dbo].[Album].GeneroId AND DiaSemana = DATEPART(dw,[dbo].[Venda].DataVenda)
WHERE [dbo].[Venda].VendaId = (SELECT MAX(VendaId) FROM [dbo].[Venda])
) result
) WHERE VendaId = (SELECT MAX(VendaId) FROM [dbo].[Venda])

INSERT INTO [dbo].[Venda] VALUES (GETDATE()-2, 'Rosimeire Silva', 3 * 19.99, 0);
INSERT INTO [dbo].[VendaItem] VALUES (1, 19.99, ABS(CHECKSUM(NEWID()) % (@maximo - @minimo - 1)) + @minimo, (SELECT MAX(VendaId) FROM [dbo].[Venda]))
INSERT INTO [dbo].[VendaItem] VALUES (1, 19.99, ABS(CHECKSUM(NEWID()) % (@maximo - @minimo - 1)) + @minimo, (SELECT MAX(VendaId) FROM [dbo].[Venda]))
INSERT INTO [dbo].[VendaItem] VALUES (1, 19.99, ABS(CHECKSUM(NEWID()) % (@maximo - @minimo - 1)) + @minimo, (SELECT MAX(VendaId) FROM [dbo].[Venda]))
UPDATE [dbo].[Venda] SET TotalCashback = (
SELECT SUM(Cashback) from (
SELECT (Quantidade*ValorUnitario)*(Percentual/100) 'Cashback' FROM [dbo].[Venda]
LEFT JOIN [dbo].[VendaItem] ON [dbo].[VendaItem].VendaId = [dbo].[Venda].VendaId 
LEFT JOIN [dbo].[Album] ON [dbo].[Album].AlbumId = [dbo].[VendaItem].AlbumId 
LEFT JOIN [dbo].[Cashback] ON [dbo].[Cashback].GeneroId = [dbo].[Album].GeneroId AND DiaSemana = DATEPART(dw,[dbo].[Venda].DataVenda)
WHERE [dbo].[Venda].VendaId = (SELECT MAX(VendaId) FROM [dbo].[Venda])
) result
) WHERE VendaId = (SELECT MAX(VendaId) FROM [dbo].[Venda])

INSERT INTO [dbo].[Venda] VALUES (GETDATE()-3, 'Nivea Maria', 6 * 19.99, 0);
INSERT INTO [dbo].[VendaItem] VALUES (2, 19.99, ABS(CHECKSUM(NEWID()) % (@maximo - @minimo - 1)) + @minimo, (SELECT MAX(VendaId) FROM [dbo].[Venda]))
INSERT INTO [dbo].[VendaItem] VALUES (3, 19.99, ABS(CHECKSUM(NEWID()) % (@maximo - @minimo - 1)) + @minimo, (SELECT MAX(VendaId) FROM [dbo].[Venda]))
INSERT INTO [dbo].[VendaItem] VALUES (1, 19.99, ABS(CHECKSUM(NEWID()) % (@maximo - @minimo - 1)) + @minimo, (SELECT MAX(VendaId) FROM [dbo].[Venda]))
UPDATE [dbo].[Venda] SET TotalCashback = (
SELECT SUM(Cashback) from (
SELECT (Quantidade*ValorUnitario)*(Percentual/100) 'Cashback' FROM [dbo].[Venda]
LEFT JOIN [dbo].[VendaItem] ON [dbo].[VendaItem].VendaId = [dbo].[Venda].VendaId 
LEFT JOIN [dbo].[Album] ON [dbo].[Album].AlbumId = [dbo].[VendaItem].AlbumId 
LEFT JOIN [dbo].[Cashback] ON [dbo].[Cashback].GeneroId = [dbo].[Album].GeneroId AND DiaSemana = DATEPART(dw,[dbo].[Venda].DataVenda)
WHERE [dbo].[Venda].VendaId = (SELECT MAX(VendaId) FROM [dbo].[Venda])
) result
) WHERE VendaId = (SELECT MAX(VendaId) FROM [dbo].[Venda])

INSERT INTO [dbo].[Venda] VALUES (GETDATE()-4, 'Sofia Regina', 5 * 19.99, 0);
INSERT INTO [dbo].[VendaItem] VALUES (1, 19.99, ABS(CHECKSUM(NEWID()) % (@maximo - @minimo - 1)) + @minimo, (SELECT MAX(VendaId) FROM [dbo].[Venda]))
INSERT INTO [dbo].[VendaItem] VALUES (2, 19.99, ABS(CHECKSUM(NEWID()) % (@maximo - @minimo - 1)) + @minimo, (SELECT MAX(VendaId) FROM [dbo].[Venda]))
INSERT INTO [dbo].[VendaItem] VALUES (2, 19.99, ABS(CHECKSUM(NEWID()) % (@maximo - @minimo - 1)) + @minimo, (SELECT MAX(VendaId) FROM [dbo].[Venda]))
UPDATE [dbo].[Venda] SET TotalCashback = (
SELECT SUM(Cashback) from (
SELECT (Quantidade*ValorUnitario)*(Percentual/100) 'Cashback' FROM [dbo].[Venda]
LEFT JOIN [dbo].[VendaItem] ON [dbo].[VendaItem].VendaId = [dbo].[Venda].VendaId 
LEFT JOIN [dbo].[Album] ON [dbo].[Album].AlbumId = [dbo].[VendaItem].AlbumId 
LEFT JOIN [dbo].[Cashback] ON [dbo].[Cashback].GeneroId = [dbo].[Album].GeneroId AND DiaSemana = DATEPART(dw,[dbo].[Venda].DataVenda)
WHERE [dbo].[Venda].VendaId = (SELECT MAX(VendaId) FROM [dbo].[Venda])
) result
) WHERE VendaId = (SELECT MAX(VendaId) FROM [dbo].[Venda])

--SELECT * FROM [dbo].[Venda] 
--SELECT * FROM [dbo].[VendaItem] WHERE VendaId = (SELECT MAX(VendaId) FROM [dbo].[Venda])
--SELECT * FROM [dbo].[Album] ORDER BY 2
--SELECT * FROM [dbo].[Genero]

