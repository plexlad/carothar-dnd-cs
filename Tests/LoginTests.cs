namespace Tests;
using Logic.Login;
using FluentAssertions;
using SimpleCrypto;

public class LoginTest
{
    [Fact]
    public void CheckIfUserIsLoggedIn()
    {
        LoginManager l = new();
        string username = "jimbo";
        string password = "password";

        User user = l.CreateNewUser(username, password, null);
        l.LogIn(username, password).Should().NotBeNull();
        l.IsLoggedIn("jimbo").Should().BeTrue();
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
