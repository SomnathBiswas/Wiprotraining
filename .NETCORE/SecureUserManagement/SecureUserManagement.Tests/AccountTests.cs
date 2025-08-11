//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace SecureUserManagement.Tests
//{
//    internal class AccountTests
//    {
//    }
//}


using Microsoft.AspNetCore.Mvc;
using Moq;
using SecureUserManagement.Controllers;
using SecureUserManagement.Services;
using System;
using Xunit;

namespace SecureUserManagement.Tests
{
    public class AccountTests
    {
        private readonly Mock<AuthService> _authServiceMock;
        private readonly Mock<EncryptionService> _encryptionServiceMock;
        private readonly Mock<LoggerService> _loggerMock;
        private readonly AccountController _controller;

        public AccountTests()
        {
            _authServiceMock = new Mock<AuthService>(null); // null DbContext for now
            _encryptionServiceMock = new Mock<EncryptionService>();
            _loggerMock = new Mock<LoggerService>();

            _controller = new AccountController(
                _authServiceMock.Object,
                _encryptionServiceMock.Object,
                _loggerMock.Object);
        }

        [Fact]
        public void Register_ShouldRedirectToLogin_OnSuccess()
        {
            // Arrange
            _authServiceMock.Setup(s => s.Register("user1", "pass")).Returns(true);
            _encryptionServiceMock.Setup(e => e.Encrypt("data")).Returns("encrypted");

            // Act
            var result = _controller.Register("user1", "pass", "data");

            // Assert
            var redirectResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Login", redirectResult.ActionName);
        }

        [Fact]
        public void Register_ShouldReturnView_WithError_WhenUsernameExists()
        {
            _authServiceMock.Setup(s => s.Register("user1", "pass")).Returns(false);

            var result = _controller.Register("user1", "pass", "data");

            var viewResult = Assert.IsType<ViewResult>(result);
            //Assert.Equal("Username already exists.", viewResult.ViewData["Error"] ?? viewResult.ViewBag.Error);
            Assert.Equal("Username already exists.", viewResult.ViewData["Error"]);
        }

        [Fact]
        public void Login_ShouldRedirectToHomeIndex_OnSuccess()
        {
            _authServiceMock.Setup(s => s.Authenticate("user1", "pass")).Returns(true);

            var result = _controller.Login("user1", "pass");

            var redirect = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirect.ActionName);
            Assert.Equal("Home", redirect.ControllerName);
        }

        [Fact]
        public void Login_ShouldReturnView_WithError_OnInvalidCredentials()
        {
            _authServiceMock.Setup(s => s.Authenticate("user1", "wrongpass")).Returns(false);

            var result = _controller.Login("user1", "wrongpass");

            var viewResult = Assert.IsType<ViewResult>(result);
            //Assert.Equal("Invalid credentials.", viewResult.ViewData["Error"] ?? viewResult.ViewBag.Error);

            Assert.Equal("Invalid credentials.", viewResult.ViewData["Error"]);
        }
    }
}