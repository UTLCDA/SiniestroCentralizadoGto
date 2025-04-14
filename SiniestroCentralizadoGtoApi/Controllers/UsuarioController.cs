using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Siniestro.Servidor.Dtos;
using Siniestro.Servidor.Interfaces;

namespace Siniestro.Servidor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequest)
        {
            if (loginRequest == null || string.IsNullOrEmpty(loginRequest.NumeroEmpleado) || string.IsNullOrEmpty(loginRequest.Contrasena))
            {
                return BadRequest("Número de empleado y contraseña son requeridos.");
            }

            try
            {
                var usuario = await _usuarioService.LoginAsync(loginRequest);

                // Si el login es exitoso, devolvemos la información del usuario
                return Ok(usuario);
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized("Credenciales incorrectas.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }
    }
}
