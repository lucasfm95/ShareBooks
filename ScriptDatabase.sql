use DeveloperDB01
go
-- Criação da tabela book
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
-- Criação da tabela Reader
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