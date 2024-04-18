// These are the the instances of games that people can connect to
// Use the instance manager to manage sets of instances
namespace Logic.Session;

using SimpleCrypto; // Uses the random password feature for the key

// Session probably wasn't the greatest name, but it is persistantly stored
// so users can access their character data
public class Session
{
    public string Name { get; set; }
    // A key to invite people to the session
    public string Key { get; }
    // Users on the session
    public List<string> users;

    public Session()
    {
        Key = RandomPassword.Generate(16); // Generates a session id
        users = new();
    }
}
