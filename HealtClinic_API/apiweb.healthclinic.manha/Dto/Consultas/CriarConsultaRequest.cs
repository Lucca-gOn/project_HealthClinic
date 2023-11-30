using apiweb.healthclinic.manha.Dto.Consultas;
using System.Text.Json.Serialization;

public record CriarConsultaRequest(
    [property: JsonPropertyName("patient")] Paciente Paciente,
    [property: JsonPropertyName("esp")] string Esp,
    [property: JsonPropertyName("doctor")] Medico Medico,
    [property: JsonPropertyName("prontuario")] string Prontuario,
    [property: JsonPropertyName("comentario")] string Comentario,
    [property: JsonPropertyName("consultationDateTime")] string DataHorarioConsulta);

