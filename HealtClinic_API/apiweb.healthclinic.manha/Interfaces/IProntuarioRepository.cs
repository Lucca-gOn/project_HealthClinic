using apiweb.healthclinic.manha.Domains;

namespace apiweb.healthclinic.manha.Interfaces
{
    public interface IProntuarioRepository
    {
        void Cadastrar(Prontuario novoProntuario);

        Prontuario BuscarPorId(Guid id);

        void Atualizar(Guid id, Prontuario prontuario);
    }
}
