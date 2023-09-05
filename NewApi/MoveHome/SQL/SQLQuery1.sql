create database FilmesDb
go

use FilmesDb
go

create table tbGenero(
	IdGenero int primary key identity(1,1),
	NomeGenero varchar(200) not null
)
go

create table tbDiretor(
	IdDiretor int primary key identity(1,1),
	NomeDiretor varchar(200) not null,
	MaiorObra varchar(200) not null
)
go

create table tbAtor(
	IdAtor int primary key identity(1,1),
	NomeAtor varchar(200) not null, 
	ObraTrab varchar(200) not null
)
go

create table tbFilme(
	IdFilme int primary key identity(1,1),
	NomeFilme varchar(200) not null,
	Classific int not null,
	DataLanc date not null,
	Idioma varchar(60) not null,
	IdGenero int FOREIGN KEY REFERENCES tbGenero(IdGenero),
	IdDiretor int FOREIGN KEY REFERENCES tbDiretor(IdDiretor),
	IdAtor int FOREIGN KEY REFERENCES tbAtor(IdAtor)
)
go

set identity_insert [dbo].[tbGenero] on
go
insert [dbo].[tbGenero]([IdGenero], [NomeGenero]) values (1, 'Ação')
go
insert [dbo].[tbGenero]([IdGenero], [NomeGenero]) values (2, 'Comédia')
go
insert [dbo].[tbGenero]([IdGenero], [NomeGenero]) values (3, 'Ficção')
go
set identity_insert [dbo].[tbGenero] off
go

set identity_insert [dbo].[tbDiretor] on
go
insert [dbo].[tbDiretor]([IdDiretor], [NomeDiretor], [MaiorObra]) values(1, 'Chris Columbus', 'Quarteto Fantástico')
go
insert [dbo].[tbDiretor]([IdDiretor], [NomeDiretor], [MaiorObra]) values(2, 'Nina Jacobson', 'Como Eu Era Antes de Você')
go
insert [dbo].[tbDiretor]([IdDiretor], [NomeDiretor], [MaiorObra]) values(3, 'Louis Leterrier', 'Velozes e Furiosos 10')
go
set identity_insert [dbo].[tbDiretor] off
go

set identity_insert [dbo].[tbAtor] on
go
insert [dbo].[tbAtor]([IdAtor], [NomeAtor], [ObraTrab]) values(1, 'Mahershala Ali', 'Luke Cage')
go
insert [dbo].[tbAtor]([IdAtor], [NomeAtor], [ObraTrab]) values(2, 'Jennifer Lawrence', 'Jogos Vorazes: A Esperança – Parte 1')
go
insert [dbo].[tbAtor]([IdAtor], [NomeAtor], [ObraTrab]) values(3, 'Omar Sy', 'Inferno')
go
set identity_insert [dbo].[tbAtor] off
go

set identity_insert [dbo].[tbFilme] on
go
insert [dbo].[tbFilme]([IdFilme], [NomeFilme], [Classific], [DataLanc], [Idioma], [IdGenero], [IdDiretor], [IdAtor])
		values(1, 'The Takedown', 16, CAST(N'2022-05-06' AS Date), 'Francês', 2, 3, 3)
go
insert [dbo].[tbFilme]([IdFilme], [NomeFilme], [Classific], [DataLanc], [Idioma], [IdGenero], [IdDiretor], [IdAtor])
		values(2, 'Marvel - Luke Cage', 16, CAST(N'2016-06-30' AS Date), 'Inglês', 1, 1, 2)
go
insert [dbo].[tbFilme]([IdFilme], [NomeFilme], [Classific], [DataLanc], [Idioma], [IdGenero], [IdDiretor], [IdAtor])
		values(3, 'Jogos Vorazes: A Esperança – Parte 1', 14, CAST(N'2014-11-19' AS Date), 'Inglês', 3, 2, 2)
go
set identity_insert [dbo].[tbFilme] off
go

select * from [dbo].[tbGenero]
select * from [dbo].[tbDiretor]
select * from [dbo].[tbAtor]
select * from [dbo].[tbFilme]