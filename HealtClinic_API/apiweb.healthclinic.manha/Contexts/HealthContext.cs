using apiweb.healthclinic.manha.Domains;
using Microsoft.EntityFrameworkCore;

namespace apiweb.healthclinic.manha.Contexts
{
    public class HealthContext : DbContext
    {
        public HealthContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<TiposUsuario> TiposUsuario { get; set; }
        public DbSet<Prontuario> Prontuario { get; set; }
        public DbSet<Paciente> Paciente { get; set; }
        public DbSet<Medico> Medico { get; set; }
        public DbSet<Especialidade> Especialidade { get; set; }
        public DbSet<Consulta> Consulta { get; set; }
        public DbSet<Comentario> Comentario { get; set; }
        public DbSet<Clinica> Clinica { get; set; }
    }
}
