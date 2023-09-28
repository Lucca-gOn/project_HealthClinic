using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apiweb.healthclinic.manha.Domains
{
    [Table(nameof(Prontuario))]
    public class Prontuario
    {
        [Key] 
        public Guid IdProntuario { get; set; } = Guid.NewGuid();

        [Column(TypeName ="TEXT")]
        [Required(ErrorMessage = "Descrição do prontuário obrigatória!")]
        public string? DescricaoProntuario { get; set; }
    }
}
