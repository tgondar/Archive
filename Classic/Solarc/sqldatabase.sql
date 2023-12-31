
--	use master; drop database db_solarcDevelop

--	create database db_solarcDevelop

USE [db_SolarcDevelop]
GO
/****** Object:  Table [dbo].[tb_ProcessState]    Script Date: 10/01/2011 12:08:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_ProcessState](
	[ProcessStateId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_PA_ProcessStateId] PRIMARY KEY CLUSTERED 
(
	[ProcessStateId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_ProcessPaymentBAK]    Script Date: 10/01/2011 12:08:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_ProcessPaymentBAK](
	[ProcessId] [int] NOT NULL,
	[ExecutedId] [int] NOT NULL,
	[Date] [datetime] NOT NULL,
	[Value] [real] NOT NULL,
	[PaymentTypeId] [int] NULL,
	[Account] [nvarchar](50) NULL,
	[RepresentativeId] [int] NULL,
	[EmployerId] [int] NULL,
 CONSTRAINT [PK_tb_ProcessPayment] PRIMARY KEY CLUSTERED 
(
	[ProcessId] ASC,
	[ExecutedId] ASC,
	[Date] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_Localization]    Script Date: 10/01/2011 12:08:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_Localization](
	[LocalizationId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](300) NULL,
 CONSTRAINT [PK_L_LocalizationId] PRIMARY KEY CLUSTERED 
(
	[LocalizationId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_ExtinctionCode]    Script Date: 10/01/2011 12:08:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_ExtinctionCode](
	[ExtinctionCodeId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_EC_ExtinctionCode] PRIMARY KEY CLUSTERED 
(
	[ExtinctionCodeId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_ExecutionType]    Script Date: 10/01/2011 12:08:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_ExecutionType](
	[ExecutionTypeId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
 CONSTRAINT [Pk_ET_ExecutionTypeId] PRIMARY KEY CLUSTERED 
(
	[ExecutionTypeId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_PaymentType]    Script Date: 10/01/2011 12:08:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_PaymentType](
	[PaymentTypeId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
 CONSTRAINT [Pk_PT_PaymentTypeId] PRIMARY KEY CLUSTERED 
(
	[PaymentTypeId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_PaymentAgreement]    Script Date: 10/01/2011 12:08:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_PaymentAgreement](
	[PaymentAgreementId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_PA_PaymentAgreementId] PRIMARY KEY CLUSTERED 
(
	[PaymentAgreementId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_ProcessExtinction]    Script Date: 10/01/2011 12:08:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_ProcessExtinction](
	[ProcessExtinctionId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_PE_ProcessExtinction] PRIMARY KEY CLUSTERED 
(
	[ProcessExtinctionId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_UserSetting]    Script Date: 10/01/2011 12:08:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tb_UserSetting](
	[UserId] [uniqueidentifier] NOT NULL,
	[Theme] [nvarchar](100) NULL,
	[SearchResult] [int] NULL,
	[LocalizationId] [int] NOT NULL,
 CONSTRAINT [PK_tb_UserSetting] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_UncollectabilityCertificate]    Script Date: 10/01/2011 12:08:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_UncollectabilityCertificate](
	[UncollectabilityCertificateId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_PA_UncollectabilityCertificateId] PRIMARY KEY CLUSTERED 
(
	[UncollectabilityCertificateId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_tempPayment]    Script Date: 10/01/2011 12:08:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_tempPayment](
	[field1] [nvarchar](50) NULL,
	[field2] [nvarchar](50) NULL,
	[field3] [nvarchar](1000) NULL,
	[field4] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_TemporaryPayment]    Script Date: 10/01/2011 12:08:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_TemporaryPayment](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProcessId] [int] NULL,
	[Account] [nvarchar](50) NULL,
	[Date] [datetime] NULL,
	[Description] [nvarchar](1000) NULL,
	[Value] [real] NULL,
	[Active] [int] NULL,
 CONSTRAINT [Pk_TP_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_Solicitor]    Script Date: 10/01/2011 12:08:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_Solicitor](
	[SolicitorId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[CardNumber] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_S_SolicitorId] PRIMARY KEY CLUSTERED 
(
	[SolicitorId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_Section]    Script Date: 10/01/2011 12:08:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_Section](
	[SectionId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_tb_Section] PRIMARY KEY CLUSTERED 
(
	[SectionId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_Search]    Script Date: 10/01/2011 12:08:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_Search](
	[SearchId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[CreateUserId] [uniqueidentifier] NOT NULL,
	[AlterDate] [datetime] NOT NULL,
	[AlterUserId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_tb_Search] PRIMARY KEY CLUSTERED 
(
	[SearchId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_Representative]    Script Date: 10/01/2011 12:08:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_Representative](
	[RepresentativeId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Address] [nvarchar](100) NULL,
	[Phone] [nvarchar](50) NULL,
	[Fax] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Userid] [uniqueidentifier] NULL,
	[CreateDate] [datetime] NOT NULL,
	[CreateUserId] [uniqueidentifier] NOT NULL,
	[AlterDate] [datetime] NOT NULL,
	[AlterUserId] [uniqueidentifier] NOT NULL,
	[Nif] [nvarchar](200) NULL,
	[CarbonCopy] [nvarchar](200) NULL,
	[MPhone] [nvarchar](50) NULL,
	[LawyerNumber] [nvarchar](50) NULL,
 CONSTRAINT [PK_tb_Representative] PRIMARY KEY CLUSTERED 
(
	[RepresentativeId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_Executed]    Script Date: 10/01/2011 12:08:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_Executed](
	[ExecutedId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Address] [nvarchar](100) NULL,
	[Phone] [nvarchar](50) NULL,
	[Fax] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[IdentityCard] [nvarchar](20) NULL,
	[NifNipl] [nvarchar](20) NULL,
	[Nifs] [nvarchar](20) NULL,
	[BornDate] [datetime] NULL,
	[Active] [int] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[CreateUserId] [uniqueidentifier] NOT NULL,
	[AlterDate] [datetime] NOT NULL,
	[AlterUserId] [uniqueidentifier] NOT NULL,
	[MPhone] [nvarchar](50) NULL,
 CONSTRAINT [PK_tb_Executed] PRIMARY KEY CLUSTERED 
(
	[ExecutedId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_Event]    Script Date: 10/01/2011 12:08:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_Event](
	[EventId] [int] IDENTITY(1,1) NOT NULL,
	[Date] [datetime] NULL,
	[Description] [nvarchar](50) NULL,
	[Alert] [int] NULL,
	[CreateDate] [datetime] NULL,
	[CreateUserId] [uniqueidentifier] NULL,
	[AlterDate] [datetime] NULL,
	[AlterUserId] [uniqueidentifier] NULL,
 CONSTRAINT [PK_E_EventId] PRIMARY KEY CLUSTERED 
(
	[EventId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_Employer]    Script Date: 10/01/2011 12:08:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_Employer](
	[EmployerdId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Address] [nvarchar](100) NULL,
	[Phone] [nvarchar](50) NULL,
	[Fax] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[CreateDate] [datetime] NOT NULL,
	[CreateUserId] [uniqueidentifier] NOT NULL,
	[AlterDate] [datetime] NOT NULL,
	[AlterUserId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_tb_Employer] PRIMARY KEY CLUSTERED 
(
	[EmployerdId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_Document]    Script Date: 10/01/2011 12:08:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_Document](
	[DocumentId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NULL,
	[Value] [text] NULL,
	[CreateDate] [datetime] NULL,
	[CreateUserId] [uniqueidentifier] NULL,
	[AlterDate] [datetime] NULL,
	[AlterUSerId] [uniqueidentifier] NULL,
 CONSTRAINT [PK_D_DocumentId] PRIMARY KEY CLUSTERED 
(
	[DocumentId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_Delegate]    Script Date: 10/01/2011 12:08:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_Delegate](
	[DelegateId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NULL,
	[Address] [nvarchar](200) NULL,
	[Phone] [nvarchar](50) NULL,
	[MPhone] [nvarchar](50) NULL,
	[Fax] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[CreateDate] [datetime] NULL,
	[CreateUserId] [uniqueidentifier] NULL,
	[AlterDate] [datetime] NULL,
	[AlterUserId] [uniqueidentifier] NULL,
 CONSTRAINT [PK_D_DelegateId] PRIMARY KEY CLUSTERED 
(
	[DelegateId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_DBInfo]    Script Date: 10/01/2011 12:08:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_DBInfo](
	[DBInfoId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_PA_DBInfoId] PRIMARY KEY CLUSTERED 
(
	[DBInfoId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_Creditor]    Script Date: 10/01/2011 12:08:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_Creditor](
	[CreditorId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Address] [nvarchar](100) NULL,
	[Phone] [nvarchar](50) NULL,
	[Fax] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[IdentityCard] [nvarchar](20) NULL,
	[NifNipl] [nvarchar](20) NULL,
	[Nifs] [nvarchar](20) NULL,
	[BornDate] [datetime] NULL,
	[Active] [int] NOT NULL,
	[CreateDate] [datetime] NULL,
	[CreateUserId] [uniqueidentifier] NULL,
	[AlterDate] [datetime] NULL,
	[AlterUserId] [uniqueidentifier] NULL,
	[MPhone] [nvarchar](50) NULL,
 CONSTRAINT [PK_tb_Creditor] PRIMARY KEY CLUSTERED 
(
	[CreditorId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_Court]    Script Date: 10/01/2011 12:08:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tb_Court](
	[CourtId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Address] [nvarchar](100) NULL,
	[Phone] [nvarchar](50) NULL,
	[Fax] [varchar](15) NULL,
	[Email] [nvarchar](50) NULL,
	[Active] [int] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[CreateUserId] [uniqueidentifier] NOT NULL,
	[AlterDate] [datetime] NOT NULL,
	[AlterUserId] [uniqueidentifier] NOT NULL,
	[JudicialDistrict] [nvarchar](200) NULL,
 CONSTRAINT [PK_tb_Court] PRIMARY KEY CLUSTERED 
(
	[CourtId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tb_Client]    Script Date: 10/01/2011 12:08:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_Client](
	[ClientId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[Address] [nvarchar](200) NULL,
	[Phone] [nvarchar](50) NULL,
	[MPhone] [nvarchar](50) NULL,
	[Fax] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[IdentityCard] [nvarchar](20) NULL,
	[NifNipl] [nvarchar](20) NULL,
	[Nifs] [nvarchar](20) NULL,
	[BornDate] [datetime] NULL,
	[Active] [int] NOT NULL,
	[CreateDate] [datetime] NULL,
	[CreateUserId] [uniqueidentifier] NULL,
	[AlterDate] [datetime] NULL,
	[AlterUserId] [uniqueidentifier] NULL,
 CONSTRAINT [PK_Pc_ClientId] PRIMARY KEY CLUSTERED 
(
	[ClientId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_Attachment]    Script Date: 10/01/2011 12:08:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_Attachment](
	[AttachmentId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[CreateUserId] [uniqueidentifier] NOT NULL,
	[AlterDate] [datetime] NOT NULL,
	[AlterUserID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_tb_Attachment] PRIMARY KEY CLUSTERED 
(
	[AttachmentId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_ArrangementsInPlace]    Script Date: 10/01/2011 12:08:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_ArrangementsInPlace](
	[ArrangementsInPlaceId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_PA_ArrangementsInPlaceId] PRIMARY KEY CLUSTERED 
(
	[ArrangementsInPlaceId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_Process]    Script Date: 10/01/2011 12:08:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_Process](
	[ProcessId] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](50) NOT NULL,
	[Number] [int] NOT NULL,
	[Initials] [nvarchar](50) NOT NULL,
	[Year] [int] NOT NULL,
	[ProcessNumber] [nvarchar](50) NULL,
	[Value] [real] NULL,
	[ExesAE] [real] NULL,
	[Classification] [nvarchar](50) NULL,
	[Observation] [nvarchar](4000) NULL,
	[CourtId] [int] NULL,
	[SectionId] [int] NULL,
	[RepresentativeId] [int] NULL,
	[Enforcement] [nvarchar](50) NULL,
	[CreateDate] [datetime] NOT NULL,
	[CreateUserID] [uniqueidentifier] NOT NULL,
	[AlterDate] [datetime] NOT NULL,
	[AlterUserId] [uniqueidentifier] NOT NULL,
	[AlterDate1] [datetime] NULL,
	[AlterUserId1] [uniqueidentifier] NULL,
	[AlterDate2] [datetime] NULL,
	[AlterUserId2] [uniqueidentifier] NULL,
	[Section] [int] NULL,
	[Localization] [nvarchar](50) NULL,
	[ExecutionTypeId] [int] NULL,
	[LocalizationDetail] [nvarchar](50) NULL,
	[Alt] [nvarchar](10) NULL,
	[LocalizationId] [int] NULL,
	[CreatePCInfo] [nvarchar](400) NULL,
	[AlterPCInfo] [nvarchar](400) NULL,
	[AlterPCInfo1] [nvarchar](400) NULL,
	[AlterPCInfo2] [nvarchar](400) NULL,
	Irs datetime default ('1900-01-01') not null,
 CONSTRAINT [PK_tb_Process] PRIMARY KEY CLUSTERED 
(
	[ProcessId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_ProcessSearch]    Script Date: 10/01/2011 12:08:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_ProcessSearch](
	[SearchId] [int] NOT NULL,
	[ProcessId] [int] NOT NULL,
	[ExecutedId] [int] NOT NULL,
	[Date] [datetime] NOT NULL,
	[Value] [int] NOT NULL,
	[Obs] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_tb_ProcessSearch] PRIMARY KEY CLUSTERED 
(
	[SearchId] ASC,
	[ProcessId] ASC,
	[ExecutedId] ASC,
	[Date] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_ProcessRepresentativeInformation]    Script Date: 10/01/2011 12:08:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_ProcessRepresentativeInformation](
	[ProcessId] [int] NOT NULL,
	[RepresentativeId] [int] NOT NULL,
	[Date] [datetime] NOT NULL,
	[Information] [nvarchar](250) NOT NULL,
	[CreateUser] [nvarchar](50) NULL,
 CONSTRAINT [PK_tb_ProcessRepresentativeInfo] PRIMARY KEY CLUSTERED 
(
	[ProcessId] ASC,
	[RepresentativeId] ASC,
	[Date] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_ProcessPayment]    Script Date: 10/01/2011 12:08:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_ProcessPayment](
	[PaymentYear] [int] NOT NULL,
	[PaymentId] [int] NOT NULL,
	[ProcessId] [int] NOT NULL,
	[ExecutedId] [int] NULL,
	[OutCome] [decimal](10, 2) NOT NULL,
	[InCome] [decimal](10, 2) NOT NULL,
	[Vat] [decimal](10,2) NOT NULL,
	[RetentionValue] [decimal](10,2) NOT NULL,
	[PaymentTypeId] [int] NULL,
	[RepresentativeId] [int] NULL,
	[EmployerId] [int] NULL,
	[Status] [int] NOT NULL,
	[InvoiceNumber] [nvarchar](200) NULL,
	[Observation] [nvarchar](4000) NULL,
	[PaymentDate] [datetime] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[CreateUserId] [uniqueidentifier] NOT NULL,
	[AlterDate] [datetime] NOT NULL,
	[AlterUserId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_PP_PaymentYearPaymentId] PRIMARY KEY CLUSTERED 
(
	[PaymentYear] ASC,
	[PaymentId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_ProcessFile]    Script Date: 10/01/2011 12:08:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_ProcessFile](
	[ProcessId] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[SecureName] [nvarchar](50) NOT NULL,
	[UserPermission] [int] NOT NULL,
	[RepresentativePermission] [int] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[CreateUserId] [uniqueidentifier] NOT NULL,
	[AlterDate] [datetime] NOT NULL,
	[AlterUserId] [uniqueidentifier] NOT NULL,
	[Id] [smallint] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_tb_ProcessFile] PRIMARY KEY CLUSTERED 
(
	[ProcessId] ASC,
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_ProvisionRequest]    Script Date: 10/01/2011 12:08:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_ProvisionRequest](
	[ProcessId] [int] NOT NULL,
	[ProvisionRequest1] [datetime] NULL,
	[ProvisionRequest2] [datetime] NULL,
	[ProvisionRequest3] [datetime] NULL,
	[ProvisionReinforcement1] [datetime] NULL,
	[ProvisionReinforcement2] [datetime] NULL,
	[ProvisionReinforcement3] [datetime] NULL,
 CONSTRAINT [PK_PR_ProcessId] PRIMARY KEY CLUSTERED 
(
	[ProcessId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_Provision]    Script Date: 10/01/2011 12:08:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_Provision](
	[ProcessId] [int] NOT NULL,
	[ExecutedId] [int] NOT NULL,
	[Date] [datetime] NOT NULL,
	[Value] [real] NULL,
	[Payed] [int] NOT NULL,
 CONSTRAINT [PK_tb_Provision_1] PRIMARY KEY CLUSTERED 
(
	[ProcessId] ASC,
	[ExecutedId] ASC,
	[Date] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_ProcessExecuted]    Script Date: 10/01/2011 12:08:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_ProcessExecuted](
	[ExecutedId] [int] NOT NULL,
	[ProcessId] [int] NOT NULL,
 CONSTRAINT [PK_tb_ProcessExecuted] PRIMARY KEY CLUSTERED 
(
	[ExecutedId] ASC,
	[ProcessId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_ProcessEmployer]    Script Date: 10/01/2011 12:08:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_ProcessEmployer](
	[EmployerId] [int] NOT NULL,
	[ExecutedId] [int] NOT NULL,
	[ProcessId] [int] NOT NULL,
 CONSTRAINT [PK_tb_ProcessEmployer] PRIMARY KEY CLUSTERED 
(
	[EmployerId] ASC,
	[ExecutedId] ASC,
	[ProcessId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_ProcessDetail]    Script Date: 10/01/2011 12:08:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_ProcessDetail](
	[ProcessId] [int] NOT NULL,
	[PaymentAgreementId] [int] NULL,
	[ProcessExtinctionId] [int] NULL,
	[ExtinctionCodeId] [int] NULL,
	[ArrangementsInPlaceId] [int] NULL,
	[InAttachmentId] [int] NULL,
	[ProcessStateId] [int] NULL,
	[DBInfoId] [int] NULL,
	[UncollectabilityCertificateId] [int] NULL,
	[Provision] [decimal](10, 2) NULL,
	[ProvisionReceptionDate] [datetime] NULL,
	[PendingInvoicePayment] [decimal](10, 2) NULL,
	[DiligenceLocation] [nvarchar](100) NULL,
	[JudicialPhaseId] [int] NULL,
	[PendingInvoicePaymentDate] [datetime] NULL,
	[CreditorReference] [nvarchar](50) NULL,
	[AcceptDate] [datetime] NULL,
	[DuplicatesReceipt] [datetime] NULL,
	[JudgeObservation] [nvarchar](4000) NULL,
	[Alert] [int] NOT NULL,
 CONSTRAINT [PK_PDet_ProcessId] PRIMARY KEY CLUSTERED 
(
	[ProcessId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_ProcessDelegate]    Script Date: 10/01/2011 12:08:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_ProcessDelegate](
	[ProcessId] [int] NOT NULL,
	[DelegateId] [int] NOT NULL,
	[Observation] [nvarchar](4000) NULL,
 CONSTRAINT [PK_PD_ProcessId] PRIMARY KEY CLUSTERED 
(
	[ProcessId] ASC,
	[DelegateId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_ProcessCreditor]    Script Date: 10/01/2011 12:08:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_ProcessCreditor](
	[CreditorId] [int] NOT NULL,
	[ProcessId] [int] NOT NULL,
 CONSTRAINT [PK_tb_ProcessCreditor] PRIMARY KEY CLUSTERED 
(
	[CreditorId] ASC,
	[ProcessId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_ProcessAttachment]    Script Date: 10/01/2011 12:08:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_ProcessAttachment](
	[AttachmentId] [int] NOT NULL,
	[ExecutedId] [int] NOT NULL,
	[ProcessId] [int] NOT NULL,
	[Value] [int] NOT NULL,
 CONSTRAINT [PK_tb_ProcessAttachment] PRIMARY KEY CLUSTERED 
(
	[AttachmentId] ASC,
	[ExecutedId] ASC,
	[ProcessId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_Payment]    Script Date: 10/01/2011 12:08:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_Payment](
	[ProcessId] [int] IDENTITY(1,1) NOT NULL,
	[Value] [real] NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[CreateUseriId] [uniqueidentifier] NOT NULL,
	[AlterDate] [datetime] NOT NULL,
	[AlterUserId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_tb_Payment] PRIMARY KEY CLUSTERED 
(
	[ProcessId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_ExecutedAddresses]    Script Date: 10/01/2011 12:08:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_ExecutedAddresses](
	[ExecutedId] [int] NOT NULL,
	[ProcessId] [int] NOT NULL,
	[Date] [datetime] NOT NULL,
	[Address] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_tb_ExecutedAddresses] PRIMARY KEY CLUSTERED 
(
	[ExecutedId] ASC,
	[ProcessId] ASC,
	[Date] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Default [DF_tb_Court_active]    Script Date: 10/01/2011 12:08:01 ******/
