using apiweb.healthclinic.manha.Contexts;
using apiweb.healthclinic.manha.Domains;
using apiweb.healthclinic.manha.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace apiweb.healthclinic.manha.Repositories
{
    public class ConsultaRepository : IConsultaRepository
    {
        private readonly HealthContext _healthContext;

        public ConsultaRepository(HealthContext healthContext)
        {
            _healthContext = healthContext;
        }

        public void Atualizar(Consulta consulta)
        {
            try
            {
                var consultaExistente = _healthContext.Consulta.Find(consulta.IdConsulta);
                if (consultaExistente != null)
                {
                    _healthContext.Entry(consultaExistente).CurrentValues.SetValues(consulta);
                    _healthContext.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Consulta BuscarPorId(Guid id)
        {
            try
            {
                return _healthContext.Consulta.FirstOrDefault(e => e.IdConsulta == id)!;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(Consulta novaConsulta)
        {
            try
            {
                _healthContext.Add(novaConsulta);
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
                var consultaDeletar = _healthContext.Consulta
                    .Include(c => c.Comentario) 
                    .Include(c => c.Prontuario) 
                    .FirstOrDefault(e => e.IdConsulta == id);

                if (consultaDeletar != null)
                {
                    // Remover o comentário relacionado/prontuario
                    if (consultaDeletar.Comentario != null)
                    {
                        _healthContext.Comentario.Remove(consultaDeletar.Comentario);
                    }if (consultaDeletar.Prontuario != null)
                    {
                        _healthContext.Prontuario.Remove(consultaDeletar.Prontuario);
                    }

                    _healthContext.Consulta.Remove(consultaDeletar);
                    _healthContext.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Consulta> Listar()
        {
            try
            {
                return _healthContext.Consulta
                    .Include(c => c.Paciente)
                        .ThenInclude(p => p.Usuario)
                    .Include(c => c.Medico)
                        .ThenInclude(m => m.Usuario)
                    .Include(c => c.Medico)
                        .ThenInclude(m => m.Especialidade)
                    .Include(c => c.Prontuario)
                    .Include(c => c.Comentario) 
                    .ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Consulta> ListarPorUsuario(Guid IdUsuario)
        {
            try
            {
                return _healthContext.Consulta
                    .Include(c => c.Paciente)
                        .ThenInclude(p => p.Usuario)
                    .Include(c => c.Medico)
                        .ThenInclude(m => m.Usuario)
                    .Include(c => c.Medico)
                        .ThenInclude(m => m.Especialidade)
                    .Include(c => c.Prontuario)
                    .Include(c => c.Comentario)
                    .Where(c => c.Medico.Usuario.IdUsuario == IdUsuario || c.Paciente.Usuario.IdUsuario == IdUsuario)
                    .ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
