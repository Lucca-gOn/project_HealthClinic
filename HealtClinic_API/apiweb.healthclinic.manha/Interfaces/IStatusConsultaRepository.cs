using apiweb.healthclinic.manha.Domains;

namespace apiweb.healthclinic.manha.Interfaces
{
    public interface IStatusConsultaRepository
    {
        void Cadastrar(StatusConsulta novoStatusConsulta);
        
        StatusConsulta BuscarPorId(Guid id);

        void Atualizar(Guid id, StatusConsulta statusConsulta);
    }
}
