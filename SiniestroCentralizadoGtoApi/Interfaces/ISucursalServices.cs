using SiniestroCentralizadoGtoApi.Modelos;
namespace Siniestro.Servidor.Interfaces
{
    public interface ISucursalServices
    {
        Task<IEnumerable<Sucursal>> ObtenerTodosAsync();
        Task<Sucursal> ObtenerPorIdAsync(int id);
        Task<Sucursal> CrearAsync(Sucursal sucursal);
        Task<bool> ActualizarAsync(Sucursal sucursal);
        Task<bool> EliminarAsync(int id);
        Task<IEnumerable<Sucursal>> ObtenerSucursalesConCodigoPostalAsync(string codigoPostal);
    }
}
