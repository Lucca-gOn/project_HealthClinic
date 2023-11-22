using apiweb.healthclinic.manha.Dto.Imagens;

namespace apiweb.healthclinic.manha.Interfaces;

public interface IImagemService
{
    ImagemPersistida PersistirImagem(IFormFile file);
}
