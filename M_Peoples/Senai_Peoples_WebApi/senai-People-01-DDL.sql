CREATE DATABASE M_Peoples;


USE M_Peoples;

CREATE TABLE Funcionarios
(
idFcnr INT PRIMARY KEY IDENTITY,

nome VARCHAR(200) NOT NULL,

sobrenome VARCHAR(200) NOT NULL,
);