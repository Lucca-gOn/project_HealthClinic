using apiweb.healthclinic.manha.Domains;
using apiweb.healthclinic.manha.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace apiweb.healthclinic.manha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class TiposUsuarioController : ControllerBase
    {
        private ITiposUsuarioRepository _tiposUsuarioRepository;

        public TiposUsuarioController(ITiposUsuarioRepository tiposUsuarioRepository)
        {
            _tiposUsuarioRepository = tiposUsuarioRepository;
        }


        /// <summary>
        /// Cadastra um novo tipo de usuário no sistema.
        /// </summary>
        /// <param name="novoTipoUsuario">Dados do novo tipo de usuário a ser cadastrado.</param>
        /// <returns>Retorna um código de status 201 se o tipo de usuário foi cadastrado com sucesso, ou BadRequest em caso de erro.</returns>
        [HttpPost]
        public IActionResult Post(TiposUsuario novoTipoUsuario)
        {
            try
            {
                _tiposUsuarioRepository.Cadastrar(novoTipoUsuario);
                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Lista todos os tipos de usuários cadastrados no sistema.
        /// </summary>
        /// <returns>Retorna uma lista de tipos de usuários ou um código de status BadRequest em caso de erro.</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_tiposUsuarioRepository.Listar());
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Busca um tipo de usuário específico por seu identificador único.
        /// </summary>
        /// <param name="id">Identificador único do tipo de usuário.</param>
        /// <returns>Retorna os detalhes do tipo de usuário correspondente ao ID fornecido ou BadRequest em caso de erro.</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                return Ok(_tiposUsuarioRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Atualiza os dados de um tipo de usuário existente.
        /// </summary>
        /// <param name="id">Identificador único do tipo de usuário a ser atualizado.</param>
        /// <param name="tipoUsuario">Dados atualizados do tipo de usuário.</param>
        /// <returns>Retorna um código de status 200 se a atualização foi bem-sucedida ou BadRequest em caso de erro.</returns>
        [HttpPut]
        public IActionResult Put(Guid id, TiposUsuario tipoUsuario)
        {
            try
            {
                _tiposUsuarioRepository.Atualizar(id, tipoUsuario);
                return StatusCode(200);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
