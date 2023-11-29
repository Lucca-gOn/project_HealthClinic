using System.Text.Json.Serialization;

public record AtualizarComentarioConsultaRequest(
    [property: JsonPropertyName("id")] Guid Id,
    [property: JsonPropertyName("comentario")] string Comentario);