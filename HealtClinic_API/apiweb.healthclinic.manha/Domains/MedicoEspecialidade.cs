using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apiweb.healthclinic.manha.Domains
{
    [Table(nameof(MedicoEspecialidade))]
    public class MedicoEspecialidade
    {
        [Key]
        public Guid IdMedicoEspecialidade { get; set; } = Guid.NewGuid();
        
        //Referencia com Medico
        [Required(ErrorMessage = "Informe o tipo do médico!")]
        public Guid IdMedico { get; set; }

        [ForeignKey(nameof(IdMedico))]
        //ForeignKey com (IdMedico))]
        public Medico? Medico { get; set; }


        //Referencia com TiposUsuario
        [Required(ErrorMessage = "Informe o tipo da especialidade!")]
        public Guid IdEspecialidade { get; set; }

        [ForeignKey(nameof(IdEspecialidade))]
        //ForeignKey com (IdTipoUsuario))]
        public Especialidade? Especialidade { get; set; }
    }
}
