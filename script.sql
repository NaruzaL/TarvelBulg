USE [TravelBlog]
GO
SET IDENTITY_INSERT [dbo].[Locations] ON 

INSERT [dbo].[Locations] ([LocationId], [Name]) VALUES (1, N'Disneyland')
INSERT [dbo].[Locations] ([LocationId], [Name]) VALUES (2, N'Praug')
INSERT [dbo].[Locations] ([LocationId], [Name]) VALUES (3, N'Hawaii')
INSERT [dbo].[Locations] ([LocationId], [Name]) VALUES (4, N'Seoul, Korea')
INSERT [dbo].[Locations] ([LocationId], [Name]) VALUES (5, N'Walmart')
SET IDENTITY_INSERT [dbo].[Locations] OFF
SET IDENTITY_INSERT [dbo].[Experiences] ON 

INSERT [dbo].[Experiences] ([ExperienceId], [Story], [LocationId]) VALUES (1, N'Luau and bonfire', 3)
INSERT [dbo].[Experiences] ([ExperienceId], [Story], [LocationId]) VALUES (2, N'Beer Garden', 2)
INSERT [dbo].[Experiences] ([ExperienceId], [Story], [LocationId]) VALUES (3, N'KimChi Making lesson', 4)
INSERT [dbo].[Experiences] ([ExperienceId], [Story], [LocationId]) VALUES (4, N'Splash Mountain', 1)
INSERT [dbo].[Experiences] ([ExperienceId], [Story], [LocationId]) VALUES (6, N'Steal Candy', 5)
INSERT [dbo].[Experiences] ([ExperienceId], [Story], [LocationId]) VALUES (7, N'S', 1)
SET IDENTITY_INSERT [dbo].[Experiences] OFF
SET IDENTITY_INSERT [dbo].[People] ON 

INSERT [dbo].[People] ([PeopleId], [Name], [ExperienceId]) VALUES (1, N'Carlos', 1)
INSERT [dbo].[People] ([PeopleId], [Name], [ExperienceId]) VALUES (2, N'Jordan', 5)
INSERT [dbo].[People] ([PeopleId], [Name], [ExperienceId]) VALUES (3, N'Jun', 4)
INSERT [dbo].[People] ([PeopleId], [Name], [ExperienceId]) VALUES (4, N'Girk', 3)
INSERT [dbo].[People] ([PeopleId], [Name], [ExperienceId]) VALUES (5, N'Gurc', 2)
SET IDENTITY_INSERT [dbo].[People] OFF
