using Microsoft.IdentityModel.Tokens;
using Servidor.Modelos;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Servidor.Security
{
    public class GenerarJwtToken
    {
        private string GenerarJwtTokenUno(Usuario usuario)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Pepita")); 
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
        new Claim(ClaimTypes.NameIdentifier, usuario.IdUsuario.ToString()),
        new Claim(ClaimTypes.Name, usuario.NumeroEmpleado)
    };

            var token = new JwtSecurityToken(
                issuer: "HDI",
                audience: "SINIESTROS",
                claims: claims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
