using apiweb.healthclinic.manha.Contexts;
using apiweb.healthclinic.manha.Domains;
using apiweb.healthclinic.manha.Interfaces;
using apiweb.healthclinic.manha.Utils;

namespace apiweb.healthclinic.manha.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly HealthContext _healthContext;

        public UsuarioRepository(HealthContext healthContext)
        {
            _healthContext = healthContext;
        }

        public void Atualizar(Usuario usuario)
        {
            try
            {
                Usuario usuarioExistente = _healthContext.Usuario.Find(usuario.IdUsuario);
                if (usuarioExistente != null)
                {
                    // Armazena os valores atuais que não devem ser alterados
                    var dataNascimentoAtual = usuarioExistente.DataNascimento;
                    var sexoAtual = usuarioExistente.Sexo;
                    var idTipoUsuarioAtual = usuarioExistente.IdTipoUsuario;

                    // Atualiza o usuário existente com os novos valores
                    _healthContext.Entry(usuarioExistente).CurrentValues.SetValues(usuario);

                    // Restaura os valores que não devem ser alterados
                    usuarioExistente.DataNascimento = dataNascimentoAtual;
                    usuarioExistente.Sexo = sexoAtual;
                    usuarioExistente.IdTipoUsuario = idTipoUsuarioAtual;

                    // Persiste as alterações no banco de dados
                    _healthContext.SaveChanges();
                }
                else
                {
                    throw new Exception("Usuário não encontrado.");
                }
            }
            catch (Exception)
            {
                throw;
            }
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
                        CaminhoImagem = u.CaminhoImagem,

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
                        Email =u.Email,
                        DataNascimento = u.DataNascimento,
                        Sexo = u.Sexo,
                        CaminhoImagem = u.CaminhoImagem,

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
