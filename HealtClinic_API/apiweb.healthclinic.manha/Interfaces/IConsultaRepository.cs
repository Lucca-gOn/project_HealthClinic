﻿using apiweb.healthclinic.manha.Domains;

namespace apiweb.healthclinic.manha.Interfaces
{
    public interface IConsultaRepository
    {
        void Cadastrar(Consulta novaConsulta);

        void Deletar(Guid id);

        Consulta BuscarPorId(Guid id);

        List<Consulta> Listar();

        List<Consulta> ListarPorUsuario(Guid IdUsuario);

        void Atualizar(Consulta consulta);
    }
}
