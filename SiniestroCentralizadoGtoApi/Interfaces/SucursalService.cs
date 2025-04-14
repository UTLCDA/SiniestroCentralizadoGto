using SiniestroCentralizadoGtoApi.Modelos;
using Microsoft.EntityFrameworkCore;

namespace Siniestro.Servidor.Interfaces
{
    public class SucursalService : ISucursalServices
    {
        private readonly SiniestrosContext _context;

        public SucursalService(SiniestrosContext siniestrosContext)
        {
            _context = siniestrosContext;
        }

        public async Task<IEnumerable<Sucursal>> ObtenerTodosAsync()
        {
            return await _context.Sucursal.ToListAsync();
        }

        public async Task<Sucursal> ObtenerPorIdAsync(int id)
        {
            return await _context.Sucursal.FindAsync(id);
        }
        public async Task<Sucursal> CrearAsync(Sucursal sucursal)
        {
            _context.Sucursal.Add(sucursal);
            await _context.SaveChangesAsync();
            return sucursal;
        }
        public async Task<bool> ActualizarAsync(Sucursal sucursal)
        {
            var existe = await _context.Sucursal.AnyAsync(e => e.Id == sucursal.Id);
            if (!existe) return false;

            _context.Sucursal.Update(sucursal);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EliminarAsync(int id)
        {
            var sucursal = await _context.Sucursal.FindAsync(id);
            if (sucursal == null) return false;

            _context.Sucursal.Remove(sucursal);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Sucursal>> ObtenerSucursalesConCodigoPostalAsync(string codigoPostal)
        {
            var sql = $"SELECT * FROM Sucursal WHERE CodigoPostal = {0}";
            return await _context.Sucursal
                                 .FromSqlRaw(sql, codigoPostal)
                                 .ToListAsync();
        }
    }
}
