using apiweb.healthclinic.manha.Domains;

namespace apiweb.healthclinic.manha.Interfaces
{
    public interface IComentarioRepository
    {
        void Cadastrar(Comentario novoComentario);

        void Deletar(Guid id);

        List<Comentario> Listar();

        void Atualizar(Guid id, Comentario comentario);

        Comentario BuscarPorId(Guid id);
    }
}
