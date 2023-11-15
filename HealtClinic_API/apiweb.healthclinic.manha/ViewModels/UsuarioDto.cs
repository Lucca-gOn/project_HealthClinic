using System.ComponentModel.DataAnnotations;

namespace apiweb.healthclinic.manha.ViewModels
{
    public class UsuarioDto
    {

        [Required(ErrorMessage = "Nome do usuario obrigatório!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Email do usuario obrigatório!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Senha do usuario obrigatório!")]
        [StringLength(60, MinimumLength = 6, ErrorMessage = "A senha deve conter de 6 a 60 caracteres")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Data de nascimento obrigatória!")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "Campo de sexo obrigatório!")]
        public string Sexo { get; set; }

        [Required(ErrorMessage = "Informe o tipo do usuário!")]
        public Guid IdTipoUsuario { get; set; }

    }
}
