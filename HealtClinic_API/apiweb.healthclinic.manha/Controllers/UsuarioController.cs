using apiweb.healthclinic.manha.Domains;
using apiweb.healthclinic.manha.Dto.Usuarios;
using apiweb.healthclinic.manha.Interfaces;
using apiweb.healthclinic.manha.Repositories;
using apiweb.healthclinic.manha.Services;
using apiweb.healthclinic.manha.Utils;
using apiweb.healthclinic.manha.ViewModels;
using Microsoft.AspNetCore.Http;
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
                return Ok(_usuarioRepository.BuscarPorId(id));
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
                var listarUsuario = _service.ListarUsuarios();
                return Ok(listarUsuario.Itens);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        [HttpGet("(GetAll)")]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_usuarioRepository.ListarAll());
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

    }
}
