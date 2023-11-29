using apiweb.healthclinic.manha.Contexts;
using apiweb.healthclinic.manha.Domains;
using apiweb.healthclinic.manha.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace apiweb.healthclinic.manha.Repositories
{
    public class ClinicaRepository : IClinicaRepository
    {
        private readonly HealthContext _healthContext;

        public ClinicaRepository(HealthContext healthContext)
        {
            _healthContext = healthContext;
        }

        public void Atualizar(Guid id, Clinica clinica)
        {
            try
            {
                Clinica buscarClinica = _healthContext.Clinica.Find(id)!;
                if (buscarClinica != null)
                {
                    buscarClinica.NomeFantasia = clinica.NomeFantasia;
                    buscarClinica.RazaoSocial = clinica.RazaoSocial;
                    buscarClinica.Endereco = clinica.Endereco;
                    buscarClinica.CEP = clinica.CEP;
                    buscarClinica.Numero = clinica.Numero;
                    buscarClinica.PrimeiroDiaSemana = clinica.PrimeiroDiaSemana;
                    buscarClinica.SegundoDiaSemana = clinica.SegundoDiaSemana;
                    buscarClinica.CNPJ = clinica.CNPJ;
                    buscarClinica.HorarioAbertura = clinica.HorarioAbertura;
                    buscarClinica.HorarioFechamento = clinica.HorarioFechamento;

                    _healthContext.Update(buscarClinica);

                    _healthContext.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(Clinica novaClinica)
        {
            try
            {
                _healthContext.Add(novaClinica);
                _healthContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Deletar(Guid id)
        {
            try
            {
                _healthContext.Clinica.Where(e => e.IdClinica == id).ExecuteDelete();
                _healthContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Clinica> Listar()
        {
            try
            {
                return _healthContext.Clinica.ToList();
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
