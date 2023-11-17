using apiweb.healthclinic.manha.Domains;

namespace apiweb.healthclinic.manha.Interfaces
{
    public interface IMedicoServiceRepository
    {
        void CadastrarMedicoComUsuario(Medico novoMedico, IFormFile file);
    }
}

