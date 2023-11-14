﻿using apiweb.healthclinic.manha.Domains;
using apiweb.healthclinic.manha.Interfaces;
using apiweb.healthclinic.manha.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace apiweb.healthclinic.manha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ConsultaController : ControllerBase
    {
        private readonly IConsultaRepository _consultaRepository;

        public ConsultaController()
        {
            _consultaRepository = new ConsultaRepository();
        }

        /// <summary>
        /// Cria uma nova consulta na clínica.
        /// </summary>
        /// <param name="novaConsulta">A consulta a ser criada.</param>
        /// <returns>Retorna o status 201 se bem-sucedido, ou um erro caso contrário.</returns>
        [HttpPost]
        public IActionResult Post(Consulta novaConsulta)
        {
            try
            {
                _consultaRepository.Cadastrar(novaConsulta);
                return StatusCode(201);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Lista todas as consultas disponíveis na clínica.
        /// </summary>
        /// <returns>Uma lista de consultas ou um erro caso algo dê errado.</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_consultaRepository.Listar());

            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Lista todas as consultas de um paciente específico.
        /// </summary>
        /// <param name="IdPaciente">O ID do paciente para buscar suas consultas.</param>
        /// <returns>Uma lista de consultas do paciente ou um erro caso algo dê errado.</returns>
        [HttpGet("{idpaciente}")]
        public IActionResult GetByPaciente(Guid IdPaciente) 
        {
            try
            {
                return Ok(_consultaRepository.ListarPorPaciente(IdPaciente));
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Deleta uma consulta específica com base no seu ID.
        /// </summary>
        /// <param name="id">O ID da consulta a ser deletada.</param>
        /// <returns>Retorna o status OK se bem-sucedido, ou um erro caso contrário.</returns>
        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _consultaRepository.Deletar(id);
                return Ok();
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }
    }
}