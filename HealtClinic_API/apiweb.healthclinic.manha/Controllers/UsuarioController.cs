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
        private readonly IUsuarioService _usuarioService;
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(
            IUsuarioService usuarioService,
            IUsuarioRepository usuarioRepository)
        {
            _usuarioService = usuarioService;
            _usuarioRepository = usuarioRepository;
        }

        /// <summary>
        /// Cadastra um novo usuário no sistema.
        /// </summary>
        /// <param name="request">Dados do usuário a ser cadastrado.</param>
        /// <returns>Retorna uma resposta contendo o ID do usuário criado e seus detalhes, ou BadRequest em caso de erro.</returns>
        [HttpPost]
        public IActionResult CriarUsuario([FromForm] CriarUsuarioRequest request)
        {
            try
            {
                var response = _usuarioService.CriarUsuario(request);

                return CreatedAtAction(
                    nameof(GetById),
                    new { id = response.Id },
                    response);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }


        /// <summary>
        /// Busca um usuário específico por seu identificador único.
        /// </summary>
        /// <param name="id">Identificador único do usuário.</param>
        /// <returns>Retorna os detalhes do usuário correspondente ao ID fornecido ou BadRequest em caso de erro.</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                return Ok(_usuarioService.ListarPorId(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Lista todos os usuários cadastrados no sistema.
        /// </summary>
        /// <returns>Retorna uma lista de usuários ou um código de status BadRequest em caso de erro.</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_usuarioService.ListarUsuarios().Itens);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Atualiza os dados de um usuário existente.
        /// </summary>
        /// <param name="idUsuario">Identificador único do usuário a ser atualizado.</param>
        /// <param name="request">Dados atualizados do usuário.</param>
        /// <returns>Retorna uma resposta com os detalhes atualizados do usuário ou BadRequest em caso de erro.</returns>
        [HttpPut]
        public IActionResult Put(Guid idUsuario,[FromForm] AtualizarUsuarioRequest request)
        {
            try
            {
                var response = _usuarioService.AtualizarUsuario(idUsuario, request);

                return Ok(response);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Remove um usuário específico do sistema.
        /// </summary>
        /// <param name="id">Identificador único do usuário a ser removido.</param>
        /// <returns>Retorna um código de status OK se o usuário foi removido com sucesso ou BadRequest em caso de erro.</returns>
        [HttpDelete("{id}")]
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

        /// <summary>
        /// Lista todos os usuários com perfil de administrador no sistema.
        /// </summary>
        /// <returns>Retorna uma lista de usuários administradores ou um código de status BadRequest em caso de erro.</returns>
        [HttpGet("ListarAdministradores")]
        public IActionResult ListarAdministradores()
        {
            try
            {
                return Ok(_usuarioService.ListarAdministradores().Itens);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
