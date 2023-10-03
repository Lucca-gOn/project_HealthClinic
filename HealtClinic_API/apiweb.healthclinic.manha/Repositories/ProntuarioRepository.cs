using apiweb.healthclinic.manha.Contexts;
using apiweb.healthclinic.manha.Domains;
using apiweb.healthclinic.manha.Interfaces;

namespace apiweb.healthclinic.manha.Repositories
{
    public class ProntuarioRepository : IProntuarioRepository
    {
        private readonly HealthContext _healthContext;

        public ProntuarioRepository()
        {
            _healthContext = new HealthContext();
        }
        public void Atualizar(Guid id, Prontuario prontuario)
        {
            try
            {
                Prontuario buscarProntuario = _healthContext.Prontuario.Find(id)!;
                if (buscarProntuario != null)
                {
                    buscarProntuario.DescricaoProntuario = prontuario.DescricaoProntuario;

                    _healthContext.Update(buscarProntuario);

                    _healthContext.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Prontuario BuscarPorId(Guid id)
        {
            try
            {
                return _healthContext.Prontuario.FirstOrDefault(e => e.IdProntuario == id)!;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(Prontuario novoProntuario)
        {
            try
            {
                _healthContext.Prontuario.Add(novoProntuario);
                _healthContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
