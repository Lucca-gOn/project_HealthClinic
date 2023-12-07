﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apiweb.healthclinic.manha.Domains
{
    [Table(nameof(Consulta))]
    public class Consulta
    {
        [Key] 
        public Guid IdConsulta { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "Data e horário da consulta obrigatórios!")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public DateTime DataHorarioConsulta { get; set; }

        //Referencia com Paciente
        [Required]
        public Guid IdPaciente { get; set; }

        [ForeignKey(nameof(IdPaciente))]
        //ForeignKey com (IdPaciente))]
        public Paciente? Paciente { get; set; }

        //Referencia com Medico
        [Required]
        public Guid IdMedico { get; set; }

        [ForeignKey(nameof(IdMedico))]
        //ForeignKey com (IdMedico))]
        public Medico? Medico { get; set; }

        //Referencia com Prontuario
        public Guid IdProntuario { get; set; }

        [ForeignKey(nameof(IdProntuario))]
        //ForeignKey com (IdProntuario))]
        public Prontuario? Prontuario { get; set; }

        //Referencia com Comentario
        public Guid IdComentario { get; set; }

        [ForeignKey(nameof(IdComentario))]
        //ForeignKey com (IdComentario))]
        public Comentario? Comentario { get; set; }
    }
}
