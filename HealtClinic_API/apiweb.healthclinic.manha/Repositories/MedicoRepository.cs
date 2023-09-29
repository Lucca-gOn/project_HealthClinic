using apiweb.healthclinic.manha.Domains;
using apiweb.healthclinic.manha.Interfaces;

namespace apiweb.healthclinic.manha.Repositories
{
    public class MedicoRepository : IMedicoRepository
    {
        public void Atualizar(Guid id, Medico medico)
        {
            throw new NotImplementedException();
        }

        public List<Medico> BuscarMedicoPorEspecialidade(string buscarEspecialidade)
        {
            throw new NotImplementedException();
        }

        public Medico BuscarPorNome(string nomeMedico)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Medico novoMedico)
        {
            throw new NotImplementedException();
        }

        public void Deletar(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Medico> Listar()
        {
            throw new NotImplementedException();
        }
    }
}
