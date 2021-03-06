USE [master]
GO
/****** Object:  Database [PerformaceEvaluation]    Script Date: 5/25/2021 11:08:19 AM ******/
CREATE DATABASE [PerformaceEvaluation]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PerformaceEvaluation', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\PerformaceEvaluation.mdf' , SIZE = 3136KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'PerformaceEvaluation_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\PerformaceEvaluation_log.ldf' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [PerformaceEvaluation] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PerformaceEvaluation].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PerformaceEvaluation] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PerformaceEvaluation] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PerformaceEvaluation] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PerformaceEvaluation] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PerformaceEvaluation] SET ARITHABORT OFF 
GO
ALTER DATABASE [PerformaceEvaluation] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PerformaceEvaluation] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [PerformaceEvaluation] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PerformaceEvaluation] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PerformaceEvaluation] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PerformaceEvaluation] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PerformaceEvaluation] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PerformaceEvaluation] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PerformaceEvaluation] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PerformaceEvaluation] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PerformaceEvaluation] SET  ENABLE_BROKER 
GO
ALTER DATABASE [PerformaceEvaluation] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PerformaceEvaluation] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PerformaceEvaluation] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PerformaceEvaluation] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PerformaceEvaluation] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PerformaceEvaluation] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PerformaceEvaluation] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PerformaceEvaluation] SET RECOVERY FULL 
GO
ALTER DATABASE [PerformaceEvaluation] SET  MULTI_USER 
GO
ALTER DATABASE [PerformaceEvaluation] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PerformaceEvaluation] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PerformaceEvaluation] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PerformaceEvaluation] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'PerformaceEvaluation', N'ON'
GO
USE [PerformaceEvaluation]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 5/25/2021 11:08:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EName] [nvarchar](250) NULL,
	[ELName] [nvarchar](250) NULL,
	[ENameAM] [nvarchar](250) NULL,
	[ELNameAM] [nvarchar](250) NULL,
	[JobPosition] [nvarchar](250) NULL,
	[JobPositionAM] [nvarchar](250) NULL,
	[isActive] [nvarchar](10) NULL,
	[CompanyId] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EvaluatedPoints]    Script Date: 5/25/2021 11:08:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EvaluatedPoints](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeId] [int] NULL,
	[EvaluatorId] [int] NULL,
	[EvaluationPointName] [int] NULL,
	[EvaluationPeriod] [int] NULL,
	[EvaluationPointGiven] [nvarchar](max) NULL,
	[evaluationDate] [datetime] NULL,
	[IsSubmitted] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EvaluationPeriod]    Script Date: 5/25/2021 11:08:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EvaluationPeriod](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EvaluationPeriod] [nvarchar](250) NULL,
	[isClosed] [nvarchar](1) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LKDatatypes]    Script Date: 5/25/2021 11:08:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LKDatatypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TypeName] [nvarchar](250) NULL,
	[Remarks] [nvarchar](250) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LKEvaluationPoints]    Script Date: 5/25/2021 11:08:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LKEvaluationPoints](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EvaluationName] [nvarchar](250) NULL,
	[MaxRate] [int] NULL,
	[MinRate] [int] NULL,
	[Status] [nvarchar](250) NULL,
	[Language] [nvarchar](50) NULL,
	[DataTypes] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LKSixMonthPlan]    Script Date: 5/25/2021 11:08:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LKSixMonthPlan](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PlanName] [nvarchar](max) NOT NULL,
	[DataTypeSelection] [int] NULL,
	[LanguageSelection] [nvarchar](25) NULL,
	[StatusRemark] [nvarchar](max) NULL,
	[PreparedByID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LKUsersRoles]    Script Date: 5/25/2021 11:08:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LKUsersRoles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](250) NOT NULL,
	[statusRemark] [nvarchar](250) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SixMonthPlan]    Script Date: 5/25/2021 11:08:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SixMonthPlan](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PlanSetByEmployeeId] [int] NULL,
	[EvaluationPeriod] [int] NULL,
	[PlanName] [int] NOT NULL,
	[PriorityGiven] [nvarchar](max) NULL,
	[DatePlanned] [datetime] NULL,
	[StatusRemark] [nvarchar](max) NULL,
	[IsSubmitted] [bit] NULL,
	[PlanSetForEmployeeId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UsersLogIn]    Script Date: 5/25/2021 11:08:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsersLogIn](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](250) NULL,
	[Pwd] [nvarchar](250) NULL,
	[IsActive] [nvarchar](10) NULL,
	[CompanyId] [nvarchar](max) NULL,
	[UserRole] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  View [dbo].[View_EmployessList]    Script Date: 5/25/2021 11:08:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[View_EmployessList]
