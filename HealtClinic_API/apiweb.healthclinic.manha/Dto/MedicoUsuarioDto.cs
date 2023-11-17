using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace apiweb.healthclinic.manha.Dto
{
    public class MedicoUsuarioDto
    {
        // Dados do usuário
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string? Sexo { get; set; }

        // Dados do médico
        public string CRM { get; set; }
        public string Especialidade { get; set; }

        // Arquivo da imagem
        public IFormFile File { get; set; }
    }
}
