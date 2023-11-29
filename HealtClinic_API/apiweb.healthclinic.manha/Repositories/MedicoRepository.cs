using apiweb.healthclinic.manha.Contexts;
using apiweb.healthclinic.manha.Domains;
using apiweb.healthclinic.manha.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace apiweb.healthclinic.manha.Repositories
{
    public class MedicoRepository : IMedicoRepository
    {
        private readonly HealthContext _healthContext;

        public MedicoRepository(HealthContext healthContext)
        {
            _healthContext = healthContext;
        }

        public Medico BuscarPorId(Guid id)
        {
            try
            {
                return _healthContext.Medico.Include(m => m.Usuario).FirstOrDefault(e => e.IdMedico == id)!;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(Medico novoMedico)
        {
            try
            {
                _healthContext.Add(novoMedico);
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
                _healthContext.Medico.Where(e => e.IdMedico == id).ExecuteDelete();
                _healthContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Medico> Listar()
        {
            try
            {
                return _healthContext.Medico.Include(p => p.Usuario).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
