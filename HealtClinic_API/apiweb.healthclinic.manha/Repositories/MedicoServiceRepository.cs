using apiweb.healthclinic.manha.Domains;
using apiweb.healthclinic.manha.Interfaces;

namespace apiweb.healthclinic.manha.Repositories
{
    public class MedicoServiceRepository : IMedicoServiceRepository
    {
        private readonly IMedicoRepository _medicoRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IEspecialidadeRepository _especialidadeRepository;


        public MedicoServiceRepository(IMedicoRepository medicoRepository, IUsuarioRepository usuarioRepository, IEspecialidadeRepository especialidadeRepository)
        {
            _medicoRepository = medicoRepository;
            _usuarioRepository = usuarioRepository;
            _especialidadeRepository = especialidadeRepository;

        }

        public void CadastrarMedicoComUsuario(Medico novoMedico, IFormFile file)
        {
           _usuarioRepository.Cadastrar(novoMedico.Usuario, file);
           _especialidadeRepository.Cadastrar(novoMedico.Especialidade);
           _medicoRepository.Cadastrar(novoMedico);
           
        }
    }
}

