using apiweb.healthclinic.manha.Domains;

namespace apiweb.healthclinic.manha.Interfaces
{
    public interface IClinicaRepository
    {
        void Cadastrar(Clinica novaClinica);

        List<Clinica> Listar();
    }
}
