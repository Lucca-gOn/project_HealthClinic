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
        [Required(ErrorMessage = "Nome fantasia obrigatório!")]
        public string? NomeFantasia { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Razão social obrigatório!")]
        public string? RazaoSocial { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Endereço obrigatório!")]
        public string? Endereco { get; set; }

        [Column(TypeName = "VARCHAR(8)")]
        [Required(ErrorMessage = "CEP obrigatório!")]
        public string? CEP { get; set; }

        [Column(TypeName = "VARCHAR(30)")]
        [Required(ErrorMessage = "Número obrigatório!")]
        public string? Numero { get; set; }

        [Column(TypeName = "VARCHAR(MAX)")]
        [Required(ErrorMessage = "Primeiro dia semana obrigatório!")]
        public string? PrimeiroDiaSemana { get; set; }

        [Column(TypeName = "VARCHAR(MAX)")]
        [Required(ErrorMessage = "Segundo dia semana obrigatório!")]
        public string? SegundoDiaSemana { get; set; }

        [Column(TypeName = "VARCHAR(14)")]
        [Required(ErrorMessage = "CNPJ obrigatório!")]
        [StringLength(14)]
        public string? CNPJ { get; set; }

        [Column(TypeName = "TIME")]
        [Required(ErrorMessage = "Horário de abertura obrigatório!")]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = @"hh\:mm")]
        public TimeSpan HorarioAbertura { get; set; }

        [Column(TypeName = "TIME")]
        [Required(ErrorMessage = "Horário de fechamento obrigatório!")]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = @"hh\:mm")]
        public TimeSpan HorarioFechamento { get; set; }   
    }
}
