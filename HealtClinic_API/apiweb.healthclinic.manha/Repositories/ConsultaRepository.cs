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
                _healthContext.Consulta.Where(e => e.IdConsulta == id).ExecuteDelete();
                _healthContext.SaveChanges();
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
                    .ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Consulta> ListarPorPaciente(Guid IdPaciente)
        {
            return _healthContext.Consulta.Where(e => e.IdPaciente == IdPaciente).ToList();
        }
    }
}
