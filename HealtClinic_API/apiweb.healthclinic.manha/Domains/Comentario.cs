using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apiweb.healthclinic.manha.Domains
{
    [Table(nameof(Comentario))]
    public class Comentario
    {
        [Key]
        public Guid IdComentario { get; set; } = Guid.NewGuid();

        [Column(TypeName = "TEXT")]
        [Required(ErrorMessage = "Descrição do comentário obrigatória!")]
        public string? DescricaoComentario { get; set; }

        //Referencia com Paciente
        [Required(ErrorMessage = "Informe o paciente!")]
        public Guid IdPaciente { get; set; }

        [ForeignKey(nameof(IdPaciente))]
        //ForeignKey com (IdPaciente))]
        public Paciente? Paciente { get; set; }


        //Referencia com Consulta
        [Required(ErrorMessage = "Consulta obrigatória!")]
        public Guid IdConsulta { get; set; }

        [ForeignKey(nameof(IdConsulta))]
        //ForeignKey com (IdConsulta))]
        public Consulta? Consulta { get; set; }
    }
}
