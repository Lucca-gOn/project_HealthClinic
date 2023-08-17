--DML   Data Manipulation Language
USE [HealthClinic_manha];

INSERT INTO tb_TipoDeUsuario (TituloTipoUsuario)
VALUES ('Administrador'),('Médico'),('Paciente')

INSERT INTO tb_Clinica (Endereco,HoraInicio,HoraFim,CNPJ,NomeFantasia,RazaoSocial)
VALUES ('Rua das Flores, 123', '08:00:00','22:00:00', '12345678000123', 'Health Clinic', 'Health Clinic Saúde Ltda');

INSERT INTO tb_Especialidade (DescricaoEspecialidade)
VALUES	('Cardiologia: especialidade médica dedicada ao diagnóstico e tratamento de doenças do coração.'),
		('Dermatologia: focada no diagnóstico, prevenção e tratamento de doenças e afecções relacionadas à pele.'),
		('Ortopedia: especialidade médica que cuida da saúde dos ossos, músculos e articulações.');

INSERT INTO tb_StatusConsulta (DescricaoStatusConsulta)
VALUES 
		('Aguardando avaliação cardiológica: O paciente está aguardando para ser avaliado por um cardiologista.'),
		('Requer exame dermatológico: O paciente precisa realizar exames específicos relacionados à pele.'),
		('Em recuperação ortopédica: O paciente está em um período pós-operatório ou de reabilitação relacionado a um procedimento ortopédico.'),
		('Consulta confirmada: A consulta foi confirmada e está agendada para ocorrer.'),
		('Exames pendentes: O paciente tem exames pendentes a serem realizados ou entregues.'),
		('Requer retorno: O paciente precisa agendar uma consulta de retorno para revisão.');

INSERT INTO tb_Prontuario (DescricaoProntuario)
VALUES	('Paciente apresentou episódios de palpitações e falta de ar. Foi solicitado ECG e ecocardiograma. Aguardando avaliação detalhada por cardiologista.'),
		('Paciente apresentou erupções cutâneas persistentes e coceira. Necessário exame dermatológico específico para determinar a causa e o tratamento adequado.'),
		('Paciente submetido a cirurgia ortopédica após fratura no tornozelo. Em fase de reabilitação e fisioterapia. Aguardando nova avaliação para verificar progresso.');


INSERT INTO tb_Usuario (IdTipoDeUsuario,NomeUsuario,EmailUsuario,Senha,DataNascimento)
VALUES	(1, 'Admin Silva', 'admin.silva@email.com', 'Admin123', '1980-01-01'),
		(2, 'Ranchucrutes', 'ranchucrutes@email.com', 'Ranchucrutes123', '1985-08-25'),
		(2, 'Ranchucrutes Segundo', 'ranchucrutessegundo@email.com', 'Ranchucrutessegundo123', '2000-04-20'),
		(3, 'Pica Pau', 'Picapau@email.com', 'picapau123', '1990-05-15'),
		(3, 'Leoncio da Silva', 'Leoncio@email.com', 'Leoncio123', '1994-05-15');

INSERT INTO tb_Paciente (IdUsuario,CPF,RG,Telefone,EnderecoPaciente)
VALUES	(4,'12345678901','12.345.678-9','(11) 98765-4321','Rua das Flores, 123, Bairro Jardim'),
		(5,'23456789012','23.456.789-0','(11) 95165-4641','Avenida das Árvores, 456, Bairro Bosque');

INSERT INTO tb_Medico (IdUsuario,IdClinica,CRM)
VALUES	(2,1,'12345-SP'),
		(3,1,'54345-SP');

INSERT INTO tb_Medico_tb_Especialidade (IdMedico,IdEspecialidade)
VALUES	(1,1),
		(2,2);

INSERT INTO tb_Consulta (IdPaciente,IdMedico,IdStatusConsulta,IdProntuario,DataConsulta,Hora)
VALUES	(1,1,1,1,'2023-08-16', '15:30:00'),
		(2,2,2,2,'2023-08-20', '16:30:00');

INSERT INTO tb_Comentario (IdPaciente,IdConsulta,DescricaoComentario,ExibirComentario)
VALUES	(1,2,'Estou extremamente satisfeito com o atendimento da clinica!',1),
		(2,3,'A clínica superou todas as minhas expectativas! Ambiente limpo, equipe atenciosa e médicos competentes.',1)

SELECT * FROM tb_TipoDeUsuario
SELECT * FROM tb_Clinica
SELECT * FROM tb_Especialidade
SELECT * FROM tb_StatusConsulta
SELECT * FROM tb_Prontuario
SELECT * FROM tb_Usuario
SELECT * FROM tb_Paciente
SELECT * FROM tb_Medico
SELECT * FROM tb_Medico_tb_Especialidade
SELECT * FROM tb_Consulta
SELECT * FROM tb_Comentario
