using apiweb.healthclinic.manha.Domains;

namespace apiweb.healthclinic.manha.Interfaces
{
    public interface ITiposUsuarioRepository
    {
        void Cadastrar(TiposUsuario novoTipoUsuario);

        List<TiposUsuario> Listar();

        TiposUsuario BuscarPorId(Guid id);

        void Atualizar(Guid id, TiposUsuario tipoUsuario);
        TiposUsuario? BuscarTipoUsuarioPorTitulo(string titulo);
    }
}
