﻿using apiweb.healthclinic.manha.Dto.Consultas;
using System.Text.Json.Serialization;

public record AtualizarConsultaRequest(
    [property: JsonPropertyName("patient")] Paciente Paciente,
    [property: JsonPropertyName("esp")] string Esp,
    [property: JsonPropertyName("doctor")] Medico Medico,
    [property: JsonPropertyName("consultationDateTime")] string DataHorarioConsulta);