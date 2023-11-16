﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apiweb.healthclinic.manha.Domains
{
    [Table(nameof(Medico))]
    [Index(nameof(CRM), IsUnique = true)]
    public class Medico
    {
        [Key]
        public Guid IdMedico { get; set; }  = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(8)")]
        [Required(ErrorMessage = "CRM do médico obrigatório!")]
        public string? CRM { get; set; }

        [Column(TypeName = "VARCHAR(MAX)")]
        [Required(ErrorMessage = "Especialidade do médico obrigatória!")]
        public string? Especialidade { get; set; }

        //Referencia com Usuario
        [Required(ErrorMessage = "Informe o usuário!")]
        public Guid IdUsuario { get; set; }

        [ForeignKey(nameof(IdUsuario))]
        //ForeignKey com (IdUsuario))]
        public Usuario? Usuario { get; set; }

    }
}
