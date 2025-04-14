using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Siniestro.Servidor.Interfaces;

namespace Siniestro.Servidor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PolizaController : ControllerBase
    {
        private readonly IPolizaServices _polizaService;

        public PolizaController(IPolizaServices polizaServices) 
        {
            _polizaService = polizaServices;
        }

        [HttpGet("ListadoPolizas")]
        public async Task<IActionResult> Get()
        {
            var poliza = await _polizaService.ObtenerTodosAsync();
            return Ok(poliza);
        }

        [HttpGet("ObtenerPoliza/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var poliza = await _polizaService.ObtenerPorIdAsync(id);
            if (poliza == null) return NotFound();

            return Ok(poliza);
        }

        [HttpGet("NombreBeneficiario")]
        public async Task<IActionResult> GetNombreBeneficiarioPolizaSql([FromQuery] string nombreLike)
        {
            if (string.IsNullOrEmpty(nombreLike))
            {
                return BadRequest("El nombre del beneficiario es requerido.");
            }

            var poliza = await _polizaService.BuscarPolizaPorNombreAsync(nombreLike);
            return Ok(poliza);
        }

        [HttpGet("NumeroPoliza")]
        public async Task<IActionResult> GetNumeroPolizaSql([FromQuery] string numeroPoliza)
        {
            if (string.IsNullOrEmpty(numeroPoliza))
            {
                return BadRequest("El número de poliza es requerido.");
            }

            var poliza = await _polizaService.BuscarPolizaPorNumeroPolizaAsync(numeroPoliza);
            return Ok(poliza);
        }

        [HttpGet("NumeroPolizaLinq")]
        public async Task<IActionResult> GetNumeroPolizaVistaSql([FromQuery] string cadena)
        {
            if (string.IsNullOrEmpty(cadena))
            {
                return BadRequest("El número de poliza es requerido.");
            }

            var poliza = await _polizaService.BuscarPolizaPorNumeroPolizaRelacionAsync(cadena);
            return Ok(poliza);
        }
    }
}
