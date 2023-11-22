using apiweb.healthclinic.manha.Dto.Consultas;

namespace apiweb.healthclinic.manha.Interfaces;

public interface IConsultaService
{
    ListarConsultasResponse ListarConsultas();

    CriarConsultaResponse CriarConsulta(CriarConsultaRequest request);
}