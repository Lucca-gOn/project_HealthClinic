using System.Text.Json.Serialization;

namespace apiweb.healthclinic.manha.Dto.Usuarios;

public record AtualizarUsuarioRequest(
    [property: JsonPropertyName("img")] IFormFile Imagem,
    [property: JsonPropertyName("name")] string Nome,
    [property: JsonPropertyName("email")] string Email,
    [property: JsonPropertyName("password")] string Senha,
    [property: JsonPropertyName("confirm_password")] string ConfirmacaoSenha);
