using System.Text.Json.Serialization;

public record ListarConsultasResponse([property: JsonPropertyName("items")] IReadOnlyCollection<ListarConsultasResponseItem> Itens);
