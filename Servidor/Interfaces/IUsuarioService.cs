using Servidor.Dtos;

namespace Servidor.Interfaces
{
    public interface IUsuarioService
    {
        Task<LoginResponseDto> LoginAsync(LoginRequestDto loginRequest);

    }
}
