using apiweb.healthclinic.manha.Domains;
using apiweb.healthclinic.manha.Dto;

namespace apiweb.healthclinic.manha.Interfaces
{
    public interface IUsuarioRepository
    {
        Task Cadastrar(Usuario novoUsuario, IFormFile file);

        Usuario BuscarPorId(Guid id);

        Usuario BuscarPorEmailESenha (string email, string senha);

        List<UsuarioListarDto> Listar();

        List<Usuario> ListarAll();

    }
}
