using apiweb.healthclinic.manha.Dto.Usuarios;
using apiweb.healthclinic.manha.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace apiweb.healthclinic.manha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _service;
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(
            IUsuarioService service,
            IUsuarioRepository usuarioRepository)
        {
            _service = service;
            _usuarioRepository = usuarioRepository;
        }

        [HttpPost]
        public IActionResult CriarUsuario([FromForm] CriarUsuarioRequest request)
        {
            try
            {
                var response = _service.CriarUsuario(request);

                return CreatedAtAction(
                    nameof(GetById),
                    new { id = response.Id },
                    response);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        /// <summary>
        /// Endpoint GET para buscar um usuário pelo ID.
        /// </summary>
        /// <param name="id">ID do usuário a ser buscado.</param>
        /// <returns>Detalhes do usuário ou código 400 com a mensagem de erro.</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                return Ok(_service.ListarPorId(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_service.ListarUsuarios());
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        [HttpPut]
        public IActionResult Put(Guid idUsuario,[FromForm] AtualizarUsuarioRequest request)
        {
            try
            {
                var response = _service.AtualizarUsuario(idUsuario, request);

                return Ok(response);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _usuarioRepository.Deletar(id);
                return Ok();
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        [HttpGet("ListarAdministradores")]
        public IActionResult ListarAdministradores()
        {
            try
            {
                return Ok(_service.ListarAdministradores());
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
