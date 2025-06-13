using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Servidor.Modelos;

public partial class Contratante
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? ApellidoPaterno { get; set; }

    public string? ApellidoMaterno { get; set; }

    public string? Rfc { get; set; }

    public string? Curp { get; set; }

    public string? Telefono { get; set; }

    public string? CorreoElectronico { get; set; }

    public string? CuentaBancaria { get; set; }

    public string? Banco { get; set; }

    [JsonIgnore]
    public virtual ICollection<Poliza> Polizas { get; set; } = new List<Poliza>();
}
