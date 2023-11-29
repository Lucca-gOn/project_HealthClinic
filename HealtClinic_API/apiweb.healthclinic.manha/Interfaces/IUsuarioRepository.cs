using apiweb.healthclinic.manha.Domains;

namespace apiweb.healthclinic.manha.Interfaces
{
    public interface IUsuarioRepository
    {
        void Cadastrar(Usuario novoUsuario);

        Usuario BuscarPorId(Guid id);

        Usuario BuscarPorEmailESenha (string email, string senha);

        void Deletar(Guid idUsuario);
        
        void Atualizar(Usuario usuario);
    }
}
