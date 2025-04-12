using System;
using System.Collections.Generic;

namespace SiniestroCentralizadoGtoApi.Modelos;

public partial class SolicitudContratante
{
    public int Id { get; set; }

    public string? NumeroPoliza { get; set; }

    public DateTime? FechaHora { get; set; }

    public string? Motivo { get; set; }

    public string? LugarCoordenadas { get; set; }

    public string? LugarSiniestroDetalle { get; set; }

    public string? DescripcionAccidente { get; set; }

    public string? Telefono { get; set; }

    public string? Correo { get; set; }

    public int? NumSiniestros { get; set; }
}
