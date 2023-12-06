using apiweb.healthclinic.manha.Domains;
using apiweb.healthclinic.manha.Dto.Consultas;
using apiweb.healthclinic.manha.Interfaces;
namespace apiweb.healthclinic.manha.Services;

public class ConsultaService : IConsultaService
{
    private readonly IConsultaRepository _consultaRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ConsultaService
    (
        IConsultaRepository consultaRepository,
        IUnitOfWork unitOfWork
    )
    {
        _consultaRepository = consultaRepository;
        _unitOfWork = unitOfWork;

    }

    public CriarConsultaResponse CriarConsulta(CriarConsultaRequest request)
    {
        Consulta novaConsulta = new Consulta
        {
            DataHorarioConsulta = DateTime.Parse(request.DataHorarioConsulta),
            IdMedico = Guid.Parse(request.Medico.Value),
            IdPaciente = Guid.Parse(request.Paciente.Value),
            Prontuario = new Domains.Prontuario()
            {
                IdProntuario = Guid.NewGuid(),
                DescricaoProntuario = request.Prontuario
            },
            Comentario = new Domains.Comentario()
            {
                IdComentario = Guid.NewGuid(),
                DescricaoComentario = request.Comentario
            }
        };

        _consultaRepository.Cadastrar(novaConsulta);

        return new CriarConsultaResponse(Guid.NewGuid());
    }

    public ListarConsultasResponse ListarConsultas()
    {
        List<Consulta> consultas = _consultaRepository.Listar();

        var itens = consultas
            .Select(c => new ListarConsultasResponseItem(
                Id: c.IdConsulta,
                IdPaciente: c.Paciente.IdPaciente,
                Nome: c.Paciente.Usuario.Nome,
                CaminhoImagem: c.Paciente.Usuario.CaminhoImagem,
                IdMedico: c.Medico.IdMedico,
                NomeMedico: c.Medico.Usuario.Nome,
                CaminhoImagemMedico: c.Medico.Usuario.CaminhoImagem,
                IdEspecialidade: c.Medico.Especialidade.IdEspecialidade,
                Especialidade: c.Medico.Especialidade.TituloEspecialidade,
                DataHorarioConsulta: c.DataHorarioConsulta.ToString("dd/MM/yyyy HH:mm"),
                DescricaoProntuario: c.Prontuario?.DescricaoProntuario,
                IdProntuario: c.Prontuario?.IdProntuario,
                DescricaoComentario: c.Comentario?.DescricaoComentario,
                IdComentario: c.Comentario?.IdComentario))
            .ToList()
            .AsReadOnly();

        return new ListarConsultasResponse(itens);
    }

    public ListarConsultasResponse ListarConsultasPorUsuario(Guid idUsuario)
    {
        List<Consulta> consultas = _consultaRepository.ListarPorUsuario(idUsuario);

        var itens = consultas
            .Select(c => new ListarConsultasResponseItem(
                Id: c.IdConsulta,
                IdPaciente: c.Paciente.IdPaciente,
                Nome: c.Paciente.Usuario.Nome,
                CaminhoImagem: c.Paciente.Usuario.CaminhoImagem,
                IdMedico: c.Medico.IdMedico,
                NomeMedico: c.Medico.Usuario.Nome,
                CaminhoImagemMedico: c.Medico.Usuario.CaminhoImagem,
                IdEspecialidade: c.Medico.Especialidade.IdEspecialidade,
                Especialidade: c.Medico.Especialidade.TituloEspecialidade,
                DataHorarioConsulta: c.DataHorarioConsulta.ToString("dd/MM/yyyy HH:mm"),
                DescricaoProntuario: c.Prontuario?.DescricaoProntuario,
                IdProntuario: c.Prontuario?.IdProntuario,
                DescricaoComentario: c.Comentario?.DescricaoComentario,
                IdComentario: c.Comentario?.IdComentario))
            .ToList()
            .AsReadOnly();

        return new ListarConsultasResponse(itens);
    }

    public AtualizarConsultaResponse AtualizarConsulta(Guid id, AtualizarConsultaRequest request)
    {
        var consultaBuscada = _consultaRepository.BuscarPorId(id);
        if (consultaBuscada == null)
        {
            throw new Exception("Consulta não encontrada");
        }

        consultaBuscada.DataHorarioConsulta = DateTime.Parse(request.DataHorarioConsulta);
        consultaBuscada.IdMedico = Guid.Parse(request.Medico.Value);
        consultaBuscada.IdPaciente = Guid.Parse(request.Paciente.Value);

        _consultaRepository.Atualizar(consultaBuscada);
        return new AtualizarConsultaResponse(consultaBuscada.IdConsulta);
    }

}

