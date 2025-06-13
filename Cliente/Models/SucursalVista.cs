using System.ComponentModel.DataAnnotations;

namespace Cliente.Models
{
    public class SucursalVista
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }

        public string? Direccion { get; set; }

        [Required]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "El teléfono debe tener 10 dígitos numéricos.")]
        public string? Telefono { get; set; }

        [Required]
        [RegularExpression(@"^\d{5}$", ErrorMessage = "El código postal debe tener 5 dígitos.")]
        public string? CodigoPostal { get; set; }

        public string? Ciudad { get; set; }

        public string? Estado { get; set; }
    }
}
