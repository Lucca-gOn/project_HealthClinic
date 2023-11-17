using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace apiweb.healthclinic.manha.Domains
{
    [Table(nameof(Especialidade))]
    public class Especialidade
    {  
        [Key]
        public Guid IdEspecialidade { get; set; } = Guid.NewGuid();

        [Column(TypeName = "TEXT")]
        public string? TituloEspecialidade { get; set; }

    }
}