ALTER TABLE [dbo].[tb_Court] ADD  CONSTRAINT [DF_tb_Court_active]  DEFAULT ((1)) FOR [Active]
GO
/****** Object:  Default [DF_tb_Creditor_Active]    Script Date: 10/01/2011 12:08:01 ******/
ALTER TABLE [dbo].[tb_Creditor] ADD  CONSTRAINT [DF_tb_Creditor_Active]  DEFAULT ((1)) FOR [Active]
GO
/****** Object:  Default [DF_tb_Executed_Active]    Script Date: 10/01/2011 12:08:01 ******/
ALTER TABLE [dbo].[tb_Executed] ADD  CONSTRAINT [DF_tb_Executed_Active]  DEFAULT ((1)) FOR [Active]
GO
/****** Object:  Default [DF_tb_ProcessAttachment_Value]    Script Date: 10/01/2011 12:08:01 ******/
ALTER TABLE [dbo].[tb_ProcessAttachment] ADD  CONSTRAINT [DF_tb_ProcessAttachment_Value]  DEFAULT ((0)) FOR [Value]
GO
/****** Object:  Default [DF__tb_Proces__Alert__24285DB4]    Script Date: 10/01/2011 12:08:01 ******/
ALTER TABLE [dbo].[tb_ProcessDetail] ADD  DEFAULT ((30)) FOR [Alert]
GO
/****** Object:  Default [DF_tb_Provision_Payed]    Script Date: 10/01/2011 12:08:01 ******/
ALTER TABLE [dbo].[tb_Provision] ADD  CONSTRAINT [DF_tb_Provision_Payed]  DEFAULT ((0)) FOR [Payed]
GO
/****** Object:  Default [DF__tb_UserSe__Searc__37A5467C]    Script Date: 10/01/2011 12:08:01 ******/
ALTER TABLE [dbo].[tb_UserSetting] ADD  DEFAULT ((1)) FOR [SearchResult]
GO
/****** Object:  Default [DF__tb_UserSe__Local__251C81ED]    Script Date: 10/01/2011 12:08:01 ******/
ALTER TABLE [dbo].[tb_UserSetting] ADD  DEFAULT ((1)) FOR [LocalizationId]
GO
/****** Object:  ForeignKey [FK__tb_Execut__Execu__3DE82FB7]    Script Date: 10/01/2011 12:08:01 ******/
ALTER TABLE [dbo].[tb_ExecutedAddresses]  WITH CHECK ADD FOREIGN KEY([ExecutedId])
REFERENCES [dbo].[tb_Executed] ([ExecutedId])
GO
/****** Object:  ForeignKey [FK__tb_Execut__Proce__3CF40B7E]    Script Date: 10/01/2011 12:08:01 ******/
ALTER TABLE [dbo].[tb_ExecutedAddresses]  WITH CHECK ADD FOREIGN KEY([ProcessId])
REFERENCES [dbo].[tb_Process] ([ProcessId])
GO
/****** Object:  ForeignKey [FK__tb_Paymen__Proce__50FB042B]    Script Date: 10/01/2011 12:08:01 ******/
ALTER TABLE [dbo].[tb_Payment]  WITH CHECK ADD FOREIGN KEY([ProcessId])
REFERENCES [dbo].[tb_Process] ([ProcessId])
GO
/****** Object:  ForeignKey [FK__tb_Proces__Court__1F63A897]    Script Date: 10/01/2011 12:08:01 ******/
ALTER TABLE [dbo].[tb_Process]  WITH CHECK ADD  CONSTRAINT [FK__tb_Proces__Court__1F63A897] FOREIGN KEY([CourtId])
REFERENCES [dbo].[tb_Court] ([CourtId])
GO
ALTER TABLE [dbo].[tb_Process] CHECK CONSTRAINT [FK__tb_Proces__Court__1F63A897]
GO
/****** Object:  ForeignKey [FK__tb_Proces__Execu__22401542]    Script Date: 10/01/2011 12:08:01 ******/
ALTER TABLE [dbo].[tb_Process]  WITH CHECK ADD  CONSTRAINT [FK__tb_Proces__Execu__22401542] FOREIGN KEY([ExecutionTypeId])
REFERENCES [dbo].[tb_ExecutionType] ([ExecutionTypeId])
GO
ALTER TABLE [dbo].[tb_Process] CHECK CONSTRAINT [FK__tb_Proces__Execu__22401542]
GO
/****** Object:  ForeignKey [FK__tb_Proces__Local__308E3499]    Script Date: 10/01/2011 12:08:01 ******/
ALTER TABLE [dbo].[tb_Process]  WITH CHECK ADD FOREIGN KEY([LocalizationId])
REFERENCES [dbo].[tb_Localization] ([LocalizationId])
GO
/****** Object:  ForeignKey [FK__tb_Proces__Repre__214BF109]    Script Date: 10/01/2011 12:08:01 ******/
ALTER TABLE [dbo].[tb_Process]  WITH CHECK ADD  CONSTRAINT [FK__tb_Proces__Repre__214BF109] FOREIGN KEY([RepresentativeId])
REFERENCES [dbo].[tb_Representative] ([RepresentativeId])
GO
ALTER TABLE [dbo].[tb_Process] CHECK CONSTRAINT [FK__tb_Proces__Repre__214BF109]
GO
/****** Object:  ForeignKey [FK__tb_Proces__Secti__2057CCD0]    Script Date: 10/01/2011 12:08:01 ******/
ALTER TABLE [dbo].[tb_Process]  WITH CHECK ADD  CONSTRAINT [FK__tb_Proces__Secti__2057CCD0] FOREIGN KEY([SectionId])
REFERENCES [dbo].[tb_Section] ([SectionId])
GO
ALTER TABLE [dbo].[tb_Process] CHECK CONSTRAINT [FK__tb_Proces__Secti__2057CCD0]
GO
/****** Object:  ForeignKey [FK__tb_Proces__Attac__3A179ED3]    Script Date: 10/01/2011 12:08:01 ******/
ALTER TABLE [dbo].[tb_ProcessAttachment]  WITH CHECK ADD FOREIGN KEY([AttachmentId])
REFERENCES [dbo].[tb_Attachment] ([AttachmentId])
GO
/****** Object:  ForeignKey [FK__tb_Proces__Attac__3B0BC30C]    Script Date: 10/01/2011 12:08:01 ******/
ALTER TABLE [dbo].[tb_ProcessAttachment]  WITH CHECK ADD FOREIGN KEY([AttachmentId])
REFERENCES [dbo].[tb_Attachment] ([AttachmentId])
GO
/****** Object:  ForeignKey [FK__tb_Proces__Attac__3BFFE745]    Script Date: 10/01/2011 12:08:01 ******/
ALTER TABLE [dbo].[tb_ProcessAttachment]  WITH CHECK ADD FOREIGN KEY([AttachmentId])
REFERENCES [dbo].[tb_Attachment] ([AttachmentId])
GO
/****** Object:  ForeignKey [FK__tb_Proces__Execu__39237A9A]    Script Date: 10/01/2011 12:08:01 ******/
ALTER TABLE [dbo].[tb_ProcessAttachment]  WITH CHECK ADD FOREIGN KEY([ExecutedId])
REFERENCES [dbo].[tb_Executed] ([ExecutedId])
GO
/****** Object:  ForeignKey [FK__tb_Proces__Proce__382F5661]    Script Date: 10/01/2011 12:08:01 ******/
ALTER TABLE [dbo].[tb_ProcessAttachment]  WITH CHECK ADD FOREIGN KEY([ProcessId])
REFERENCES [dbo].[tb_Process] ([ProcessId])
GO
/****** Object:  ForeignKey [FK__tb_Proces__Credi__373B3228]    Script Date: 10/01/2011 12:08:01 ******/
ALTER TABLE [dbo].[tb_ProcessCreditor]  WITH CHECK ADD FOREIGN KEY([CreditorId])
REFERENCES [dbo].[tb_Creditor] ([CreditorId])
GO
/****** Object:  ForeignKey [FK__tb_Proces__Proce__36470DEF]    Script Date: 10/01/2011 12:08:01 ******/
ALTER TABLE [dbo].[tb_ProcessCreditor]  WITH CHECK ADD FOREIGN KEY([ProcessId])
REFERENCES [dbo].[tb_Process] ([ProcessId])
GO
/****** Object:  ForeignKey [FK__tb_Proces__Deleg__3FD07829]    Script Date: 10/01/2011 12:08:01 ******/
ALTER TABLE [dbo].[tb_ProcessDelegate]  WITH CHECK ADD FOREIGN KEY([DelegateId])
REFERENCES [dbo].[tb_Delegate] ([DelegateId])
GO
/****** Object:  ForeignKey [FK__tb_Proces__Proce__3EDC53F0]    Script Date: 10/01/2011 12:08:01 ******/
ALTER TABLE [dbo].[tb_ProcessDelegate]  WITH CHECK ADD FOREIGN KEY([ProcessId])
REFERENCES [dbo].[tb_Process] ([ProcessId])
GO
/****** Object:  ForeignKey [FK__tb_Proces__Arran__4D2A7347]    Script Date: 10/01/2011 12:08:01 ******/
ALTER TABLE [dbo].[tb_ProcessDetail]  WITH CHECK ADD FOREIGN KEY([ArrangementsInPlaceId])
REFERENCES [dbo].[tb_ArrangementsInPlace] ([ArrangementsInPlaceId])
GO
/****** Object:  ForeignKey [FK__tb_Proces__DBInf__43A1090D]    Script Date: 10/01/2011 12:08:01 ******/
ALTER TABLE [dbo].[tb_ProcessDetail]  WITH CHECK ADD FOREIGN KEY([DBInfoId])
REFERENCES [dbo].[tb_DBInfo] ([DBInfoId])
GO
/****** Object:  ForeignKey [FK__tb_Proces__Extin__4C364F0E]    Script Date: 10/01/2011 12:08:01 ******/
ALTER TABLE [dbo].[tb_ProcessDetail]  WITH CHECK ADD FOREIGN KEY([ExtinctionCodeId])
REFERENCES [dbo].[tb_ExtinctionCode] ([ExtinctionCodeId])
GO
/****** Object:  ForeignKey [FK__tb_Proces__Proce__2334397B]    Script Date: 10/01/2011 12:08:01 ******/
ALTER TABLE [dbo].[tb_ProcessDetail]  WITH CHECK ADD  CONSTRAINT [FK__tb_Proces__Proce__2334397B] FOREIGN KEY([ProcessId])
REFERENCES [dbo].[tb_Process] ([ProcessId])
GO
ALTER TABLE [dbo].[tb_ProcessDetail] CHECK CONSTRAINT [FK__tb_Proces__Proce__2334397B]
GO
/****** Object:  ForeignKey [FK__tb_Proces__Proce__42ACE4D4]    Script Date: 10/01/2011 12:08:01 ******/
ALTER TABLE [dbo].[tb_ProcessDetail]  WITH CHECK ADD FOREIGN KEY([ProcessStateId])
REFERENCES [dbo].[tb_ProcessState] ([ProcessStateId])
GO
/****** Object:  ForeignKey [FK__tb_Proces__Proce__4B422AD5]    Script Date: 10/01/2011 12:08:01 ******/
ALTER TABLE [dbo].[tb_ProcessDetail]  WITH CHECK ADD FOREIGN KEY([ProcessExtinctionId])
REFERENCES [dbo].[tb_ProcessExtinction] ([ProcessExtinctionId])
GO
/****** Object:  ForeignKey [FK__tb_Proces__Uncol__477199F1]    Script Date: 10/01/2011 12:08:01 ******/
ALTER TABLE [dbo].[tb_ProcessDetail]  WITH CHECK ADD FOREIGN KEY([UncollectabilityCertificateId])
REFERENCES [dbo].[tb_UncollectabilityCertificate] ([UncollectabilityCertificateId])
GO
/****** Object:  ForeignKey [FK__tb_Proces__Emplo__4865BE2A]    Script Date: 10/01/2011 12:08:01 ******/
ALTER TABLE [dbo].[tb_ProcessEmployer]  WITH CHECK ADD FOREIGN KEY([EmployerId])
REFERENCES [dbo].[tb_Employer] ([EmployerdId])
GO
/****** Object:  ForeignKey [FK__tb_Proces__Execu__4959E263]    Script Date: 10/01/2011 12:08:01 ******/
ALTER TABLE [dbo].[tb_ProcessEmployer]  WITH CHECK ADD FOREIGN KEY([ExecutedId])
REFERENCES [dbo].[tb_Executed] ([ExecutedId])
GO
/****** Object:  ForeignKey [FK__tb_Proces__Proce__4A4E069C]    Script Date: 10/01/2011 12:08:01 ******/
ALTER TABLE [dbo].[tb_ProcessEmployer]  WITH CHECK ADD FOREIGN KEY([ProcessId])
REFERENCES [dbo].[tb_Process] ([ProcessId])
GO
/****** Object:  ForeignKey [FK__tb_Proces__Execu__5006DFF2]    Script Date: 10/01/2011 12:08:01 ******/
ALTER TABLE [dbo].[tb_ProcessExecuted]  WITH CHECK ADD FOREIGN KEY([ExecutedId])
REFERENCES [dbo].[tb_Executed] ([ExecutedId])
GO
/****** Object:  ForeignKey [FK__tb_Proces__Proce__4F12BBB9]    Script Date: 10/01/2011 12:08:01 ******/
ALTER TABLE [dbo].[tb_ProcessExecuted]  WITH CHECK ADD FOREIGN KEY([ProcessId])
REFERENCES [dbo].[tb_Process] ([ProcessId])
GO
/****** Object:  ForeignKey [FK__tb_Proces__Proce__3552E9B6]    Script Date: 10/01/2011 12:08:01 ******/
ALTER TABLE [dbo].[tb_ProcessFile]  WITH CHECK ADD FOREIGN KEY([ProcessId])
REFERENCES [dbo].[tb_Process] ([ProcessId])
GO
/****** Object:  ForeignKey [FK_PP_EmployerId]    Script Date: 10/01/2011 12:08:01 ******/
ALTER TABLE [dbo].[tb_ProcessPayment]  WITH CHECK ADD  CONSTRAINT [FK_PP_EmployerId] FOREIGN KEY([EmployerId])
REFERENCES [dbo].[tb_Employer] ([EmployerdId])
GO
ALTER TABLE [dbo].[tb_ProcessPayment] CHECK CONSTRAINT [FK_PP_EmployerId]
GO
/****** Object:  ForeignKey [FK_PP_ExecutedId]    Script Date: 10/01/2011 12:08:01 ******/
ALTER TABLE [dbo].[tb_ProcessPayment]  WITH CHECK ADD  CONSTRAINT [FK_PP_ExecutedId] FOREIGN KEY([ExecutedId])
REFERENCES [dbo].[tb_Executed] ([ExecutedId])
GO
ALTER TABLE [dbo].[tb_ProcessPayment] CHECK CONSTRAINT [FK_PP_ExecutedId]
GO
/****** Object:  ForeignKey [FK_PP_PaymentTypeId]    Script Date: 10/01/2011 12:08:01 ******/
ALTER TABLE [dbo].[tb_ProcessPayment]  WITH CHECK ADD  CONSTRAINT [FK_PP_PaymentTypeId] FOREIGN KEY([PaymentTypeId])
REFERENCES [dbo].[tb_PaymentType] ([PaymentTypeId])
GO
ALTER TABLE [dbo].[tb_ProcessPayment] CHECK CONSTRAINT [FK_PP_PaymentTypeId]
GO
/****** Object:  ForeignKey [FK_PP_ProcessId]    Script Date: 10/01/2011 12:08:01 ******/
ALTER TABLE [dbo].[tb_ProcessPayment]  WITH CHECK ADD  CONSTRAINT [FK_PP_ProcessId] FOREIGN KEY([ProcessId])
REFERENCES [dbo].[tb_Process] ([ProcessId])
GO
ALTER TABLE [dbo].[tb_ProcessPayment] CHECK CONSTRAINT [FK_PP_ProcessId]
GO
/****** Object:  ForeignKey [FK_PP_RepresentativeId]    Script Date: 10/01/2011 12:08:01 ******/
ALTER TABLE [dbo].[tb_ProcessPayment]  WITH CHECK ADD  CONSTRAINT [FK_PP_RepresentativeId] FOREIGN KEY([RepresentativeId])
REFERENCES [dbo].[tb_Representative] ([RepresentativeId])
GO
ALTER TABLE [dbo].[tb_ProcessPayment] CHECK CONSTRAINT [FK_PP_RepresentativeId]
GO
/****** Object:  ForeignKey [FK__tb_Proces__Proce__51EF2864]    Script Date: 10/01/2011 12:08:01 ******/
ALTER TABLE [dbo].[tb_ProcessRepresentativeInformation]  WITH CHECK ADD FOREIGN KEY([ProcessId])
REFERENCES [dbo].[tb_Process] ([ProcessId])
GO
/****** Object:  ForeignKey [FK__tb_Proces__Repre__52E34C9D]    Script Date: 10/01/2011 12:08:01 ******/
ALTER TABLE [dbo].[tb_ProcessRepresentativeInformation]  WITH CHECK ADD FOREIGN KEY([RepresentativeId])
REFERENCES [dbo].[tb_Representative] ([RepresentativeId])
GO
/****** Object:  ForeignKey [FK__tb_Proces__Execu__4589517F]    Script Date: 10/01/2011 12:08:01 ******/
ALTER TABLE [dbo].[tb_ProcessSearch]  WITH CHECK ADD FOREIGN KEY([ExecutedId])
REFERENCES [dbo].[tb_Executed] ([ExecutedId])
GO
/****** Object:  ForeignKey [FK__tb_Proces__Proce__44952D46]    Script Date: 10/01/2011 12:08:01 ******/
ALTER TABLE [dbo].[tb_ProcessSearch]  WITH CHECK ADD FOREIGN KEY([ProcessId])
REFERENCES [dbo].[tb_Process] ([ProcessId])
GO
/****** Object:  ForeignKey [FK__tb_Proces__Searc__467D75B8]    Script Date: 10/01/2011 12:08:01 ******/
ALTER TABLE [dbo].[tb_ProcessSearch]  WITH CHECK ADD FOREIGN KEY([SearchId])
REFERENCES [dbo].[tb_Search] ([SearchId])
GO
/****** Object:  ForeignKey [FK__tb_Provis__Execu__41B8C09B]    Script Date: 10/01/2011 12:08:01 ******/
ALTER TABLE [dbo].[tb_Provision]  WITH CHECK ADD FOREIGN KEY([ExecutedId])
REFERENCES [dbo].[tb_Executed] ([ExecutedId])
GO
/****** Object:  ForeignKey [FK__tb_Provis__Proce__40C49C62]    Script Date: 10/01/2011 12:08:01 ******/
ALTER TABLE [dbo].[tb_Provision]  WITH CHECK ADD FOREIGN KEY([ProcessId])
REFERENCES [dbo].[tb_Process] ([ProcessId])
GO
/****** Object:  ForeignKey [FK__tb_Provis__Proce__4E1E9780]    Script Date: 10/01/2011 12:08:01 ******/
ALTER TABLE [dbo].[tb_ProvisionRequest]  WITH CHECK ADD FOREIGN KEY([ProcessId])
REFERENCES [dbo].[tb_Process] ([ProcessId])
GO


