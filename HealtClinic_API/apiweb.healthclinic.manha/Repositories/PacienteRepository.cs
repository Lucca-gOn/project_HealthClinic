using apiweb.healthclinic.manha.Contexts;
using apiweb.healthclinic.manha.Domains;
using apiweb.healthclinic.manha.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace apiweb.healthclinic.manha.Repositories
{
    public class PacienteRepository : IPacienteRepository
    {
        private readonly HealthContext _healthContext;

        public PacienteRepository(HealthContext healthContext)
        {
            _healthContext = healthContext;
        }

        public void Atualizar(Guid id, Paciente paciente)
        {
            try
            {
                Paciente buscarPaciente = _healthContext.Paciente.Find(id)!;

                _healthContext.Update(buscarPaciente);
                _healthContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Paciente BuscarPorId(Guid id)
        {
            try
            {
                return _healthContext.Paciente.FirstOrDefault(e => e.IdPaciente == id)!;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(Paciente novoPaciente)
        {
            try
            {
                _healthContext.Add(novoPaciente);
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
                _healthContext.Paciente.Where(e => e.IdPaciente == id).ExecuteDelete();
                _healthContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Paciente> Listar()
        {
            try
            {
                return _healthContext.Paciente.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
