//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace SecureUserManagement.Tests
//{
//    internal class AuthServiceTests
//    {
//    }
//}


using Microsoft.EntityFrameworkCore;
using SecureUserManagement.Data;
using SecureUserManagement.Models;
using SecureUserManagement.Services;
using System;
using Xunit;

public class AuthServiceTests
{
    private ApplicationDbContext GetDbContext()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
        .UseInMemoryDatabase(databaseName: "TestDb")
        .Options;
        return new ApplicationDbContext(options);
    }

    [Fact]
public void Register_ShouldStoreHashedPassword()
    {
        var context = GetDbContext();
        var service = new AuthService(context);

        var result = service.Register("testuser", "pass123");
        var user = context.Users.FirstOrDefault(u => u.Username == "testuser");

        Assert.True(result);
        Assert.NotNull(user);
        Assert.NotEqual("pass123", user.HashedPassword);
    }

    [Fact]
    public void Authenticate_ShouldReturnTrue_ForCorrectPassword()
    {
        var context = GetDbContext();
        var service = new AuthService(context);

        service.Register("user1", "hello123");
        var result = service.Authenticate("user1", "hello123");

        Assert.True(result);
    }

    [Fact]
    public void Authenticate_ShouldReturnFalse_ForWrongPassword()
    {
        var context = GetDbContext();
        var service = new AuthService(context);

        service.Register("user2", "correct123");
        var result = service.Authenticate("user2", "wrong456");

        Assert.False(result);
    }
}
