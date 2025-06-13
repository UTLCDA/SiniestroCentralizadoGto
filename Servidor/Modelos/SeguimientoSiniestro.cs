using System;
using System.Collections.Generic;

namespace Servidor.Modelos;

public partial class SeguimientoSiniestro
{
    public int Id { get; set; }

    public DateOnly? FechaRegistroReporteSiniestro { get; set; }

    public string? NumeroPolizaAfectado { get; set; }

    public int? NumeroSiniestroId { get; set; }

    public int? NumeroAjustadorAlta { get; set; }

    public string? NombreAjustador { get; set; }

    public string? Comentarios { get; set; }

    public virtual Ajustador? NumeroAjustadorAltaNavigation { get; set; }

    public virtual Reporte? NumeroSiniestro { get; set; }
}
