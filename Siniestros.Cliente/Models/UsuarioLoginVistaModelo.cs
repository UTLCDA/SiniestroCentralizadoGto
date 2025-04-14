using SiniestroCentralizadoGtoApi.Modelos;

namespace Siniestros.Cliente.Models
{
    public class UsuarioLoginVistaModelo
    {
        public int IdUsuario { get; set; }
        public string NumeroEmpleado { get; set; }
        public bool Activo { get; set; }
        public DateTime? UltimoAcceso { get; set; }
        public string? Localizacion { get; set; }
        public virtual Ajustador NombreAjustador { get; set; } = null!;
    }
}
