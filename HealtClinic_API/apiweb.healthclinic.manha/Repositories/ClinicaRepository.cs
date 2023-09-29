using apiweb.healthclinic.manha.Contexts;
using apiweb.healthclinic.manha.Domains;
using apiweb.healthclinic.manha.Interfaces;

namespace apiweb.healthclinic.manha.Repositories
{
    public class ClinicaRepository : IClinicaRepository
    {
        private readonly HealthContext _healthContext;

        public ClinicaRepository()
        {
            _healthContext = new HealthContext();
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
