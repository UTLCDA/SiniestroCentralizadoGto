using SiniestroCentralizadoGtoApi.Modelos;

namespace Siniestro.Servidor.Interfaces
{
    public interface IReporteServices
    {
        Task<IEnumerable<Reporte>> ObtenerTodosAsync();
        Task<Reporte> ObtenerPorIdAsync(int id);
        Task<Reporte> CrearAsync(Reporte reporte);
        Task<IEnumerable<Reporte>> ConsultaSqlAsync(string cadena);
    }
}
