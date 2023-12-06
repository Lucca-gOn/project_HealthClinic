using apiweb.healthclinic.manha.Domains;
using apiweb.healthclinic.manha.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace apiweb.healthclinic.manha.Controllers
{
    /// <summary>
    /// Controlador responsável pelas operações envolvendo os prontuários.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ProntuarioController : ControllerBase
    {
        private IProntuarioRepository _prontuarioRepository;

        public ProntuarioController(IProntuarioRepository prontuarioRepository)
        {
            _prontuarioRepository = prontuarioRepository;
        }

        /// <summary>
        /// Cadastra um novo prontuário no sistema.
        /// </summary>
        /// <param name="novoProntuario">Dados do novo prontuário a ser cadastrado.</param>
        /// <returns>Retorna um código de status 201 se o prontuário foi cadastrado com sucesso, ou BadRequest em caso de erro.</returns>
        [HttpPost]
        public IActionResult Post(Prontuario novoProntuario)
        {
            try
            {
                _prontuarioRepository.Cadastrar(novoProntuario);
                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Busca um prontuário específico por seu identificador único.
        /// </summary>
        /// <param name="id">Identificador único do prontuário.</param>
        /// <returns>Retorna os detalhes do prontuário correspondente ao ID fornecido ou BadRequest em caso de erro.</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                return Ok(_prontuarioRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Atualiza os dados de um prontuário existente.
        /// </summary>
        /// <param name="id">Identificador único do prontuário a ser atualizado.</param>
        /// <param name="prontuario">Dados atualizados do prontuário.</param>
        /// <returns>Retorna um código de status 200 se a atualização foi bem-sucedida ou BadRequest em caso de erro.</returns>
        [HttpPut]
        public IActionResult Put(Guid id, Prontuario prontuario)
        {
            try
            {
                _prontuarioRepository.Atualizar(id, prontuario);
                return StatusCode(200);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
