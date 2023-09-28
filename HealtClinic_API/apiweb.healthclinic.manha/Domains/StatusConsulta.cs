using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apiweb.healthclinic.manha.Domains
{
    [Table(nameof(StatusConsulta))]
    public class StatusConsulta
    {
        [Key]
        public Guid IdStatusConsulta {  get; set; } = Guid.NewGuid();

        [Column(TypeName = "TEXT")]
        [Required(ErrorMessage = "Descrição da consulta obrigatória!")]
        public string? DescricaoStatusConsulta { get; set; }
    }
}
