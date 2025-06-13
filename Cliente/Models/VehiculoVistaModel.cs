using Servidor.Modelos;
using System.Text.Json.Serialization;

namespace Cliente.Models
{
    public class VehiculoVistaModel
    {
        public int Id { get; set; }

        public string? Marca { get; set; }

        public string? Modelo { get; set; }

        public int? Año { get; set; }

        public string? Placas { get; set; }

        public string? NumeroSerie { get; set; }

        public string? Color { get; set; }

        public int? IdTipoVehiculo { get; set; }
        [JsonIgnore]
        public virtual TipoVehiculo? IdTipoVehiculoNavigation { get; set; }

    }
}
