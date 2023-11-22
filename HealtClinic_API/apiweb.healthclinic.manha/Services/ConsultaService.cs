using apiweb.healthclinic.manha.Domains;
using apiweb.healthclinic.manha.Interfaces;

namespace apiweb.healthclinic.manha.Services;

public class ConsultaService : IConsultaService
{
    private readonly IConsultaRepository _consultaRepository;

    public ConsultaService(IConsultaRepository consultaRepository)
    {
        _consultaRepository = consultaRepository;
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