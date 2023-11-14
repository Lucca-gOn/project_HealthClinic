using apiweb.healthclinic.manha.Domains;
using apiweb.healthclinic.manha.Interfaces;
using apiweb.healthclinic.manha.Repositories;
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
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        /// <summary>
        /// Endpoint POST para cadastrar um novo usuário com imagem.
        /// </summary>
        /// <param name="usuarioDto">DTO contendo informações do usuário.</param>
        /// <param name="file">Arquivo de imagem do usuário.</param>
        /// <returns>Código de status 201 em caso de sucesso ou 400 com a mensagem de erro.</returns>
        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Post([FromForm] UsuarioDto usuarioDto, [FromForm] IFormFile file)
        {
            try
            {
                // Aqui você mapeará o DTO para a entidade Usuario
                Usuario novoUsuario = new Usuario
                {
                    Nome = usuarioDto.Nome,
                    Email = usuarioDto.Email,
                    Senha = usuarioDto.Senha,
                    // Outras propriedades...
                };

                // Adicione a lógica para tratar o arquivo de imagem aqui
                // Exemplo: novoUsuario.Imagem = await ConvertFileToByteArrayAsync(file);

                await _usuarioRepository.Cadastrar(novoUsuario, file);
                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
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
    }
}
