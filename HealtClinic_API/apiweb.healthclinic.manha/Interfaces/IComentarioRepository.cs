using apiweb.healthclinic.manha.Domains;

namespace apiweb.healthclinic.manha.Interfaces
{
    public interface IComentarioRepository
    {
        void Cadastrar(Comentario novoComentario);

        void Deletar(Guid id);

        List<Comentario> Listar();

        Comentario BuscarPorId(Guid id);
    }
}
