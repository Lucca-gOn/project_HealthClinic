using apiweb.healthclinic.manha.Dto.Consultas;
using System.Text.Json.Serialization;
public record CriarConsultaRequest(
    [property: JsonPropertyName("patient")] Paciente Paciente,
    [property: JsonPropertyName("esp")] Especialidade Esp,
    [property: JsonPropertyName("doctor")] Medico Medico,
    [property: JsonPropertyName("consultationDate")] DateTime DateConsulta,
    [property: JsonPropertyName("consultationTime")] DateTime TimeConsulta);

