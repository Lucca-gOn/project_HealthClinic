--DDL - Data Definition Language 
--Criar o banco de dados
CREATE DATABASE [HealthClinic_manha];

USE [HealthClinic_manha];

--Criar tabelas
CREATE TABLE tb_TipoDeUsuario
(
	IdTipoDeUsuario INT PRIMARY KEY IDENTITY,    --IDENTITY É UM AUTO ENCREMENTO
	TituloTipoUsuario VARCHAR(40) NOT NULL UNIQUE
)

CREATE TABLE tb_Clinica
(
	IdClinica INT PRIMARY KEY IDENTITY,
	Endereco VARCHAR(30) NOT NULL,
	HoraInicio TIME NOT NULL,
	HoraFim TIME NOT NULL,
	CNPJ VARCHAR(14) NOT NULL UNIQUE,
	NomeFantasia VARCHAR(30) NOT NULL,
	RazaoSocial VARCHAR(30) NOT NULL UNIQUE
)

CREATE TABLE tb_Especialidade 
(
	IdEspecialidade INT PRIMARY KEY IDENTITY,
	DescricaoEspecialidade VARCHAR (3000) NOT NULL
)

CREATE TABLE tb_StatusConsulta
(
	IdStatusConsulta INT PRIMARY KEY IDENTITY,
	DescricaoStatusConsulta VARCHAR (3000) NOT NULL
)

CREATE TABLE tb_Prontuario
(
	IdProntuario INT PRIMARY KEY IDENTITY,
	DescricaoProntuario VARCHAR (3000) NOT NULL
)

CREATE TABLE tb_Usuario
(
	IdUsuario INT PRIMARY KEY IDENTITY,
	IdTipoDeUsuario INT FOREIGN KEY REFERENCES tb_TipoDeUsuario(IdTipoDeUsuario) NOT NULL,
	NomeUsuario VARCHAR (256) NOT NULL,
	EmailUsuario VARCHAR(256) NOT NULL UNIQUE,
	Senha VARCHAR(50) NOT NULL,
	DataNascimento DATE NOT NULL
)

CREATE TABLE tb_Paciente
(
	IdPaciente INT PRIMARY KEY IDENTITY,
	IdUsuario INT FOREIGN KEY REFERENCES tb_Usuario(IdUsuario) NOT NULL,
	CPF VARCHAR(11) NOT NULL UNIQUE,
	RG VARCHAR(15) NOT NULL UNIQUE,
	Telefone VARCHAR(20) NOT NULL,
	EnderecoPaciente VARCHAR(60) NOT NULL
)

CREATE TABLE tb_Medico
(
	IdMedico INT PRIMARY KEY IDENTITY,
	IdUsuario INT FOREIGN KEY REFERENCES tb_Usuario(IdUsuario) NOT NULL,
	IdClinica INT FOREIGN KEY REFERENCES tb_Clinica(IdClinica) NOT NULL,
	CRM VARCHAR(10) NOT NULL UNIQUE
)

CREATE TABLE tb_Medico_tb_Especialidade
(
	IdMedico_IdEspecialidade INT PRIMARY KEY IDENTITY,
	IdMedico INT FOREIGN KEY REFERENCES tb_Medico(IdMedico),
	IdEspecialidade INT FOREIGN KEY REFERENCES tb_Especialidade(IdEspecialidade)
)

CREATE TABLE tb_Consulta
(
	IdConsulta INT PRIMARY KEY IDENTITY,
	IdPaciente INT FOREIGN KEY REFERENCES tb_Paciente(IdPaciente),
	IdMedico INT FOREIGN KEY REFERENCES tb_Medico(IdMedico),
	IdStatusConsulta INT FOREIGN KEY REFERENCES tb_StatusConsulta(IdStatusConsulta),
	IdProntuario INT FOREIGN KEY REFERENCES tb_Prontuario(IdProntuario),
	DataConsulta DATE NOT NULL,
	Hora TIME NOT NULL
)

CREATE TABLE tb_Comentario
(
	IdComentario INT PRIMARY KEY IDENTITY,
	IdPaciente INT FOREIGN KEY REFERENCES tb_Paciente(IdPaciente),
	IdConsulta INT FOREIGN KEY REFERENCES tb_Consulta(IdConsulta),
	DescricaoComentario VARCHAR(256),
	ExibirComentario BIT DEFAULT(0)
)

