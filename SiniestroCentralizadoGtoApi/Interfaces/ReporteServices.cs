using SiniestroCentralizadoGtoApi.Modelos;
using Microsoft.EntityFrameworkCore;

namespace Siniestro.Servidor.Interfaces
{
    public class ReporteServices : IReporteServices
    {
        private readonly SiniestrosContext _context;

        public ReporteServices(SiniestrosContext siniestrosContext)
        {
            _context = siniestrosContext;
        }

        public async Task<IEnumerable<Reporte>> ObtenerTodosAsync()
        {
            return await _context.Reporte
        .Include(r => r.Sucursal)
        .Include(r => r.Poliza)
        .Include(r => r.Contratante)
        .Include(r => r.Vehiculo)
        .Include(r => r.Ajustador)
        .ToListAsync();
        }

        public async Task<Reporte> ObtenerPorIdAsync(int id)
        {
            return await _context.Reporte.FindAsync(id);
        }

        public async Task<Reporte> CrearAsync(Reporte reporte)
        {
            _context.Reporte.Add(reporte);
            //Validar si la ALTA del siniestro con las fechas 
            // alta y vigencia estan dentro del rango

            //Validar si la poliza esta pagada y no tiene pendiente de pago

            // validar si la ALTA del siniestro cumple con los 18 meses que 
            // tiene como politica la empresa para dar de alta el siniestro

            // si todo es true guarda el reporte 

            // si es falso por alguna de estas condiciones 
            // no guarda el reporte y retorna un estatus 200 pero no hace
            // commit
            await _context.SaveChangesAsync();
            return reporte;
        }

        public async Task<IEnumerable<Reporte>> ConsultaSqlAsync(string cadena)
        {
            var sql = $"SELECT * FROM Reporte WHERE CodigoPostal = {cadena}";
            return await _context.Reporte
                                 .FromSqlRaw(sql, cadena)
                                 .ToListAsync();
        }

    }
}
