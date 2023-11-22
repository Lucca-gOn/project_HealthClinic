using apiweb.healthclinic.manha.Dto.Imagens;
using apiweb.healthclinic.manha.Interfaces;

namespace apiweb.healthclinic.manha.Services;

public class ImagemService : IImagemService
{
    private readonly IConfiguration _configuration;

    public ImagemService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public ImagemPersistida PersistirImagem(IFormFile file)
    {
        var uploadsFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");

        if (!Directory.Exists(uploadsFolderPath))
            Directory.CreateDirectory(uploadsFolderPath);

        string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
        string filePath = Path.Combine(uploadsFolderPath, fileName);

        using FileStream stream = new(filePath, FileMode.Create);
        file.CopyTo(stream);

        string relativePath = Path.Combine("uploads", fileName);

        // Obter a URL base do appsettings.json
        string baseUrl = _configuration.GetValue<string>("ApplicationSettings:BaseUrl");
        string absolutePath = new Uri(new Uri(baseUrl), relativePath).ToString();

        return new ImagemPersistida(absolutePath);
    }
}
