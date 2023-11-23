using apiweb.healthclinic.manha.Domains;
using apiweb.healthclinic.manha.Dto.Consultas;
using apiweb.healthclinic.manha.Interfaces;

namespace apiweb.healthclinic.manha.Services;

public class ConsultaService : IConsultaService
{
    private readonly IConsultaRepository _consultaRepository;
    private readonly IPacienteRepository _pacienteRepository;
    private readonly IMedicoRepository _medicoRepository;
    private readonly IEspecialidadeRepository _especialidadeRepository;

    public ConsultaService(
        IConsultaRepository consultaRepository, 
        IPacienteRepository pacienteRepository, 
        IMedicoRepository medicoRepository, 
        IEspecialidadeRepository especialidadeRepository)
    {
        _consultaRepository = consultaRepository;
        _pacienteRepository = pacienteRepository;
        _medicoRepository = medicoRepository;
        _especialidadeRepository = especialidadeRepository;
    }

    public CriarConsultaResponse CriarConsulta(CriarConsultaRequest request)
    {
        Consulta novaConsulta = new Consulta
        {
            DataConsulta = request.DateConsulta,
            HorarioConsulta = request.TimeConsulta.TimeOfDay,
            IdMedico =  Guid.Parse(request.Medico.Value),
            IdPaciente = Guid.Parse(request.Paciente.Value),
            IdProntuario = Guid.Parse(request.Prontuario.Value)
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
                Nome: c.Paciente.Usuario.Nome,
                CaminhoImagem: c.Paciente.Usuario.CaminhoImagem,
                NomeMedico: c.Medico.Usuario.Nome,
                CaminhoImagemMedico: c.Medico.Usuario.CaminhoImagem,
                Especialidade: c.Medico.Especialidade.TituloEspecialidade,
                DataConsulta: DateOnly.FromDateTime(c.DataConsulta),
                HoraConsulta: TimeOnly.FromTimeSpan(c.HorarioConsulta)))
            .ToList()
            .AsReadOnly();

        return new ListarConsultasResponse(itens);
    }
}