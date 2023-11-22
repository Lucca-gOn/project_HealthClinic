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
    public class PacienteController : ControllerBase
    {
        private readonly IPacienteRepository _pacienteRepository;

        public PacienteController(IPacienteRepository pacienteRepository)
        {
            _pacienteRepository = pacienteRepository;
        }

        /// <summary>
        /// Cadastra um novo paciente.
        /// </summary>
        /// <param name="novoPaciente">Objeto contendo informações do paciente a ser cadastrado.</param>
        /// <returns>StatusCode 201 se bem-sucedido.</returns>
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
        /// Lista todos os pacientes.
        /// </summary>
        /// <returns>Lista de pacientes.</returns>
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
        /// Obtém um paciente específico baseado em seu ID.
        /// </summary>
        /// <param name="id">ID do paciente a ser obtido.</param>
        /// <returns>Detalhes do paciente específico.</returns>
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
        /// Atualiza as informações de um paciente específico.
        /// </summary>
        /// <param name="id">ID do paciente a ser atualizado.</param>
        /// <param name="paciente">Objeto contendo as informações atualizadas do paciente.</param>
        /// <returns>StatusCode 200 se bem-sucedido.</returns>
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
        /// Deleta um paciente específico baseado em seu ID.
        /// </summary>
        /// <param name="id">ID do paciente a ser deletado.</param>
        /// <returns>Status 200 OK se bem-sucedido.</returns>
        [HttpDelete]
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
