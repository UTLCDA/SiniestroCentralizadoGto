using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SiniestroCentralizadoGtoApi.Modelos;

public partial class Sucursal
{

    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Direccion { get; set; }
    [Required(ErrorMessage = "El teléfono es obligatorio")]
    [RegularExpression(@"^\d{10}$", ErrorMessage = "El teléfono debe tener exactamente 10 dígitos")]
    public string? Telefono { get; set; }

    [Required(ErrorMessage = "El código postal es obligatorio")]
    [RegularExpression(@"^\d{5}$", ErrorMessage = "El código postal debe tener exactamente 5 dígitos")]
    public string? CodigoPostal { get; set; }

    public string? Ciudad { get; set; }

    public string? Estado { get; set; }

    [JsonIgnore]
    public virtual ICollection<Poliza> Polizas { get; set; } = new List<Poliza>();
}
