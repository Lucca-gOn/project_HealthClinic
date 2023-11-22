using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apiweb.healthclinic.manha.Domains
{
    [Table(nameof(Paciente))]
    [Index(nameof(CPF), IsUnique = true)]
    public class Paciente
    {
        [Key]
        public Guid IdPaciente { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(12)")]
        public string? CPF { get; set; }

        //Referencia com Usuario
        [Required(ErrorMessage = "Informe o usuário!")]
        public Guid IdUsuario { get; set; }

        [ForeignKey(nameof(IdUsuario))]
        //ForeignKey com (IdUsuario))]
        public Usuario? Usuario { get; set; }
    }
}
