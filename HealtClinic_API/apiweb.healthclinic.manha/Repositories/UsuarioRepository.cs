using apiweb.healthclinic.manha.Contexts;
using apiweb.healthclinic.manha.Domains;
using apiweb.healthclinic.manha.Dto.Usuarios;
using apiweb.healthclinic.manha.Interfaces;
using apiweb.healthclinic.manha.Services;
using apiweb.healthclinic.manha.Utils;
using apiweb.healthclinic.manha.ViewModels;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace apiweb.healthclinic.manha.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly HealthContext _healthContext;
        private readonly IImagemService _imageService;

        public UsuarioRepository(HealthContext healthContext, IImagemService imageService)
        {
            _healthContext = healthContext;
            _imageService = imageService;
        }

        public void Atualizar(Guid id, Usuario usuario,IFormFile novaImagem)
        {
            try
            {
                Usuario buscarUsuario = _healthContext.Usuario.Find(id);
                if (buscarUsuario != null)
                {
                    buscarUsuario!.Nome = usuario.Nome;
                    buscarUsuario!.Email = usuario.Email;
                    buscarUsuario!.Senha = usuario.Senha; 
                    buscarUsuario!.Sexo = usuario.Sexo;

                    if (novaImagem != null)
                    {
                        var imagemPersistida = _imageService.PersistirImagem(novaImagem);
                        buscarUsuario.CaminhoImagem = imagemPersistida.Src;
                    }
                    _healthContext.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Atualizar(Usuario usuario)
        {
            if (usuario == null)
            {
                throw new ArgumentNullException(nameof(usuario));
            }

            Usuario usuarioExistente = _healthContext.Usuario.Find(usuario.IdUsuario);
            if (usuarioExistente == null)
            {
                throw new KeyNotFoundException("Usuário não encontrado com o ID fornecido.");
            }

            // Atualiza as propriedades do usuário existente com as do usuário fornecido
            _healthContext.Entry(usuarioExistente).CurrentValues.SetValues(usuario);

            _healthContext.SaveChanges();
        }

        public Usuario BuscarPorEmailESenha(string email, string senha)
        {
            try
            {
                //Esta sendo buscado por email e guardando objeto em usuario buscado;
                Usuario usuarioBuscado = _healthContext.Usuario
                    .Select(u => new Usuario
                    {
                        IdUsuario = u.IdUsuario,
                        Nome = u.Nome,
                        Email = u.Email,
                        Senha = u.Senha,

                        TiposUsuario = new TiposUsuario
                        {
                            IdTipoUsuario = u.IdTipoUsuario,
                            Titulo = u.TiposUsuario!.Titulo
                        }
                    }).FirstOrDefault(u => u.Email == email)!;

                if (usuarioBuscado != null)
                {
                    bool confere = Criptografia.CompararHash(senha, usuarioBuscado.Senha!);
                    if (confere)
                    {
                        return usuarioBuscado;
                    }
                }
                return null!;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Usuario BuscarPorId(Guid id)
        {
            try
            {
                Usuario usuarioBuscado = _healthContext.Usuario
                    .Select(u => new Usuario
                    {
                        IdUsuario = u.IdUsuario,
                        Nome = u.Nome,

                        TiposUsuario = new TiposUsuario
                        {
                            IdTipoUsuario = u.IdTipoUsuario,
                            Titulo = u.TiposUsuario!.Titulo
                        }
                    }).FirstOrDefault(z => z.IdUsuario == id)!;

                if (usuarioBuscado != null)
                {
                    return usuarioBuscado;
                }
                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(Usuario novoUsuario)
        {
            try
            {
                _healthContext.Add(novoUsuario);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Deletar(Guid idUsuario)
        {
            try
            {
                // Busca os pacientes associados ao usuário
                var pacientes = _healthContext.Paciente
                    .Where(p => p.IdUsuario == idUsuario)
                    .ToList();

                // Para cada paciente, buscar e deletar todas as consultas relacionadas
                foreach (var paciente in pacientes)
                {
                    var consultas = _healthContext.Consulta
                        .Where(c => c.IdPaciente == paciente.IdPaciente)
                        .ToList();

                    //RemoverRange deleta uma coleção de objetos do contexto de uma só vez. 
                    _healthContext.Consulta.RemoveRange(consultas);
                }

                // Deletar os pacientes
                _healthContext.Paciente.RemoveRange(pacientes);

                // Deletar o usuário
                var usuario = _healthContext.Usuario.Find(idUsuario);
                if (usuario != null)
                {
                    _healthContext.Usuario.Remove(usuario);
                }

                _healthContext.SaveChanges();
            }
            catch (Exception)
            {
                
            }
        }

    }
}
