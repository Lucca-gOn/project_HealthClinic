using apiweb.healthclinic.manha.Domains;

namespace apiweb.healthclinic.manha.Interfaces
{
    public interface IEspecialidadeRepository
    {
        void Cadastrar(Especialidade novaEspecialidade);

        void Deletar(Guid id);

        List<Especialidade> Listar();

        Especialidade BuscarPorId(Guid id);

        void Atualizar(Guid id, Especialidade especialidade);
    }
}