create table tb_Entity
(
	EntityId int not null identity(1,1),
	Code nvarchar(50),
	Name nvarchar(2000),
	IdentityCard nvarchar(50),
	HPhone nvarchar(50),
	MPhone nvarchar(50),
	ContactName nvarchar(1000),
	Fax nvarchar(50),
	Email nvarchar(200),
	Active bit default(1) not null,
	TaxNumber nvarchar(20),
	EAddress nvarchar(200),
	PostalCode nvarchar(50),
	Observation nvarchar(4000),
	CreateDate datetime not null,
	CreateUser nvarchar(50) not null,
	AlterDate datetime not null,
	AlterUser nvarchar(50) not null,
	constraint PK_EntityId primary key (EntityId)
)

go

--	drop table tb_ProcessG
Create table tb_ProcessG
(
	ProcessGId int not null identity,
	Code nvarchar(50) not null,
	EntityId int not null,
	Closed bit default(0) not null,
	Reference nvarchar(50),
	Observation nvarchar(2000),
	Localization nvarchar(200),
	CreateDate datetime not null,
	CreateUser nvarchar(50) not null,
	AlterDate datetime not null,
	AlterUser nvarchar(50) not null,
	DateAlert datetime not null
	constraint pk_ProcessGId primary key (ProcessGId),
	constraint fk_eid foreign key (EntityId) references tb_Entity(EntityId)
)

go

create table tb_ProcessGPayment
(
	ProcessGId int not null,
	PaymentId int not null,
	Designation nvarchar(100) not null,
	Value decimal(10,2) not null,
	Income bit not null,
	PayDate datetime not null,
	CreateDate datetime not null,
	CreateUser nvarchar(50) not null,
	AlterDate datetime not null,
	AlterUser nvarchar(50) not null,
	constraint pk_pgp_pids primary key (ProcessGId,PaymentId),
	constraint fk_pgp_processg foreign key (ProcessGId) references tb_ProcessG(ProcessGId)
)
select * from tb_ProcessGPayment

























































































































/* ################################################################################################################################################################### */
/* ################################################################################################################################################################### */
/* ################################################################################################################################################################### */
/* ################################################################################################################################################################### */
/* ################################################################################################################################################################### */
/* ################################################################################################################################################################### */
/* ################################################################################################################################################################### */
/* ################################################################################################################################################################### */
/* ################################################################################################################################################################### */
/* ################################################################################################################################################################### */
/* ################################################################################################################################################################### */
/* ################################################################################################################################################################### */
/* ################################################################################################################################################################### */
/* ################################################################################################################################################################### */
/* ################################################################################################################################################################### */
/* ################################################################################################################################################################### */
/* ################################################################################################################################################################### */
/* ################################################################################################################################################################### */
/* ################################################################################################################################################################### */
/* ################################################################################################################################################################### */
/* ################################################################################################################################################################### */

/* PROCEDURES */ 


