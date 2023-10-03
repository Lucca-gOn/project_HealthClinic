using apiweb.healthclinic.manha.Domains;

namespace apiweb.healthclinic.manha.Interfaces
{
    public interface IEspecialidadeRepository
    {
        void Cadastrar(Especialidade novaEspecialidade);

        void Deletar(Guid id);

        List<Especialidade> Listar();
    }
}
