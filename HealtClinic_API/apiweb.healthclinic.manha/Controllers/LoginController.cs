using apiweb.healthclinic.manha.Domains;
using apiweb.healthclinic.manha.Dto.Imagens;
using apiweb.healthclinic.manha.Interfaces;
using apiweb.healthclinic.manha.ViewModels;
using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace apiweb.healthclinic.manha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class LoginController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public LoginController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        /// <summary>
        /// Realiza o login do usuário utilizando seu email e senha, retornando um token JWT caso bem-sucedido.
        /// </summary>
        /// <param name="usuario">Objeto que contém as informações de email e senha do usuário.</param>
        /// <returns>Token JWT para autenticação caso bem-sucedido, ou um erro caso contrário.</returns>
        [HttpPost]
        public IActionResult Login(LoginViewModel usuario)
        {
            try
            {
                Usuario usuarioBuscado = _usuarioRepository.BuscarPorEmailESenha(usuario.Email!, usuario.Senha!);
                if (usuarioBuscado == null)
                {
                    return NotFound("Email ou senha inválidos!");
                }

                //Caso encontre o usuario, prossegue para criação do token

                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Jti,usuarioBuscado.IdUsuario.ToString()),
                    new Claim(JwtRegisteredClaimNames.Name,usuarioBuscado.Nome!),
                    new Claim(JwtRegisteredClaimNames.Email,usuarioBuscado.Email!),
                    new Claim(ClaimTypes.Role, usuarioBuscado.TiposUsuario!.Titulo!),
                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("chave-autenticacao-code-first-webapi-projeto-healthclinic"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken
              (
                  //emissor do token (ver em program)
                  issuer: "apiweb.healthclinic.manha",

                  //Destinatario do token
                  audience: "apiweb.healthclinic.manha",

                  //Dados definidos nas claims(informações)
                  claims: claims,

                  //tempo de expiração
                  expires: DateTime.Now.AddMinutes(10),

                //credenciais token
                  signingCredentials: creds
                );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    caminhoImagem = usuarioBuscado.CaminhoImagem
                    
                });
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }

        }
    }
}