GO
/****** Object:  StoredProcedure [dbo].[uspAutoComplete]    Script Date: 12/30/2011 01:47:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[uspAutoComplete]
@table varchar(50),
@value varchar(20),
@aux int
as
begin
	if @aux=0
		exec ('select name from '+@table+' where name like ''%'+@value+'%'' order by name')
end
GO
/****** Object:  StoredProcedure [dbo].[uspBackup]    Script Date: 12/30/2011 01:47:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[uspBackup]
@DataBaseName nvarchar(100),
@Path nvarchar(200)
as
begin
	DECLARE @BackupFile varchar(255), @DB varchar(30), @Description varchar(255), @LogFile varchar(50)
	DECLARE @Name varchar(30), @MediaName varchar(30), @BackupDirectory nvarchar(200) 
	select @DB=@DataBaseName
	SET @BackupDirectory = @Path
	SET @Name = @DB
	SET @MediaName = @DB + '_Dump' + CONVERT(varchar, CURRENT_TIMESTAMP , 112)
	SET @BackupFile = @BackupDirectory + @DB + '_' + CONVERT(varchar, CURRENT_TIMESTAMP , 112) + '.bak'
	SET @Description = 'Full' + ' BACKUP at ' + CONVERT(varchar, CURRENT_TIMESTAMP) + '.' 
	BACKUP DATABASE @DB TO DISK = @BackupFile
	WITH NAME = @Name, DESCRIPTION = @Description , 
	MEDIANAME = @MediaName, MEDIADESCRIPTION = @Description , STATS = 10
end
GO
/****** Object:  StoredProcedure [dbo].[uspMntSearch]    Script Date: 12/30/2011 01:47:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[uspMntSearch]
@Table nvarchar(50),
@Init int,
@End int,
@AllFields int
as
begin
	declare @sql nvarchar(4000)
	select @sql='select FieldId,Name,Id from('
	select @sql=@sql+' select '+@Table+'Id as ''FieldId'',Name,row_number() over(order by Name) as ''Id''  from tb_'+@Table
	select @sql=@sql+')as t'
	if @AllFields=0
		select @sql=@sql+' where Id between '+CAST(@Init as nvarchar(10))+' and '+CAST(@End as nvarchar(10))
	
	exec(@sql)
end
GO

/****** Object:  StoredProcedure [dbo].[uspProcessInsert]    Script Date: 12/30/2011 01:47:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[uspProcessInsert]
@code varchar(5),
@number int,
@year int,
@initials varchar(5),
@processNumber varchar(50),
@userID varchar(50)
as
begin
	declare @val int;
	select @val=0
	
	select @val=ProcessId from tb_Process where Code=@code and Number=@number and Year=@year and Initials=@initials
	if @val=0
	begin
		insert into tb_Process (Code,Number,Year,Initials,ProcessNumber,CreateDate,CreateUserID,AlterDate,AlterUserId) 
			values (@code,@number,@year,@initials,@processNumber,GETDATE(),@userID,GETDATE(),@userID)
		
		select @val=ProcessId 
			from tb_Process 
			where Code=@code and Number=@number and Year=@year and Initials=@initials
	end
	select @val
end
GO
/****** Object:  StoredProcedure [dbo].[uspSearchCount]    Script Date: 12/30/2011 01:47:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[uspSearchCount]
@InternalNumber nvarchar(50),
@ProcessNumber nvarchar(50),
@Court nvarchar(100),
@Creditor nvarchar(100),
@Representative nvarchar(100),
@Executed nvarchar(100),
@NDays int,
@LocalizationDetail nvarchar(50),
@UserName nvarchar(200),
@LocalizationId int,
@Date1 nvarchar(10),
@Date2 nvarchar(10),

@Provision decimal(10,2),
@PendingInvoicePayment decimal(10,2),

@Start int,
@End int

as
begin

	declare @strsql nvarchar(2000)
	select @strsql=''

	select @strsql=@strsql+'select count(*) from('
	select @strsql=@strsql+'select ProcessId,InternalNumber,Court,Representative,ProcessNumber,Number,year,Enforcement from ('
	select @strsql=@strsql+'	select * from vwProcess WHERE ProcessId > 0'

	if LEN(@InternalNumber)>0
		select @strsql=@strsql+' and InternalNumber like ''%'+@InternalNumber+'%'''
	if LEN(@ProcessNumber)>0
		select @strsql=@strsql+' and ProcessNumber like ''%'+@ProcessNumber+'%'''
	if LEN(@Court)>0
		select @strsql=@strsql+' and Court like ''%'+@Court+'%'''
	if LEN(@Creditor)>0
		select @strsql=@strsql+' and Creditor like ''%'+@Creditor+'%'''
	if LEN(@Representative)>0
		select @strsql=@strsql+' and Representative like ''%'+@Representative+'%'''
	if LEN(@Executed)>0
		select @strsql=@strsql+' and Executed like ''%'+@Executed+'%'''
	if @NDays>0
		select @strsql=@strsql+' and AlterDate<getdate()-'+CAST(@NDays as nvarchar(10))
	if @LocalizationId>0
		select @strsql=@strsql+' and LocalizationId='+CAST(@LocalizationId as nvarchar(10))
	if LEN(@LocalizationDetail)>0
		select @strsql=@strsql+' and LocalizationDetail like ''%'+@LocalizationDetail+'%'''
	if LEN(@UserName)>0
		select @strsql=@strsql+' and UserName = '''+@UserName+''''
	if LEN(@Date1)>0 and Len(@Date2)>0
		select @strsql=@strsql+' and AlterDate between '''+@Date1+''' and '''+@Date2+''''

	if @Provision>0
		select @strsql=@strsql+' and Provision='+CAST(@Provision as nvarchar(10))
	if @PendingInvoicePayment>0
		select @strsql=@strsql+' and PendingInvoicePayment='+CAST(@PendingInvoicePayment as nvarchar(10))

	select @strsql=@strsql+' ) as tab'
	select @strsql=@strsql+' group by ProcessId,InternalNumber,Court,Representative,ProcessNumber,Number,year,Enforcement'
	select @strsql=@strsql+' ) as tab2'


	exec(@strsql)
	--print(@strsql)
end
GO






/****** Object:  StoredProcedure [dbo].[uspSearchRepresentative]    Script Date: 12/30/2011 01:47:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[uspSearchRepresentative]
@InternalNumber nvarchar(50),
@ProcessNumber nvarchar(50),
@Creditor nvarchar(100),
@Executed nvarchar(100),
@UserId nvarchar(50),
@Start int,
@End int
as
begin
	declare @strsql nvarchar(2000)
	select @strsql=''
	
	select @End=@End+1
	select @strsql=@strsql+'select * from ( select'
	select @strsql=@strsql+' InternalNumber,ProcessNumber,replace(dbo.udfCreditor(ProcessId),'', '','',<br/>'')as ''Creditor'',replace(dbo.udfExecuted(ProcessId),'', '','',<br/>'') as ''Executed'''
	select @strsql=@strsql+',dbo.udfRepresentativeInformation(ProcessId)as ''Obs'',dbo.udfRepresentativeFile('''+@UserId+''',ProcessId) as ''Files'''
	select @strsql=@strsql+' ,row_number() over(order by alterdate desc) as ''Id'' from ('
	select @strsql=@strsql+'	select ProcessId,InternalNumber,ProcessNumber,Number,year,Enforcement,alterdate from vwProcess WHERE RepresentativeUserId='''+@UserId+''''
	if LEN(@InternalNumber)>0
		select @strsql=@strsql+' and InternalNumber like ''%'+@InternalNumber+'%'''
	if LEN(@ProcessNumber)>0
		select @strsql=@strsql+' and ProcessNumber like ''%'+@ProcessNumber+'%'''
	if LEN(@Creditor)>0
		select @strsql=@strsql+' and Creditor like ''%'+@Creditor+'%'''
	if LEN(@Executed)>0
		select @strsql=@strsql+' and Executed like ''%'+@Executed+'%'''
	select @strsql=@strsql+' ) as tab'
	select @strsql=@strsql+' group by ProcessId,InternalNumber,ProcessNumber,Number,year,Enforcement,alterdate '
	select @strsql=@strsql+' ) as tab2'
	select @strsql=@strsql+' where Id between '+CAST(@Start as nvarchar(10))+' and '+CAST(@End as nvarchar(10))
	exec(@strsql)
end
GO
/****** Object:  StoredProcedure [dbo].[uspChartUserUpdate]    Script Date: 12/30/2011 01:47:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[uspChartUserUpdate]
as
begin
	select u.UserName,count(*)t
	from aspnet_UsersInRoles uir
		left join aspnet_Roles r on uir.RoleId=r.RoleId
		left join aspnet_Users u on uir.UserId=u.UserId
		left join tb_Process p on (u.UserId=p.AlterUserId or u.UserId=p.AlterUserId1 or u.UserId=p.AlterUserId2)
	where r.RoleName<>'Representative'
	group by uir.UserId,u.UserName
	order by t desc
end
GO
/****** Object:  StoredProcedure [dbo].[uspProcessAttachment]    Script Date: 12/30/2011 01:47:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[uspProcessAttachment]
@Attachment nvarchar(100),
@ExecutedId int,
@ProcessId int
as 
begin
	SET NOCOUNT ON;
	
	begin try
		declare @aux int
		select @aux=0
		select @aux=AttachmentId from tb_Attachment where Name=@Attachment
		if @aux>0
		begin
			insert into tb_ProcessAttachment values (@aux,@ExecutedId,@processId,0)
		end
	end try
	begin catch
	end catch
end
GO
/****** Object:  StoredProcedure [dbo].[uspAttachment]    Script Date: 12/30/2011 01:47:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[uspAttachment]
@Name nvarchar(100),
@UserId uniqueidentifier
as 
begin
	SET NOCOUNT ON;
	
	declare @aux int
	select @aux=0
	select @aux=AttachmentId from tb_Attachment where Name=@name
	if @aux=0
		insert into tb_Attachment values (@Name,GETDATE(),@UserId,GETDATE(),@UserId)
end
GO
/****** Object:  StoredProcedure [dbo].[uspProcessCourt]    Script Date: 12/30/2011 01:47:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[uspProcessCourt]
@Name nvarchar(100),
@ProcessId int
as 
begin
	SET NOCOUNT ON;
	
	declare @aux int
	select @aux=0
	select @aux=CourtId from tb_Court where Name=@name
	if @aux>0
		update tb_Process set CourtId=@aux where ProcessId=@processId
end
GO
/****** Object:  StoredProcedure [dbo].[uspCourtUpdate]    Script Date: 12/30/2011 01:47:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspCourtUpdate]
@name nvarchar(100),
@address nvarchar(100),
@phone nvarchar(15),
@fax nvarchar(15),
@email nvarchar(50),
@JudicialDistrict nvarchar(200),
@userid uniqueidentifier,
@CourtId int
AS
BEGIN
	SET NOCOUNT ON;
	declare @aux int
	select @aux=0
	if @CourtId>0
		update tb_Court set Name=@name,Address=@address,Phone=@phone,Fax=@fax,Email=@email,JudicialDistrict=@JudicialDistrict,AlterDate=GETDATE(),AlterUserId=@userid
		where CourtId=@CourtId
	else
	begin
		select @aux=CourtId from tb_Court where Name=@name and active=1
		if @aux>0
			update tb_Court set Address=@address,Phone=@phone,Fax=@fax,Email=@email,AlterDate=GETDATE(),AlterUserId=@userid
			where Name=@name
		else
			insert into tb_Court (Name,Address,Phone,Fax,Email,JudicialDistrict,Active,CreateDate,CreateUserId,AlterDate,AlterUserId)
			values (@name,@address,@phone,@fax,@email,@JudicialDistrict,1,GETDATE(),@userid,GETDATE(),@userid)
	end
END
GO
/****** Object:  StoredProcedure [dbo].[uspProcessInfo]    Script Date: 12/30/2011 01:47:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[uspProcessInfo]
@ProcessId int
as
begin
	select (tp.Code+'/'+cast(tp.Number as varchar(5))+'/'+cast(tp.Year as varchar(5))+'/'+tp.Initials)as internalNumber,
		tp.ProcessNumber,tp.Observation,
		isnull(tp.ExesAE,'0') as ExesAE,
		isnull(tp.Value,'0') as Value,
		(tc.Name+' - '+tc.Section)courtName,tc.Address,tc.Phone,tc.Fax,tc.Email
	from tb_Process tp
		left join tb_ProcessCourt tpc on tp.ProcessId=tpc.ProcessId
		left join tb_Court tc on tpc.CourtId=tc.CourtId
		left join tb_ProcessRepresentative tpr on tp.ProcessId=tpr.ProcessId
		left join tb_Representative tr on tpr.RepresentativeId=tr.RepresentativeId
	where tp.ProcessId=@ProcessId
	select tp.Date,te.Name,tp.Value,(case when tp.Payed=0 then 'Não' else 'Sim' end)as payed
	from tb_Provision tp
		left join tb_Executed te on tp.ExecutedId=te.ExecutedId
	where tp.ProcessId=@ProcessId
	select tc.Name,tc.Address,tc.Phone,tc.Fax,tc.Email
	from tb_Creditor tc
		left join tb_ProcessCreditor tpc on tc.CreditorId=tpc.CreditorId
	where tpc.ProcessId=@ProcessId
	select te.Name,te.Address,te.Phone,te.Fax,te.Email
	from tb_Executed te
		left join tb_ProcessExecuted tpe on te.ExecutedId=tpe.ExecutedId
	where tpe.ProcessId=@ProcessId
end
GO
/****** Object:  StoredProcedure [dbo].[uspCreditorUpdate]    Script Date: 12/30/2011 01:47:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspCreditorUpdate]
@name nvarchar(100),
@address nvarchar(100),
@phone nvarchar(15),
@Mphone nvarchar(15),
@fax nvarchar(15),
@email nvarchar(50),
@userid uniqueidentifier,
@IdentityCard nvarchar(20),
@NifNipl nvarchar(20),
@Nifs nvarchar(20),
@BornDate datetime,
@CreditorId int
AS
BEGIN
	SET NOCOUNT ON;
	if @BornDate='01-01-1900' or @BornDate='01/01/1900'
		select @BornDate=null
	if @CreditorId>0
		update tb_Creditor set Name=@name,Address=@address,Phone=@phone,MPhone=@Mphone,Fax=@fax,Email=@email,
			CreateDate=GETDATE(),CreateUserId=@userid,AlterDate=GETDATE(),AlterUserId=@userid,
			IdentityCard=@IdentityCard,NifNipl=@NifNipl,Nifs=@Nifs,BornDate=@BornDate
		where CreditorId=@CreditorId
	else
	begin
		declare @aux int
		select @aux=0
		select @aux=CreditorId from tb_Creditor where Name=@name
		if @aux>0
			update tb_Creditor set Address=@address,Phone=@phone,MPhone=@Mphone,Fax=@fax,Email=@email,
				CreateDate=GETDATE(),CreateUserId=@userid,AlterDate=GETDATE(),AlterUserId=@userid,
				IdentityCard=@IdentityCard,NifNipl=@NifNipl,Nifs=@Nifs,BornDate=@BornDate
			where Name=@name
		else
			insert into tb_Creditor (Name,Address,Phone,MPhone,Fax,Email,IdentityCard,NifNipl,Nifs,BornDate,Active,CreateDate,CreateUserId,AlterDate,AlterUserId) 
			values (@name,@address,@phone,@MPhone,@fax,@email,@IdentityCard,@NifNipl,@Nifs,@BornDate,1,GETDATE(),@userid,GETDATE(),@userid)
	end
END
GO
/****** Object:  StoredProcedure [dbo].[uspProcessCreditor]    Script Date: 12/30/2011 01:47:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[uspProcessCreditor]
@Name nvarchar(100),
@ProcessId int
as 
begin
	SET NOCOUNT ON;
	
	declare @aux int
	select @aux=0
	select @aux=CreditorId from tb_Creditor where Name=@name
	if @aux>0
	begin
		delete from tb_ProcessCreditor where ProcessId=@processId and CreditorId=@aux
		insert into tb_ProcessCreditor values (@aux,@processId)
	end
end
GO
/****** Object:  StoredProcedure [dbo].[uspDelegateUpdate]    Script Date: 12/30/2011 01:47:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[uspDelegateUpdate]
@name nvarchar(200),
@address nvarchar(200),
@phone nvarchar(50),
@mphone nvarchar(50),
@fax nvarchar(50),
@email nvarchar(50),
@userid uniqueidentifier,
@DelegateId int
AS
BEGIN
	SET NOCOUNT ON;
	if @DelegateId>0
		update tb_Delegate set Name=@name,Address=@address,Phone=@phone,Fax=@fax,Email=@email,AlterDate=GETDATE(),AlterUserId=@userid
		where DelegateId=@DelegateId
	else
		insert into tb_Delegate (Name,Address,Phone,MPhone,Fax,Email,CreateDate,CreateUserId,AlterDate,AlterUserId)
		values (@name,@address,@phone,@mphone,@fax,@email,GETDATE(),@userid,GETDATE(),@userid)
END
GO
/****** Object:  StoredProcedure [dbo].[uspGetDelegateFromProcess]    Script Date: 12/30/2011 01:47:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[uspGetDelegateFromProcess]
@ProcessId int
as
begin
	select d.DelegateId,d.Name,pd.Observation
	from tb_Delegate d left join tb_ProcessDelegate pd on d.DelegateId=pd.DelegateId
	where pd.ProcessId=@ProcessId
end
GO
/****** Object:  StoredProcedure [dbo].[uspNewDocument]    Script Date: 12/30/2011 01:47:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[uspNewDocument]
@DocumentId int,
@Name nvarchar(200),
@Value text,
@UserId uniqueidentifier
as
begin
	if @DocumentId>0
		update tb_Document set Value=@Value,Name=@Name,AlterDate=GETDATE(),AlterUserId=@UserId where DocumentId=@DocumentId
	else
		insert into tb_Document(Name,Value,CreateDate,CreateUserId,AlterDate,AlterUSerId)
		values (@Name,@Value,GETDATE(),@UserId,GETDATE(),@UserId)
end
GO
/****** Object:  StoredProcedure [dbo].[uspEmployerUpdate]    Script Date: 12/30/2011 01:47:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[uspEmployerUpdate]
@name nvarchar(100),
@address nvarchar(100),
@phone nvarchar(15),
@fax nvarchar(15),
@email nvarchar(50),
@userid uniqueidentifier
AS
BEGIN
	SET NOCOUNT ON;
	
	declare @aux int
	select @aux=0
	
	select @aux=EmployerdId from tb_Employer where Name=@name
	if @aux>0
		update tb_Employer set Address=@address,Phone=@phone,Fax=@fax,Email=@email,CreateDate=GETDATE(),CreateUserId=@userid,AlterDate=GETDATE(),AlterUserId=@userid
			where Name=@name
	else
		insert into tb_Employer values (@name,@address,@phone,@fax,@email,GETDATE(),@userid,GETDATE(),@userid)
	
END
GO
/****** Object:  StoredProcedure [dbo].[uspProcessEmployer]    Script Date: 12/30/2011 01:47:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[uspProcessEmployer]
@Name nvarchar(100),
@ExecutedId int,
@ProcessId int
as 
begin
	SET NOCOUNT ON;
	
	declare @aux int
	select @aux=0
	select @aux=EmployerdId from tb_Employer where Name=@name
	if @aux>0
	begin
		delete from tb_ProcessEmployer where ProcessId=@processId and ExecutedId=@ExecutedId
		insert into tb_ProcessEmployer (EmployerId,ExecutedId,ProcessId) values (@aux,@ExecutedId,@processId)
	end
end
GO
/*
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[uspProcessProvisionNEW]
@ProcessId int,
@OnlyProvision int
as
begin
	declare @temp table (id int identity(1,1),Executed nvarchar(100),[Date] datetime,Value real,PaymentName nvarchar(100),Total real,ExecutedId int)
	if @OnlyProvision=1
		insert into @temp (Executed,Date,Value,PaymentName,ExecutedId)
		select (case when len(em.Name)>0 then em.Name when len(r.Name)>0 then r.Name else '' end) as Name,pp.[Date],pp.Value,pt.name,pp.ExecutedId
		from tb_ProcessPayment pp
			left join tb_paymenttype pt on pp.PaymentTypeId=pt.paymenttypeid
			left join tb_Employer em on pp.EmployerId=em.EmployerdId
			left join tb_Representative r on pp.RepresentativeId=r.RepresentativeId
		where pp.ProcessId=@ProcessId and pp.PaymentTypeId=1
		order by pp.Date
	else
		insert into @temp (Executed,Date,Value,PaymentName,ExecutedId)
		select (case when len(em.Name)>0 then em.Name when len(r.Name)>0 then r.Name else '' end)+(case when pp.PaymentTypeId>1 then ' - '+e.Name else '' end) as Name
			,pp.Date,pp.Value,pt.name,pp.ExecutedId
		from tb_ProcessPayment pp
			left join tb_executed e on pp.ExecutedId=e.ExecutedId
			left join tb_paymenttype pt on pp.PaymentTypeId=pt.paymenttypeid
			left join tb_Employer em on pp.EmployerId=em.EmployerdId
			left join tb_Representative r on pp.RepresentativeId=r.RepresentativeId
		where pp.ProcessId=@ProcessId and pp.PaymentTypeId<>1
		order by pp.Date
	declare @start int, @end int,@total real,@tempTotal real
	select @start=1,@end=COUNT(*) from @temp
	if @end>0
	begin
		select @total=0,@tempTotal=0
		while @start<=@end
		begin
			select @total=Value from @temp where id=@start
			select @tempTotal=@tempTotal+@total
			update @temp set Total=@tempTotal where id=@start
			select @start=@start+1
		end
		select Executed,convert(varchar(30),Date,105) as 'DatePay' ,replace(CONVERT(varchar, CONVERT(money, Value), 1),'.',',') + ' €' as 'Value',PaymentName
			,replace(CONVERT(varchar, CONVERT(money, Total), 1),'.',',') + ' €' as 'Total'
			,Date,ExecutedId
		from @temp
	end
end
GO
*/

