using System.Text.Json.Serialization;

namespace apiweb.healthclinic.manha.Dto.Usuarios;

public record TipoUsuario(
    [property: JsonPropertyName("label")] string Label,
    [property: JsonPropertyName("value")] string Value);
