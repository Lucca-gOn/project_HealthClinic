using apiweb.healthclinic.manha.Contexts;
using apiweb.healthclinic.manha.Domains;
using apiweb.healthclinic.manha.Interfaces;

namespace apiweb.healthclinic.manha.Repositories
{
    public class StatusConsultaRepository : IStatusConsultaRepository
    {
        private readonly HealthContext _healthContext;

        public StatusConsultaRepository()
        {
            _healthContext = new HealthContext();
        }
        public void Atualizar(Guid id, StatusConsulta statusConsulta)
        {
            try
            {
                StatusConsulta buscarTipoConsulta = _healthContext.StatusConsulta.Find(id)!;
                if (buscarTipoConsulta != null)
                {
                    buscarTipoConsulta.DescricaoStatusConsulta = statusConsulta.DescricaoStatusConsulta;

                    _healthContext.Update(buscarTipoConsulta);

                    _healthContext.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public StatusConsulta BuscarPorId(Guid id)
        {
            try
            {
               return _healthContext.StatusConsulta.FirstOrDefault(e => e.IdStatusConsulta == id)!;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(StatusConsulta novoStatusConsulta)
        {
            try
            {
                _healthContext.StatusConsulta.Add(novoStatusConsulta);
                _healthContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
