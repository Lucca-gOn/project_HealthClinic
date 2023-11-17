using apiweb.healthclinic.manha.Domains;
using apiweb.healthclinic.manha.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace apiweb.healthclinic.manha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class MedicoServiceController : ControllerBase
    {

            private readonly IMedicoServiceRepository _medicoServiceRepository;

            public MedicoServiceController(IMedicoServiceRepository medicoServiceRepository)
            {
                _medicoServiceRepository = medicoServiceRepository;
            }

            [HttpPost]
            public IActionResult CadastrarMedicoComUsuario([FromForm] Medico novoMedico, [FromForm] IFormFile file)
            {
                try
                {
                    _medicoServiceRepository.CadastrarMedicoComUsuario(novoMedico, file);
                    return StatusCode(201);
                }
                catch (Exception erro)
                {
                    return BadRequest(erro.Message);
                }
            }
    }



}

