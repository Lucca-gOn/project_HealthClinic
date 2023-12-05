using apiweb.healthclinic.manha.Domains;

namespace apiweb.healthclinic.manha.Interfaces
{
    public interface IConsultaRepository
    {
        void Cadastrar(Consulta novaConsulta);

        void Deletar(Guid id);

        Consulta BuscarPorId(Guid id);

        List<Consulta> Listar();

        List<Consulta> ListarPorPaciente(Guid IdPaciente);

        List<Consulta> ListarPorMedico(Guid IdMedico);

        void Atualizar(Consulta consulta);
    }
}
