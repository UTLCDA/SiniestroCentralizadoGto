using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Siniestro.Servidor.Interfaces;
using SiniestroCentralizadoGtoApi.Modelos;

namespace Siniestro.Servidor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReporteController : ControllerBase
    {
        private readonly IReporteServices _reporteServices;

        public ReporteController(IReporteServices reporteServices)
        {
            _reporteServices = reporteServices;
        }

        [HttpGet("ListadoReportes")]
        public async Task<IActionResult> Get()
        {
            var reporte = await _reporteServices.ObtenerTodosAsync();
            return Ok(reporte);
        }
        [HttpGet("ObtenerReporte/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var reporte = await _reporteServices.ObtenerPorIdAsync(id);
            if (reporte == null) return NotFound();

            return Ok(reporte);
        }

        [HttpPost("AltaReporte")]
        public async Task<IActionResult> Post([FromBody] Reporte reporte)
        {
            // verificar si aqui metemos las reglas de negocio
            // primero hacer el insert into a reportes
            var nuevo = await _reporteServices.CrearAsync(reporte);
            return CreatedAtAction(nameof(Get), new { id = nuevo.Id }, nuevo);
        }
        [HttpGet("Reporte")]
        public async Task<IActionResult> GetActivosSql([FromQuery] string cadena)
        {
            if (string.IsNullOrEmpty(cadena))
            {
                return BadRequest("El código postal es requerido.");
            }

            var reportes = await _reporteServices.ConsultaSqlAsync(cadena);
            return Ok(reportes);
        }
    }
}
