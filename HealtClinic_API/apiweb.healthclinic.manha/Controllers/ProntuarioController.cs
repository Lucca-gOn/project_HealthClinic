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
        /// Cadastra um novo prontuário.
        /// </summary>
        /// <param name="novoProntuario">Objeto contendo informações do prontuário a ser cadastrado.</param>
        /// <returns>StatusCode 201 se bem-sucedido.</returns>
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
        /// Obtém um prontuário específico baseado em seu ID.
        /// </summary>
        /// <param name="id">ID do prontuário a ser obtido.</param>
        /// <returns>Detalhes do prontuário específico.</returns>
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
        /// Atualiza as informações de um prontuário específico.
        /// </summary>
        /// <param name="id">ID do prontuário a ser atualizado.</param>
        /// <param name="prontuario">Objeto contendo as informações atualizadas do prontuário.</param>
        /// <returns>StatusCode 200 se bem-sucedido.</returns>
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
