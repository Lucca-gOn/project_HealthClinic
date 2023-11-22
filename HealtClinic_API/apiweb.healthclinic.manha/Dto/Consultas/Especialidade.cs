using System.Text.Json.Serialization;

namespace apiweb.healthclinic.manha.Dto.Consultas;

public record Especialidade(
    [property: JsonPropertyName("label")] string Label,
    [property: JsonPropertyName("value")] string Value);
