using apiweb.healthclinic.manha.Contexts;
using apiweb.healthclinic.manha.Domains;
using apiweb.healthclinic.manha.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace apiweb.healthclinic.manha.Repositories
{
    public class TiposUsuarioRepository : ITiposUsuarioRepository
    {
        private readonly HealthContext _healthContext;

        public TiposUsuarioRepository()
        {
            _healthContext = new HealthContext();
        }
        public void Atualizar(Guid id, TiposUsuario tipoUsuario)
        {
            try
            {
                TiposUsuario buscarTiposUsuario = _healthContext.TiposUsuario.Find(id)!;
                if (buscarTiposUsuario != null)
                {
                    buscarTiposUsuario!.Titulo = tipoUsuario.Titulo;

                    _healthContext.Update(buscarTiposUsuario);

                    _healthContext.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public TiposUsuario BuscarPorId(Guid id)
        {
            try
            {
                return _healthContext.TiposUsuario.FirstOrDefault(e => e.IdTipoUsuario == id)!;
            }
            catch (Exception)
            {

                throw;
            }
            

        }

        public void Cadastrar(TiposUsuario novoTipoUsuario)
        {
            try
            {
                _healthContext.TiposUsuario.Add(novoTipoUsuario);
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
                _healthContext.TiposUsuario.Where(e => e.IdTipoUsuario == id).ExecuteDelete();
                _healthContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public List<TiposUsuario> Listar()
        {
            try
            {
               return _healthContext.TiposUsuario.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
