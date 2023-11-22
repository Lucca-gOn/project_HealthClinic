using apiweb.healthclinic.manha.Contexts;
using apiweb.healthclinic.manha.Domains;
using apiweb.healthclinic.manha.Dto.Imagens;
using apiweb.healthclinic.manha.Dto.Usuarios;
using apiweb.healthclinic.manha.Interfaces;
using apiweb.healthclinic.manha.Repositories;
using apiweb.healthclinic.manha.Utils;
using Microsoft.EntityFrameworkCore;

namespace apiweb.healthclinic.manha.Services;

public class UsuarioService : IUsuarioService
{
    private readonly IImagemService _imageService;
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IMedicoRepository _medicoRepository;
    private readonly IPacienteRepository _pacienteRepository;
    private readonly ITiposUsuarioRepository _tiposUsuarioRepository;
    private readonly IEspecialidadeRepository _especialidadeRepository;
    private readonly HealthContext _healthContext;
    private readonly IUnitOfWork _unitOfWork;

    public UsuarioService(
        IImagemService imageService,
        IUsuarioRepository usuarioRepository,
        IMedicoRepository medicoRepository,
        IPacienteRepository pacienteRepository,
        ITiposUsuarioRepository tiposUsuarioRepository,
        IEspecialidadeRepository especialidadeRepository,
        IUnitOfWork unitOfWork,
        HealthContext healthContext)
    {
        _imageService = imageService;
        _usuarioRepository = usuarioRepository;
        _medicoRepository = medicoRepository;
        _pacienteRepository = pacienteRepository;
        _tiposUsuarioRepository = tiposUsuarioRepository;
        _especialidadeRepository = especialidadeRepository;
        _unitOfWork = unitOfWork;
        _healthContext = healthContext;

    }

    public CriarUsuarioResponse CriarUsuario(CriarUsuarioRequest request)
    {
        string hashSenha = Criptografia.GerarHash(request.Senha);
        string tituloTipoUsuario = request.TipoUsuario.Value;

        TiposUsuario tipo = BuscarOuCriarTipoUsuario(tituloTipoUsuario);
        ImagemPersistida imagem = _imageService.PersistirImagem(request.Imagem);

        Usuario usuario = new()
        {
            Nome = request.Nome,
            Email = request.Email,
            Senha = hashSenha,
            DataNascimento = request.DataNascimento,
            Sexo = request.Sexo.Value,
            CaminhoImagem = imagem.Src,
            IdTipoUsuario = tipo.IdTipoUsuario
        };

        _usuarioRepository.Cadastrar(usuario);

        switch (tituloTipoUsuario)
        {
            case "Medico":
                CriarMedico(request, usuario);
                break;
            case "Paciente":
                CriarPaciente(request, usuario);
                break;
            case "Administrador":
                CriarPaciente(request, usuario);
                break;
            default:
                throw new InvalidOperationException("Tipo de Usuário não reconhecido");
        }

        _unitOfWork.Commit();

        return new(Id: usuario.IdUsuario);
    }

    private void CriarMedico(CriarUsuarioRequest request, Usuario usuario)
    {
        string tituloEspecialidade = request.Esp;
        Especialidade especialidade = BuscarOuCriarEspecialidade(tituloEspecialidade);

        Medico medico = new()
        {
            IdUsuario = usuario.IdUsuario,
            CRM = request.Crm,
            IdEspecialidade = especialidade.IdEspecialidade
        };

        _medicoRepository.Cadastrar(medico);
    }

    private void CriarPaciente(CriarUsuarioRequest request, Usuario usuario)
    {
        Paciente paciente = new()
        {
            IdUsuario = usuario.IdUsuario,
            CPF = request.Cpf,
        };

        _pacienteRepository.Cadastrar(paciente);
    }

    private TiposUsuario BuscarOuCriarTipoUsuario(string titulo)
    {
        TiposUsuario? tipoUsuarioEncontrado = _tiposUsuarioRepository.BuscarTipoUsuarioPorTitulo(titulo);

        if (tipoUsuarioEncontrado is not null)
        {
            return tipoUsuarioEncontrado;
        }
        else
        {
            TiposUsuario novoTipoUsuario = new()
            {
                Titulo = titulo
            };

            _tiposUsuarioRepository.Cadastrar(novoTipoUsuario);

            return novoTipoUsuario;
        }
    }

    private Especialidade BuscarOuCriarEspecialidade(string titulo)
    {
        Especialidade? especialidadeEncontrada = _especialidadeRepository.BuscarEspecialidadePorTitulo(titulo);

        if (especialidadeEncontrada is not null)
        {
            return especialidadeEncontrada;
        }
        else
        {
            Especialidade novaEspecialidade = new()
            {
                TituloEspecialidade = titulo
            };

            _especialidadeRepository.Cadastrar(novaEspecialidade);

            return novaEspecialidade;
        }
    }

    public ListarUsuariosResponse ListarUsuarios()
    {

        var listaUsuarios = _healthContext.Usuario
        .Include(u => u.TiposUsuario)
        .Select(u => new ListarUsuariosResponseItem(
            u.IdUsuario,
            u.Nome,
            u.CaminhoImagem,
            u.TiposUsuario.Titulo,
            _healthContext.Medico
                .Include(m => m.Especialidade)
                .Where(m => m.IdUsuario == u.IdUsuario)
                .Select(m => m.Especialidade.TituloEspecialidade)
                .FirstOrDefault() ?? "Especialidade não informada"
        ))
        .ToList()
        .AsReadOnly();

        return new ListarUsuariosResponse(listaUsuarios);
    }
}