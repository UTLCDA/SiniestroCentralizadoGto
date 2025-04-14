namespace Siniestro.Servidor.Dtos
{
    public class LoginResponseDto
    {
        public int IdUsuario { get; set; }
        public string NumeroEmpleado { get; set; }
        public string? Localizacion { get; set; }
        public string? NombreAjustador { get; set; } 
    }
}
