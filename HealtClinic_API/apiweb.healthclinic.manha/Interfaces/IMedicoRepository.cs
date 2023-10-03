using apiweb.healthclinic.manha.Domains;

namespace apiweb.healthclinic.manha.Interfaces
{
    public interface IMedicoRepository
    {
        void Cadastrar(Medico novoMedico);

        void Deletar(Guid id);

        List<Medico> Listar();
    }
}
