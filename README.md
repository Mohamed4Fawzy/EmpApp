# EmpApp
# Kindly do below steps to run the App

1-	Create Data Base in Sql Server with Name EmpDB.

2-	Run Attached DBScript File on DB EmpDB.

3-	Open and run Attached App with VS 2022.

4-	Log in Credentials

User Name: ABC
Password: 123	
Role: Admin, Employee

User Name: DEF
Password: 456	
Role: Employee

# DBScript


create table Employee  
(  
   EmpId int primary key identity (1,1),  
   Name nvarchar(50),  
   Gender char(10),  
   Age int,  
   Position nvarchar(50),  
   Office nvarchar(50),  
   HireDate datetime,  
   Salary int,  
   DepartmentId int  
)  
  
create table Department  
(  
   DeptId int primary key identity(1,1),  
   DepartmentName nvarchar(50)  
)  
  
create table Users  
(  
   Id int primary key identity(1,1),  
   Username nvarchar(50),  
   Password nvarchar(50)  
)  
  
create table Roles  
(  
   Id int primary key identity(1,1),  
   RoleName nvarchar(50)  
)  
  
create table UserRoleMapping  
(  
   Id int primary key identity(1,1),  
   UserId int,  
   RoleId int  
)  
  
alter table Employee Add foreign key  
(DepartmentId) references Department(DeptId)  
  
alter table UserRoleMapping Add foreign key(UserId)  
references Users(Id)  
  
alter table UserRoleMapping Add foreign key(RoleId)  
references Roles(id) 


USE [EmpDB]
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 
GO
INSERT [dbo].[Roles] ([Id], [RoleName]) VALUES (1, N'Admin')
GO
INSERT [dbo].[Roles] ([Id], [RoleName]) VALUES (2, N'Employee')
GO
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 
GO
INSERT [dbo].[Users] ([Id], [Username], [Password]) VALUES (1, N'ABC', N'123')
GO
INSERT [dbo].[Users] ([Id], [Username], [Password]) VALUES (2, N'DEF', N'456')
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
SET IDENTITY_INSERT [dbo].[UserRoleMapping] ON 
GO
INSERT [dbo].[UserRoleMapping] ([Id], [UserId], [RoleId]) VALUES (1, 1, 1)
GO
INSERT [dbo].[UserRoleMapping] ([Id], [UserId], [RoleId]) VALUES (2, 2, 2)
GO
INSERT [dbo].[UserRoleMapping] ([Id], [UserId], [RoleId]) VALUES (3, 1, 2)
GO
SET IDENTITY_INSERT [dbo].[UserRoleMapping] OFF
GO
