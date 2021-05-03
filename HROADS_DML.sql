USE SENAI_HROADS_MANHA;
GO;

INSERT INTO TiposUsuarios (titulo)
VALUES ('Administrador'),
	   ('Usuario');
GO;


INSERT INTO Usuarios(nome,email, senha,idTipoUsuarios)
VALUES ('Pedro','adm@gmail.com','padmin',1),
	    ('Marta','martajoga@gmail.com','mj123',2);
GO;


UPDATE TiposUsuarios
SET titulo = 'Jogador' 
WHERE idTiposUsuarios=2;

