using apiweb.healthclinic.manha.Domains;
using apiweb.healthclinic.manha.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace apiweb.healthclinic.manha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class EspecialidadeController : ControllerBase
    {
        private readonly IEspecialidadeRepository _especialidadeRepository;

        public EspecialidadeController(IEspecialidadeRepository especialidadeRepository)
        {
            _especialidadeRepository = especialidadeRepository;
        }

        /// <summary>
        /// Cadastra uma nova especialidade no sistema.
        /// </summary>
        /// <param name="novaEspecialidade">Dados da nova especialidade a ser cadastrada.</param>
        /// <returns>Retorna um código de status 201 se a especialidade foi cadastrada com sucesso, ou BadRequest em caso de erro.</returns>
        [HttpPost]
        public IActionResult Post(Especialidade novaEspecialidade)
        {
            try
            {
                _especialidadeRepository.Cadastrar(novaEspecialidade);
                return StatusCode(201);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Lista todas as especialidades cadastradas no sistema.
        /// </summary>
        /// <returns>Retorna uma lista de especialidades ou um código de status BadRequest em caso de erro.</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_especialidadeRepository.Listar());

            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Remove uma especialidade específica do sistema.
        /// </summary>
        /// <param name="id">Identificador único da especialidade a ser removida.</param>
        /// <returns>Retorna um código de status OK se a especialidade foi removida com sucesso ou BadRequest em caso de erro.</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _especialidadeRepository.Deletar(id);
                return Ok();
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }
    }
}