/****** Object:  StoredProcedure [dbo].[uspProcessExecuted]    Script Date: 12/30/2011 01:47:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[uspProcessExecuted]
@Name nvarchar(100),
@ProcessId int
as 
begin
	SET NOCOUNT ON;
	
	declare @aux int
	select @aux=0
	select @aux=ExecutedId from tb_Executed where Name=@name
	if @aux>0
	begin
		delete from tb_ProcessExecuted where ProcessId=@processId and ExecutedId=@aux
		insert into tb_ProcessExecuted values (@aux,@processId)
	end
end
GO
/****** Object:  StoredProcedure [dbo].[uspExecutedUpdate]    Script Date: 12/30/2011 01:47:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspExecutedUpdate]
@name nvarchar(100),
@address nvarchar(100),
@phone nvarchar(50),
@Mphone nvarchar(50),
@fax nvarchar(50),
@email nvarchar(50),
@userid uniqueidentifier,
@IdentityCard nvarchar(20),
@NifNipl nvarchar(20),
@Nifs nvarchar(20),
@BornDate datetime,
@ExecutedId int
AS
BEGIN
	SET NOCOUNT ON;
	
	if @BornDate='01-01-1900' or @BornDate='01/01/1900'
		select @BornDate=null
	if @ExecutedId>0
		update tb_Executed set Name=@name,Address=@address,Phone=@phone,MPhone=@Mphone,Fax=@fax,Email=@email,
			CreateDate=GETDATE(),CreateUserId=@userid,AlterDate=GETDATE(),AlterUserId=@userid,
			IdentityCard=@IdentityCard,NifNipl=@NifNipl,Nifs=@Nifs,BornDate=@BornDate
		where ExecutedId=@ExecutedId
	else
	begin
		declare @aux int
		select @aux=0
		select @aux=ExecutedId from tb_Executed where Name=@name and active=1
		if @aux>0
			update tb_Executed set Address=@address,Phone=@phone,MPhone=@Mphone,Fax=@fax,Email=@email,
				CreateDate=GETDATE(),CreateUserId=@userid,AlterDate=GETDATE(),AlterUserId=@userid,
				IdentityCard=@IdentityCard,NifNipl=@NifNipl,Nifs=@Nifs,BornDate=@BornDate
			where Name=@name
		else
			insert into tb_Executed (Name,Address,Phone,MPhone,Fax,Email,IdentityCard,NifNipl,Nifs,BornDate,Active,CreateDate,CreateUserId,AlterDate,AlterUserId)
			values (@name,@address,@phone,@Mphone,@fax,@email,
				@IdentityCard,@NifNipl,@Nifs,@BornDate,1,
				GETDATE(),@userid,GETDATE(),@userid)
	end
END
GO
/****** Object:  StoredProcedure [dbo].[uspProcessExtraAddress]    Script Date: 12/30/2011 01:47:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[uspProcessExtraAddress]
@Address nvarchar(100),
@ExecutedId int,
@ProcessId int
as 
begin
	SET NOCOUNT ON;
	declare @aux int
	select @aux=0
	select @aux=COUNT(*) from tb_ExecutedAddresses where Address=@Address
	if @aux=0
		insert into tb_ExecutedAddresses values (@ExecutedId,@ProcessId,GETDATE(),@Address)
end
GO
/****** Object:  StoredProcedure [dbo].[uspProcessExecutionType]    Script Date: 12/30/2011 01:47:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[uspProcessExecutionType]
@Name nvarchar(100),
@ProcessId int
as 
begin
	SET NOCOUNT ON;
	
	declare @aux int
	select @aux=0
	select @aux=ExecutionTypeId from tb_ExecutionType where Name=@name
	if @aux>0
		update tb_Process set ExecutionTypeId=@aux where ProcessId=@processId
end
GO
/****** Object:  StoredProcedure [dbo].[uspProcessDeleteCreditor]    Script Date: 12/30/2011 01:47:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[uspProcessDeleteCreditor]
@CreditorId int,
@ProcessId int
as 
begin
	SET NOCOUNT ON;
	
	if @CreditorId>0
		delete from tb_ProcessCreditor where ProcessId=@processId and CreditorId=@CreditorId
end
GO
/****** Object:  StoredProcedure [dbo].[uspDelegateProcessUpdate]    Script Date: 12/30/2011 01:47:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[uspDelegateProcessUpdate]
@ProcessId int,
@DelegateId int,
@Observation nvarchar(4000)
as
begin
	if(select COUNT(*) from tb_ProcessDelegate where ProcessId=@ProcessId and DelegateId=@DelegateId)=0
		insert into tb_ProcessDelegate (ProcessId,DelegateId,Observation) values (@ProcessId,@DelegateId,@Observation)
	else
		update tb_ProcessDelegate set Observation=@Observation where ProcessId=@ProcessId and DelegateId=@DelegateId
end
GO
/****** Object:  StoredProcedure [dbo].[uspMntUpdate]    Script Date: 12/30/2011 01:47:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[uspMntUpdate]
@ProcessId int,
@PaymentAgreementId int,
@ProcessExtinctionId int,
@ExtinctionCodeId int,
@ArrangementsInPlaceId int,
@InAttachment int,
@ProcessStateId int,
@DBInfoId int,
@UncollectabilityCertificateId int,
@Provision decimal(10,2),
@ProvisionReceptionDate datetime,
@PendingInvoicePayment decimal(10,2),
@DiligenceLocation nvarchar(50),
@JudicialPhaseId int,
@PendingInvoicePaymentDate datetime,
@CreditorReference nvarchar(50),
@AcceptDate datetime,
@DuplicatesReceipt datetime,
@JudgeObservation nvarchar(4000),
@Alert int

as

begin
	declare @sql nvarchar(4000)

	if(select COUNT(*) from tb_ProcessDetail where ProcessId=@ProcessId)=0
	begin
		select @sql='insert into tb_ProcessDetail (ProcessId,PaymentAgreementId,ProcessExtinctionId,ExtinctionCodeId,ArrangementsInPlaceId,InAttachmentId,ProcessStateId,DBInfoId,UncollectabilityCertificateId'
		select @sql=@sql+',Provision,ProvisionReceptionDate,PendingInvoicePayment,DiligenceLocation,JudicialPhaseId'
		select @sql=@sql+',PendingInvoicePaymentDate,CreditorReference,AcceptDate,DuplicatesReceipt,JudgeObservation,Alert)'
		select @sql=@sql+' values('

		select @sql=@sql+CAST(@ProcessId as nvarchar(10))
		select @sql=@sql+','
		if @PaymentAgreementId>0 select @sql=@sql+CAST(@PaymentAgreementId as nvarchar(10)) else select @sql=@sql+'null'
		select @sql=@sql+','
		if @ProcessExtinctionId>0 select @sql=@sql+CAST(@ProcessExtinctionId as nvarchar(10)) else select @sql=@sql+'null'
		select @sql=@sql+','
		if @ExtinctionCodeId>0 select @sql=@sql+CAST(@ExtinctionCodeId as nvarchar(10)) else select @sql=@sql+'null'
		select @sql=@sql+','
		if @ArrangementsInPlaceId>0 select @sql=@sql+CAST(@ArrangementsInPlaceId as nvarchar(10)) else select @sql=@sql+'null'
		select @sql=@sql+','
		if @InAttachment>0 select @sql=@sql+CAST(@InAttachment as nvarchar(10)) else select @sql=@sql+'null'
		select @sql=@sql+','
		if @ProcessStateId>0 select @sql=@sql+CAST(@ProcessStateId as nvarchar(10)) else select @sql=@sql+'null'
		select @sql=@sql+','
		if @DBInfoId>0 select @sql=@sql+CAST(@DBInfoId as nvarchar(10)) else select @sql=@sql+'null'
		select @sql=@sql+','
		if @UncollectabilityCertificateId>0 select @sql=@sql+CAST(@UncollectabilityCertificateId as nvarchar(10)) else select @sql=@sql+'null'

		select @sql=@sql+','
		if @Provision>0 select @sql=@sql+CAST(@Provision as nvarchar(10)) else select @sql=@sql+'null'
		select @sql=@sql+','
		if @ProvisionReceptionDate>'01-01-1900' select @sql=@sql+''''+convert(nvarchar(30),@ProvisionReceptionDate,20)+'''' else select @sql=@sql+'null'
		select @sql=@sql+','
		if @PendingInvoicePayment>0 select @sql=@sql+CAST(@PendingInvoicePayment as nvarchar(10)) else select @sql=@sql+'null'
		select @sql=@sql+','
		if len(@DiligenceLocation)>0 select @sql=@sql+''''+@DiligenceLocation+'''' else select @sql=@sql+'null'
		select @sql=@sql+','
		if @JudicialPhaseId>0 select @sql=@sql+CAST(@JudicialPhaseId as nvarchar(10)) else select @sql=@sql+'null'
		select @sql=@sql+','
		if @PendingInvoicePaymentDate>'01-01-1900' select @sql=@sql+''''+convert(nvarchar(30),@PendingInvoicePaymentDate,20)+'''' else select @sql=@sql+'null'
		select @sql=@sql+','
		if len(@CreditorReference)>0 select @sql=@sql+''''+@CreditorReference+'''' else select @sql=@sql+'null'
		select @sql=@sql+','
		if @AcceptDate>'01-01-1900' select @sql=@sql+''''+convert(nvarchar(30),@AcceptDate,20)+'''' else select @sql=@sql+'null'
		select @sql=@sql+','
		if @DuplicatesReceipt>'01-01-1900' select @sql=@sql+''''+convert(nvarchar(30),@DuplicatesReceipt,20)+'''' else select @sql=@sql+'null'

		select @sql=@sql+','
		if len(@JudgeObservation)>0 select @sql=@sql+''''+@JudgeObservation+'''' else select @sql=@sql+'null'

		select @sql=@sql+','+cast(@Alert as nvarchar(20))

		select @sql=@sql+')'

	end
	else
	begin

		select @sql='update tb_ProcessDetail set '

		select @sql=@sql+' PaymentAgreementId='
		if @PaymentAgreementId>0 select @sql=@sql+CAST(@PaymentAgreementId as nvarchar(10)) else select @sql=@sql+'null'

		select @sql=@sql+',ProcessExtinctionId='
		if @ProcessExtinctionId>0 select @sql=@sql+CAST(@ProcessExtinctionId as nvarchar(10)) else select @sql=@sql+'null'

		select @sql=@sql+',ExtinctionCodeId='
		if @ExtinctionCodeId>0 select @sql=@sql+CAST(@ExtinctionCodeId as nvarchar(10)) else select @sql=@sql+'null'

		select @sql=@sql+',ArrangementsInPlaceId='
		if @ArrangementsInPlaceId>0 select @sql=@sql+CAST(@ArrangementsInPlaceId as nvarchar(10)) else select @sql=@sql+'null'

		select @sql=@sql+',InAttachmentId='
		if @InAttachment>0 select @sql=@sql+CAST(@InAttachment as nvarchar(10)) else select @sql=@sql+'null'

		select @sql=@sql+',ProcessStateId='
		if @ProcessStateId>0 select @sql=@sql+CAST(@ProcessStateId as nvarchar(10)) else select @sql=@sql+'null'

		select @sql=@sql+',DBInfoId='
		if @DBInfoId>0 select @sql=@sql+CAST(@DBInfoId as nvarchar(10)) else select @sql=@sql+'null'

		select @sql=@sql+',UncollectabilityCertificateId='
		if @UncollectabilityCertificateId>0 select @sql=@sql+CAST(@UncollectabilityCertificateId as nvarchar(10)) else select @sql=@sql+'null'

		select @sql=@sql+',Provision='
		if @Provision>0 select @sql=@sql+CAST(@Provision as nvarchar(10)) else select @sql=@sql+'null'
		select @sql=@sql+',ProvisionReceptionDate='
		if @ProvisionReceptionDate>'01-01-1900' select @sql=@sql+''''+convert(varchar(30),@ProvisionReceptionDate,20)+'''' else select @sql=@sql+'null'
		select @sql=@sql+',PendingInvoicePayment='
		if @PendingInvoicePayment>0 select @sql=@sql+CAST(@PendingInvoicePayment as nvarchar(10)) else select @sql=@sql+'null'
		select @sql=@sql+',DiligenceLocation='
		if len(@DiligenceLocation)>0 select @sql=@sql+''''+CAST(@DiligenceLocation as nvarchar(10))+'''' else select @sql=@sql+'null'
		select @sql=@sql+',JudicialPhaseId='
		if @JudicialPhaseId>0 select @sql=@sql+CAST(@JudicialPhaseId as nvarchar(10)) else select @sql=@sql+'null'
		select @sql=@sql+',PendingInvoicePaymentDate='
		if @PendingInvoicePaymentDate>'01-01-1900' select @sql=@sql+''''+convert(varchar(30),@PendingInvoicePaymentDate,20)+'''' else select @sql=@sql+'null'
		select @sql=@sql+',CreditorReference='
		if len(@CreditorReference)>0 select @sql=@sql+''''+@CreditorReference+'''' else select @sql=@sql+'null'

		select @sql=@sql+',AcceptDate='
		if @AcceptDate>'01-01-1900' select @sql=@sql+''''+convert(varchar(30),@AcceptDate,20)+'''' else select @sql=@sql+'null'
		select @sql=@sql+',DuplicatesReceipt='
		if @DuplicatesReceipt>'01-01-1900' select @sql=@sql+''''+convert(varchar(30),@DuplicatesReceipt,20)+'''' else select @sql=@sql+'null'

		select @sql=@sql+',JudgeObservation='
		if len(@JudgeObservation)>0 select @sql=@sql+''''+@JudgeObservation+'''' else select @sql=@sql+'null'

		select @sql=@sql+',Alert='+CAST(@Alert as nvarchar(20))

		select @sql=@sql+' where ProcessId='+CAST(@ProcessId as nvarchar(10))

	end

	exec(@sql)
	--print(@sql)

end
GO
/****** Object:  StoredProcedure [dbo].[uspMntValues]    Script Date: 12/30/2011 01:47:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[uspMntValues]
@ProcessId int

as
begin
	select isnull(PaymentAgreementId,'0'),isnull(ProcessExtinctionId,'0'),isnull(ExtinctionCodeId,'0'),isnull(ArrangementsInPlaceId,'0'),
		isnull(InAttachmentId,'0'),isnull(ProcessStateId,'0'),isnull(DBInfoId,'0'),isnull(UncollectabilityCertificateId,'0'),
		isnull(Provision,'0'),ProvisionReceptionDate,isnull(PendingInvoicePayment,'0'),isnull(DiligenceLocation,'0'),isnull(JudicialPhaseId,'0')
		,PendingInvoicePaymentDate,CreditorReference,AcceptDate,DuplicatesReceipt,JudgeObservation,Alert
	from tb_ProcessDetail
	where ProcessId=@ProcessId
end
GO
/****** Object:  StoredProcedure [dbo].[uspRepresentativeInformationAdd]    Script Date: 12/30/2011 01:47:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[uspRepresentativeInformationAdd]
@ProcessId int,
@Information nvarchar(250),
@CreateUser nvarchar(50)
as
begin
	declare @RepresentativeId int
	select @RepresentativeId=RepresentativeId from tb_Process where ProcessId=@ProcessId
	if @RepresentativeId>0
		insert into tb_ProcessRepresentativeInformation (ProcessId,RepresentativeId,Date,Information,CreateUser)
			values (@ProcessId,@RepresentativeId,GETDATE(),@Information,@CreateUser)
end
GO
/****** Object:  StoredProcedure [dbo].[uspChartProcess]    Script Date: 12/30/2011 01:47:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[uspChartProcess]
@UserName nvarchar(100)

as
begin
	--	## media de processos alterados por dia
	select isnull(AVG(t),'0') from (
		select COUNT(*)t
		from tb_Process
		where ProcessId not in(
			select processid from tb_Process p
				left join tb_Localization l on p.LocalizationId=l.LocalizationId
			where (l.Name like '%arquivo%' or l.Name like '%findo%')
		)
		group by DAY(AlterDate)
	)as tab

	--	##	total processos nao alterados ha mais de X dias
	select COUNT(*)
	from vwProcess
	where AlterDate<GETDATE()-30
		and ProcessId not in(
			select processid from tb_Process p
				left join tb_Localization l on p.LocalizationId=l.LocalizationId
			where (l.Name like '%arquivo%' or l.Name like '%findo%')
		)

	--	##	total processos nao alterados ha mais de X dias
	select COUNT(*)
	from vwProcess
	where AlterDate<GETDATE()-60
		and ProcessId not in(
			select processid from tb_Process p
				left join tb_Localization l on p.LocalizationId=l.LocalizationId
			where (l.Name like '%arquivo%' or l.Name like '%findo%')
		)

	--	##	total processos nao alterados ha mais de X dias, nos quais o ultimo utilizador foi o X
	select COUNT(*)
	from vwProcess
	where AlterDate<GETDATE()-90
		and ProcessId not in(
			select processid from tb_Process p
				left join tb_Localization l on p.LocalizationId=l.LocalizationId
			where (l.Name like '%arquivo%' or l.Name like '%findo%')
		)

end
GO
/****** Object:  StoredProcedure [dbo].[uspProcessDeleteExecuted]    Script Date: 12/30/2011 01:47:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[uspProcessDeleteExecuted]
@ExecutedId int,
@ProcessId int
as 
begin
	SET NOCOUNT ON;
	
	if @ExecutedId>0
		delete from tb_ProcessExecuted where ProcessId=@processId and ExecutedId=@ExecutedId
end
GO
/****** Object:  StoredProcedure [dbo].[uspProcessFile]    Script Date: 12/30/2011 01:47:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[uspProcessFile]
@ProcessId int,
@Name nvarchar(50),
@SecureName nvarchar(50),
@UserPermission int,
@RepresentativePermission int,
@UserId uniqueidentifier
as
begin
	insert into tb_ProcessFile 
	values (@ProcessId,@Name,@SecureName,@UserPermission,@RepresentativePermission,getdate(),@UserId,getdate(),@UserId)
end
GO
/****** Object:  StoredProcedure [dbo].[uspProcessSearch]    Script Date: 12/30/2011 01:47:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[uspProcessSearch]
@SearchName nvarchar(100),
@ProcessId int,
@ExecutedId int,
@Date datetime,
@Obs nvarchar(100),
@UserId uniqueidentifier
as 
begin
	SET NOCOUNT ON;
	declare @aux int
	select @aux=0
	select @aux=SearchId from tb_Search where Name=@SearchName
	if @aux=0
	begin
		insert into tb_Search values (@SearchName,GETDATE(),@UserId,GETDATE(),@UserId)
		select @aux=SearchId from tb_Search where Name=@SearchName
	end
	delete from tb_ProcessSearch 
		where SearchId=@aux and ProcessId=@processId and ExecutedId=@ExecutedId and Date=@Date
	insert into tb_ProcessSearch values (@aux,@processId,@ExecutedId,@Date,0,@Obs)
end
GO
/****** Object:  StoredProcedure [dbo].[uspProcessProvision]    Script Date: 12/30/2011 01:47:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[uspProcessProvision]
@ProcessId int,
@ExecutedId int,
@Date datetime,
@Value real
as 
begin
	SET NOCOUNT ON;
	
	declare @aux int
	select @aux=0
	
	select @aux=COUNT(*) from tb_Provision where ProcessId=@ProcessId and ExecutedId=@ExecutedId and date=@Date
	if @aux=0
		insert into tb_Provision values (@ProcessId,@ExecutedId,@Date,@Value,0)
end
GO
/****** Object:  StoredProcedure [dbo].[uspChartRepresentative]    Script Date: 12/30/2011 01:47:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[uspChartRepresentative]
as
begin
	select top 5 r.Name,COUNT(*) t
	from tb_Process p
		left join tb_Representative r on p.RepresentativeId=r.RepresentativeId
	group by p.RepresentativeId,r.Name,r.LawyerNumber
	order by t desc
end
GO
/****** Object:  StoredProcedure [dbo].[uspProcessRepresentative]    Script Date: 12/30/2011 01:47:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[uspProcessRepresentative]
@Name nvarchar(100),
@ProcessId int
as 
begin
	SET NOCOUNT ON;
	
	declare @aux int
	select @aux=0
	select @aux=RepresentativeId from tb_Representative where Name=@name
	if @aux>0
		update tb_Process set RepresentativeId=@aux where ProcessId=@processId
end
GO
/****** Object:  StoredProcedure [dbo].[uspRepresentativeUpdate]    Script Date: 12/30/2011 01:47:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[uspRepresentativeUpdate]
@name nvarchar(100),
@address nvarchar(100),
@phone nvarchar(15),
@fax nvarchar(15),
@email nvarchar(50),
@userid uniqueidentifier
AS
BEGIN
	SET NOCOUNT ON;
	
	declare @aux int
	select @aux=0
	
	select @aux=RepresentativeId from tb_Representative where Name=@name
	if @aux>0
		update tb_Representative set Address=@address,Phone=@phone,Fax=@fax,Email=@email,AlterDate=GETDATE(),AlterUserId=@userid
			where Name=@name
	else
		insert into tb_Representative (Name,Address,Phone,Fax,Email,CreateDate,CreateUserId,AlterDate,AlterUserId)
			values (@name,@address,@phone,@fax,@email,GETDATE(),@userid,GETDATE(),@userid)
	
END
GO

/****** Object:  StoredProcedure [dbo].[uspProcessSection]    Script Date: 12/30/2011 01:47:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[uspProcessSection]
@Name nvarchar(100),
@ProcessId int
as 
begin
	SET NOCOUNT ON;
	
	declare @aux int
	select @aux=0
	select @aux=SectionId from tb_Section where Name=@name
	if @aux=0
	begin
		insert into tb_Section values(@name)
		select @aux=SectionId from tb_Section where Name=@name
	end
	update tb_Process set SectionId=@aux where ProcessId=@processId
end
GO
/****** Object:  StoredProcedure [dbo].[uspSolicitorAdd]    Script Date: 12/30/2011 01:47:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[uspSolicitorAdd]
@SolicitorId int,
@Name nvarchar(200),
@CardNumber nvarchar(200)
as
begin
	if @SolicitorId=0 and (select COUNT(*) from tb_Solicitor where Name=@Name and CardNumber=@CardNumber)=0
		insert into tb_Solicitor (Name,CardNumber) values (@Name,@CardNumber)
	else
		update tb_Solicitor set Name=@Name, CardNumber=@CardNumber where SolicitorId=@SolicitorId
end
GO
/****** Object:  StoredProcedure [dbo].[uspPaymenTemp]    Script Date: 12/30/2011 01:47:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[uspPaymenTemp]
as
begin
	declare @temp table (idX int identity(1,1),id int,field1 nvarchar(50),field2 datetime,field3 nvarchar(1000),field4 real)
	insert into @temp
	SELECT Id,Account,Date,Description,Value FROM tb_TemporaryPayment
	declare @start int,
			@end int,
			@field1 nvarchar(50),
			@field2 datetime,
			@field3 nvarchar(1000),
			@field4 real,
			@processid int,
			@Id int
	select @start=1,@processid=0,@end=COUNT(*) from @temp
	while @start<=@end
	begin
		select @processid=0,@Id=0
		select @field1=field1,@field2=field2,@field3=field3,@field4=field4 from @temp where idX=@start
		select @processid=ProcessId from vwProcess where InternalNumber LIKE '%'+@field3+'%' or ProcessNumber like '%'+@field3+'%' or creditor like '%'+@field3+'%' or executed like '%'+@field3+'%' group by ProcessId
		if @processid>0
		begin
			select @Id=id from tb_TemporaryPayment where Account=@field1 and Date=@field2 and Description=@field3 and Value=@field4
			if @Id>0
				update tb_TemporaryPayment set ProcessId=@processid where Id=@Id
		end
		select @start=@start+1
	end
	select tp.Id,isnull(tp.ProcessId,0) as 'ProcessId',tp.Date,tp.Description,tp.Value,p.InternalNumber,p.ProcessNumber,tp.Account
	from tb_TemporaryPayment tp
		left join vwProcess p on tp.ProcessId=p.ProcessId
	where tp.Active=1
	group by tp.ProcessId,tp.Id,tp.Date,tp.Description,tp.Value,p.InternalNumber,p.ProcessNumber,tp.Account
end
GO
/****** Object:  StoredProcedure [dbo].[uspPaymentFilter]    Script Date: 12/30/2011 01:47:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[uspPaymentFilter]
@Path as nvarchar(200),
@Account as nvarchar(200)
as
begin
	declare @temp table (id int identity(1,1),field1 nvarchar(50),field2 datetime,field3 nvarchar(1000),field4 real)
	delete from tb_tempPayment
	exec('BULK INSERT tb_tempPayment FROM '''+@Path+'''WITH( FIELDTERMINATOR = '';'',ROWTERMINATOR = ''\n'' )')
	insert into @temp
	SELECT @Account,convert(datetime,field2,105),field3,cast(replace(field4,',','.') as real) FROM tb_tempPayment
	declare @start int,
			@end int,
			@field1 nvarchar(50),
			@field2 datetime,
			@field3 nvarchar(1000),
			@field4 real,
			@processid int,
			@Id int
	select @start=1,@processid=0,@end=COUNT(*) from @temp
	while @start<=@end
	begin
		select @field1=field1,@field2=field2,@field3=field3,@field4=field4 from @temp where id=@start
		if(select COUNT(*) from tb_TemporaryPayment where Account=@field1 and Date=@field2 and Description=@field3 and Value=@field4)=0
		begin
			insert into tb_TemporaryPayment (Account,Date,Description,Value,Active)
			select field1,field2,field3,field4,1 from @temp where id=@start
		end
		select @start=@start+1
	end
	
end
GO
/****** Object:  StoredProcedure [dbo].[uspUserSettingGet]    Script Date: 12/30/2011 01:47:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[uspUserSettingGet]
@UserId nvarchar(50)
as
begin
	if(select COUNT(*) from tb_UserSetting where UserId=@UserId)=0
		insert into tb_UserSetting (UserId,Theme,SearchResult,LocalizationId) values (@UserId,'Blue',1,1)
	
	select Theme+'|'+cast(SearchResult as nvarchar(10)) from tb_UserSetting where UserId=@UserId
end
GO
/****** Object:  StoredProcedure [dbo].[uspUserSettingSave]    Script Date: 12/30/2011 01:47:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[uspUserSettingSave]
@UserId nvarchar(50),
@Theme nvarchar(50),
@SearchResult int,
@LocalizationId int

as
begin
	if(select COUNT(*) from tb_UserSetting where UserId=@UserId)=0
		insert into tb_UserSetting (UserId,Theme,SearchResult,LocalizationId) values (@UserId,@Theme,@SearchResult,@LocalizationId)
	else
		update tb_UserSetting set Theme=@Theme,SearchResult=@SearchResult,LocalizationId=@LocalizationId where UserId=@UserId
end
GO
/****** Object:  StoredProcedure [dbo].[uspSearch]    Script Date: 12/30/2011 01:47:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[uspSearch]
@InternalNumber nvarchar(50),
@ProcessNumber nvarchar(50),
@Court nvarchar(100),
@Creditor nvarchar(100),
@Representative nvarchar(100),
@Executed nvarchar(100),
@NDays int,
@LocalizationDetail nvarchar(50),
@UserName nvarchar(200),
@LocalizationId int,
@Date1 nvarchar(10),
@Date2 nvarchar(10),

@Provision decimal(10,2),
@PendingInvoicePayment decimal(10,2),

@Start int,
@End int,
@PostBack int

as
begin

	if @PostBack=0
		select top 30 ProcessId,InternalNumber,Court,Representative,ProcessNumber,Number,year,Enforcement,dbo.udfCreditor(ProcessId)Creditor,dbo.udfExecuted(ProcessId)Executed,Localization,LocalizationDetail,username,alterdate,Provision,PendingInvoicePayment
		from vwProcess 
		group by ProcessId,InternalNumber,Court,Representative,ProcessNumber,Number,year,Enforcement,AlterDate,Localization,LocalizationId,LocalizationDetail,username,alterdate,Provision,PendingInvoicePayment
		order by AlterDate desc
	else
	begin
		declare @strsql nvarchar(2000)
		select @strsql=''

		select @strsql=@strsql+'select * from('
		select @strsql=@strsql+'select ProcessId'
		select @strsql=@strsql+',(case when datediff(dd,alterdate,getdate())>=Alert then ''<img alt="" src="../../images/icons/alert.png"/>''+InternalNumber else InternalNumber end) as InternalNumber'
		select @strsql=@strsql+',Court,Representative,ProcessNumber,Number,year,Enforcement'
		select @strsql=@strsql+',dbo.udfCreditor(ProcessId)Creditor,dbo.udfExecuted(ProcessId)Executed,Localization,LocalizationDetail'
		select @strsql=@strsql+'  ,username,alterdate,Provision,PendingInvoicePayment,ROW_NUMBER() OVER(ORDER BY alterdate desc) as num'
		select @strsql=@strsql+' from ('
		select @strsql=@strsql+'	select * from vwProcess WHERE ProcessId > 0'

		if LEN(@InternalNumber)>0
			select @strsql=@strsql+' and InternalNumber like ''%'+@InternalNumber+'%'''
		if LEN(@ProcessNumber)>0
			select @strsql=@strsql+' and ProcessNumber like ''%'+@ProcessNumber+'%'''
		if LEN(@Court)>0
			select @strsql=@strsql+' and Court like ''%'+@Court+'%'''
		if LEN(@Creditor)>0
			select @strsql=@strsql+' and Creditor like ''%'+@Creditor+'%'''
		if LEN(@Representative)>0
			select @strsql=@strsql+' and Representative like ''%'+@Representative+'%'''
		if LEN(@Executed)>0
			select @strsql=@strsql+' and Executed like ''%'+@Executed+'%'''
		if @NDays>0
			select @strsql=@strsql+' and AlterDate<getdate()-'+CAST(@NDays as nvarchar(10))
		if @LocalizationId>0
			select @strsql=@strsql+' and LocalizationId='+CAST(@LocalizationId as nvarchar(10))
		if LEN(@LocalizationDetail)>0
			select @strsql=@strsql+' and LocalizationDetail like ''%'+@LocalizationDetail+'%'''
		if LEN(@UserName)>0
			select @strsql=@strsql+' and UserName = '''+@UserName+''''
		if LEN(@Date1)>0 and Len(@Date2)>0
			select @strsql=@strsql+' and AlterDate between '''+@Date1+''' and '''+@Date2+''''

		if @Provision>0
			select @strsql=@strsql+' and Provision='+CAST(@Provision as nvarchar(10))
		if @PendingInvoicePayment>0
			select @strsql=@strsql+' and PendingInvoicePayment='+CAST(@PendingInvoicePayment as nvarchar(10))

		select @strsql=@strsql+' ) as tab'
		select @strsql=@strsql+' group by ProcessId,InternalNumber,Court,Representative,ProcessNumber,Number,year,Enforcement,alterdate,UserName,Localization,LocalizationId,LocalizationDetail,Alert,Provision,PendingInvoicePayment'

		select @strsql=@strsql+' ) as tab2'
		select @strsql=@strsql+' where num between '+cast(@Start as nvarchar(5))+' and '+cast(@End as nvarchar(5))

		exec(@strsql)
		--print(@strsql)
	end
end
GO
/****** Object:  StoredProcedure [dbo].[uspExcel]    Script Date: 12/30/2011 01:47:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[uspExcel]
@Representative nvarchar(100),
@Creditor nvarchar(100)
as
begin
	if LEN(@Representative)>0
		select InternalNumber,ProcessNumber,dbo.udfCreditor(ProcessId)Creditor,dbo.udfExecuted(ProcessId)Executed,Representative,replace(Observation,';',',')
			,court,localization,UserName,AlterDate
		from vwProcess
		where Representative like '%'+@Representative+'%'
		group by ProcessId,InternalNumber,ProcessNumber,Representative,Observation,court,localization,UserName,AlterDate
	else if LEN(@Creditor)>0
		select InternalNumber,ProcessNumber,dbo.udfCreditor(ProcessId)Creditor,dbo.udfExecuted(ProcessId)Executed,Representative,replace(Observation,';',',')
			,court,localization,UserName,AlterDate
		from vwProcess
		where Creditor like '%'+@Creditor+'%'
		group by ProcessId,InternalNumber,ProcessNumber,Representative,Observation,court,localization,UserName,AlterDate
	else
		select InternalNumber,ProcessNumber,dbo.udfCreditor(ProcessId)Creditor,dbo.udfExecuted(ProcessId)Executed,Representative,replace(Observation,';',',')
			,court,localization,UserName,AlterDate
		from vwProcess
		group by ProcessId,InternalNumber,ProcessNumber,Representative,Observation,court,localization,UserName,AlterDate
end
GO








/****** Object:  StoredProcedure [dbo].[uspRepresentative]    Script Date: 12/30/2011 01:47:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[uspRepresentative]
@Name nvarchar(100),
@Address nvarchar(100),
@Phone nvarchar(50),
@Fax nvarchar(50),
@Email nvarchar(50),
@Nif nvarchar(50),
@CarbonCopy nvarchar(200),
@Init int,
@End int,
@UserId uniqueidentifier
as
begin
	declare @sql nvarchar(4000)
	select @sql=''
	select @sql=@sql+'select * from('
	select @sql=@sql+' select RepresentativeId,Name,Address,Phone,Fax,Email,Nif,CarbonCopy,UserName,AlterDate,LawyerNumber'
	select @sql=@sql+',row_number() over(order by AlterDate desc) as ''Id'''
	select @sql=@sql+' from vwRepresentative'
	select @sql=@sql+' where RepresentativeId>0'
	
	if LEN(@Name)>0 select @sql=@sql+' and Name like ''%'+@Name+'%'''
	if LEN(@Address)>0 select @sql=@sql+' and Address like ''%'+@Address+'%'''
	if LEN(@Phone)>0 select @sql=@sql+' and Phone like ''%'+@Phone+'%'''
	if LEN(@Fax)>0 select @sql=@sql+' and Fax like ''%'+@Fax+'%'''
	if LEN(@Email)>0 select @sql=@sql+' and Email like ''%'+@Email+'%'''
	if LEN(@Nif)>0 select @sql=@sql+' and Nif like ''%'+@Nif+'%'''
	if LEN(@CarbonCopy)>0 select @sql=@sql+' and CarbonCopy like ''%'+@CarbonCopy+'%'''
	select @sql=@sql+')as t where Id between '+CAST(@Init as nvarchar(10))+' and '+CAST(@End as nvarchar(10))
	exec(@sql)
end
GO



































































































































































/*######################################################################################################################*/
/*######################################################################################################################*/
/*######################################################################################################################*/
/*######################################################################################################################*/
/*######################################################################################################################*/
/*######################################################################################################################*/
/*######################################################################################################################*/
/*######################################################################################################################*/
/*######################################################################################################################*/
/*######################################################################################################################*/
/*######################################################################################################################*/
/*######################################################################################################################*/
/*######################################################################################################################*/
/*######################################################################################################################*/
/*######################################################################################################################*/
/*######################################################################################################################*/
/*######################################################################################################################*/
/*######################################################################################################################*/
/*######################################################################################################################*/
/*######################################################################################################################*/
/*######################################################################################################################*/
/*######################################################################################################################*/
/*######################################################################################################################*/
/*######################################################################################################################*/

