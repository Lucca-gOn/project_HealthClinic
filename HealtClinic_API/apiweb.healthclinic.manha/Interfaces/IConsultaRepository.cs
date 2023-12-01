using apiweb.healthclinic.manha.Domains;

namespace apiweb.healthclinic.manha.Interfaces
{
    public interface IConsultaRepository
    {
        void Cadastrar(Consulta novaConsulta);

        void AtualizarProntuario(AtualizarProntuarioConsultaRequest consultaAtualizada);

        void AtualizarComentario(AtualizarComentarioConsultaRequest consultaAtualizada);

        void Deletar(Guid id);

        List<Consulta> Listar();

        List<Consulta> ListarPorPaciente(Guid IdPaciente);

        List<Consulta> ListarPorMedico(Guid IdMedico);
    }
}
