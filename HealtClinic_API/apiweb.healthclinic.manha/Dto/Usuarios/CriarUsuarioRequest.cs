using System.Text.Json.Serialization;

namespace apiweb.healthclinic.manha.Dto.Usuarios;

public record CriarUsuarioRequest(
    [property: JsonPropertyName("img")] IFormFile Imagem,
    [property: JsonPropertyName("name")] string Nome,
    [property: JsonPropertyName("email")] string Email,
    [property: JsonPropertyName("password")] string Senha,
    [property: JsonPropertyName("confirm_password")] string ConfirmacaoSenha,
    [property: JsonPropertyName("userType")] TipoUsuario TipoUsuario,
    [property: JsonPropertyName("sex")] Sexo Sexo,
    [property: JsonPropertyName("birthDate")] DateTime DataNascimento,
    [property: JsonPropertyName("registrationDate")] DateTime RegistrationDate,
    [property: JsonPropertyName("cpf")] string Cpf = "",
    [property: JsonPropertyName("crm")] string Crm = "",
    [property: JsonPropertyName("esp")] string Esp = "");
