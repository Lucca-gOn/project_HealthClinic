using apiweb.healthclinic.manha.Dto.Usuarios;

namespace apiweb.healthclinic.manha.Interfaces;

public interface IUsuarioService
{
    CriarUsuarioResponse CriarUsuario(CriarUsuarioRequest request);

    ListarUsuariosResponse ListarUsuarios();

    ListarUsuariosResponse ListarAdministradores();

    AtualizarUsuarioResponse AtualizarUsuario(Guid idUsuario, AtualizarUsuarioRequest request);

    ListarUsuarioPorIdResponseItem ListarPorId(Guid idUsuario);
}