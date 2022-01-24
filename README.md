# Tecnologias utilizadas:
C#,
.NetCore,
EntityFramework,
Banco de Dados SqlServer


Scripts

create table Integrantes
(
	Id int,
	Nome varchar(100)
	)

insert Integrantes values(1,'Marcelo')
insert Integrantes values(2,'Amanda')
insert Integrantes values(3,'Patricia')

create table Posts
(
	Id int,
	Texto varchar(100)
)

insert Posts values(1,'A vida de José')
insert Posts values(2,'Novela das 9')
insert Posts values(3,'O Descobrimento do Brasil')

create table Servico
(
	Id int,
	Descricao varchar(100)
)

insert Servico values(1,'Pintura')
insert Servico values(2,'Lanternagem')
insert Servico values(3,'Pedreiro')
