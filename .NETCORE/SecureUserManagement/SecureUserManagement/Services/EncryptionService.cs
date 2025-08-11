using System.Security.Cryptography;
using System.Text;

namespace SecureUserManagement.Services
{
    public class EncryptionService
    {
        private readonly byte[] Key;
        private readonly byte[] IV;

        public EncryptionService()
        {
            // 32-byte key and 16-byte IV for AES
            Key = Encoding.UTF8.GetBytes("12345678901234567890123456789012");
            IV = Encoding.UTF8.GetBytes("1234567890123456");
        }

        public string Encrypt(string plainText)
        {
            using var aes = Aes.Create();
            aes.Key = Key;
            aes.IV = IV;
            var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

            var plainBytes = Encoding.UTF8.GetBytes(plainText);
            var encrypted = encryptor.TransformFinalBlock(plainBytes, 0, plainBytes.Length);
            return Convert.ToBase64String(encrypted);
        }

        public string Decrypt(string encryptedText)
        {
            using var aes = Aes.Create();
            aes.Key = Key;
            aes.IV = IV;
            var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

            var encryptedBytes = Convert.FromBase64String(encryptedText);
            var decrypted = decryptor.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length);
            return Encoding.UTF8.GetString(decrypted);
        }
    }
}
