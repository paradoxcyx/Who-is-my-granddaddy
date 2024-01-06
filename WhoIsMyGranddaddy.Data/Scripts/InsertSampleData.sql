SET IDENTITY_INSERT [site].[Persons] ON 
GO
INSERT [site].[Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (1, NULL, NULL, N'John', N'Doe', CAST(N'1980-01-01T00:00:00.0000000' AS DateTime2), N'ID1')
GO
INSERT [site].[Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (2, NULL, NULL, N'Amy', N'Doe', CAST(N'1970-01-01T00:00:00.0000000' AS DateTime2), N'ID2')
GO
INSERT [site].[Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (4, 1, 2, N'Lilly', N'Doe', CAST(N'1970-01-01T00:00:00.0000000' AS DateTime2), N'ID3')
GO
INSERT [site].[Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (5, 1, 2, N'Johnny', N'Doe', CAST(N'1960-01-01T00:00:00.0000000' AS DateTime2), N'ID4')
GO
INSERT [site].[Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (6, 1, 2, N'Sam', N'Doe', CAST(N'2001-01-01T00:00:00.0000000' AS DateTime2), N'ID5')
GO
INSERT [site].[Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (7, 9, 10, N'Frank', N'Doe', CAST(N'2002-01-01T00:00:00.0000000' AS DateTime2), N'ID6')
GO
INSERT [site].[Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (8, 7, 6, N'Sammy', N'Frank', CAST(N'2003-01-01T00:00:00.0000000' AS DateTime2), N'ID7')
GO
INSERT [site].[Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (9, NULL, NULL, N'John', N'Frank', CAST(N'2004-01-01T00:00:00.0000000' AS DateTime2), N'ID8')
GO
INSERT [site].[Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (10, NULL, NULL, N'Samantha', N'Frank', CAST(N'2005-01-01T00:00:00.0000000' AS DateTime2), N'ID9')
GO
INSERT [site].[Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (11, 7, 6, N'Johnny', N'Frank', CAST(N'2005-01-01T00:00:00.0000000' AS DateTime2), N'ID10')
GO
INSERT [site].[Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (12, 26, 27, N'Lily', N'Frank', CAST(N'2005-01-01T00:00:00.0000000' AS DateTime2), N'ID11')
GO
INSERT [site].[Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (13, 12, 11, N'Lileth', N'Frank', CAST(N'2005-01-01T00:00:00.0000000' AS DateTime2), N'ID12')
GO
INSERT [site].[Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (14, NULL, NULL, N'Lola', N'Blank', CAST(N'2005-01-01T00:00:00.0000000' AS DateTime2), N'ID13')
GO
INSERT [site].[Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (15, 5, 14, N'Lolitha', N'Blank', CAST(N'2005-01-01T00:00:00.0000000' AS DateTime2), N'ID14')
GO
INSERT [site].[Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (16, 5, 14, N'Frankie', N'Blank', CAST(N'2005-01-01T00:00:00.0000000' AS DateTime2), N'ID15')
GO
INSERT [site].[Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (17, NULL, NULL, N'Frederik', N'Monk', CAST(N'2005-01-01T00:00:00.0000000' AS DateTime2), N'ID16')
GO
INSERT [site].[Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (18, 17, 15, N'Freddy', N'Monk', CAST(N'2005-01-01T00:00:00.0000000' AS DateTime2), N'ID17')
GO
INSERT [site].[Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (19, 17, 15, N'Renitha', N'Monk', CAST(N'2005-01-01T00:00:00.0000000' AS DateTime2), N'ID18')
GO
INSERT [site].[Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (20, NULL, NULL, N'Rennie', N'Van Wyk', CAST(N'2005-01-01T00:00:00.0000000' AS DateTime2), N'ID19')
GO
INSERT [site].[Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (21, 20, 4, N'Kenny', N'Van Wyk', CAST(N'2005-01-01T00:00:00.0000000' AS DateTime2), N'ID20')
GO
INSERT [site].[Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (22, 20, 4, N'Sandra', N'Van Wyk', CAST(N'2005-01-01T00:00:00.0000000' AS DateTime2), N'ID21')
GO
INSERT [site].[Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (23, 20, 4, N'Conrad', N'Van Wyk', CAST(N'2005-01-01T00:00:00.0000000' AS DateTime2), N'ID22')
GO
INSERT [site].[Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (24, NULL, NULL, N'Harmony', N'Ronn', CAST(N'2005-01-01T00:00:00.0000000' AS DateTime2), N'ID23')
GO
INSERT [site].[Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (25, 23, 24, N'Harry', N'Van Wyk', CAST(N'2005-01-01T00:00:00.0000000' AS DateTime2), N'ID24')
GO
INSERT [site].[Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (26, NULL, NULL, N'Peter', N'Frank', CAST(N'2005-01-01T00:00:00.0000000' AS DateTime2), N'ID25')
GO
INSERT [site].[Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (27, NULL, NULL, N'Sendra', N'Frank', CAST(N'2005-01-01T00:00:00.0000000' AS DateTime2), N'ID26')
GO
INSERT [site].[Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (28, NULL, NULL, N'Adri', N'Shan', CAST(N'2005-01-01T00:00:00.0000000' AS DateTime2), N'ID27')
GO
INSERT [site].[Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (29, 18, 28, N'Adrina', N'Shan', CAST(N'2005-01-01T00:00:00.0000000' AS DateTime2), N'ID28')
GO
INSERT [site].[Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (30, NULL, NULL, N'Bakkies', N'Botha', CAST(N'2005-01-01T00:00:00.0000000' AS DateTime2), N'ID29')
GO
INSERT [site].[Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (31, 30, 29, N'Ronald', N'Botha', CAST(N'2005-01-01T00:00:00.0000000' AS DateTime2), N'ID30')
GO
INSERT [site].[Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (32, NULL, NULL, N'Keisha', N'McDonald', CAST(N'2005-01-01T00:00:00.0000000' AS DateTime2), N'ID31')
GO
INSERT [site].[Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (33, 31, 32, N'Keela', N'McDonald', CAST(N'2005-01-01T00:00:00.0000000' AS DateTime2), N'ID32')
GO
INSERT [site].[Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (34, NULL, NULL, N'Johan', N'Fourie', CAST(N'2005-01-01T00:00:00.0000000' AS DateTime2), N'ID33')
GO
INSERT [site].[Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (35, 34, 33, N'Koolie', N'Fourie', CAST(N'2005-01-01T00:00:00.0000000' AS DateTime2), N'ID44')
GO
INSERT [site].[Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (36, NULL, NULL, N'Jan-Hendrik', N'Human', CAST(N'2005-01-01T00:00:00.0000000' AS DateTime2), N'ID45')
GO
INSERT [site].[Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (37, 36, 35, N'Jannie', N'Human', CAST(N'2005-01-01T00:00:00.0000000' AS DateTime2), N'ID46')
GO
INSERT [site].[Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (39, 31, 32, N'Fannie', N'Fourie', CAST(N'2005-01-01T00:00:00.0000000' AS DateTime2), N'ID47')
GO
SET IDENTITY_INSERT [site].[Persons] OFF
GO
