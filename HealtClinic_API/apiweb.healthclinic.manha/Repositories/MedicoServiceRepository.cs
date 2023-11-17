using apiweb.healthclinic.manha.Domains;
using apiweb.healthclinic.manha.Interfaces;

namespace apiweb.healthclinic.manha.Repositories
{
    public class MedicoServiceRepository : IMedicoServiceRepository
    {
        private readonly IMedicoRepository _medicoRepository;
        private readonly IUsuarioRepository _usuarioRepository;

        public MedicoServiceRepository(IMedicoRepository medicoRepository, IUsuarioRepository usuarioRepository)
        {
            _medicoRepository = medicoRepository;
            _usuarioRepository = usuarioRepository;
        }

        public async Task CadastrarMedicoComUsuarioAsync(Medico novoMedico, Usuario novoUsuario, IFormFile file)
        {
            // Implementação da lógica de cadastro do usuário e do médico
            // Exemplo básico, você precisará adaptar de acordo com sua lógica de negócio e repositórios

            // Primeiro, cadastrar o usuário
            await _usuarioRepository.Cadastrar(novoUsuario, file);

            // O IdUsuario do novoUsuario deve ser definido após o cadastro
            novoMedico.IdUsuario = novoUsuario.IdUsuario;

            // Depois, cadastrar o médico
            _medicoRepository.Cadastrar(novoMedico);
        }
    }
}

