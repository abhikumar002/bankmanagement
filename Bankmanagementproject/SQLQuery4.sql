Create database BANK;
GO

Use BANK;
GO

CREATE TABLE accountdetail(
	[id] [nvarchar](50) NOT NULL,
	[acctype] [nvarchar](50) NULL,
	[name] [nvarchar](50) NULL,
	[dob] [nvarchar](50) NULL,
	[nominee] [nvarchar](50) NULL,
	[balance] [decimal](18, 0) NULL,
 CONSTRAINT [PK_accountdetail] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


CREATE TABLE atmdetail(
	[id] [nvarchar](50) NOT NULL,
	[atmpin] [nchar](4) NULL,
 CONSTRAINT [PK_atmdetail] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE branches(
	[bankname] [nvarchar](50) NOT NULL,
	[branchcode] [nvarchar](50) NOT NULL,
	[username] [nvarchar](50) NOT NULL,
	[password] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_branches] PRIMARY KEY CLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE trans(
	[accType] [nvarchar](50) NOT NULL,
	[accNum] [nvarchar](50) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[transType] [nvarchar](50) NOT NULL,
	[TransAmt] [decimal](18, 0) NOT NULL,
	[Date] [datetime] NOT NULL
) ON [PRIMARY]

GO
