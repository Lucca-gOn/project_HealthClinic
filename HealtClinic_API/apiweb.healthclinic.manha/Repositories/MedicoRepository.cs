using apiweb.healthclinic.manha.Contexts;
using apiweb.healthclinic.manha.Domains;
using apiweb.healthclinic.manha.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace apiweb.healthclinic.manha.Repositories
{
    public class MedicoRepository : IMedicoRepository
    {
        private readonly HealthContext _healthContext;

        public MedicoRepository(HealthContext healthContext)
        {
            _healthContext = healthContext;
        }

        public Medico BuscarPorId(Guid id)
        {
            try
            {
                return _healthContext.Medico.Include(m => m.Usuario).FirstOrDefault(e => e.IdMedico == id)!;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(Medico novoMedico)
        {
            try
            {
                _healthContext.Add(novoMedico);
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
                _healthContext.Medico.Where(e => e.IdMedico == id).ExecuteDelete();
                _healthContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Medico> Listar()
        {
            try
            {
                return _healthContext.Medico
                    .Include(m => m.Usuario)
                        .ThenInclude(m => m.TiposUsuario)
                    .Include(m => m.Especialidade)
                    .Select(m => new Medico
                    {
                        IdMedico = m.IdMedico,
                        CRM = m.CRM,
                        IdUsuario = m.Usuario!.IdUsuario,
                        Usuario = new Usuario
                        {
                            IdUsuario = m.Usuario.IdUsuario,
                            Nome = m.Usuario.Nome,
                            Email = m.Usuario.Email,
                            DataNascimento = m.Usuario.DataNascimento,
                            Sexo = m.Usuario.Sexo,
                            CaminhoImagem = m.Usuario.CaminhoImagem,

                            TiposUsuario = new TiposUsuario
                            {
                                IdTipoUsuario = m.Usuario.IdTipoUsuario,
                                Titulo = m.Usuario.TiposUsuario!.Titulo
                            }
                        },
                        Especialidade = new Especialidade
                        {
                            IdEspecialidade = m.IdEspecialidade,
                            TituloEspecialidade = m.Especialidade!.TituloEspecialidade
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
