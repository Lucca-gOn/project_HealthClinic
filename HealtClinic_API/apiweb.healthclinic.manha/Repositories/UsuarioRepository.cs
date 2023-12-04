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
                    var dataNascimentoAtual = usuarioExistente.DataNascimento;
                    var sexoAtual = usuarioExistente.Sexo;
                    var idTipoUsuarioAtual = usuarioExistente.IdTipoUsuario;

                    _healthContext.Entry(usuarioExistente).CurrentValues.SetValues(usuario);

                    // Restaurar os valores que não devem ser alterados
                    usuarioExistente.DataNascimento = dataNascimentoAtual;
                    usuarioExistente.Sexo = sexoAtual;
                    usuarioExistente.IdTipoUsuario = idTipoUsuarioAtual;

                    _healthContext.SaveChanges();
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
                var consultasRelacionadas = _healthContext.Consulta
                    .Where(consulta => consulta.Medico.IdUsuario == idUsuario || consulta.Paciente.IdUsuario == idUsuario)
                    .ToList();

                // Extrair os IDs dos prontuários e comentários das consultas relacionadas
                var idsDosProntuarios = consultasRelacionadas.Select(consulta => consulta.IdProntuario).Distinct().ToList();
                var idsDosComentarios = consultasRelacionadas.Select(consulta => consulta.IdComentario).Distinct().ToList();

                _healthContext.Prontuario.RemoveRange(_healthContext.Prontuario.Where(prontuario => idsDosProntuarios.Contains(prontuario.IdProntuario)));
                _healthContext.Comentario.RemoveRange(_healthContext.Comentario.Where(comentario => idsDosComentarios.Contains(comentario.IdComentario)));

                // Remover as consultas relacionadas
                _healthContext.Consulta.RemoveRange(consultasRelacionadas);

                var pacienteRemover = _healthContext.Paciente.FirstOrDefault(paciente => paciente.IdUsuario == idUsuario);
                if (pacienteRemover != null)
                {
                    _healthContext.Paciente.Remove(pacienteRemover);
                }

                var medicoRemover = _healthContext.Medico.FirstOrDefault(medico => medico.IdUsuario == idUsuario);
                if (medicoRemover != null)
                {
                    _healthContext.Medico.Remove(medicoRemover);
                }

                // Remover o usuário
                var usuarioARemover = _healthContext.Usuario.Find(idUsuario);
                if (usuarioARemover != null)
                {
                    _healthContext.Usuario.Remove(usuarioARemover);
                }

                _healthContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
