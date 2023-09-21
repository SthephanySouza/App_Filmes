use Filmes_Db
go

set identity_insert [dbo].[Generos] on
go
insert [dbo].[Generos]([IdGenero], [NomeGenero]) values (1, 'Ação')
go
insert [dbo].[Generos]([IdGenero], [NomeGenero]) values (2, 'Comédia')
go
insert [dbo].[Generos]([IdGenero], [NomeGenero]) values (3, 'Ficção')
go
set identity_insert [dbo].[Generos] off
go

set identity_insert [dbo].[Diretores] on
go
insert [dbo].[Diretores]([IdDiretor], [NomeDiretor], [MaiorObra]) values(1, 'Chris Columbus', 'Quarteto Fantástico')
go
insert [dbo].[Diretores]([IdDiretor], [NomeDiretor], [MaiorObra]) values(2, 'Nina Jacobson', 'Como Eu Era Antes de Você')
go
insert [dbo].[Diretores]([IdDiretor], [NomeDiretor], [MaiorObra]) values(3, 'Louis Leterrier', 'Velozes e Furiosos 10')
go
set identity_insert [dbo].[Diretores] off
go

set identity_insert [dbo].[Atores] on
go
insert [dbo].[Atores]([IdAtor], [NomeAtor], [ObraTrab]) values(1, 'Mahershala Ali', 'Luke Cage')
go
insert [dbo].[Atores]([IdAtor], [NomeAtor], [ObraTrab]) values(2, 'Jennifer Lawrence', 'Jogos Vorazes: A Esperança – Parte 1')
go
insert [dbo].[Atores]([IdAtor], [NomeAtor], [ObraTrab]) values(3, 'Omar Sy', 'Inferno')
go
set identity_insert [dbo].[Atores] off
go

set identity_insert [dbo].[Filmes] on
go
insert [dbo].[Filmes]([IdFilme], [NomeFilme], [Classificacao], [DataLanc], [Idioma], [Genero], [Diretor], [Ator])
		values(1, 'The Takedown', 16, CAST(N'2022-05-06' AS Date), 'Francês', 2, 3, 3)
go
insert [dbo].[Filmes]([IdFilme], [NomeFilme], [Classificacao], [DataLanc], [Idioma], [Genero], [Diretor], [Ator])
		values(2, 'Marvel - Luke Cage', 16, CAST(N'2016-06-30' AS Date), 'Inglês', 1, 1, 2)
go
insert [dbo].[Filmes]([IdFilme], [NomeFilme], [Classificacao], [DataLanc], [Idioma], [Genero], [Diretor], [Ator])
		values(3, 'Jogos Vorazes: A Esperança – Parte 1', 14, CAST(N'2014-11-19' AS Date), 'Inglês', 3, 2, 2)
go
set identity_insert [dbo].[Filmes] off
go

select * from [dbo].[Generos]
select * from [dbo].[Diretores]
select * from [dbo].[Atores]
select * from [dbo].[Filmes]