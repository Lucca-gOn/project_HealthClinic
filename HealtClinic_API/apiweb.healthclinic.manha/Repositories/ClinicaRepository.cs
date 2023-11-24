using apiweb.healthclinic.manha.Contexts;
using apiweb.healthclinic.manha.Domains;
using apiweb.healthclinic.manha.Interfaces;

namespace apiweb.healthclinic.manha.Repositories
{
    public class ClinicaRepository : IClinicaRepository
    {
        private readonly HealthContext _healthContext;

        public ClinicaRepository(HealthContext healthContext)
        {
            _healthContext = healthContext;
        }

        public void Atualizar(Guid id, Clinica clinica)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Clinica novaClinica)
        {
            try
            {
                _healthContext.Add(novaClinica);
                _healthContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Deletar(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Clinica> Listar()
        {
            try
            {
                return _healthContext.Clinica.ToList();
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
