USE [ElectricPower]
GO
/****** Object:  Table [dbo].[BaseUser]    Script Date: 2017/9/1 16:25:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BaseUser](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[Account] [nvarchar](50) NOT NULL,
	[UserPassword] [nvarchar](50) NOT NULL,
	[Code] [nvarchar](50) NULL,
	[RealName] [nvarchar](20) NULL,
	[Gender] [nvarchar](10) NULL,
	[Mobile] [nvarchar](20) NULL,
	[Telephone] [nvarchar](20) NULL,
	[OICQ] [nvarchar](20) NULL,
	[Email] [nvarchar](50) NULL,
	[ChangePasswordDate] [datetime] NULL,
	[LogOnCount] [int] NULL,
	[FirstVisit] [datetime] NULL,
	[PreviousVisit] [datetime] NULL,
	[LastVisit] [datetime] NULL,
	[AuditStatus] [int] NULL,
	[AuditUserId] [int] NULL,
	[AuditUserName] [nvarchar](50) NULL,
	[AuditDateTime] [datetime] NULL,
	[Remark] [nvarchar](100) NULL,
	[Enabled] [int] NULL,
	[SortCode] [int] NULL,
	[DeleteMark] [int] NULL,
	[CreateTime] [datetime] NOT NULL,
	[CreateUserId] [int] NULL,
	[CreateUserName] [nvarchar](50) NULL,
	[ModifyDate] [datetime] NULL,
	[ModifyUserId] [int] NULL,
	[ModifyUserName] [nvarchar](50) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Module]    Script Date: 2017/9/1 16:25:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Module](
	[ModuleId] [int] IDENTITY(1,1) NOT NULL,
	[ModuleName] [nvarchar](50) NOT NULL,
	[ParentId] [int] NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[Sort] [int] NOT NULL,
	[CreateUserId] [int] NOT NULL,
	[ControllerName] [varchar](50) NULL,
	[ActionName] [varchar](50) NULL,
	[Code] [nvarchar](100) NULL,
	[Icon] [nvarchar](50) NULL,
	[ModuleLevel] [int] NULL,
	[IsShow] [int] NULL,
 CONSTRAINT [PK_Module] PRIMARY KEY CLUSTERED 
(
	[ModuleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ModuleOperate]    Script Date: 2017/9/1 16:25:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ModuleOperate](
	[ModuleOperateId] [int] IDENTITY(1,1) NOT NULL,
	[ModuleOperateName] [nvarchar](50) NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[CreateUserId] [int] NOT NULL,
	[CreateUserName] [nvarchar](50) NOT NULL,
	[Enabled] [int] NOT NULL,
	[ModuleId] [int] NOT NULL,
	[JsEvent] [nvarchar](50) NULL,
	[Icon] [nvarchar](50) NULL,
	[Code] [nvarchar](50) NULL,
	[Sort] [int] NULL,
 CONSTRAINT [PK_ModuleOperate] PRIMARY KEY CLUSTERED 
(
	[ModuleOperateId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ModuleOperateRole]    Script Date: 2017/9/1 16:25:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ModuleOperateRole](
	[ModuleOperateRoleId] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [int] NOT NULL,
	[ModuleOperateId] [int] NOT NULL,
 CONSTRAINT [PK_ModuleOperateRole] PRIMARY KEY CLUSTERED 
(
	[ModuleOperateRoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ModuleRole]    Script Date: 2017/9/1 16:25:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ModuleRole](
	[ModuleRoleId] [int] IDENTITY(1,1) NOT NULL,
	[ModuleId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
 CONSTRAINT [PK_ModuleRole] PRIMARY KEY CLUSTERED 
(
	[ModuleRoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Role]    Script Date: 2017/9/1 16:25:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](50) NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[CreateUserId] [int] NOT NULL,
	[Sort] [int] NOT NULL,
	[Code] [nvarchar](50) NULL,
	[Remark] [nvarchar](50) NULL,
	[DeleteMark] [int] NULL,
	[CreateUserName] [nvarchar](50) NULL,
	[ModifyDate] [datetime] NULL,
	[ModifyUserId] [int] NULL,
	[ModifyUserName] [nvarchar](50) NULL,
 CONSTRAINT [PK_ep] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SysLog]    Script Date: 2017/9/1 16:25:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SysLog](
	[SysLogId] [int] IDENTITY(1,1) NOT NULL,
	[ModuleId] [int] NULL,
	[IPAddress] [varchar](50) NULL,
	[IPAddressName] [nvarchar](100) NULL,
	[LogType] [int] NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[CreateUserId] [int] NULL,
	[CreateUserName] [nvarchar](50) NULL,
	[Remark] [nvarchar](100) NULL,
	[Status] [int] NOT NULL,
	[ObjectId] [nvarchar](50) NULL,
 CONSTRAINT [PK_SysLog] PRIMARY KEY CLUSTERED 
(
	[SysLogId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SysLOgDetail]    Script Date: 2017/9/1 16:25:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SysLOgDetail](
	[SysLogDetailId] [int] NOT NULL,
	[SysLogId] [int] NOT NULL,
	[PropertyName] [nvarchar](50) NULL,
	[PropertyField] [nvarchar](50) NULL,
	[NewValue] [nvarchar](1000) NULL,
	[OldValue] [nvarchar](1000) NULL,
	[CreateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_SysLOgDetail] PRIMARY KEY CLUSTERED 
(
	[SysLogDetailId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserRole]    Script Date: 2017/9/1 16:25:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRole](
	[UserRoleId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
 CONSTRAINT [PK_UserRole] PRIMARY KEY CLUSTERED 
(
	[UserRoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[BaseUser] ADD  CONSTRAINT [DF_BaseUser_LogOnCount]  DEFAULT ((1)) FOR [LogOnCount]
GO
ALTER TABLE [dbo].[BaseUser] ADD  CONSTRAINT [DF_BaseUser_AuditStatus]  DEFAULT ((1)) FOR [AuditStatus]
GO
ALTER TABLE [dbo].[BaseUser] ADD  CONSTRAINT [DF_BaseUser_SortCode]  DEFAULT ((1)) FOR [SortCode]
GO
ALTER TABLE [dbo].[BaseUser] ADD  CONSTRAINT [DF_BaseUser_DeleteMark]  DEFAULT ((0)) FOR [DeleteMark]
GO
ALTER TABLE [dbo].[ModuleOperate]  WITH CHECK ADD  CONSTRAINT [FK_ModuleOperate_Module] FOREIGN KEY([ModuleId])
REFERENCES [dbo].[Module] ([ModuleId])
GO
ALTER TABLE [dbo].[ModuleOperate] CHECK CONSTRAINT [FK_ModuleOperate_Module]
GO
ALTER TABLE [dbo].[ModuleRole]  WITH CHECK ADD  CONSTRAINT [FK_ModuleRole_Role] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([RoleId])
GO
ALTER TABLE [dbo].[ModuleRole] CHECK CONSTRAINT [FK_ModuleRole_Role]
GO
ALTER TABLE [dbo].[SysLog]  WITH CHECK ADD  CONSTRAINT [FK_SysLog_BaseUser] FOREIGN KEY([CreateUserId])
REFERENCES [dbo].[BaseUser] ([UserId])
GO
ALTER TABLE [dbo].[SysLog] CHECK CONSTRAINT [FK_SysLog_BaseUser]
GO
ALTER TABLE [dbo].[SysLog]  WITH CHECK ADD  CONSTRAINT [FK_SysLog_Module] FOREIGN KEY([ModuleId])
REFERENCES [dbo].[Module] ([ModuleId])
GO
ALTER TABLE [dbo].[SysLog] CHECK CONSTRAINT [FK_SysLog_Module]
GO
ALTER TABLE [dbo].[SysLOgDetail]  WITH CHECK ADD  CONSTRAINT [FK_SysLOgDetail_SysLog] FOREIGN KEY([SysLogId])
REFERENCES [dbo].[SysLog] ([SysLogId])
GO
ALTER TABLE [dbo].[SysLOgDetail] CHECK CONSTRAINT [FK_SysLOgDetail_SysLog]
GO
ALTER TABLE [dbo].[UserRole]  WITH CHECK ADD  CONSTRAINT [FK_UserRole_Role] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([RoleId])
GO
ALTER TABLE [dbo].[UserRole] CHECK CONSTRAINT [FK_UserRole_Role]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登录' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaseUser', @level2type=N'COLUMN',@level2name=N'Account'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户编码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaseUser', @level2type=N'COLUMN',@level2name=N'Code'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'性别' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaseUser', @level2type=N'COLUMN',@level2name=N'Gender'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'手机号码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaseUser', @level2type=N'COLUMN',@level2name=N'Mobile'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'电话号码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaseUser', @level2type=N'COLUMN',@level2name=N'Telephone'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'QQ号码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaseUser', @level2type=N'COLUMN',@level2name=N'OICQ'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最后修改密码的日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaseUser', @level2type=N'COLUMN',@level2name=N'ChangePasswordDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登录次数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaseUser', @level2type=N'COLUMN',@level2name=N'LogOnCount'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'第一次访问时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaseUser', @level2type=N'COLUMN',@level2name=N'FirstVisit'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'上一次访问时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaseUser', @level2type=N'COLUMN',@level2name=N'PreviousVisit'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'审核状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaseUser', @level2type=N'COLUMN',@level2name=N'AuditStatus'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'0无效 1有效' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaseUser', @level2type=N'COLUMN',@level2name=N'Enabled'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'排序' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaseUser', @level2type=N'COLUMN',@level2name=N'SortCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'删除标记 1删除0不删除' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaseUser', @level2type=N'COLUMN',@level2name=N'DeleteMark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'排序' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Module', @level2type=N'COLUMN',@level2name=N'Sort'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'控制器' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Module', @level2type=N'COLUMN',@level2name=N'ControllerName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'方法' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Module', @level2type=N'COLUMN',@level2name=N'ActionName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Module', @level2type=N'COLUMN',@level2name=N'Code'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'图标' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Module', @level2type=N'COLUMN',@level2name=N'Icon'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'等级' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Module', @level2type=N'COLUMN',@level2name=N'ModuleLevel'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否显示1显示0不显示' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Module', @level2type=N'COLUMN',@level2name=N'IsShow'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'模块操作名字' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ModuleOperate', @level2type=N'COLUMN',@level2name=N'ModuleOperateName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'模块Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysLog', @level2type=N'COLUMN',@level2name=N'ModuleId'
GO
