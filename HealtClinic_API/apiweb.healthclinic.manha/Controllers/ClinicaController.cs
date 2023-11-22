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
    public class ClinicaController : ControllerBase
    {
        private IClinicaRepository _clinicaRepository;

        public ClinicaController(IClinicaRepository clinicaRepository)
        {
            _clinicaRepository = clinicaRepository;
        }

        /// <summary>
        /// Cadastra uma nova clínica.
        /// </summary>
        /// <param name="novaClinica">Dados da nova clínica a ser cadastrada.</param>
        /// <returns>Retorna um código de status indicando o resultado da operação.</returns>
        [HttpPost]
        public IActionResult Post(Clinica novaClinica)
        {
            try
            {
                _clinicaRepository.Cadastrar(novaClinica);
                return StatusCode(201);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Lista todas as clínicas cadastradas.
        /// </summary>
        /// <returns>Retorna uma lista contendo todas as clínicas.</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_clinicaRepository.Listar());
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }
    }
}
