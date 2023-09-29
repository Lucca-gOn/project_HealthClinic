using apiweb.healthclinic.manha.Domains;

namespace apiweb.healthclinic.manha.Interfaces
{
    public interface IConsultaRepository
    {
        void Cadastrar(Consulta novaConsulta);

        void Deletar(Guid id);

        Especialidade BuscarPorId(Guid id);

        void Atualizar(Guid id, Consulta consulta);
    }
}
