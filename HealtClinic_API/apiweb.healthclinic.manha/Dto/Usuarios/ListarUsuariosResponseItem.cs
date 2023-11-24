using System.Text.Json.Serialization;

public record ListarUsuariosResponseItem(
    [property: JsonPropertyName("_id")] Guid Id,
    [property: JsonPropertyName("name")] string Nome,
    [property: JsonPropertyName("email")] string Email,
    [property: JsonPropertyName("birthDate")] DateTime? DataNascimento,
    [property: JsonPropertyName("sex")] string Sexo,
    [property: JsonPropertyName("image_src")] string CaminhoImagem,
    [property: JsonPropertyName("userType")] string NomeUser,
    [property: JsonPropertyName("specialty")] string Especialidade,
    [property: JsonPropertyName("cpf")] string Cpf = "",
    [property: JsonPropertyName("crm")] string Crm = "");