using apiweb.healthclinic.manha.Dto.Consultas;
using System.Text.Json.Serialization;

public record AtualizarProntuarioConsultaRequest(
    [property: JsonPropertyName("id")] Guid Id,
    [property: JsonPropertyName("prontuario")] string Prontuario);