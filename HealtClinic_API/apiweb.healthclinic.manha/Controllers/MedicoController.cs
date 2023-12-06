using apiweb.healthclinic.manha.Domains;
using apiweb.healthclinic.manha.Interfaces;
using apiweb.healthclinic.manha.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace apiweb.healthclinic.manha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class MedicoController : ControllerBase
    {
        private readonly IMedicoRepository _medicoRepository;

        public MedicoController(IMedicoRepository medicoRepository)
        {
            _medicoRepository = medicoRepository;
        }

        /// <summary>
        /// Cadastra um novo médico no sistema.
        /// </summary>
        /// <param name="novoMedico">Dados do novo médico a ser cadastrado.</param>
        /// <returns>Retorna um código de status 201 se o médico foi cadastrado com sucesso, ou BadRequest em caso de erro.</returns>
        [HttpPost]
        public IActionResult Post(Medico novoMedico)
        {
            try
            {
                _medicoRepository.Cadastrar(novoMedico);
                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Lista todos os médicos cadastrados no sistema.
        /// </summary>
        /// <returns>Retorna uma lista de médicos ou um código de status BadRequest em caso de erro.</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_medicoRepository.Listar());
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Busca um médico específico por seu identificador único.
        /// </summary>
        /// <param name="id">Identificador único do médico.</param>
        /// <returns>Retorna os detalhes do médico correspondente ao ID fornecido ou BadRequest em caso de erro.</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                return Ok(_medicoRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Remove um médico específico do sistema.
        /// </summary>
        /// <param name="id">Identificador único do médico a ser removido.</param>
        /// <returns>Retorna um código de status OK se o médico foi removido com sucesso ou BadRequest em caso de erro.</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _medicoRepository.Deletar(id);
                return Ok();
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
