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
