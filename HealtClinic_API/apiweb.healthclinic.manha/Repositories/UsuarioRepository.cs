using apiweb.healthclinic.manha.Contexts;
using apiweb.healthclinic.manha.Domains;
using apiweb.healthclinic.manha.Dto;
using apiweb.healthclinic.manha.Interfaces;
using apiweb.healthclinic.manha.Utils;
using apiweb.healthclinic.manha.ViewModels;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace apiweb.healthclinic.manha.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly HealthContext _healthContext;

        public UsuarioRepository()
        {
            _healthContext = new HealthContext();
        }

        public void Atualizar(Guid id, Usuario usuario, string novoCaminhoImagem)
        {
            throw new NotImplementedException();
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

        public async Task Cadastrar(Usuario novoUsuario, IFormFile file)
        {
            try
            {
                // Criação do diretório de uploads
                var uploadsFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");
                if (!Directory.Exists(uploadsFolderPath))
                {
                    Directory.CreateDirectory(uploadsFolderPath);
                }

                // Tratamento do arquivo de upload
                if (file != null && file.Length > 0)
                {
                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    var filePath = Path.Combine(uploadsFolderPath, fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                    novoUsuario.CaminhoImagem = Path.Combine("uploads", fileName);
                }
                else
                {
                    novoUsuario.CaminhoImagem = null; // ou caminho padrão se aplicável
                }

                // Criptografando a senha do usuário
                novoUsuario.Senha = Criptografia.GerarHash(novoUsuario.Senha);

                // Salva o usuário no banco de dados
                _healthContext.Usuario.Add(novoUsuario);
                await _healthContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw; 
            }
        }

        public List<Usuario> ListarAll()
        {
            try
            {
                return _healthContext.Usuario.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        List<UsuarioListarDto> IUsuarioRepository.Listar()
        {
            try
            {
                var listaUsuarios = _healthContext.Usuario
                .Include(u => u.TiposUsuario)
                .Select(u => new UsuarioListarDto
                {
                    IdUsuario = u.IdUsuario,
                    Nome = u.Nome,
                    CaminhoImagem = u.CaminhoImagem,
                    TipoUsuario = u.TiposUsuario.Titulo,
                    EspecialidadeMedico = _healthContext.Medico
                                        .Include(m => m.Especialidade) 
                                        .Where(m => m.IdUsuario == u.IdUsuario)
                                        .Select(m => m.Especialidade.TituloEspecialidade) 
                                        .FirstOrDefault()
                })
                .ToList();

                return listaUsuarios;
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
