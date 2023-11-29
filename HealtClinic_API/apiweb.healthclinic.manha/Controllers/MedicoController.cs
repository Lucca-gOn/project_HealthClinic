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
        /// Cadastra um novo médico.
        /// </summary>
        /// <param name="novoMedico">Objeto contendo informações do médico a ser cadastrado.</param>
        /// <returns>StatusCode 201 se bem-sucedido.</returns>
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
        /// Lista todos os médicos.
        /// </summary>
        /// <returns>Lista de médicos.</returns>
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
        /// Deleta um médico específico baseado em seu ID.
        /// </summary>
        /// <param name="id">ID do médico a ser deletado.</param>
        /// <returns>Status 200 OK se bem-sucedido.</returns>
        [HttpDelete]
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
