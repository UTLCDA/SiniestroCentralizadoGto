using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SiniestroCentralizadoGtoApi.Modelos;

public partial class Ajustador
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? ApellidoPaterno { get; set; }

    public string? ApellidoMaterno { get; set; }

    public string? Telefono { get; set; }

    public string? Correo { get; set; }

    public string? Curp { get; set; }

    public string? Rfc { get; set; }

    public int? Edad { get; set; }

    public string NumeroEmpleado { get; set; } = null!;

    public string? Carro { get; set; }

    public string? Matricula { get; set; }

    public string? Cp { get; set; }

    public string? Calle { get; set; }

    public string? Numero { get; set; }

    public string? Colonia { get; set; }

    public string? Localidad { get; set; }

    public string? Estado { get; set; }

    public string? Coordenadas { get; set; }

    [JsonIgnore]
    public virtual ICollection<Reporte> Reportes { get; set; } = new List<Reporte>();
    [JsonIgnore]
    public virtual ICollection<SeguimientoSiniestro> SeguimientoSiniestros { get; set; } = new List<SeguimientoSiniestro>();
    [JsonIgnore]
    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
