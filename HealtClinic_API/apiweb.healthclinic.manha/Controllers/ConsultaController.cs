using apiweb.healthclinic.manha.Domains;
using apiweb.healthclinic.manha.Interfaces;
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
        /// Cadastra uma nova consulta no sistema.
        /// </summary>
        /// <param name="novaConsulta">Dados da nova consulta a ser cadastrada.</param>
        /// <returns>Retorna um código de status 201 se a consulta foi cadastrada com sucesso, ou BadRequest em caso de erro.</returns>
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
        /// Lista todas as consultas cadastradas no sistema.
        /// </summary>
        /// <returns>Retorna uma lista de consultas ou um código de status BadRequest em caso de erro.</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_consultaService.ListarConsultas().Itens);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Lista todas as consultas associadas a um usuário específico.
        /// </summary>
        /// <param name="IdUsuario">Identificador único do usuário.</param>
        /// <returns>Retorna uma lista de consultas relacionadas ao usuário ou BadRequest em caso de erro.</returns>
        [HttpGet("Usuario/{IdUsuario}")]
        public IActionResult GetByConsulta(Guid IdUsuario)
        {
            try
            {
                return Ok(_consultaService.ListarConsultasPorUsuario(IdUsuario).Itens);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Remove uma consulta específica do sistema.
        /// </summary>
        /// <param name="id">Identificador único da consulta a ser removida.</param>
        /// <returns>Retorna um código de status OK se a consulta foi removida com sucesso ou BadRequest em caso de erro.</returns>
        [HttpDelete("{id}")]
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
        /// Cadastra uma nova consulta no sistema com um Objeto contendo dados específicos.
        /// </summary>
        /// <param name="request">Dados detalhados da consulta a ser cadastrada.</param>
        /// <returns>Retorna um código de status 201 se a consulta foi cadastrada com sucesso, ou BadRequest em caso de erro.</returns>
        [HttpPost("CriarConsulta")]
        public IActionResult CriarConsulta(CriarConsultaRequest request)
        {
            try
            {
                _consultaService.CriarConsulta(request);
                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Busca uma consulta específica por seu identificador único.
        /// </summary>
        /// <param name="id">Identificador único da consulta.</param>
        /// <returns>Retorna a consulta correspondente ao ID fornecido ou BadRequest em caso de erro.</returns>

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                return Ok(_consultaRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Atualiza os detalhes de uma consulta existente.
        /// </summary>
        /// <param name="id">Identificador único da consulta a ser atualizada.</param>
        /// <param name="request">Dados atualizados da consulta.</param>
        /// <returns>Retorna um código de status OK se a atualização foi bem-sucedida ou BadRequest em caso de erro.</returns>

        [HttpPut]
        public IActionResult Put(Guid id, AtualizarConsultaRequest request)
        {
            try
            {
                var response = _consultaService.AtualizarConsulta(id, request);
                return Ok(response);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
