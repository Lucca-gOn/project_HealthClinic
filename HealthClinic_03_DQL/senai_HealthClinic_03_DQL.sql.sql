--Criar script que exiba os seguintes dados:

--Id Consulta
--Data da Consulta
--Horario da Consulta
--Nome da Clinica
--Nome do Paciente
--Nome do Medico
--Especialidade do Medico
--CRM
--Prontuário ou Descricao
--FeedBack(Comentario da consulta)

SELECT 
    tb_Consulta.IdConsulta AS 'ID CONSULTA',
    tb_Consulta.DataConsulta AS 'DATA DA CONSULTA',
    tb_Consulta.Hora AS 'HORA CONSULTA', 
    tb_Clinica.NomeFantasia AS 'CLINICA',
    tb_Usuario.NomeUsuario AS 'PACIENTE',
    medicoUsuario.NomeUsuario AS 'MÉDICO',
    tb_Especialidade.DescricaoEspecialidade AS 'ESPECIALIDADE',
    tb_Medico.CRM AS 'CRM',
    tb_Prontuario.DescricaoProntuario AS 'PRONTUARIO',
    tb_Comentario.DescricaoComentario AS 'COMENTÁRIO'
FROM 
    tb_Consulta
JOIN 
    tb_Paciente ON tb_Consulta.IdPaciente = tb_Paciente.IdPaciente
JOIN 
    tb_Usuario ON tb_Paciente.IdUsuario = tb_Usuario.IdUsuario
JOIN 
    tb_Medico ON tb_Consulta.IdMedico = tb_Medico.IdMedico
JOIN 
    tb_Usuario medicoUsuario ON tb_Medico.IdUsuario = medicoUsuario.IdUsuario
JOIN 
    tb_Clinica ON tb_Medico.IdClinica = tb_Clinica.IdClinica
JOIN 
    tb_Medico_tb_Especialidade ON tb_Medico.IdMedico = tb_Medico_tb_Especialidade.IdMedico
JOIN 
    tb_Especialidade ON tb_Medico_tb_Especialidade.IdEspecialidade = tb_Especialidade.IdEspecialidade
JOIN 
    tb_Prontuario ON tb_Consulta.IdProntuario = tb_Prontuario.IdProntuario
LEFT JOIN 
    tb_Comentario ON tb_Consulta.IdConsulta = tb_Comentario.IdConsulta
ORDER BY 
    tb_Consulta.IdConsulta; 


--DESAFIO 1

CREATE FUNCTION MedicosPorEspecialidade(@IDEspecialidade INT)
RETURNS TABLE 
AS
RETURN 
(
    SELECT 
        tb_Usuario.NomeUsuario AS NomeMedico
    FROM 
        tb_Medico_tb_Especialidade
    JOIN 
        tb_Medico ON tb_Medico_tb_Especialidade.IdMedico = tb_Medico.IdMedico
    JOIN 
        tb_Usuario ON tb_Medico.IdUsuario = tb_Usuario.IdUsuario
    WHERE 
        tb_Medico_tb_Especialidade.IdEspecialidade = @IDEspecialidade
);

SELECT * FROM MedicosPorEspecialidade(2);
