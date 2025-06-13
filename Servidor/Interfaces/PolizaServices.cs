using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Servidor.Modelos;

namespace Servidor.Interfaces
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
            return await _context.Poliza
            .Include(p => p.Contratante)     // Incluye la entidad Contratante
            .Include(p => p.Vehiculo)        // Incluye la entidad Vehiculo
            .Include(p => p.OficinaEmision)  // Incluye la entidad OficinaEmision
            .Include(p => p.Periodicidad)    // Incluye la entidad Periodicidad
            .ToListAsync();     
        }

        public async Task<Poliza> ObtenerPorIdAsync(int id)
        {
            return await _context.Poliza.FindAsync(id);
        }

        public async Task<IEnumerable<Poliza>> BuscarPolizaPorNombreAsync(string nombreLike)
        {
            return await _context.Poliza
            .Where(p => p.Beneficiario.Contains(nombreLike))
            .Include(p => p.Contratante)
            .Include(p => p.Vehiculo)
            .Include(p => p.OficinaEmision)
            .Include(p => p.Periodicidad)
            .ToListAsync();
        }

        public async Task<IEnumerable<Poliza>> BuscarPolizaPorNumeroPolizaRelacionAsync(string cadena)
        {
            return await _context.Poliza
                .Where(p => p.NumeroPoliza.Contains(cadena))
                .Include(p => p.Contratante)
                .Include(p => p.Vehiculo)
                .Include(p => p.OficinaEmision)
                .Include(p => p.Periodicidad)
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
