using apiweb.healthclinic.manha.Domains;
using apiweb.healthclinic.manha.Dto;
using apiweb.healthclinic.manha.Repositories;
using apiweb.healthclinic.manha.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace apiweb.healthclinic.manha.Interfaces
{
    public interface IUsuarioRepository
    {
        Task Cadastrar(Usuario novoUsuario, IFormFile file, string CRM, string especialidade);

        Usuario BuscarPorId(Guid id);

        Usuario BuscarPorEmailESenha (string email, string senha);

        List<UsuarioListarDto> Listar();

    }
}
