using apiweb.healthclinic.manha.Contexts;
using apiweb.healthclinic.manha.Domains;
using apiweb.healthclinic.manha.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace apiweb.healthclinic.manha.Repositories
{
    public class ComentarioRepository : IComentarioRepository
    {
        private readonly HealthContext _healthContext;

        public ComentarioRepository(HealthContext healthContext)
        {
            _healthContext = healthContext;
        }

        public void Atualizar(Guid id, Comentario comentario)
        {
            try
            {
                Comentario buscarComentario = _healthContext.Comentario.Find(id)!;
                if (buscarComentario != null)
                {
                    buscarComentario.DescricaoComentario = comentario.DescricaoComentario;

                    _healthContext.Update(buscarComentario);
                    _healthContext.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Comentario BuscarPorId(Guid id)
        {
            try
            {
                return _healthContext.Comentario.FirstOrDefault(e => e.IdComentario == id)!;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(Comentario novoComentario)
        {
            try
            {
                _healthContext.Comentario.Add(novoComentario);
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
                _healthContext.Comentario.Where(e => e.IdComentario == id).ExecuteDelete();
                _healthContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Comentario> Listar()
        {
            try
            {
                return _healthContext.Comentario.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
