using System.Text;
using System.Security.Cryptography;

namespace Siniestro.Servidor.Security
{
    public class PasswordHash
    {
        public static string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(password);
            var hash = sha256.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }

        public static bool VerifyPassword(string inputPassword, string hashedPassword)
        {
            var inputHashed = HashPassword(inputPassword);
            return inputHashed == hashedPassword;
        }
    }
}
