CREATE TABLE [Student](
    [Student_ID] [nvarchar](10) NOT NULL,
    [Student_Name] [nvarchar](50) NOT NULL,
    [Student_Phone] [nvarchar](50) NOT NULL,
    [Student_Address] [nvarchar](50) NOT NULL,
    [Student_chk] [char](1) NULL,
    [Student_InDate] [datetime] NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
    [Student_ID] ASC
) 
) ON [PRIMARY]