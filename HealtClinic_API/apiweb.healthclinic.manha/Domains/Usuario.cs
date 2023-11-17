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
        [Required(ErrorMessage = "Nome do usuario obrigatório!")]
        public string? Nome { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Email do usuario obrigatório!")]
        public string? Email { get; set; }

        [Column(TypeName = "VARCHAR(MAX)")]
        [Required(ErrorMessage = "Senha do usuario obrigatório!")]
        [StringLength(60, MinimumLength = 6, ErrorMessage = "A senha deve conter de 6 a 60 caracteres")]
        public string? Senha { get; set; }

        [Column(TypeName = "DATE")]
        [Required(ErrorMessage = "Data de nascimento obrigatória!")]
        public DateTime? DataNascimento { get; set; }

        [Column(TypeName = "VARCHAR(20)")]
        [Required(ErrorMessage = "Campo de sexo obrigatório!")]
        public string? Sexo { get; set; }

        [Column(TypeName = "VARCHAR(MAX)")]
        public string CaminhoImagem { get; set; }

        //Referencia com TiposUsuario
        [Required(ErrorMessage = "Informe o tipo do usuário!")]
        public Guid IdTipoUsuario { get; set; }

        [ForeignKey(nameof(IdTipoUsuario))]
        //ForeignKey com (IdTipoUsuario))]
        public TiposUsuario? TiposUsuario { get; set; }
    }
}