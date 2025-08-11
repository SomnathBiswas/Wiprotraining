using SecureUserManagement.Service;
using Xunit;

namespace SecureUserManagement.Tests
{
    public class SecurityServiceTests
    {
        [Fact]
        public void HashPassword_ShouldReturnConsistentHash_ForSameInput()
        {
            var service = new SecurityService();
            var password = "Test123";

            var hash1 = service.HashPassword(password);
            var hash2 = service.HashPassword(password);

            Assert.Equal(hash1, hash2);
        }

        [Fact]
        public void EncryptDecrypt_ShouldReturnOriginalData()
        {
            var service = new SecurityService();
            var key = "MySecretKey123";
            var originalText = "sensitive@example.com";

            var encrypted = service.Encrypt(originalText, key);
            var decrypted = service.Decrypt(encrypted, key);

            Assert.Equal(originalText, decrypted);
        }
    }
}