-- VIEWS

GO
/****** Object:  View [dbo].[vwDocument]    Script Date: 12/30/2011 02:10:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE view [dbo].[vwDocument]
as
(
SELECT     tp.ProcessId, UPPER(CAST(tp.Code AS nvarchar(4)) + '/' + SUBSTRING('0000' + CAST(tp.Number AS nvarchar(10)), LEN(tp.Number) + 1, 4)+isnull(tp.Alt,'')+ 
	+ '/' + CAST(tp.Year AS nvarchar(4)) + (CASE WHEN LEN(tp.Initials) > 0 THEN '/' + tp.Initials ELSE '' END)) AS 'NumeroInterno',
	
	tc.Name AS 'TribunalNome',tc.Address as 'TribunalMorada',tc.Phone as 'TribunalTlf',tc.Email as 'TribunalEmail', tc.JudicialDistrict as 'TribunalComarca',
	tp.ProcessNumber as 'TribunalCodigoProcesso', tp.Number, tp.Year, tp.Enforcement,
	tp.Observation, tp.Localization+' - '+tp.LocalizationDetail as 'Localization',
	tr.RepresentativeId, tr.name as 'MandatarioNome',tr.Address as 'MandatarioMorada',tr.Phone as 'MandatarioTlf',tr.MPhone as 'MandatarioTlm',tr.Fax as 'MandatarioFax',tr.Email as 'MandatarioEmail',tr.Nif as 'MandatarioNif',tr.LawyerNumber as 'MandatarioNumCedula',
	te.ExecutedId,te.name as 'ExecutadoNome',te.Address as 'ExecutadoMorada',te.Phone as 'ExecutadoTlf',te.MPhone as 'ExecutadoTlm',te.Fax as 'ExecutadoFax',te.Email as 'ExecutadoEmail',te.IdentityCard as 'ExecutadoBi',te.NifNipl as 'ExecutadoNifNipl',te.Nifs as 'ExecutadoNifs',te.BornDate as 'ExecutadoDataNascimento',
	tcr.CreditorId,tcr.name as 'ExequenteNome',tcr.Address as 'ExequenteMorada',tcr.Phone as 'ExequenteTlf',tcr.MPhone as 'ExequenteTlm',tcr.Fax as 'ExequenteFax',tcr.Email as 'ExequenteEmail',tcr.IdentityCard as 'ExequenteBi',tcr.NifNipl as 'ExequenteNifNipl',tcr.Nifs as 'ExequenteNifs',tcr.BornDate as 'ExequenteDataNascimento'
	,tp.Value
FROM         dbo.tb_Process AS tp LEFT OUTER JOIN
	dbo.tb_ProcessCreditor AS tpc ON tp.ProcessId = tpc.ProcessId LEFT OUTER JOIN
	dbo.tb_ProcessExecuted AS tpe ON tp.ProcessId = tpe.ProcessId LEFT OUTER JOIN
	dbo.tb_Court AS tc ON tp.CourtId = tc.CourtId LEFT OUTER JOIN
	dbo.tb_Creditor AS tcr ON tpc.CreditorId = tcr.CreditorId LEFT OUTER JOIN
	dbo.tb_Executed AS te ON tpe.ExecutedId = te.ExecutedId LEFT OUTER JOIN
	dbo.tb_Representative AS tr ON tp.RepresentativeId = tr.RepresentativeId LEFT OUTER JOIN
	dbo.aspnet_Users AS au ON tp.AlterUserId = au.UserId
)
GO

/****** Object:  View [dbo].[vwProcess]    Script Date: 12/30/2011 02:10:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vwProcess]
AS
SELECT     tp.ProcessId, UPPER(CAST(tp.Code AS nvarchar(4)) + '/' + SUBSTRING('0000' + CAST(tp.Number AS nvarchar(10)), LEN(tp.Number) + 1, 4) + ISNULL(tp.Alt, '') 
                      + + '/' + CAST(tp.Year AS nvarchar(4)) + (CASE WHEN LEN(tp.Initials) > 0 THEN '/' + tp.Initials ELSE '' END)) AS InternalNumber, tc.Name AS Court, 
                      tr.Name AS Representative, tp.ProcessNumber, tp.Number, tp.Year, tp.Enforcement, tcr.Name AS Creditor, te.Name AS executed, au.UserName, tp.AlterDate, 
                      tp.Observation, ISNULL
                          ((SELECT     Name
                              FROM         dbo.tb_Localization AS lo
                              WHERE     (LocalizationId = tp.LocalizationId)), '') AS Localization, tp.LocalizationDetail, tp.RepresentativeId, tr.Userid AS RepresentativeUserId, tp.LocalizationId, 
                      pd.Alert, pd.Provision, pd.PendingInvoicePayment
FROM         dbo.tb_Process AS tp LEFT OUTER JOIN
                      dbo.tb_ProcessCreditor AS tpc ON tp.ProcessId = tpc.ProcessId LEFT OUTER JOIN
                      dbo.tb_ProcessExecuted AS tpe ON tp.ProcessId = tpe.ProcessId LEFT OUTER JOIN
                      dbo.tb_Court AS tc ON tp.CourtId = tc.CourtId LEFT OUTER JOIN
                      dbo.tb_Creditor AS tcr ON tpc.CreditorId = tcr.CreditorId LEFT OUTER JOIN
                      dbo.tb_Executed AS te ON tpe.ExecutedId = te.ExecutedId LEFT OUTER JOIN
                      dbo.tb_Representative AS tr ON tp.RepresentativeId = tr.RepresentativeId LEFT OUTER JOIN
                      dbo.aspnet_Users AS au ON tp.AlterUserId = au.UserId LEFT OUTER JOIN
                      dbo.tb_ProcessDetail AS pd ON tp.ProcessId = pd.ProcessId
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
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
         Begin Table = "tp"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 125
               Right = 211
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "tpc"
            Begin Extent = 
               Top = 6
               Left = 249
               Bottom = 95
               Right = 409
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "tpe"
            Begin Extent = 
               Top = 96
               Left = 249
               Bottom = 185
               Right = 409
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "tc"
            Begin Extent = 
               Top = 126
               Left = 38
               Bottom = 245
               Right = 198
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "tcr"
            Begin Extent = 
               Top = 186
               Left = 236
               Bottom = 305
               Right = 396
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "te"
            Begin Extent = 
               Top = 246
               Left = 38
               Bottom = 365
               Right = 198
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "tr"
            Begin Extent = 
               Top = 306
               Left = 236
               Bottom = 425
               Right = 409
            End
            DisplayFlags = 280
            TopColumn = 0
      ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vwProcess'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'   End
         Begin Table = "au"
            Begin Extent = 
               Top = 366
               Left = 38
               Bottom = 485
               Right = 217
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "pd"
            Begin Extent = 
               Top = 486
               Left = 38
               Bottom = 605
               Right = 265
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 22
         Width = 284
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vwProcess'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vwProcess'
GO
/****** Object:  View [dbo].[vwProcessInfo]    Script Date: 12/30/2011 02:10:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE view [dbo].[vwProcessInfo]
as(
SELECT     tp.ProcessId, tp.Code + '/' + CAST(tp.Number AS varchar(5)) + '/' + CAST(tp.Year AS varchar(5)) + '/' + tp.Initials AS internalNumber, tp.ProcessNumber, tp.Observation, 
                      ISNULL(tp.ExesAE, '0') AS ExesAE, ISNULL(tp.Value, '0') AS Value, tp.Classification, ts.Name AS Section, tp.Enforcement, tp.AlterDate, au.UserName AS AlterUser, 
                      tp.AlterDate1, au2.UserName AS AlterUser1, tp.AlterDate2, au3.UserName AS AlterUser2, tp.Localization,et.Name as 'ExecutionType',tp.LocalizationDetail
                      ,tp.LocalizationId
FROM         dbo.tb_Process AS tp LEFT OUTER JOIN
                      dbo.aspnet_Users AS au ON tp.AlterUserId = au.UserId LEFT OUTER JOIN
                      dbo.aspnet_Users AS au2 ON tp.AlterUserId1 = au2.UserId LEFT OUTER JOIN
                      dbo.aspnet_Users AS au3 ON tp.AlterUserId2 = au3.UserId LEFT OUTER JOIN
                      dbo.tb_Section AS ts ON tp.SectionId = ts.SectionId
                      left join tb_ExecutionType et on tp.ExecutionTypeId=et.ExecutionTypeId
)
GO
/****** Object:  View [dbo].[vwExecuted]    Script Date: 12/30/2011 02:10:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vwExecuted]
AS
	SELECT     te.ExecutedId, te.Name, te.Address, te.Phone, te.MPhone, te.Fax, te.Email, te.IdentityCard, te.NifNipl, te.Nifs, CONVERT(varchar(10), te.BornDate, 105) AS BornDate, 
						  au.UserName AS AlterUser, te.AlterDate, te.Active
	FROM         dbo.tb_Executed AS te LEFT OUTER JOIN
						  dbo.aspnet_Users AS au ON te.AlterUserId = au.UserId
GO
/****** Object:  View [dbo].[vwCreditor]    Script Date: 12/30/2011 02:10:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vwCreditor]
AS
	SELECT     tc.CreditorId, tc.Name, tc.Address, tc.Phone, tc.MPhone, tc.Fax, tc.Email, tc.IdentityCard, tc.NifNipl, tc.Nifs, CONVERT(varchar(10), tc.BornDate, 105) AS BornDate, 
						  au.UserName AS AlterUser, tc.AlterDate, tc.Active
	FROM         dbo.tb_Creditor AS tc LEFT OUTER JOIN
						  dbo.aspnet_Users AS au ON tc.AlterUserId = au.UserId
GO
/****** Object:  View [dbo].[vwCourt]    Script Date: 12/30/2011 02:10:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vwCourt]
AS
	SELECT     TOP (100) PERCENT tc.CourtId, tc.Name, tc.Address, tc.Phone, tc.Fax, tc.Email,tc.JudicialDistrict, au.UserName AS AlterUser, tc.AlterDate, tc.active
	FROM         dbo.tb_Court AS tc INNER JOIN
						  dbo.aspnet_Users AS au ON tc.AlterUserId = au.UserId
GO
/****** Object:  View [dbo].[vwProcessAttachment]    Script Date: 12/30/2011 02:10:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[vwProcessAttachment]
as(
	select ta.AttachmentId,te.ExecutedId,tpa.value,tpa.ProcessId,te.Name as 'ExecutedName',ta.Name as 'AttachmentName'
	from tb_Attachment ta
		left join tb_ProcessAttachment tpa on ta.AttachmentId=tpa.AttachmentId
		left join tb_Executed te on tpa.ExecutedId=te.ExecutedId
)
GO
/****** Object:  View [dbo].[vwProcessCourt]    Script Date: 12/30/2011 02:10:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vwProcessCourt]
AS
SELECT     tp.ProcessId, tc.CourtId, tc.Name, tc.Address, tc.Phone, tc.Fax, tc.Email,tc.JudicialDistrict
FROM         dbo.tb_Court AS tc LEFT OUTER JOIN
                      dbo.tb_Process AS tp ON tc.CourtId = tp.CourtId
GO
/****** Object:  View [dbo].[vwProcessCreditor]    Script Date: 12/30/2011 02:10:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vwProcessCreditor]
AS
	SELECT     TOP (100) PERCENT tpc.ProcessId, tc.CreditorId, tc.Name, tc.Address, tc.Phone, tc.MPhone, tc.Fax, tc.Email, tc.IdentityCard, tc.NifNipl, tc.Nifs, tc.BornDate
	FROM         dbo.tb_Creditor AS tc LEFT OUTER JOIN
						  dbo.tb_ProcessCreditor AS tpc ON tc.CreditorId = tpc.CreditorId
	ORDER BY tc.Name
GO
/****** Object:  View [dbo].[vwProcessEmployer]    Script Date: 12/30/2011 02:10:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE view [dbo].[vwProcessEmployer]
as(
SELECT tpe.ProcessId, te.Name AS EmployerName, te.Address, te.Phone, te.Fax, te.Email, tex.Name AS ExecutedName, te.EmployerdId
	,tex.ExecutedId
FROM dbo.tb_Employer AS te INNER JOIN
	dbo.tb_ProcessEmployer AS tpe ON te.EmployerdId = tpe.EmployerId INNER JOIN
	dbo.tb_Executed AS tex ON tpe.ExecutedId = tex.ExecutedId
)
GO
/*
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[vwReport]
as(
	select pp.ProcessId
		,UPPER(CAST(p.Code AS nvarchar(4)) + '/' + SUBSTRING('0000' + CAST(p.Number AS nvarchar(10)), LEN(p.Number) + 1, 4)+isnull(p.Alt,'')+ 
			+ '/' + CAST(p.Year AS nvarchar(4)) + (CASE WHEN LEN(p.Initials) > 0 THEN '/' + p.Initials ELSE '' END)) AS InternalNumber
		,e.Name as 'Executed',convert(varchar(30),pp.[Date],105) as 'Date',
		CONVERT(varchar, CONVERT(money, pp.Value), 1) + ' €' as 'Value',
		pt.Name as 'PaymentType',pp.Account,r.Name as 'Representative',em.Name as 'Employer'
	from tb_ProcessPayment pp
		left join tb_Process p on pp.ProcessId=p.ProcessId
		left join tb_PaymentType pt on pp.PaymentTypeId=pt.PaymentTypeId
		left join tb_Representative r on pp.RepresentativeId=r.RepresentativeId
		left join tb_Executed e on pp.ExecutedId=e.ExecutedId
		left join tb_Employer em on pp.EmployerId=em.EmployerdId
)
GO
*/
/****** Object:  View [dbo].[vwProcessProvision]    Script Date: 12/30/2011 02:10:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vwProcessProvision]
AS
SELECT     tp.ProcessId, CAST(tp.ProcessId AS nvarchar(5)) + '|' + CAST(tp.ExecutedId AS nvarchar(5)) + '|' + CONVERT(nvarchar(12), tp.Date, 103) AS id, CONVERT(varchar(30), 
                      tp.Date, 103) + ' - ' + te.Name AS Name, tp.Payed
FROM         dbo.tb_Provision AS tp LEFT OUTER JOIN
                      dbo.tb_Process AS tpr ON tp.ProcessId = tpr.ProcessId LEFT OUTER JOIN
                      dbo.tb_Executed AS te ON tp.ExecutedId = te.ExecutedId
WHERE     (tp.ProcessId = 2)
GO
/****** Object:  View [dbo].[vwProcessSearch]    Script Date: 12/30/2011 02:10:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[vwProcessSearch]
as(
	select ps.SearchId,ps.ProcessId,ps.ExecutedId,ps.Date,ps.Value,ps.Obs,s.Name as 'SearchName',e.Name as 'ExecutedName'
	from tb_ProcessSearch ps
		left join tb_Search s on ps.SearchId=s.SearchId
		left join tb_Executed e on ps.ExecutedId=e.ExecutedId
)
GO
/****** Object:  View [dbo].[vwProcessExecuted]    Script Date: 12/30/2011 02:10:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vwProcessExecuted]
AS
	SELECT     tpe.ProcessId, te.ExecutedId, te.Name, te.Address, te.Phone, te.MPhone, te.Fax, te.Email, te.IdentityCard, te.NifNipl, te.Nifs, te.BornDate
	FROM         dbo.tb_Executed AS te LEFT OUTER JOIN
						  dbo.tb_ProcessExecuted AS tpe ON te.ExecutedId = tpe.ExecutedId
GO
/****** Object:  View [dbo].[vwProcessFile]    Script Date: 12/30/2011 02:10:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[vwProcessFile]
as(
	select ProcessId,Name,SecureName,UserPermission,RepresentativePermission
	from tb_processfile pf
)
GO
/****** Object:  View [dbo].[vwRepresentativeInformation]    Script Date: 12/30/2011 02:10:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vwRepresentativeInformation]
AS
SELECT     ProcessId, RepresentativeId, Date, ISNULL(CreateUser, '') + ' - ' + Information AS Information
FROM         dbo.tb_ProcessRepresentativeInformation
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
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
         Begin Table = "tb_ProcessRepresentativeInformation"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 125
               Right = 211
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vwRepresentativeInformation'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vwRepresentativeInformation'
GO
/****** Object:  View [dbo].[vwProcessRepresentative]    Script Date: 12/30/2011 02:10:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vwProcessRepresentative]
AS
SELECT     tp.ProcessId, tr.RepresentativeId, tr.Name, tr.Address, tr.Phone, tr.MPhone, tr.Fax, tr.Email,CarbonCopy
FROM         dbo.tb_Representative AS tr LEFT OUTER JOIN
                      dbo.tb_Process AS tp ON tr.RepresentativeId = tp.RepresentativeId
GO
/****** Object:  View [dbo].[vwSolicitor]    Script Date: 12/30/2011 02:10:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[vwSolicitor]
as
(
	select SolicitorId,Name+' - Cédula N.º'+CardNumber as 'Name' from tb_Solicitor
)
GO
/****** Object:  View [dbo].[vwUserSetting]    Script Date: 12/30/2011 02:10:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[vwUserSetting]
as
(
	select UserId,Theme,SearchResult from tb_UserSetting
)


GO

create procedure [dbo].[uspRepresentativeUpdateMnt]
@RepresentativeId int,
@Name nvarchar(100),
@Address nvarchar(100),
@Phone nvarchar(50),
@Fax nvarchar(50),
@Email nvarchar(50),
@Nif nvarchar(50),
@CarbonCopy nvarchar(200),
@UserId uniqueidentifier,
@LawyerNumber nvarchar(50)
as
begin
	if @RepresentativeId>0
		update tb_Representative
		set Name=@Name,Address=@Address,Phone=@Phone,Fax=@Fax,Email=@Email,Nif=@Nif,CarbonCopy=@CarbonCopy,AlterDate=getdate(),AlterUserId=@UserId,LawyerNumber=@LawyerNumber
		where RepresentativeId=@RepresentativeId
	else
		insert into tb_Representative (Name,[Address],Phone,Fax,Email,Nif,CarbonCopy,CreateDate,CreateUserId,AlterDate,AlterUserId,LawyerNumber)
		values (@Name,@Address,@Phone,@Fax,@Email,@Nif,@CarbonCopy,getdate(),@UserId,getdate(),@UserId,@LawyerNumber)
end

go

CREATE view [dbo].[vwRepresentative]
as(
	SELECT     r.RepresentativeId, r.Name, r.Address, r.Phone, r.Fax, r.Email, r.Nif, r.CarbonCopy, au.UserName, r.AlterDate, r.LawyerNumber
	FROM         dbo.tb_Representative AS r LEFT OUTER JOIN
						  dbo.aspnet_Users AS au ON r.AlterUserId = au.UserId
)
GO
















































/*************************************************/
/*************************************************/

