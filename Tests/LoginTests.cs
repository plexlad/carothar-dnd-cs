namespace Tests;
using Logic.Login;
using FluentAssertions;
using SimpleCrypto;

public class LoginTest
{
    [Fact]
    public void CheckIfUserIsLoggedIn()
    {
        ICryptoService c = new PBKDF2();
        LoginManager l = new();
        string username = "jimbo";
        string password = "password";

        l.CreateNewUser(username, password, null);

        l.LogIn(username, password).Should().NotBeNull();
    }

    [Fact]
    public void MakeSureUsernameCantBeCopied()
    {
        LoginManager l = new();
        string username = "jimbo";

        l.CreateNewUser(username, "password", null).Should().NotBeNull();
        l.CreateNewUser(username, "password2", null).Should().BeNull();
    }
}
