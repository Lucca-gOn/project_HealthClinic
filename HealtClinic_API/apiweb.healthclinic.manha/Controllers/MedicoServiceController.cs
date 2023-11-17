using apiweb.healthclinic.manha.Domains;
using apiweb.healthclinic.manha.Dto;
using apiweb.healthclinic.manha.Interfaces;
using apiweb.healthclinic.manha.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace apiweb.healthclinic.manha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class MedicoServiceController : ControllerBase
    {
        private readonly IMedicoServiceRepository _medicoService;

        // O ASP.NET Core irá fornecer uma instância de IMedicoService para você
        public MedicoServiceController(IMedicoServiceRepository medicoService)
        {
            _medicoService = medicoService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] MedicoUsuarioDto medicoUsuarioDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                // Aqui você converteria o DTO para suas entidades de domínio
                // e chamaria o serviço para realizar o cadastro
                Usuario novoUsuario = new Usuario
                {
                    // Preencha com os dados recebidos do DTO
                    Nome = medicoUsuarioDto.Nome,
                    Email = medicoUsuarioDto.Email,
                    Senha = medicoUsuarioDto.Senha,
                    DataNascimento = medicoUsuarioDto.DataNascimento,
                    Sexo = medicoUsuarioDto.Sexo
                };

                Medico novoMedico = new Medico
                {
                    // Preencha com os dados recebidos do DTO
                    CRM = medicoUsuarioDto.CRM,
                    Especialidade = medicoUsuarioDto.Especialidade,
                    // O IdUsuario será associado pelo serviço
                };

                // O serviço cuida de salvar o usuário e o médico de forma transacional
                 _medicoService.CadastrarMedicoComUsuarioAsync(novoMedico, novoUsuario, medicoUsuarioDto.File);

                return CreatedAtAction("Post", new { id = novoMedico.IdMedico }, novoMedico);
            }
            catch (Exception ex)
            {
                // Trate a exceção conforme necessário
                return StatusCode(500, ex.Message);
            }
        }


    }
}
