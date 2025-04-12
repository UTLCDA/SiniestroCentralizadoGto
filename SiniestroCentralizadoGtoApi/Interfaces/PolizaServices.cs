using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SiniestroCentralizadoGtoApi.Modelos;

namespace Siniestro.Servidor.Interfaces
{
    public class PolizaServices : IPolizaServices
    {
        private readonly SiniestrosContext _context;

        public PolizaServices(SiniestrosContext siniestrosContext)
        {
            _context = siniestrosContext;
        }

        public async Task<IEnumerable<Poliza>> ObtenerTodosAsync()
        {
            return await _context.Poliza.ToListAsync();
        }

        public async Task<Poliza> ObtenerPorIdAsync(int id)
        {
            return await _context.Poliza.FindAsync(id);
        }

        public async Task<IEnumerable<Poliza>> BuscarPolizaPorNombreAsync(string nombreLike)
        {
            var sql = $"SELECT * FROM Poliza WHERE Beneficiario like '%{nombreLike}%'";
            return await _context.Poliza
                                 .FromSqlRaw(sql, nombreLike)
                                 .ToListAsync();
        }

        public async Task<IEnumerable<Poliza>> BuscarPolizaPorNumeroPolizaAsync(string numeroPoliza)
        {
            var sql = $"SELECT * FROM Poliza WHERE NumeroPoliza = {numeroPoliza}";
            return await _context.Poliza
                                 .FromSqlRaw(sql, numeroPoliza)
                                 .ToListAsync();
        }

        public async Task<IEnumerable<Poliza>> BuscarPolizaPorVistaAsync(string numeroPoliza)
        {
            var sql = $"SELECT 0 as Id,* FROM vw_PolizaDetalleContratante WHERE NumeroPoliza = @NumeroPoliza";
            return await _context.Poliza
                                 .FromSqlRaw(sql, new SqlParameter("@NumeroPoliza", numeroPoliza))
                                 .ToListAsync();
        }

    }
}
