using apiweb.healthclinic.manha.Domains;
using apiweb.healthclinic.manha.Interfaces;
using apiweb.healthclinic.manha.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace apiweb.healthclinic.manha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class StatusConsultaController : ControllerBase
    {
        private IStatusConsultaRepository _statusConsultaRepository;
        public StatusConsultaController()
        {
            _statusConsultaRepository = new StatusConsultaRepository();
        }

        /// <summary>
        /// Cadastra um novo status de consulta.
        /// </summary>
        /// <param name="novoStatusConsulta">Objeto contendo informações do status da consulta a ser cadastrado.</param>
        /// <returns>StatusCode 201 se bem-sucedido.</returns>
        [HttpPost]
        public IActionResult Post(StatusConsulta novoStatusConsulta)
        {
            try
            {
                _statusConsultaRepository.Cadastrar(novoStatusConsulta);
                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Obtém um status de consulta específico baseado em seu ID.
        /// </summary>
        /// <param name="id">ID do status de consulta a ser obtido.</param>
        /// <returns>Detalhes do status de consulta específico.</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                return Ok(_statusConsultaRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Atualiza as informações de um status de consulta específico.
        /// </summary>
        /// <param name="id">ID do status de consulta a ser atualizado.</param>
        /// <param name="statusConsulta">Objeto contendo as informações atualizadas do status de consulta.</param>
        /// <returns>StatusCode 200 se bem-sucedido.</returns>
        [HttpPut]
        public IActionResult Put(Guid id, StatusConsulta statusConsulta)
        {
            try
            {
                _statusConsultaRepository.Atualizar(id, statusConsulta);
                return StatusCode(200);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
