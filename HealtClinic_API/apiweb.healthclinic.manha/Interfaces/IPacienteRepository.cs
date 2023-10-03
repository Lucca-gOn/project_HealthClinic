using apiweb.healthclinic.manha.Domains;

namespace apiweb.healthclinic.manha.Interfaces
{
    public interface IPacienteRepository
    {
        void Cadastrar(Paciente novoPaciente);

        void Deletar(Guid id);

        Paciente BuscarPorId(Guid id);

        List<Paciente> Listar();

        void Atualizar(Guid id, Paciente paciente);
    }
}
