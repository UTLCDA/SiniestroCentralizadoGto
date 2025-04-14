using AutoMapper;
using Siniestro.Servidor.Dtos;
using SiniestroCentralizadoGtoApi.Modelos;
using Microsoft.EntityFrameworkCore;

namespace Siniestro.Servidor.Interfaces
{
    public class UsuarioService : IUsuarioService
    {
        private readonly SiniestrosContext _context;
        private readonly IMapper _mapper;

        public UsuarioService(SiniestrosContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<LoginResponseDto> LoginAsync(LoginRequestDto loginRequest)
        {
            // Buscar el usuario en la base de datos
            var usuario = await _context.Usuario
                .Include(u => u.NumeroEmpleadoNavigation) // Relación con Ajustador
                .FirstOrDefaultAsync(u => u.NumeroEmpleado == loginRequest.NumeroEmpleado);

            if (usuario == null || usuario.Contrasena != loginRequest.Contrasena)
            {
                throw new UnauthorizedAccessException("Credenciales incorrectas.");
            }

            // Mapear el objeto Usuario a UsuarioResponseDto
            var usuarioResponse = _mapper.Map<LoginResponseDto>(usuario);

            return usuarioResponse;
        }
    }
}
