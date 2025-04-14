using Siniestro.Servidor.Dtos;

namespace Siniestro.Servidor.Interfaces
{
    public interface IUsuarioService
    {
        Task<LoginResponseDto> LoginAsync(LoginRequestDto loginRequest);

    }
}
