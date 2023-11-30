using apiweb.healthclinic.manha.Dto.Consultas;

namespace apiweb.healthclinic.manha.Interfaces;

public interface IConsultaService
{
    ListarConsultasResponse ListarConsultas();

    ListarConsultasResponse ListarConsultasPorPaciente(Guid idPaciente);

    ListarConsultasResponse ListarConsultarPorMedico(Guid idMedico);

    CriarConsultaResponse CriarConsulta(CriarConsultaRequest request);
}