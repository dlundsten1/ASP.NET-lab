CREATE TABLE [dbo].[Brand] (
    [Id]  INT           IDENTITY (1, 1) NOT NULL,
    [BrandName] NVARCHAR (20) NOT NULL,
    CONSTRAINT [PK_Tbl_Brand] PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Skis] (
    [Id]        INT          IDENTITY (1, 1) NOT NULL,
    [Sk_Name]   VARCHAR (50) NOT NULL,
	[Sk_Length] INT          NOT NULL,
    [Sk_Width]  INT				 NULL,
    [Sk_Origin]      INT          NOT NULL,
    CONSTRAINT [PK_Tbl_Skis] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Tbl_Skis_Tbl_Brand] FOREIGN KEY ([Sk_Origin]) REFERENCES [dbo].[Skis] ([Id]),
);

INSERT INTO [dbo].[Brand] ([BrandName])
VALUES 
('HEAD'),
('Atomic'),
('Salomon'),
('Rossignol'),
('Dynafit');


INSERT INTO [dbo].[Skis] 
([Sk_Name], [Sk_Length], [Sk_Width], [Sk_Origin]) 
VALUES 
('MOJO', 190, 97, 1),
('Stoke', 192, 107, 5),
('MTN explore 95', 168, 95, 3),
('Soul 7', 178, 97, 4),
('Soul 3', 198, 93, 4),
('Extreme 65', 160, 65, 2),
('Quest 118', 190, 118, 3);
