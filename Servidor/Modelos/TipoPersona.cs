using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Servidor.Modelos;

public partial class TipoPersona
{
    public int Id { get; set; }

    public string? Descripcion { get; set; }
}
