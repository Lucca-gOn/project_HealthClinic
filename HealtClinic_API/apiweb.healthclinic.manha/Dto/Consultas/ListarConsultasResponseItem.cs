using System.Text.Json.Serialization;

public record ListarConsultasResponseItem(
    [property: JsonPropertyName("_id")] Guid Id,
    [property: JsonPropertyName("name")] string Nome,
    [property: JsonPropertyName("image_src")] string CaminhoImagem,
    [property: JsonPropertyName("doctor_name")] string NomeMedico,
    [property: JsonPropertyName("doctor_image_src")] string CaminhoImagemMedico,
    [property: JsonPropertyName("specialty")] string Especialidade,
    [property: JsonPropertyName("consulta_data")] DateOnly DataConsulta,
    [property: JsonPropertyName("consulta_hora")] TimeOnly HoraConsulta
);