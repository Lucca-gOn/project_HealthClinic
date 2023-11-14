using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO; // Adicione esta linha para acessar a classe Directory e Path

namespace apiweb.healthclinic.manha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("Upload de arquivo inválido.");

            // Define o caminho para o diretório "uploads"
            var uploadsFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");

            // Verifique se o diretório existe
            if (!Directory.Exists(uploadsFolderPath))
            {
                Directory.CreateDirectory(uploadsFolderPath);
            }

            // Combina o caminho do diretório de uploads com o nome do arquivo enviado
            // para criar o caminho completo onde o arquivo será salvo.
            var filePath = Path.Combine(uploadsFolderPath, file.FileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                // Copia o arquivo enviado, salvando-o no caminho especificado no servidor de forma assíncrona.
                await file.CopyToAsync(stream);
            }

            // Retorna um resultado de sucesso (200 OK) com um objeto anônimo contendo o nome do arquivo e o caminho de salvamento.
            return Ok(new { file.FileName, path = filePath });
        }
    }
}
