using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apiweb.healthclinic.manha.Domains
{
    [Table(nameof(Clinica))]
    [Index(nameof(CNPJ), IsUnique = true)]
    public class Clinica
    {
        [Key]
        public Guid IdClinica { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(100)")]
        [Required]
        public string? NomeFantasia { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required]
        public string? RazaoSocial { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required]
        public string? Endereco { get; set; }

        [Column(TypeName = "VARCHAR(20)")]
        [Required]
        public string? CEP { get; set; }

        [Column(TypeName = "VARCHAR(30)")]
        [Required]
        public string? Numero { get; set; }

        [Column(TypeName = "VARCHAR(MAX)")]
        [Required]
        public string? PrimeiroDiaSemana { get; set; }

        [Column(TypeName = "VARCHAR(MAX)")]
        [Required]
        public string? SegundoDiaSemana { get; set; }

        [Column(TypeName = "VARCHAR(25)")]
        [Required]
        [StringLength(25)]
        public string? CNPJ { get; set; }

        [Column(TypeName = "TIME")]
        [Required]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = @"hh\:mm")]
        public TimeSpan HorarioAbertura { get; set; }

        [Column(TypeName = "TIME")]
        [Required]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = @"hh\:mm")]
        public TimeSpan HorarioFechamento { get; set; }   
    }
}
