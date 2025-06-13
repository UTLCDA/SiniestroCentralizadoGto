using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Servidor.Modelos;

public partial class Reporte
{
    public int Id { get; set; }
    [Required(ErrorMessage = "El campo Id Sucursal es obligatorio.")]
    public int? SucursalId { get; set; }
    [Required(ErrorMessage = "El campo Id poliza es obligatorio")]
    public string PolizaId { get; set; }
    [Required(ErrorMessage = "El campo Id Contratante es obligatorio")]
    public int? ContratanteId { get; set; }
    [Required(ErrorMessage = "El campo Vehiculo es obligatorio")]
    public int? VehiculoId { get; set; }
    [Required(ErrorMessage = "El campo Fecha siniestro es obligatorio")]
    public DateTime FechaSiniestro { get; set; }
    [Required(ErrorMessage = "El campo Lugar Siniestro Dirección es obligatorio")]
    public string? LugarSiniestroDireccion { get; set; }
    [Required(ErrorMessage = "El campo Lugar Siniestro Coordenadas es obligatorio")]
    public string? LugarSiniestroCoordenadas { get; set; }
    [Required(ErrorMessage = "El campo Taller es obligatorio")]
    public string? Taller { get; set; }
    [Required(ErrorMessage = "El campo Responsable es obligatorio")]
    public string? Responsable { get; set; }
    [Required(ErrorMessage = "El campo Número de Siniestro es obligatorio")]
    public int? NumSiniestro { get; set; }
    [Required(ErrorMessage = "El campo Folio Reporte es obligatorio")]
    public string? FolioReporte { get; set; }
    [Required(ErrorMessage = "El campo Telefono Propietario es obligatorio")]
    public string? TelefonoPropietrio { get; set; }
    [Required(ErrorMessage = "El campo Nombre Asegurado es obligatorio")]
    public string? NombreAsegurado { get; set; }
    [Required(ErrorMessage = "El campo Nombre propietario es obligatorio")]
    public string? NombrePropietario { get; set; }

    public bool AplicaDeducible { get; set; }

    public decimal? PorcentajeDeducible { get; set; }
    [Required(ErrorMessage = "El Descripción siniestro Póliza es obligatorio")]
    public string? DescripcionSiniestro { get; set; }

    public int? AjustadorId { get; set; }
    [Required(ErrorMessage = "El campo Observaciones Ajustador es obligatorio")]
    public string? ObservacionesAjustador { get; set; }
    [NotMapped]
    public bool EsCorrecto { get; set; }
    public virtual Poliza? Poliza { get; set; }
    public virtual Contratante? Contratante { get; set; }
    public virtual Vehiculo? Vehiculo { get; set; }
    public virtual Ajustador? Ajustador { get; set; }
    public virtual Sucursal? Sucursal { get; set; }
}
