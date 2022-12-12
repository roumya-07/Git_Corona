CREATE DATABASE [DBCorona]

USE [DBCorona]

CREATE TABLE [dbo].[Block](
	[BlockID] [int] IDENTITY(1,1) NOT NULL,
	[StateID] [int] NULL,
	[BlockName] [nvarchar](50) NULL,
 CONSTRAINT [PK_Block] PRIMARY KEY CLUSTERED 
(
	[BlockID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


CREATE TABLE [dbo].[CoronaStatus](
	[CoronaID] [int] IDENTITY(1,1) NOT NULL,
	[PanchyatID] [int] NULL,
	[CitizenName] [nvarchar](50) NULL,
	[AffectedDate] [date] NULL,
	[Status] [int] NULL,
 CONSTRAINT [PK_CoronaStatus] PRIMARY KEY CLUSTERED 
(
	[CoronaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


CREATE TABLE [dbo].[Panchyat](
	[PanchyatID] [int] IDENTITY(1,1) NOT NULL,
	[BlockID] [int] NULL,
	[PanchyatName] [nvarchar](50) NULL,
 CONSTRAINT [PK_Panchyat] PRIMARY KEY CLUSTERED 
(
	[PanchyatID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


CREATE TABLE [dbo].[State](
	[StateID] [int] IDENTITY(1,1) NOT NULL,
	[StateName] [nvarchar](50) NULL,
 CONSTRAINT [PK_State] PRIMARY KEY CLUSTERED 
(
	[StateID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


CREATE TABLE [dbo].[Status](
	[StatusID] [int] IDENTITY(1,1) NOT NULL,
	[StatusName] [nvarchar](50) NULL,
 CONSTRAINT [PK_Status] PRIMARY KEY CLUSTERED 
(
	[StatusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


CREATE TABLE [dbo].[UserDetails](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [nvarchar](50) NULL,
	[UserName] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[PhoneNo] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[CreateDate] [datetime] NULL,
 CONSTRAINT [PK_UserDetails] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


CREATE procedure [dbo].[Sp_CoronaDetails](@action varchar(10),@ID int=0,@UserID nvarchar(50)='',@UserName nvarchar(50)='',@Password nvarchar(50)='',@PhoneNo nvarchar(50)='',@Email nvarchar(50)='',
@CoronaID int=0,@PanchyatID int=0,@CitizenName nvarchar(50)='',@AffectedDate date=null,@status int=0,@stateID int=0,@BlockID int=0)
as begin
if @action='Uinsert'
	begin
	--search id not find then insert
	if @ID=0
	insert into UserDetails(UserID,UserName,Password,PhoneNo,Email,CreateDate)
	values(@UserID,@UserName,@Password,@PhoneNo,@Email,GETDATE())
	else
	  begin
	  --check password is avaial or not then update details
		if @Password=''
		begin
	    update UserDetails set UserName=@UserName,PhoneNo=@PhoneNo,Email=@Email where ID=@ID 
		end
		else
		begin
		-- finally udate password here
		update UserDetails set Password=@Password where ID=@ID
		end
	  end
	end
else if @action='USelect'
    begin
	if @Password =''
	select * from UserDetails where UserID=@UserID
	else
	select * from UserDetails where UserID=@UserID and Password=@Password 
    end
else if @action= 'Cinsert'
	begin
	insert into CoronaStatus(PanchyatID,CitizenName,AffectedDate,Status)values(@PanchyatID,@CitizenName,@AffectedDate,@status)
	end
else if @action='Ccount'
	begin
	select s.StateName,count(cs.Status) as Affected,(select count(Status)from CoronaStatus as css inner join Panchyat pa on css.PanchyatID=pa.PanchyatID
	inner join Block as bl on pa.BlockID=bl.BlockID inner join State as st on bl.StateID=st.StateID
	where st.StateID=s.StateID and css.Status=1 group by st.StateID) 
	Death from CoronaStatus cs inner join Panchyat p on cs.PanchyatID=p.PanchyatID  
	inner join Block b on p.BlockID=b.BlockID inner join State s on s.StateID=b.StateID group by s.StateName,s.StateID 
	end
else if @action='Sselect'
begin
select * from State
end
else if @action='Bselect'
begin 
select * from Block where StateID=@stateID 
end
else if @action ='Pselect'
begin
select * from Panchyat where BlockID=@BlockID 
end
end