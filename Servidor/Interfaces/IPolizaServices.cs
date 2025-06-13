using Servidor.Modelos;
namespace Servidor.Interfaces
{
    public interface IPolizaServices
    {
        Task<IEnumerable<Poliza>> ObtenerTodosAsync();
        Task<Poliza> ObtenerPorIdAsync(int id);
        //Task<Poliza> CrearAsync(Poliza poliza); // SIEMPRE Y CUANDO SEA PERFIL ADMON O EJECUTIVO
        Task<IEnumerable<Poliza>> BuscarPolizaPorNombreAsync(string nombreLike);
        Task<IEnumerable<Poliza>> BuscarPolizaPorNumeroPolizaAsync(string numeroPoliza);
        Task<IEnumerable<Poliza>> BuscarPolizaPorNumeroPolizaRelacionAsync(string cadena);
        Task<IEnumerable<Poliza>> BuscarPolizaPorVistaAsync(string numeroPoliza);
    }
}
