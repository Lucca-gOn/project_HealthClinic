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
                // Obter os IDs dos pacientes relacionados ao usuário
                var idsDosPacientes = _healthContext.Paciente
                    .Where(paciente => paciente.IdUsuario == idUsuario)
                    .Select(paciente => paciente.IdPaciente) 
                    .ToList();

                // Remover pacientes
                _healthContext.Paciente.RemoveRange(
                    _healthContext.Paciente.Where(paciente => idsDosPacientes.Contains(paciente.IdPaciente))
                );

                // Obter os IDs das consultas relacionadas aos pacientes
                var idsDasConsultas = _healthContext.Consulta
                    .Where(consulta => idsDosPacientes.Contains(consulta.IdPaciente))
                    .Select(consulta => consulta.IdConsulta) 
                    .ToList();

                // Remover prontuários relacionados às consultas
                _healthContext.Prontuario.RemoveRange(
                    _healthContext.Prontuario.Where(prontuario => idsDasConsultas.Contains(prontuario.IdProntuario)) 
                );

                // Remover comentários relacionados às consultas
                _healthContext.Comentario.RemoveRange(
                    _healthContext.Comentario.Where(comentario => idsDasConsultas.Contains(comentario.IdComentario)) 
                );

                // Remover consultas
                _healthContext.Consulta.RemoveRange(
                    _healthContext.Consulta.Where(consulta => idsDasConsultas.Contains(consulta.IdConsulta))
                );

                // Remover médicos relacionados ao usuário
                _healthContext.Medico.RemoveRange(
                    _healthContext.Medico.Where(medico => medico.IdUsuario == idUsuario)
                );

                // Remover o usuário
                var usuarioParaRemover = _healthContext.Usuario.Find(idUsuario);
                if (usuarioParaRemover != null)
                {
                    _healthContext.Usuario.Remove(usuarioParaRemover);
                }

                // Salvar todas as alterações no banco de dados
                _healthContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