AS
SELECT        Id, EName + ' ' + ELName + '   ' + CompanyId AS FullENName, ENameAM + ' ' + ELNameAM + '   ' + CompanyId AS ELFullNameEN
FROM            dbo.Employees

GO
SET IDENTITY_INSERT [dbo].[Employees] ON 

INSERT [dbo].[Employees] ([Id], [EName], [ELName], [ENameAM], [ELNameAM], [JobPosition], [JobPositionAM], [isActive], [CompanyId]) VALUES (1, N'Kaleab', N'Getachew', N'ቃለአብ', N'ጌታቸው', N' Network and system manager', NULL, N'1', N'PAG-152')
INSERT [dbo].[Employees] ([Id], [EName], [ELName], [ENameAM], [ELNameAM], [JobPosition], [JobPositionAM], [isActive], [CompanyId]) VALUES (2, N'SystemAdmin', N'SystemAdmin', N'አድሚን', N'አድሚን', N'Admin', N'አድሚን', N'1', N'SystemAdmin')
INSERT [dbo].[Employees] ([Id], [EName], [ELName], [ENameAM], [ELNameAM], [JobPosition], [JobPositionAM], [isActive], [CompanyId]) VALUES (3, N'emp1', N'emp1', N'', NULL, N'Employee', NULL, N'1', N'PAG-Emp1')
INSERT [dbo].[Employees] ([Id], [EName], [ELName], [ENameAM], [ELNameAM], [JobPosition], [JobPositionAM], [isActive], [CompanyId]) VALUES (4, N'Boss1', N'Boss1', NULL, NULL, N'Boss', NULL, N'1', N'PAG-Boss1')
SET IDENTITY_INSERT [dbo].[Employees] OFF
SET IDENTITY_INSERT [dbo].[EvaluatedPoints] ON 

