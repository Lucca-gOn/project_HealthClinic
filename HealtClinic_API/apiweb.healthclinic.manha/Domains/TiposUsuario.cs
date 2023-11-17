using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apiweb.healthclinic.manha.Domains
{
    [Table(nameof(TiposUsuario))]
    public class TiposUsuario
    {
        [Key]
        public Guid IdTipoUsuario { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(100)")]
        public string? Titulo { get; set; }
    }
}
