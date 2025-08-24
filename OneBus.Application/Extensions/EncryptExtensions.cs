using Konscious.Security.Cryptography;
using System.Security.Cryptography;
using System.Text;

namespace OneBus.Application.Extensions
{
    public static class EncryptExtensions
    {
        public static string Hash(this string value, string salt)
        {
            var argon2 = new Argon2id(Encoding.UTF8.GetBytes(value))
            {
                Salt = Encoding.UTF8.GetBytes(salt),
                DegreeOfParallelism = 8,   // How many threads
                MemorySize = 65536,        // Memory (KB)
                Iterations = 4             // Iterations
            };

            const int hashLength = 32;     // Hash size (in bytes)
            return Convert.ToBase64String(argon2.GetBytes(hashLength));
        }

        public static bool Verify(this string value, string input, string salt)
        {
            byte[] savedHash = Convert.FromBase64String(value);

            byte[] newHash = Convert.FromBase64String(input.Hash(salt));

            // Secure comparison (prevents timing attacks)
            return CryptographicOperations.FixedTimeEquals(savedHash, newHash);
        }
    }
}
