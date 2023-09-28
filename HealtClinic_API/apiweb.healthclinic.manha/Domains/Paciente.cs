using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apiweb.healthclinic.manha.Domains
{
    [Table(nameof(Paciente))]
    [Index(nameof(CPF), IsUnique = true)]
    [Index(nameof(RG), IsUnique = true)]
    public class Paciente
    {
        [Key]
        public Guid IdPaciente { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(12)")]
        [Required(ErrorMessage = "CPF obrigatório!")]
        public string? CPF { get; set; }

        [Column(TypeName = "VARCHAR(12)")]
        [Required(ErrorMessage = "RG obrigatório!")]
        public string? RG { get; set; }

        [Column(TypeName = "VARCHAR(30)")]
        [Required(ErrorMessage = "Telefone obrigatório!")]
        public string? Telefone { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Endereço obrigatório!")]
        public string? Endereco { get; set; }

        //Referencia com Usuario
        [Required(ErrorMessage = "Informe o usuário!")]
        public Guid IdUsuario { get; set; }

        [ForeignKey(nameof(IdUsuario))]
        //ForeignKey com (IdUsuario))]
        public Usuario? Usuario { get; set; }
    }
}
