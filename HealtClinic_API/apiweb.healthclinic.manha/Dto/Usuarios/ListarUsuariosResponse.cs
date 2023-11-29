using System.Text.Json.Serialization;

public record ListarUsuariosResponse([property: JsonPropertyName("items")] IReadOnlyCollection<ListarUsuariosResponseItem> Itens);



