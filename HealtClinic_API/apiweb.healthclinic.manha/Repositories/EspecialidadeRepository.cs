using apiweb.healthclinic.manha.Contexts;
using apiweb.healthclinic.manha.Domains;
using apiweb.healthclinic.manha.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace apiweb.healthclinic.manha.Repositories
{
    public class EspecialidadeRepository : IEspecialidadeRepository
    {
        private readonly HealthContext _healthContext;

        public EspecialidadeRepository()
        {
                _healthContext = new HealthContext();
        }
        public void Cadastrar(Especialidade novaEspecialidade)
        {
            try
            {
                _healthContext.Add(novaEspecialidade);
                _healthContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Deletar(Guid id)
        {
            try
            {
                _healthContext.Especialidade.Where(e => e.IdEspecialidade == id).ExecuteDelete();
                _healthContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Especialidade> Listar()
        {
            try
            {
                return _healthContext.Especialidade.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
