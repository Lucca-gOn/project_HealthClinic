using apiweb.healthclinic.manha.Domains;
using apiweb.healthclinic.manha.Dto.Consultas;
using apiweb.healthclinic.manha.Interfaces;

namespace apiweb.healthclinic.manha.Services;

public class ConsultaService : IConsultaService
{
    private readonly IConsultaRepository _consultaRepository;

    public ConsultaService
    (
        IConsultaRepository consultaRepository
    )
    {
        _consultaRepository = consultaRepository;

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
                DataHorarioConsulta : c.DataHorarioConsulta.ToString("dd/MM/yyyy HH:mm"),
                DescricaoProntuario: c.Prontuario?.DescricaoProntuario,
                IdProntuario: c.Prontuario?.IdProntuario,
                DescricaoComentario: c.Comentario?.DescricaoComentario,
                IdComentario: c.Comentario?.IdComentario))
            .ToList()
            .AsReadOnly();

        return new ListarConsultasResponse(itens);
    }

    public ListarConsultasResponse ListarConsultasPorPaciente(Guid idPaciente)
    {
        List<Consulta> consultas = _consultaRepository.ListarPorPaciente(idPaciente);

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

    public ListarConsultasResponse ListarConsultarPorMedico(Guid idMedico)
    {
        List<Consulta> consultas = _consultaRepository.ListarPorMedico(idMedico);

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
}