using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SiniestroCentralizadoGtoApi.Modelos;

public partial class Poliza
{
    public int Id { get; set; }

    public string? LineaNegocio { get; set; }

    public int? OficinaEmisionId { get; set; }

    public string NumeroPoliza { get; set; }

    public int? ContratanteId { get; set; }

    public string? Beneficiario { get; set; }

    public DateOnly? FechaInicioVigencia { get; set; }

    public DateOnly? FechaFinVigencia { get; set; }

    public DateOnly? FechaEmision { get; set; }

    public string? Estatus { get; set; }

    public int? PeriodicidadId { get; set; }

    public int? VehiculoId { get; set; }

    public DateOnly? UltimoPago { get; set; }

    public virtual Contratante? Contratante { get; set; }

    public virtual Sucursal? OficinaEmision { get; set; }

    public virtual Periodicidad? Periodicidad { get; set; }

    public virtual Vehiculo? Vehiculo { get; set; }
    [JsonIgnore]
    public virtual ICollection<Reporte> Reportes { get; set; }
}
