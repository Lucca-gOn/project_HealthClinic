using System.Text.Json.Serialization;

public record ListarUsuarioPorIdResponse([property: JsonPropertyName("items")] IReadOnlyCollection<ListarUsuarioPorIdResponseItem> Itens);


