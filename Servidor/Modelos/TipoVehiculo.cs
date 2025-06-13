using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Servidor.Modelos;

public partial class TipoVehiculo
{
    public int IdTipoVehiculo { get; set; }

    public string Nombre { get; set; } = null!;
    [JsonIgnore]
    public virtual ICollection<Vehiculo> Vehiculos { get; set; } = new List<Vehiculo>();
}
