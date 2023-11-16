using System.ComponentModel.DataAnnotations;

namespace apiweb.healthclinic.manha.ViewModels
{
    public class UsuarioViewModel
    {

        [Required(ErrorMessage = "Nome do usuário obrigatório!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Email do usuário obrigatório!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Senha do usuário obrigatória!")]
        [StringLength(60, MinimumLength = 6, ErrorMessage = "A senha deve conter de 6 a 60 caracteres")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Data de nascimento obrigatória!")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "Campo de sexo obrigatório!")]
        public string Sexo { get; set; }

        [Required(ErrorMessage = "Informe o tipo do usuário!")]
        public Guid IdTipoUsuario { get; set; }

        // Campos específicos para o médico
        public string CRM { get; set; }
        public string Especialidade { get; set; }
    }
}
