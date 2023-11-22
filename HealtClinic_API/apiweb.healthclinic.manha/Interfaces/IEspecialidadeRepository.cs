using apiweb.healthclinic.manha.Domains;

namespace apiweb.healthclinic.manha.Interfaces
{
    public interface IEspecialidadeRepository
    {
        Especialidade? BuscarEspecialidadePorTitulo(string titulo);
        void Cadastrar(Especialidade novaEspecialidade);

        void Deletar(Guid id);

        List<Especialidade> Listar();
    }
}
