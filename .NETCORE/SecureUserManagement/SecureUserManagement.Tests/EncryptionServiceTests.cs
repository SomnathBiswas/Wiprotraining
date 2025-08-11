using Xunit;
using SecureUserManagement.Services;

namespace SecureUserManagement.Tests
{
    public class EncryptionServiceTests
    {
        [Fact]
        public void EncryptDecrypt_ShouldReturnOriginalText()
        {
            var service = new EncryptionService();

           
            string original = "Secret123";

            string encrypted = service.Encrypt(original);
            string decrypted = service.Decrypt(encrypted);

            Assert.Equal(original, decrypted);
        }

        [Fact]
        public void Decrypt_ShouldThrowFormatException_ForInvalidInput()
        {
            var service = new EncryptionService();

            Assert.Throws<System.FormatException>(() => service.Decrypt("invalidciphertext"));
        }
    }
}