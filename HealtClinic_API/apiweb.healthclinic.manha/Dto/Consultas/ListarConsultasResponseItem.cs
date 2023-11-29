using System.Text.Json.Serialization;

public record ListarConsultasResponseItem(
    [property: JsonPropertyName("_id")] Guid Id,
    [property: JsonPropertyName("name")] string Nome,
    [property: JsonPropertyName("image_src")] string CaminhoImagem,
    [property: JsonPropertyName("doctor_name")] string NomeMedico,
    [property: JsonPropertyName("doctor_image_src")] string CaminhoImagemMedico,
    [property: JsonPropertyName("specialty")] string Especialidade,
    [property: JsonPropertyName("consulta_data")] DateOnly DataConsulta,
    [property: JsonPropertyName("consulta_hora")] TimeOnly HoraConsulta,
    [property: JsonPropertyName("prontuario_description")] string DescricaoProntuario,
    [property: JsonPropertyName("prontuario_id")] Guid? IdProntuario, 
    [property: JsonPropertyName("comment_description")] string DescricaoComentario,
    [property: JsonPropertyName("comment_id")] Guid? IdComentario 
);