--	ALTERACOES
--	30-12-2011
/*

	- [uspRepresentativeUpdateMnt]
	- [uspRepresentative]
	- [uspUserSettingGet]
	-

*/

--	15-02-2012

--	select * from tb_Calendar
create table dbo.tb_Calendar
(
	CalendarId int identity not null,
	CDate datetime not null,
	Observation nvarchar(4000) not null,
	Checked bit default(0) not null,
	AssignedUser nvarchar(50) not null,
	CloseDate datetime not null,
	CreateDate datetime not null,
	CreateUser nvarchar(50) not null,
	AlterDate datetime not null,
	AlterUser nvarchar(50) not null,
	constraint pk_c_CalendarId primary key(CalendarId)
)

--	insert into tb_Calendar values (getdate()-1,'teste',0,getdate(),'telmo',getdate(),'telmo')
--	insert into tb_Calendar values (getdate()-2,'teste 1000',0,getdate(),'telmo',getdate(),'telmo')



create table dbo.tb_ProcessGHistory
(
	Id int identity not null,
	ProcessGId int not null,
	Field nvarchar(50) not null,
	FromValue nvarchar(4000),
	ToValue nvarchar(4000) not null,
	AlterUser nvarchar(50) not null,
	AlterDate datetime not null,
	constraint pk_pgh_id primary key (Id),
	constraint fk_pgh_pgid foreign key (ProcessGId) references tb_ProcessG(ProcessGId)
)









