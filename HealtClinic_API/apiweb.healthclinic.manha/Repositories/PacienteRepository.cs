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
                return _healthContext.Paciente.Include(p => p.Usuario).FirstOrDefault(e => e.IdPaciente == id)!;
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
                return _healthContext.Paciente
                    .Include(p => p.Usuario)
                        .ThenInclude(p => p.TiposUsuario)
                    .Select(p => new Paciente
                    {
                        IdPaciente = p.IdPaciente,
                        CPF = p.CPF,
                        IdUsuario = p.IdUsuario,
                        Usuario = new Usuario
                        {
                            IdUsuario = p.Usuario!.IdUsuario,
                            Nome = p.Usuario.Nome,
                            Email = p.Usuario.Email,
                            DataNascimento = p.Usuario.DataNascimento,
                            Sexo = p.Usuario.Sexo,
                            CaminhoImagem = p.Usuario.CaminhoImagem,
                            TiposUsuario = new TiposUsuario
                            {
                                IdTipoUsuario = p.Usuario.IdTipoUsuario,
                                Titulo = p.Usuario.TiposUsuario!.Titulo
                            }
                        }

                    }).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
