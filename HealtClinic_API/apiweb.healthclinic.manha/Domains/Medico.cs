using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apiweb.healthclinic.manha.Domains
{
    [Table(nameof(Medico))]
    [Index(nameof(CRM), IsUnique = true)]
    public class Medico
    {
        [Key]
        public Guid IdMedico { get; set; }  = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(8)")]
        public string? CRM { get; set; }

        //Referencia com Usuario
        public Guid IdUsuario { get; set; }

        [ForeignKey(nameof(IdUsuario))]
        //ForeignKey com (IdUsuario))]
        public Usuario? Usuario { get; set; }

        //Referencia com Especialidade
        public Guid IdEspecialidade { get; set; }

        [ForeignKey(nameof(IdEspecialidade))]
        //ForeignKey com (IdUsuario))]
        public Especialidade? Especialidade { get; set; }

    }
}