INSERT [dbo].[EvaluatedPoints] ([Id], [EmployeeId], [EvaluatorId], [EvaluationPointName], [EvaluationPeriod], [EvaluationPointGiven], [evaluationDate], [IsSubmitted]) VALUES (239, 1, 1, 12, 1, N'3', CAST(0x0000AD2F01776A40 AS DateTime), 0)
INSERT [dbo].[EvaluatedPoints] ([Id], [EmployeeId], [EvaluatorId], [EvaluationPointName], [EvaluationPeriod], [EvaluationPointGiven], [evaluationDate], [IsSubmitted]) VALUES (240, 1, 1, 13, 1, N'3', CAST(0x0000AD2F017773B3 AS DateTime), 0)
INSERT [dbo].[EvaluatedPoints] ([Id], [EmployeeId], [EvaluatorId], [EvaluationPointName], [EvaluationPeriod], [EvaluationPointGiven], [evaluationDate], [IsSubmitted]) VALUES (241, 1, 1, 14, 1, N'4', CAST(0x0000AD2F017773B5 AS DateTime), 0)
INSERT [dbo].[EvaluatedPoints] ([Id], [EmployeeId], [EvaluatorId], [EvaluationPointName], [EvaluationPeriod], [EvaluationPointGiven], [evaluationDate], [IsSubmitted]) VALUES (242, 1, 1, 15, 1, NULL, CAST(0x0000AD2F017773B6 AS DateTime), 0)
INSERT [dbo].[EvaluatedPoints] ([Id], [EmployeeId], [EvaluatorId], [EvaluationPointName], [EvaluationPeriod], [EvaluationPointGiven], [evaluationDate], [IsSubmitted]) VALUES (243, 1, 1, 16, 1, NULL, CAST(0x0000AD2F017773B8 AS DateTime), 0)
INSERT [dbo].[EvaluatedPoints] ([Id], [EmployeeId], [EvaluatorId], [EvaluationPointName], [EvaluationPeriod], [EvaluationPointGiven], [evaluationDate], [IsSubmitted]) VALUES (244, 1, 1, 17, 1, NULL, CAST(0x0000AD2F017773BA AS DateTime), 0)
INSERT [dbo].[EvaluatedPoints] ([Id], [EmployeeId], [EvaluatorId], [EvaluationPointName], [EvaluationPeriod], [EvaluationPointGiven], [evaluationDate], [IsSubmitted]) VALUES (245, 1, 1, 18, 1, NULL, CAST(0x0000AD2F017773BC AS DateTime), 0)
INSERT [dbo].[EvaluatedPoints] ([Id], [EmployeeId], [EvaluatorId], [EvaluationPointName], [EvaluationPeriod], [EvaluationPointGiven], [evaluationDate], [IsSubmitted]) VALUES (246, 1, 1, 19, 1, NULL, CAST(0x0000AD2F017773BE AS DateTime), 0)
INSERT [dbo].[EvaluatedPoints] ([Id], [EmployeeId], [EvaluatorId], [EvaluationPointName], [EvaluationPeriod], [EvaluationPointGiven], [evaluationDate], [IsSubmitted]) VALUES (247, 1, 1, 20, 1, NULL, CAST(0x0000AD2F017773C0 AS DateTime), 0)
INSERT [dbo].[EvaluatedPoints] ([Id], [EmployeeId], [EvaluatorId], [EvaluationPointName], [EvaluationPeriod], [EvaluationPointGiven], [evaluationDate], [IsSubmitted]) VALUES (248, 1, 1, 21, 1, NULL, CAST(0x0000AD2F017773C2 AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[EvaluatedPoints] OFF
SET IDENTITY_INSERT [dbo].[EvaluationPeriod] ON 

INSERT [dbo].[EvaluationPeriod] ([Id], [EvaluationPeriod], [isClosed]) VALUES (1, N'2021-May', N'0')
SET IDENTITY_INSERT [dbo].[EvaluationPeriod] OFF
SET IDENTITY_INSERT [dbo].[LKDatatypes] ON 

INSERT [dbo].[LKDatatypes] ([Id], [TypeName], [Remarks]) VALUES (1, N'Text Box', NULL)
INSERT [dbo].[LKDatatypes] ([Id], [TypeName], [Remarks]) VALUES (2, N'Text Area', NULL)
INSERT [dbo].[LKDatatypes] ([Id], [TypeName], [Remarks]) VALUES (3, N'Radio Button', NULL)
INSERT [dbo].[LKDatatypes] ([Id], [TypeName], [Remarks]) VALUES (4, N'Check Box', NULL)
INSERT [dbo].[LKDatatypes] ([Id], [TypeName], [Remarks]) VALUES (5, N'DateTime', NULL)
SET IDENTITY_INSERT [dbo].[LKDatatypes] OFF
SET IDENTITY_INSERT [dbo].[LKEvaluationPoints] ON 

INSERT [dbo].[LKEvaluationPoints] ([Id], [EvaluationName], [MaxRate], [MinRate], [Status], [Language], [DataTypes]) VALUES (1, N'Direct Job-Related Performance ', NULL, NULL, NULL, N'EN', 3)
INSERT [dbo].[LKEvaluationPoints] ([Id], [EvaluationName], [MaxRate], [MinRate], [Status], [Language], [DataTypes]) VALUES (2, N'Following my department as well as my specific plan', NULL, NULL, NULL, N'EN', 3)
INSERT [dbo].[LKEvaluationPoints] ([Id], [EvaluationName], [MaxRate], [MinRate], [Status], [Language], [DataTypes]) VALUES (3, N'Respecting administrative rules and regulation', NULL, NULL, NULL, N'EN', 3)
INSERT [dbo].[LKEvaluationPoints] ([Id], [EvaluationName], [MaxRate], [MinRate], [Status], [Language], [DataTypes]) VALUES (4, N'Time Management', NULL, NULL, NULL, N'EN', 3)
INSERT [dbo].[LKEvaluationPoints] ([Id], [EvaluationName], [MaxRate], [MinRate], [Status], [Language], [DataTypes]) VALUES (5, N'Punctuality', NULL, NULL, NULL, N'EN', 3)
INSERT [dbo].[LKEvaluationPoints] ([Id], [EvaluationName], [MaxRate], [MinRate], [Status], [Language], [DataTypes]) VALUES (6, N'Attending monthly staff meeting ', NULL, NULL, NULL, N'EN', 3)
INSERT [dbo].[LKEvaluationPoints] ([Id], [EvaluationName], [MaxRate], [MinRate], [Status], [Language], [DataTypes]) VALUES (7, N'Team work ', NULL, NULL, NULL, N'EN', 3)
INSERT [dbo].[LKEvaluationPoints] ([Id], [EvaluationName], [MaxRate], [MinRate], [Status], [Language], [DataTypes]) VALUES (8, N'Customer Service ', NULL, NULL, NULL, N'EN', 3)
INSERT [dbo].[LKEvaluationPoints] ([Id], [EvaluationName], [MaxRate], [MinRate], [Status], [Language], [DataTypes]) VALUES (9, N'Self -management', NULL, NULL, NULL, N'EN', 3)
INSERT [dbo].[LKEvaluationPoints] ([Id], [EvaluationName], [MaxRate], [MinRate], [Status], [Language], [DataTypes]) VALUES (10, N'Annual leave management', NULL, NULL, NULL, N'EN', 3)
INSERT [dbo].[LKEvaluationPoints] ([Id], [EvaluationName], [MaxRate], [MinRate], [Status], [Language], [DataTypes]) VALUES (11, N'Overall performance during the current situation', NULL, NULL, NULL, N'EN', 3)
INSERT [dbo].[LKEvaluationPoints] ([Id], [EvaluationName], [MaxRate], [MinRate], [Status], [Language], [DataTypes]) VALUES (12, N'ከቀጥታ የስራ ኃላፊነት ጋር የተገናኘ', NULL, NULL, NULL, N'AM', 3)
INSERT [dbo].[LKEvaluationPoints] ([Id], [EvaluationName], [MaxRate], [MinRate], [Status], [Language], [DataTypes]) VALUES (13, N'የራሴን እና የዲፖርትመንት እቅዶቼን  መከታተልን በተመለከተ', NULL, NULL, NULL, N'AM', 3)
INSERT [dbo].[LKEvaluationPoints] ([Id], [EvaluationName], [MaxRate], [MinRate], [Status], [Language], [DataTypes]) VALUES (14, N'አስተዳደራዊ ደንቦችና መመሪያዎችን ማክበር ', NULL, NULL, NULL, N'AM', 3)
INSERT [dbo].[LKEvaluationPoints] ([Id], [EvaluationName], [MaxRate], [MinRate], [Status], [Language], [DataTypes]) VALUES (15, N'የጊዜ አጠቃቀም ', NULL, NULL, NULL, N'AM', 3)
INSERT [dbo].[LKEvaluationPoints] ([Id], [EvaluationName], [MaxRate], [MinRate], [Status], [Language], [DataTypes]) VALUES (16, N'የስራ ሰአት ማክበር ', NULL, NULL, NULL, N'AM', 3)
INSERT [dbo].[LKEvaluationPoints] ([Id], [EvaluationName], [MaxRate], [MinRate], [Status], [Language], [DataTypes]) VALUES (17, N'ወርሃዊ ስብሰባ ላይ መሳተፍ ', NULL, NULL, NULL, N'AM', 3)
INSERT [dbo].[LKEvaluationPoints] ([Id], [EvaluationName], [MaxRate], [MinRate], [Status], [Language], [DataTypes]) VALUES (18, N'የቡድን ስራ ', NULL, NULL, NULL, N'AM', 3)
INSERT [dbo].[LKEvaluationPoints] ([Id], [EvaluationName], [MaxRate], [MinRate], [Status], [Language], [DataTypes]) VALUES (19, N'የደንበኛ አገልግሎት ', NULL, NULL, NULL, N'AM', 3)
INSERT [dbo].[LKEvaluationPoints] ([Id], [EvaluationName], [MaxRate], [MinRate], [Status], [Language], [DataTypes]) VALUES (20, N'እራስን በራስ መምራት ', NULL, NULL, NULL, N'AM', 3)
INSERT [dbo].[LKEvaluationPoints] ([Id], [EvaluationName], [MaxRate], [MinRate], [Status], [Language], [DataTypes]) VALUES (21, N'የአመት ፈቃድ አጠቃቀም', NULL, NULL, NULL, N'AM', 3)
INSERT [dbo].[LKEvaluationPoints] ([Id], [EvaluationName], [MaxRate], [MinRate], [Status], [Language], [DataTypes]) VALUES (22, N'በወቅታዊ ሁኔታ ወቅት አጠቃላይ የስራ አፈፃፀም', NULL, NULL, NULL, N'AM', 3)
INSERT [dbo].[LKEvaluationPoints] ([Id], [EvaluationName], [MaxRate], [MinRate], [Status], [Language], [DataTypes]) VALUES (23, N'AdditionalPerformance', NULL, NULL, NULL, N'EN', 2)
INSERT [dbo].[LKEvaluationPoints] ([Id], [EvaluationName], [MaxRate], [MinRate], [Status], [Language], [DataTypes]) VALUES (24, N'ተጨማሪ', NULL, NULL, NULL, N'AM', 2)
SET IDENTITY_INSERT [dbo].[LKEvaluationPoints] OFF
SET IDENTITY_INSERT [dbo].[LKSixMonthPlan] ON 

INSERT [dbo].[LKSixMonthPlan] ([Id], [PlanName], [DataTypeSelection], [LanguageSelection], [StatusRemark], [PreparedByID]) VALUES (1, N'Direct Job-Related Performance', 3, N'EN', NULL, 2)
INSERT [dbo].[LKSixMonthPlan] ([Id], [PlanName], [DataTypeSelection], [LanguageSelection], [StatusRemark], [PreparedByID]) VALUES (2, N'Following my department as well as my specific plan', 3, N'EN', NULL, 2)
INSERT [dbo].[LKSixMonthPlan] ([Id], [PlanName], [DataTypeSelection], [LanguageSelection], [StatusRemark], [PreparedByID]) VALUES (3, N'Respecting administrative rules and regulation', 3, N'EN', NULL, 2)
INSERT [dbo].[LKSixMonthPlan] ([Id], [PlanName], [DataTypeSelection], [LanguageSelection], [StatusRemark], [PreparedByID]) VALUES (4, N'Time Management ', 3, N'EN', NULL, 2)
INSERT [dbo].[LKSixMonthPlan] ([Id], [PlanName], [DataTypeSelection], [LanguageSelection], [StatusRemark], [PreparedByID]) VALUES (5, N'Punctuality', 3, N'EN', NULL, 2)
INSERT [dbo].[LKSixMonthPlan] ([Id], [PlanName], [DataTypeSelection], [LanguageSelection], [StatusRemark], [PreparedByID]) VALUES (6, N'Attending monthly staff meeting ', 3, N'EN', NULL, 2)
INSERT [dbo].[LKSixMonthPlan] ([Id], [PlanName], [DataTypeSelection], [LanguageSelection], [StatusRemark], [PreparedByID]) VALUES (7, N'Team work ', 3, N'EN', NULL, 2)
INSERT [dbo].[LKSixMonthPlan] ([Id], [PlanName], [DataTypeSelection], [LanguageSelection], [StatusRemark], [PreparedByID]) VALUES (8, N'Customer Service ', 3, N'EN', NULL, 2)
INSERT [dbo].[LKSixMonthPlan] ([Id], [PlanName], [DataTypeSelection], [LanguageSelection], [StatusRemark], [PreparedByID]) VALUES (9, N'Self -management', 3, N'EN', NULL, 2)
INSERT [dbo].[LKSixMonthPlan] ([Id], [PlanName], [DataTypeSelection], [LanguageSelection], [StatusRemark], [PreparedByID]) VALUES (11, N'ከቀጥታ የስራ ኃላፊነት ጋር የተገናኘ', 3, N'AM', NULL, 2)
INSERT [dbo].[LKSixMonthPlan] ([Id], [PlanName], [DataTypeSelection], [LanguageSelection], [StatusRemark], [PreparedByID]) VALUES (12, N'የራሴን እና የዲፖርትመንት እቅዶቼን  መከታተልን በተመለከተ', 3, N'AM', NULL, 2)
INSERT [dbo].[LKSixMonthPlan] ([Id], [PlanName], [DataTypeSelection], [LanguageSelection], [StatusRemark], [PreparedByID]) VALUES (13, N'አስተዳደራዊ ደንቦችና መመሪያዎችን ማክበር', 3, N'AM', NULL, 2)
INSERT [dbo].[LKSixMonthPlan] ([Id], [PlanName], [DataTypeSelection], [LanguageSelection], [StatusRemark], [PreparedByID]) VALUES (14, N'የጊዜ አጠቃቀም', 3, N'AM', NULL, 2)
INSERT [dbo].[LKSixMonthPlan] ([Id], [PlanName], [DataTypeSelection], [LanguageSelection], [StatusRemark], [PreparedByID]) VALUES (16, N'የስራ ሰአት ማክበር', 3, N'AM', NULL, 2)
INSERT [dbo].[LKSixMonthPlan] ([Id], [PlanName], [DataTypeSelection], [LanguageSelection], [StatusRemark], [PreparedByID]) VALUES (17, N'ወርሃዊ ስብሰባ ላይ መሳተፍ', 3, N'AM', NULL, 2)
INSERT [dbo].[LKSixMonthPlan] ([Id], [PlanName], [DataTypeSelection], [LanguageSelection], [StatusRemark], [PreparedByID]) VALUES (18, N'የቡድን ስራ', 3, N'AM', NULL, 2)
INSERT [dbo].[LKSixMonthPlan] ([Id], [PlanName], [DataTypeSelection], [LanguageSelection], [StatusRemark], [PreparedByID]) VALUES (19, N'የደንበኛ አገልግሎት', 3, N'AM', NULL, 2)
INSERT [dbo].[LKSixMonthPlan] ([Id], [PlanName], [DataTypeSelection], [LanguageSelection], [StatusRemark], [PreparedByID]) VALUES (20, N'እራስን በራስ መምራት', 3, N'AM', NULL, 2)
SET IDENTITY_INSERT [dbo].[LKSixMonthPlan] OFF
SET IDENTITY_INSERT [dbo].[LKUsersRoles] ON 

INSERT [dbo].[LKUsersRoles] ([Id], [RoleName], [statusRemark]) VALUES (1, N'DB and System Administrator', NULL)
INSERT [dbo].[LKUsersRoles] ([Id], [RoleName], [statusRemark]) VALUES (2, N'Users Administrator', NULL)
INSERT [dbo].[LKUsersRoles] ([Id], [RoleName], [statusRemark]) VALUES (3, N'Area Managers', NULL)
INSERT [dbo].[LKUsersRoles] ([Id], [RoleName], [statusRemark]) VALUES (4, N'Employess', NULL)
INSERT [dbo].[LKUsersRoles] ([Id], [RoleName], [statusRemark]) VALUES (5, N'CEO', NULL)
SET IDENTITY_INSERT [dbo].[LKUsersRoles] OFF
SET IDENTITY_INSERT [dbo].[UsersLogIn] ON 

INSERT [dbo].[UsersLogIn] ([Id], [UserName], [Pwd], [IsActive], [CompanyId], [UserRole]) VALUES (1, N'kale', N'kale$#@!', N'1', N'PAG-152', 1)
INSERT [dbo].[UsersLogIn] ([Id], [UserName], [Pwd], [IsActive], [CompanyId], [UserRole]) VALUES (2, N'Emp1', N'Emp1', N'1', N'PAG-Emp1', 4)
INSERT [dbo].[UsersLogIn] ([Id], [UserName], [Pwd], [IsActive], [CompanyId], [UserRole]) VALUES (3, N'Boss1', N'Boss1', N'1', N'PAG-Boss1', 3)
SET IDENTITY_INSERT [dbo].[UsersLogIn] OFF
ALTER TABLE [dbo].[EvaluatedPoints] ADD  CONSTRAINT [DF_EvaluatedPoints_IsSubmitted]  DEFAULT ((0)) FOR [IsSubmitted]
GO
ALTER TABLE [dbo].[EvaluatedPoints]  WITH CHECK ADD FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employees] ([Id])
GO
ALTER TABLE [dbo].[EvaluatedPoints]  WITH CHECK ADD FOREIGN KEY([EvaluatorId])
REFERENCES [dbo].[Employees] ([Id])
GO
ALTER TABLE [dbo].[EvaluatedPoints]  WITH CHECK ADD FOREIGN KEY([EvaluationPointName])
REFERENCES [dbo].[LKEvaluationPoints] ([Id])
GO
ALTER TABLE [dbo].[EvaluatedPoints]  WITH CHECK ADD FOREIGN KEY([EvaluationPeriod])
REFERENCES [dbo].[EvaluationPeriod] ([Id])
GO
ALTER TABLE [dbo].[LKEvaluationPoints]  WITH CHECK ADD FOREIGN KEY([DataTypes])
REFERENCES [dbo].[LKDatatypes] ([Id])
GO
ALTER TABLE [dbo].[LKSixMonthPlan]  WITH CHECK ADD FOREIGN KEY([DataTypeSelection])
REFERENCES [dbo].[LKDatatypes] ([Id])
GO
ALTER TABLE [dbo].[LKSixMonthPlan]  WITH CHECK ADD FOREIGN KEY([PreparedByID])
REFERENCES [dbo].[Employees] ([Id])
GO
ALTER TABLE [dbo].[SixMonthPlan]  WITH CHECK ADD FOREIGN KEY([PlanSetByEmployeeId])
REFERENCES [dbo].[Employees] ([Id])
GO
ALTER TABLE [dbo].[SixMonthPlan]  WITH CHECK ADD FOREIGN KEY([EvaluationPeriod])
REFERENCES [dbo].[EvaluationPeriod] ([Id])
GO
ALTER TABLE [dbo].[SixMonthPlan]  WITH CHECK ADD FOREIGN KEY([PlanName])
REFERENCES [dbo].[LKSixMonthPlan] ([Id])
GO
ALTER TABLE [dbo].[SixMonthPlan]  WITH CHECK ADD FOREIGN KEY([PlanSetForEmployeeId])
REFERENCES [dbo].[Employees] ([Id])
GO
ALTER TABLE [dbo].[UsersLogIn]  WITH CHECK ADD FOREIGN KEY([UserRole])
REFERENCES [dbo].[LKUsersRoles] ([Id])
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[41] 4[25] 2[16] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Employees"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 5
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 16
         Width = 284
         Width = 1500
         Width = 3465
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_EmployessList'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_EmployessList'
GO
USE [master]
GO
ALTER DATABASE [PerformaceEvaluation] SET  READ_WRITE 
GO
