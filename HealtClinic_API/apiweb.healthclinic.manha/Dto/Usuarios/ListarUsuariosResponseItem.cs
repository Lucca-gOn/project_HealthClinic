using System.Text.Json.Serialization;

public record ListarUsuariosResponseItem(
    [property: JsonPropertyName("_id")] Guid Id,
    [property: JsonPropertyName("name")] string Nome,
    [property: JsonPropertyName("image_src")] string CaminhoImagem,
    [property: JsonPropertyName("userType")] string NomeUser,
    [property: JsonPropertyName("specialty")] string Especialidade
);