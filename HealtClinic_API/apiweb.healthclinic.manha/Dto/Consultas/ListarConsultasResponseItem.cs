using System.Text.Json.Serialization;

public record ListarConsultasResponseItem(
    [property: JsonPropertyName("_id")] Guid Id,
    [property: JsonPropertyName("pacient_id")] Guid IdPaciente,
    [property: JsonPropertyName("name")] string Nome,
    [property: JsonPropertyName("image_src")] string CaminhoImagem,
    [property: JsonPropertyName("doctor_id")] Guid IdMedico,
    [property: JsonPropertyName("doctor_name")] string NomeMedico,
    [property: JsonPropertyName("doctor_image_src")] string CaminhoImagemMedico,
    [property: JsonPropertyName("specialty_id")] Guid IdEspecialidade,
    [property: JsonPropertyName("specialty")] string Especialidade,
    [property: JsonPropertyName("consultationDateTime")] string DataHorarioConsulta,
    [property: JsonPropertyName("prontuario_description")] string DescricaoProntuario,
    [property: JsonPropertyName("prontuario_id")] Guid? IdProntuario, 
    [property: JsonPropertyName("comment_description")] string DescricaoComentario,
    [property: JsonPropertyName("comment_id")] Guid? IdComentario 
);