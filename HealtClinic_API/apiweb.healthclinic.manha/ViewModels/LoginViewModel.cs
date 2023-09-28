using System.ComponentModel.DataAnnotations;

namespace apiweb.healthclinic.manha.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Email obrigatório!")]
        public string? Email { get; set; }

        [Required(ErrorMessage ="Senha obrigatória")]
        public string? Senha { get; set; }
    }
}
