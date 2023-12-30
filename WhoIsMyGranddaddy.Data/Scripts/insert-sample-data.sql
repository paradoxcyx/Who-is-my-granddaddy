SET IDENTITY_INSERT [Persons] ON 
GO
INSERT [Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (1, NULL, NULL, N'John', N'Doe', CAST(N'1950-01-01T00:00:00.0000000' AS DateTime2), N'ID1')
GO
INSERT [Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (2, NULL, NULL, N'Jane', N'Doe', CAST(N'1955-02-15T00:00:00.0000000' AS DateTime2), N'ID2')
GO
INSERT [Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (3, 1, 2, N'David', N'Doe', CAST(N'1975-05-10T00:00:00.0000000' AS DateTime2), N'ID3')
GO
INSERT [Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (4, 1, 2, N'Emily', N'Doe', CAST(N'1980-08-20T00:00:00.0000000' AS DateTime2), N'ID4')
GO
INSERT [Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (5, 1, 2, N'James', N'Doe', CAST(N'1982-11-30T00:00:00.0000000' AS DateTime2), N'ID5')
GO
INSERT [Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (6, 1, 2, N'Robert', N'Doe', CAST(N'1970-03-18T00:00:00.0000000' AS DateTime2), N'ID6')
GO
INSERT [Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (7, 1, 2, N'Alice', N'Doe', CAST(N'1972-06-22T00:00:00.0000000' AS DateTime2), N'ID7')
GO
INSERT [Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (8, 3, 4, N'Samantha', N'Doe', CAST(N'1995-09-12T00:00:00.0000000' AS DateTime2), N'ID8')
GO
INSERT [Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (9, 3, 4, N'Michael', N'Doe', CAST(N'1998-12-25T00:00:00.0000000' AS DateTime2), N'ID9')
GO
INSERT [Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (10, 3, 4, N'Linda', N'Doe', CAST(N'2002-04-02T00:00:00.0000000' AS DateTime2), N'ID10')
GO
INSERT [Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (11, 5, 6, N'William', N'Doe', CAST(N'2005-08-15T00:00:00.0000000' AS DateTime2), N'ID11')
GO
INSERT [Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (12, 5, 6, N'Sophia', N'Doe', CAST(N'2008-11-28T00:00:00.0000000' AS DateTime2), N'ID12')
GO
INSERT [Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (13, 7, 8, N'Isaac', N'Doe', CAST(N'2020-03-15T00:00:00.0000000' AS DateTime2), N'ID13')
GO
INSERT [Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (14, 7, 8, N'Ella', N'Doe', CAST(N'2022-06-28T00:00:00.0000000' AS DateTime2), N'ID14')
GO
INSERT [Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (15, 9, 10, N'Benjamin', N'Doe', CAST(N'2019-01-10T00:00:00.0000000' AS DateTime2), N'ID15')
GO
INSERT [Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (16, 9, 10, N'Emma', N'Doe', CAST(N'2021-04-23T00:00:00.0000000' AS DateTime2), N'ID16')
GO
INSERT [Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (17, 11, 12, N'Owen', N'Doe', CAST(N'2040-09-05T00:00:00.0000000' AS DateTime2), N'ID17')
GO
INSERT [Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (18, 11, 12, N'Ava', N'Doe', CAST(N'2043-12-18T00:00:00.0000000' AS DateTime2), N'ID18')
GO
INSERT [Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (19, 13, 14, N'Caleb', N'Doe', CAST(N'2038-03-22T00:00:00.0000000' AS DateTime2), N'ID19')
GO
INSERT [Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (20, 13, 14, N'Chloe', N'Doe', CAST(N'2040-06-05T00:00:00.0000000' AS DateTime2), N'ID20')
GO
INSERT [Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (21, 15, 16, N'Ethan', N'Doe', CAST(N'2065-08-10T00:00:00.0000000' AS DateTime2), N'ID21')
GO
INSERT [Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (22, 15, 16, N'Sophie', N'Doe', CAST(N'2068-11-23T00:00:00.0000000' AS DateTime2), N'ID22')
GO
INSERT [Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (23, 17, 18, N'Mia', N'Doe', CAST(N'2063-02-28T00:00:00.0000000' AS DateTime2), N'ID23')
GO
INSERT [Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (24, 17, 18, N'Logan', N'Doe', CAST(N'2065-05-12T00:00:00.0000000' AS DateTime2), N'ID24')
GO
INSERT [Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (25, 19, 20, N'Jackson', N'Doe', CAST(N'2090-07-15T00:00:00.0000000' AS DateTime2), N'ID25')
GO
INSERT [Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (26, 19, 20, N'Aria', N'Doe', CAST(N'2093-10-28T00:00:00.0000000' AS DateTime2), N'ID26')
GO
INSERT [Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (27, 21, 22, N'Noah', N'Doe', CAST(N'2088-01-10T00:00:00.0000000' AS DateTime2), N'ID27')
GO
INSERT [Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (28, 21, 22, N'Lily', N'Doe', CAST(N'2090-04-23T00:00:00.0000000' AS DateTime2), N'ID28')
GO
INSERT [Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (29, 23, 24, N'Lucas', N'Doe', CAST(N'2115-06-12T00:00:00.0000000' AS DateTime2), N'ID29')
GO
INSERT [Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (30, 23, 24, N'Evelyn', N'Doe', CAST(N'2118-09-25T00:00:00.0000000' AS DateTime2), N'ID30')
GO
INSERT [Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (31, 25, 26, N'Oliver', N'Doe', CAST(N'2113-01-05T00:00:00.0000000' AS DateTime2), N'ID31')
GO
INSERT [Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (32, 25, 26, N'Grace', N'Doe', CAST(N'2115-04-18T00:00:00.0000000' AS DateTime2), N'ID32')
GO
INSERT [Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (33, 27, 28, N'Henry', N'Doe', CAST(N'2135-07-30T00:00:00.0000000' AS DateTime2), N'ID33')
GO
INSERT [Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (34, 27, 28, N'Zoe', N'Doe', CAST(N'2138-11-12T00:00:00.0000000' AS DateTime2), N'ID34')
GO
INSERT [Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (35, 29, 30, N'Emma', N'Doe', CAST(N'2133-02-22T00:00:00.0000000' AS DateTime2), N'ID35')
GO
INSERT [Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (36, 29, 30, N'Carter', N'Doe', CAST(N'2135-05-05T00:00:00.0000000' AS DateTime2), N'ID36')
GO
INSERT [Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (37, 31, 32, N'Aiden', N'Doe', CAST(N'2160-08-18T00:00:00.0000000' AS DateTime2), N'ID37')
GO
INSERT [Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (38, 31, 32, N'Mia', N'Doe', CAST(N'2163-11-30T00:00:00.0000000' AS DateTime2), N'ID38')
GO
INSERT [Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (39, 33, 34, N'Liam', N'Doe', CAST(N'2158-03-05T00:00:00.0000000' AS DateTime2), N'ID39')
GO
INSERT [Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (40, 33, 34, N'Ava', N'Doe', CAST(N'2160-06-18T00:00:00.0000000' AS DateTime2), N'ID40')
GO
INSERT [Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (41, 35, 36, N'Elijah', N'Doe', CAST(N'2185-09-22T00:00:00.0000000' AS DateTime2), N'ID41')
GO
INSERT [Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (42, 35, 36, N'Olivia', N'Doe', CAST(N'2188-12-05T00:00:00.0000000' AS DateTime2), N'ID42')
GO
INSERT [Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (43, 37, 38, N'Jackson', N'Doe', CAST(N'2183-03-10T00:00:00.0000000' AS DateTime2), N'ID43')
GO
INSERT [Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (44, 37, 38, N'Sophia', N'Doe', CAST(N'2185-06-23T00:00:00.0000000' AS DateTime2), N'ID44')
GO
INSERT [Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (45, 39, 40, N'Logan', N'Doe', CAST(N'2210-09-15T00:00:00.0000000' AS DateTime2), N'ID45')
GO
INSERT [Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (46, 39, 40, N'Aria', N'Doe', CAST(N'2213-12-28T00:00:00.0000000' AS DateTime2), N'ID46')
GO
INSERT [Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (47, 41, 42, N'Mason', N'Doe', CAST(N'2208-03-22T00:00:00.0000000' AS DateTime2), N'ID47')
GO
INSERT [Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (48, 41, 42, N'Emma', N'Doe', CAST(N'2210-06-05T00:00:00.0000000' AS DateTime2), N'ID48')
GO
INSERT [Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (49, 43, 44, N'Caleb', N'Doe', CAST(N'2235-08-10T00:00:00.0000000' AS DateTime2), N'ID49')
GO
INSERT [Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (50, 43, 44, N'Chloe', N'Doe', CAST(N'2238-11-23T00:00:00.0000000' AS DateTime2), N'ID50')
GO
INSERT [Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (51, 45, 46, N'Henry', N'Doe', CAST(N'2233-02-28T00:00:00.0000000' AS DateTime2), N'ID51')
GO
INSERT [Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (52, 45, 46, N'Zoe', N'Doe', CAST(N'2235-05-12T00:00:00.0000000' AS DateTime2), N'ID52')
GO
INSERT [Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (53, 47, 48, N'Ethan', N'Doe', CAST(N'2260-07-15T00:00:00.0000000' AS DateTime2), N'ID53')
GO
INSERT [Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (54, 47, 48, N'Sophie', N'Doe', CAST(N'2263-10-28T00:00:00.0000000' AS DateTime2), N'ID54')
GO
INSERT [Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (55, 49, 50, N'Mia', N'Doe', CAST(N'2258-01-10T00:00:00.0000000' AS DateTime2), N'ID55')
GO
INSERT [Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (56, 49, 50, N'Logan', N'Doe', CAST(N'2260-04-23T00:00:00.0000000' AS DateTime2), N'ID56')
GO
INSERT [Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (57, 51, 52, N'Aiden', N'Doe', CAST(N'2285-09-22T00:00:00.0000000' AS DateTime2), N'ID57')
GO
INSERT [Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (58, 51, 52, N'Olivia', N'Doe', CAST(N'2288-12-05T00:00:00.0000000' AS DateTime2), N'ID58')
GO
INSERT [Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (59, 53, 54, N'Jackson', N'Doe', CAST(N'2283-03-10T00:00:00.0000000' AS DateTime2), N'ID59')
GO
INSERT [Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (60, 53, 54, N'Sophia', N'Doe', CAST(N'2285-06-23T00:00:00.0000000' AS DateTime2), N'ID60')
GO
SET IDENTITY_INSERT [Persons] OFF
GO
