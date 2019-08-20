use DeveloperDB01
go
-- Cria��o da tabela book
create table Book(
	Id int identity(1,1) not null primary key,
	KeyId uniqueidentifier not null unique,
	Title varchar(100) null,
	SubTitle varchar(100) null,
	Publisher varchar(100) null,
	Author varchar(100) null,
	Edition varchar(10) null,
	YearEdition varchar(4) null,
	Active bit null,
)
go
-- create index table book
create index Index_KeyId ON Book (KeyId);
go
-- Cria��o da tabela Reader
create table Reader(
	Id int identity(1,1) not null primary key,
	KeyId uniqueidentifier not null unique,
	Name varchar(100) null,
	IdentityDocument varchar(100) null,
	Email varchar(100) null
)
go
-- create index table book
create index Index_KeyId ON Reader (KeyId);
go

create table BookLoan(
	Id int identity(1,1) not null primary key,
	KeyId uniqueidentifier not null unique,
	BookId int foreign key references Book(Id) null, 
	ReaderId int foreign key references Reader(Id) null, 
	BookLoanDate date null,
	BookLoanFeedback varchar(200) null,
	ExpectedReturnDate date null,
	ReturnDate date null,
	ReturnFeedback varchar(200) null
)
go

create index Index_KeyId ON BookLoan (KeyId);