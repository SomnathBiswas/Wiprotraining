using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using SecureUserManagement.Controllers;
using SecureUserManagement.Data;
using SecureUserManagement.Models;
using SecureUserManagement.Service;
using System.Collections.Generic;
using System.Linq;
using Xunit;

public class UserControllerTests
{
    [Fact]
    public void Register_ShouldRedirectToLogin_OnSuccess()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "UserDb")
            .Options;

        using var context = new ApplicationDbContext(options);
        var loggerMock = new Mock<ILogger<UsersController>>();
        var controller = new UsersController(context, loggerMock.Object);

        // Act
        var result = controller.Register("testuser", "password123", "email@example.com") as RedirectToActionResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Login", result.ActionName);
    }

    [Fact]
    public void Login_ShouldReturnSuccessView_WhenCredentialsAreValid()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "LoginDb")
            .Options;

        using var context = new ApplicationDbContext(options);
        var loggerMock = new Mock<ILogger<UsersController>>();
        var controller = new UsersController(context, loggerMock.Object);

        // Add test user
        var security = new SecurityService();
        var password = "pass123";
        var hashedPassword = security.HashPassword(password);
        context.Users.Add(new User
        {
            Username = "user1",
            HashedPassword = hashedPassword,
            EncryptedEmail = security.Encrypt("u1@mail.com", "MySecretKey123")
        });
        context.SaveChanges();

        // Act
        var result = controller.Login("user1", password) as ViewResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Success", result.ViewName);
    }
}
