CREATE TABLE [site].[Persons](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FatherId] [int] NULL,
	[MotherId] [int] NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Surname] [nvarchar](max) NOT NULL,
	[BirthDate] [datetime2](7) NOT NULL,
	[IdentityNumber] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Persons] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [site].[Persons]  WITH CHECK ADD  CONSTRAINT [FK_Persons_Persons_FatherId] FOREIGN KEY([FatherId])
REFERENCES [site].[Persons] ([Id])
GO

ALTER TABLE [site].[Persons] CHECK CONSTRAINT [FK_Persons_Persons_FatherId]
GO
ALTER TABLE [site].[Persons]  WITH CHECK ADD  CONSTRAINT [FK_Persons_Persons_MotherId] FOREIGN KEY([MotherId])
REFERENCES [site].[Persons] ([Id])
GO

ALTER TABLE [site].[Persons] CHECK CONSTRAINT [FK_Persons_Persons_MotherId]
GO
/****** Object:  Index [IX_Persons_FatherId]    Script Date: 2024/01/07 02:03:21 ******/
CREATE NONCLUSTERED INDEX [IX_Persons_FatherId] ON [site].[Persons]
(
	[FatherId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Persons_MotherId]    Script Date: 2024/01/07 02:03:21 ******/
CREATE NONCLUSTERED INDEX [IX_Persons_MotherId] ON [site].[Persons]
(
	[MotherId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]