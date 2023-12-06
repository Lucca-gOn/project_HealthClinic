using apiweb.healthclinic.manha.Domains;
using apiweb.healthclinic.manha.Interfaces;
using apiweb.healthclinic.manha.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace apiweb.healthclinic.manha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ComentarioController : ControllerBase
    {
        private readonly IComentarioRepository _comentarioRepository;

        public ComentarioController(IComentarioRepository comentarioRepository)
        {
            _comentarioRepository = comentarioRepository;
        }

        /// <summary>
        /// Adiciona um novo comentário.
        /// </summary>
        /// <param name="novoComentario">O comentário a ser adicionado.</param>
        /// <returns>Retorna um código de status indicando o resultado da operação.</returns>
        [HttpPost]
        public IActionResult Post(Comentario novoComentario)
        {
            try
            {
                _comentarioRepository.Cadastrar(novoComentario);
                return StatusCode(201);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Lista todos os comentários disponíveis.
        /// </summary>
        /// <returns>Retorna uma lista de comentários.</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_comentarioRepository.Listar());
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Lista um comentário específico com base em seu ID.
        /// </summary>
        /// <param name="id">O ID do comentário a ser recuperado.</param>
        /// <returns>Retorna o comentário especificado.</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                return Ok(_comentarioRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Exclui um comentário específico com base em seu ID.
        /// </summary>
        /// <param name="id">O ID do comentário a ser excluído.</param>
        /// <returns>Retorna um código de status indicando o resultado da operação.</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _comentarioRepository.Deletar(id);
                return Ok();
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Atualiza as informações de um comentario específico.
        /// </summary>
        /// <param name="id">ID do comentario a ser atualizado.</param>
        /// <param name="comentario">Objeto contendo as informações atualizadas do comentario.</param>
        /// <returns>Retorna um código de status indicando o resultado da operação.StatusCode 200 se bem-sucedido.</returns>
        [HttpPut]
        public IActionResult Put(Guid id, Comentario comentario)
        {
            try
            {
                _comentarioRepository.Atualizar(id, comentario);
                return StatusCode(200);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}