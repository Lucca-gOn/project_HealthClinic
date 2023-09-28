using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apiweb.healthclinic.manha.Domains
{
    [Table(nameof(Consulta))]
    public class Consulta
    {
        [Key] 
        public Guid IdConsulta { get; set; } = Guid.NewGuid();

        [Column(TypeName ="DATE")]
        [Required(ErrorMessage ="Data da consulta obrigatória!")]
        public DateTime DataConsulta { get; set; }


        [Column(TypeName = "TIME")]
        [Required(ErrorMessage = "Horário da consulta obrigatório!")]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = @"hh\:mm")]
        public TimeSpan HorarioConsulta { get; set; }

        //Referencia com Paciente
        [Required(ErrorMessage = "Informe o paciente!")]
        public Guid IdPaciente { get; set; }

        [ForeignKey(nameof(IdPaciente))]
        //ForeignKey com (IdPaciente))]
        public Paciente? Paciente { get; set; }


        //Referencia com Medico
        [Required(ErrorMessage = "Informe o tipo do médico!")]
        public Guid IdMedico { get; set; }

        [ForeignKey(nameof(IdMedico))]
        //ForeignKey com (IdMedico))]
        public Medico? Medico { get; set; }


        //Referencia com Comentario
        [Required(ErrorMessage = "Informe o comentário!")]
        public Guid IdComentario { get; set; }

        [ForeignKey(nameof(IdComentario))]
        //ForeignKey com (IdComentario))]
        public Comentario? Comentario { get; set; }


        //Referencia com StatusConsulta
        [Required(ErrorMessage = "status da consulta obrigatório!")]
        public Guid IdStatusConsulta { get; set; }

        [ForeignKey(nameof(IdStatusConsulta))]
        //ForeignKey com (IdStatusConsulta))]
        public StatusConsulta? StatusConsulta { get; set; }


        //Referencia com Prontuario
        [Required(ErrorMessage = "Prontuario obrigatório!")]
        public Guid IdProntuario { get; set; }

        [ForeignKey(nameof(IdProntuario))]
        //ForeignKey com (IdProntuario))]
        public Prontuario? Prontuario { get; set; }
    }
}
