using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Servidor.Modelos;

public partial class Vehiculo
{
    public int Id { get; set; }

    public string? Marca { get; set; }

    public string? Modelo { get; set; }

    public int? Año { get; set; }

    public string? Placas { get; set; }

    public string? NumeroSerie { get; set; }

    public string? Color { get; set; }

    public int? IdTipoVehiculo { get; set; }

    public virtual TipoVehiculo? IdTipoVehiculoNavigation { get; set; }
    [JsonIgnore]
    public virtual ICollection<Poliza> Polizas { get; set; } = new List<Poliza>();
    [JsonIgnore]
    public virtual ICollection<Reporte> Reportes { get; set; } = new List<Reporte>();
}
