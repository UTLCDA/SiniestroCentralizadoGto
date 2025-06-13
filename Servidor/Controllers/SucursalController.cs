using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Servidor.Interfaces;
using Servidor.Modelos;

namespace Servidor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SucursalController : ControllerBase
    {
        private readonly ISucursalServices _sucursalService;

        public SucursalController(ISucursalServices sucursalService)
        {
            _sucursalService = sucursalService;
        }

        [HttpGet("ListadoSucursales")]
        public async Task<IActionResult> Get()
        {
            var sucursal = await _sucursalService.ObtenerTodosAsync();
            return Ok(sucursal);
        }
        [HttpGet("ObtenerSucursal/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var sucursal = await _sucursalService.ObtenerPorIdAsync(id);
            if (sucursal == null) return NotFound();

            return Ok(sucursal);
        }

        [HttpPost("AltaSucursal")]
        public async Task<IActionResult> Post([FromBody] Sucursal sucursal)
        {
            var nuevo = await _sucursalService.CrearAsync(sucursal);
            return CreatedAtAction(nameof(Get), new { id = nuevo.Id }, nuevo);
        }

        //[HttpPost]
        //public IActionResult CrearEmpleado([FromBody] EmpleadoDtos dto)
        //{
        //    var empleado = new EmpleadoDtos
        //    {
        //        Nombre = dto.Nombre,
        //        Puesto = dto.Puesto
        //        // No seteas Usuarios
        //    };


        //    return Ok();
        //}

        [HttpPut("ActualizarSucursal/{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Sucursal sucursal)
        {
            if (id != sucursal.Id) return BadRequest();

            var actualizado = await _sucursalService.ActualizarAsync(sucursal);
            if (!actualizado) return NotFound();

            return NoContent();
        }

        [HttpDelete("EliminarSucursal/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var eliminado = await _sucursalService.EliminarAsync(id);
            if (!eliminado) return NotFound();

            return NoContent();
        }
        [HttpGet("CodigoPostal")]
        public async Task<IActionResult> GetActivosSql([FromQuery] string codigoPostal)
        {
            if (string.IsNullOrEmpty(codigoPostal))
            {
                return BadRequest("El código postal es requerido.");
            }

            var sucursales = await _sucursalService.ObtenerSucursalesConCodigoPostalAsync(codigoPostal);
            return Ok(sucursales);
        }
    }
}
