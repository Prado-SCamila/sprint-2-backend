USE SENAI_HROADS_MANHA;
GO;


CREATE TABLE TiposUsuarios
(
idTiposUsuarios iNT PRIMARY KEY IDENTITY,
titulo VARCHAR(300)
)
GO;

CREATE TABLE Usuarios
(
idUsuarios INT PRIMARY KEY IDENTITY,
nome VARCHAR(300),
email VARCHAR(300),
senha VARCHAR(300),
idTipoUsuarios INT FOREIGN KEY REFERENCES TiposUsuarios(idTiposUSuarios)
)
GO;

SELECT * FROM Usuarios;

