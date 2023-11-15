using apiweb.healthclinic.manha.Domains;
using apiweb.healthclinic.manha.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace apiweb.healthclinic.manha.Interfaces
{
    public interface IUsuarioRepository
    {
        Task Cadastrar(Usuario novoUsuario, IFormFile file);

        Usuario BuscarPorId(Guid id);

        Usuario BuscarPorEmailESenha (string email, string senha);

        List<Usuario> Listar();

    }
}
