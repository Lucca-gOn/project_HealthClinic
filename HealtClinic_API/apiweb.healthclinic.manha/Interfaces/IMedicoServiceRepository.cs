using apiweb.healthclinic.manha.Domains;

namespace apiweb.healthclinic.manha.Interfaces
{
    public interface IMedicoServiceRepository
    {
        Task CadastrarMedicoComUsuarioAsync(Medico novoMedico, Usuario novoUsuario, IFormFile file);
    }
}

