using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace apiweb.healthclinic.manha.Dto.Consultas;
    public record Prontuario(
    [property: JsonPropertyName("label")] string Label,
    [property: JsonPropertyName("value")] string Value);

