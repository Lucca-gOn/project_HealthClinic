using apiweb.healthclinic.manha.Dto.Consultas;

namespace apiweb.healthclinic.manha.Interfaces;

public interface IConsultaService
{
    ListarConsultasResponse ListarConsultas();

    ListarConsultasResponse ListarConsultasPorUsuario(Guid idUsuario);

    CriarConsultaResponse CriarConsulta(CriarConsultaRequest request);

    AtualizarConsultaResponse AtualizarConsulta(Guid id, AtualizarConsultaRequest request);
}