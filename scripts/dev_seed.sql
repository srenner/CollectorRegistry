USE [CollectorRegistry]
GO
SET IDENTITY_INSERT [dbo].[Sites] ON 
GO
INSERT [dbo].[Sites] ([SiteID], [Title], [Subdomain], [Description], [AboutText], [Logo], [VinRegex], [CreationDate], [IsActive], [IsApproved], [IsDeleted]) VALUES (1, N'Mustang SVO Registry', N'svo', N'The only publicly available registry for the 1984 - 1986 Ford Mustang SVO', N'Here is some history about this type of vehicle', NULL, NULL, CAST(N'2022-12-06T00:00:00.0000000' AS DateTime2), 1, 1, 0)
GO
SET IDENTITY_INSERT [dbo].[Sites] OFF
GO
