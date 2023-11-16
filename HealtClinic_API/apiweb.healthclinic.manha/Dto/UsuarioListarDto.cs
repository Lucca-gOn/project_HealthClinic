namespace apiweb.healthclinic.manha.Dto
{
    public class UsuarioListarDto
    {
        public Guid IdUsuario { get; set; }
        public string Nome { get; set; }
        public string CaminhoImagem { get; set; }
        public string TipoUsuario { get; set; }
        public string EspecialidadeMedico { get; set; } // 
    }
}
