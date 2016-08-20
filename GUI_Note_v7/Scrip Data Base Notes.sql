--creacion de base de datos para el bloc de notas
CREATE DATABASE blocNotes;
go
--use de database
use blocNotes;
go
--creacion de tabla del bloc de notas
CREATE TABLE blocs(
	idBloc	int identity (1,1) NOT NULL,
	texto	text NULL,
	constraint pk_idBloc primary key (idBloc)
);