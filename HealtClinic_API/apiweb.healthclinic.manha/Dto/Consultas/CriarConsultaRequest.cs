using apiweb.healthclinic.manha.Dto.Consultas;
using System.Text.Json.Serialization;
public record CriarConsultaRequest(
    [property: JsonPropertyName("patient")] Paciente Paciente,
    [property: JsonPropertyName("esp")] string Esp,
    [property: JsonPropertyName("doctor")] string Doutor,
    [property: JsonPropertyName("consultationDate")] DateTime DateConsulta,
    [property: JsonPropertyName("consultationTime")] DateTime TimeConsulta);

