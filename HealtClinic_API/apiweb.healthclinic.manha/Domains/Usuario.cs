using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apiweb.healthclinic.manha.Domains
{
    [Table(nameof(Usuario))]
    [Index(nameof(Email), IsUnique = true)]
    public class Usuario
    {
        [Key]
        public Guid IdUsuario { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(100)")]
        [Required]
        public string? Nome { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required]
        public string? Email { get; set; }

        [Column(TypeName = "VARCHAR(MAX)")]
        [Required]
        [StringLength(60, MinimumLength = 6, ErrorMessage = "A senha deve conter de 6 a 60 caracteres")]
        public string? Senha { get; set; }

        [Column(TypeName = "DATE")]
        public DateTime? DataNascimento { get; set; }

        [Column(TypeName = "VARCHAR(50)")]
        public string? Sexo { get; set; }

        [Column(TypeName = "VARCHAR(MAX)")]
        public string? CaminhoImagem { get; set; }

        [Required]
        //Referencia com TiposUsuario
        public Guid IdTipoUsuario { get; set; }

        [ForeignKey(nameof(IdTipoUsuario))]
        //ForeignKey com (IdTipoUsuario))]
        public TiposUsuario? TiposUsuario { get; set; }
    }
}