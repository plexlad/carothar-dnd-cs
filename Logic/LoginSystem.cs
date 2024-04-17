namespace Logic.Login;

using SimpleCrypto; // Encrytion library for VERY basic password hashing and salt

public class User
{
    public string Username { get; }
    public string Password { get; }
    public string? ProfileImageLink { get; private set; }
    // List of session keys that the player can rejoin
    public List<string> Sessions { get; }

    public User(string username, string hashedPassword)
    {
        Username = username;
        Password = hashedPassword;
        Sessions = new();
    }

    public User(string username, string hashedPassword, string? profileImageLink) : this(username, hashedPassword)
    {
        ProfileImageLink = profileImageLink;
    }

    // Adds a session key for reference
    public void AddSession(string key)
    {
        Sessions.Add(key);
    }
}

// Manages login information, such as hashing and salting as well as 
public class LoginManager
{
    // For public available use
    public static LoginManager Instance = new();

    // A dictionary of all the users. Can retrieve user data with the username
    private Dictionary<string, User> _users;
    public Dictionary<string, User> Users => _users;

    private List<string> loggedInUsers; // By username for simplicity

    ICryptoService cryptoService; // Crypto service

    public LoginManager()
    {
        _users = new();
        loggedInUsers = new();
        cryptoService = new PBKDF2();
    }

    // Returns true if logged in successfully, false otherwise
    public User? LogIn(string username, string password)
    {
        User? user = _users[username];
        string hashedUserInput = cryptoService.Compute(password);

        // Compares the stored password$
        if (user is not null)
        {
            // Auto log in for now
            // loggedInUsers.Add(username);
            //return user;
            if (cryptoService.Compare(hashedUserInput, user.Password))
            {
                loggedInUsers.Add(username);
                return user;
            }
        }
        return null;
    }

    public bool IsLoggedIn(string username)
    {
        if (loggedInUsers.Contains(username)) return true;
        return false;
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