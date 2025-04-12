using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SiniestroCentralizadoGtoApi.Modelos;

public partial class Periodicidad
{
    public int Id { get; set; }

    public string? Tipo { get; set; }

    [JsonIgnore]
    public virtual ICollection<Poliza> Polizas { get; set; } = new List<Poliza>();
}
