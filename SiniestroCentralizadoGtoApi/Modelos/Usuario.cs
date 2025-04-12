using System;
using System.Collections.Generic;

namespace SiniestroCentralizadoGtoApi.Modelos;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string NumeroEmpleado { get; set; } = null!;

    public string Contrasena { get; set; } = null!;

    public bool Activo { get; set; }

    public DateTime? UltimoAcceso { get; set; }

    public string? Localizacion { get; set; }

    public virtual Ajustador NumeroEmpleadoNavigation { get; set; } = null!;
}
