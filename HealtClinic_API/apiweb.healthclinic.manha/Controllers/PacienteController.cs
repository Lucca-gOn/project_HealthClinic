using apiweb.healthclinic.manha.Domains;
using apiweb.healthclinic.manha.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace apiweb.healthclinic.manha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class PacienteController : ControllerBase
    {
        private readonly IPacienteRepository _pacienteRepository;

        public PacienteController(IPacienteRepository pacienteRepository)
        {
            _pacienteRepository = pacienteRepository;
        }

        /// <summary>
        /// Cadastra um novo paciente no sistema.
        /// </summary>
        /// <param name="novoPaciente">Dados do novo paciente a ser cadastrado.</param>
        /// <returns>Retorna um código de status 201 se o paciente foi cadastrado com sucesso, ou BadRequest em caso de erro.</returns>
        [HttpPost]
        public IActionResult Post(Paciente novoPaciente)
        {
            try
            {
                _pacienteRepository.Cadastrar(novoPaciente);
                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
       
        /// <summary>
        /// Lista todos os pacientes cadastrados no sistema.
        /// </summary>
        /// <returns>Retorna uma lista de pacientes ou um código de status BadRequest em caso de erro.</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_pacienteRepository.Listar());
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Busca um paciente específico por seu identificador único.
        /// </summary>
        /// <param name="id">Identificador único do paciente.</param>
        /// <returns>Retorna os detalhes do paciente correspondente ao ID fornecido ou BadRequest em caso de erro.</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                return Ok(_pacienteRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Atualiza os dados de um paciente existente.
        /// </summary>
        /// <param name="id">Identificador único do paciente a ser atualizado.</param>
        /// <param name="paciente">Dados atualizados do paciente.</param>
        /// <returns>Retorna um código de status 200 se a atualização foi bem-sucedida ou BadRequest em caso de erro.</returns>
        [HttpPut]
        public IActionResult Put(Guid id, Paciente paciente)
        {
            try
            {
                _pacienteRepository.Atualizar(id, paciente);
                return StatusCode(200);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Remove um paciente específico do sistema.
        /// </summary>
        /// <param name="id">Identificador único do paciente a ser removido.</param>
        /// <returns>Retorna um código de status OK se o paciente foi removido com sucesso ou BadRequest em caso de erro.</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _pacienteRepository.Deletar(id);
                return Ok();
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
