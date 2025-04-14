using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SiniestroCentralizadoGtoApi.Modelos;

public partial class Reporte
{
    public int Id { get; set; }

    public string PolizaId { get; set; }

    public int? ContratanteId { get; set; }

    public int? VehiculoId { get; set; }

    public int? AjustadorId { get; set; }

    public int? SucursalId { get; set; }

    public DateTime FechaSiniestro { get; set; }

    public string? LugarSiniestroDireccion { get; set; }

    public string? LugarSiniestroCoordenadas { get; set; }

    public string? Taller { get; set; }

    public string? Responsable { get; set; }

    public int? NumSiniestro { get; set; }

    public string? FolioReporte { get; set; }

    public string? TelefonoPropietrio { get; set; }

    public string? NombreAsegurado { get; set; }

    public string? NombrePropietario { get; set; }

    public bool AplicaDeducible { get; set; }

    public decimal? PorcentajeDeducible { get; set; }

    public string? DescripcionSiniestro { get; set; }

    public string? ObservacionesAjustador { get; set; }
    [NotMapped]
    public bool EsCorrecto { get; set; }
    public virtual Poliza? Poliza { get; set; }
    public virtual Contratante? Contratante { get; set; }
    public virtual Vehiculo? Vehiculo { get; set; }
    public virtual Ajustador? Ajustador { get; set; }
    public virtual Sucursal? Sucursal { get; set; }
}
