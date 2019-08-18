use DeveloperDB01

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

-- create index table book
create index Index_KeyId ON Book (KeyId);