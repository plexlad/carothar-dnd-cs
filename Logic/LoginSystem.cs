// WARNING: This code is very ramshackle
namespace Logic.Login;

using SimpleCrypto; // Encrytion library for VERY basic password hashing and salt

public class User
{
    public string Username { get; }
    public string Password { get; }
    public string? ProfileImageLink { get; private set; }
    // List of session keys that the player can rejoin
    public List<string> SessionKeys { get; }

    public User(string username, string hashedPassword)
    {
        Username = username;
        Password = hashedPassword;
        SessionKeys = new();
    }

    public User(string username, string hashedPassword, string? profileImageLink) : this(username, hashedPassword)
    {
        ProfileImageLink = profileImageLink;
    }

    // Adds a session key for reference
    public void AddSessionKey(string key)
    {
        SessionKeys.Add(key);
    }
}

// Manages login information, such as hashing and salting as well as userInfo
public class LoginManager
{
    // For public available use
    public static LoginManager Instance = new();

    // A dictionary of all the users. Can retrieve user data with the username
    private Dictionary<string, User> _users;
    public Dictionary<string, User> Users => _users;

    ICryptoService cryptoService; // Crypto service

    public LoginManager()
    {
        _users = new();
        cryptoService = new PBKDF2();
    }

    // Returns true if logged in successfully, false otherwise
    // Set hashed to true if the password is already hashed
    public User? LogIn(string username, string password, bool hashed = false)
    {
        User? user = null;

        // If value is not valid, returns null
        user = _users.TryGetValue(username, out user) ? user : null;

        // Compares the stored password$
        if (user is not null)
        {
            // Save some time by not having to compute
            string hashedUserInput = hashed ? password : cryptoService.Compute(password);

            if (cryptoService.Compare(hashedUserInput, user.Password))
            {
                return user;
            }
        }
        return null;
    }

    // True if successful (could use already used username)
    // Password is the actual password, will be hashed and salted
    public User? CreateNewUser(string username, string password, string? profileImageLink)
    {
        if (!_users.Keys.Contains(username))
        {
            string salt = cryptoService.GenerateSalt();
            string hashedPassword = cryptoService.Compute(password, salt);

            User user = new(username, hashedPassword);
            _users[username] = user;
            return user;
        }
        return null;
    }
}
