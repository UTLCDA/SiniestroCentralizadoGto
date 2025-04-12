using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SiniestroCentralizadoGtoApi.Modelos;

public partial class Reporte
{
    public int Id { get; set; }

    public DateOnly? FechaSiniestro { get; set; }

    public string? LugarSiniestroDireccion { get; set; }

    public string? LugarSiniestroCoordenadas { get; set; }

    public int? NombreReporteId { get; set; }

    public string? TelefonoContacto { get; set; }

    public string? CorreoElectronico { get; set; }

    public string? DescripcionSiniestro { get; set; }

    public int? VehiculoId { get; set; }

    public string? ObservacionesAjustador { get; set; }

    public int? AjustadorId { get; set; }

    public virtual Ajustador? Ajustador { get; set; }

    public virtual TipoPersona? NombreReporte { get; set; }

    [JsonIgnore]
    public virtual ICollection<SeguimientoSiniestro> SeguimientoSiniestros { get; set; } = new List<SeguimientoSiniestro>();

    public virtual Vehiculo? Vehiculo { get; set; }
}
