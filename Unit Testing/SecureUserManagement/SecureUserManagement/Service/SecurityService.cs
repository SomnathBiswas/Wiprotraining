using System.Security.Cryptography;
using System.Text;

namespace SecureUserManagement.Service
{
    public class SecurityService
    {

        public string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }

        public string Encrypt(string plainText, string key)
        {
            using Aes aes = Aes.Create();
            aes.Key = Encoding.UTF8.GetBytes(key.PadRight(32));
            aes.GenerateIV();

            using var encryptor = aes.CreateEncryptor();
            byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);
            byte[] encryptedBytes = encryptor.TransformFinalBlock(plainBytes, 0, plainBytes.Length);

            return Convert.ToBase64String(aes.IV.Concat(encryptedBytes).ToArray());
        }

        public string Decrypt(string cipherText, string key)
        {
            byte[] fullBytes = Convert.FromBase64String(cipherText);
            byte[] iv = fullBytes.Take(16).ToArray();
            byte[] cipherBytes = fullBytes.Skip(16).ToArray();

            using Aes aes = Aes.Create();
            aes.Key = Encoding.UTF8.GetBytes(key.PadRight(32));
            aes.IV = iv;

            using var decryptor = aes.CreateDecryptor();
            byte[] decryptedBytes = decryptor.TransformFinalBlock(cipherBytes, 0, cipherBytes.Length);
            return Encoding.UTF8.GetString(decryptedBytes);
        }
    }
}
