using Servidor.Modelos;

namespace Servidor.Dtos
{
    public class LoginResponseDto
    {
        public int IdUsuario { get; set; }
        public string NumeroEmpleado { get; set; }
        public string? Localizacion { get; set; }
        public DateTime? UltimoAcceso { get; set; }
        public AjustadorDto? Ajustador { get; set; }

    }
}
