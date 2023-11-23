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
        private readonly IConsultaService _consultaService;
        private readonly IConsultaRepository _consultaRepository;

        public ConsultaController(
            IConsultaService consultaService,
            IConsultaRepository consultaRepository)
        {
            _consultaService = consultaService;
            _consultaRepository = consultaRepository;
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
                var consultas = _consultaService.ListarConsultas();
                return Ok(consultas.Itens);

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

        /// <summary>
        /// Cria uma consulta recebendo um objeto CriarConsultaRequest.
        /// </summary>
        /// <param name="request">O objeto para criar a consulta.</param>
        /// <returns>Retorna o status OK se bem-sucedido, ou um erro caso contrário.</returns>
        [HttpPost("CriarConsulta")]
        public IActionResult CriarConsulta(CriarConsultaRequest request)
        {
            try
            {
                var response = _consultaService.CriarConsulta(request);
                return StatusCode(201, response);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
