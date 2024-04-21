// These are the the instances of games that people can connect to
// Use the instance manager to manage sets of instances
namespace Persistence;

using SimpleCrypto;

// Session probably wasn't the greatest name, but it is persistantly stored
// so users can access their character data
public class Session
{
    public string Name { get; set; }
    public string Key { get; init; } // Used to invite and work with people
    public string CreatedBy { get; set; } // Username of person who created this session
    public List<string> Users; // Users on the session
    public Dictionary<string, PlayerStats> Characters;

    public event Action SessionUpdated;

    public Session() {}

    public Session(string name, string createdBy)
    {
        Name = name;
        // Generates a unique key
        Key = RandomPassword.Generate(16, PasswordGroup.Lowercase, PasswordGroup.Uppercase);
        CreatedBy = createdBy;
        Users = new();
        Characters = new();
    }

    public void UpdateSessionData()
    {
        SessionUpdated?.Invoke();
    }

    public void AddCharacter(PlayerStats character)
    {
        Characters.Add(character.Key, character);
    }

    public PlayerStats? GetCharacter(string key)
    {
        PlayerStats character;
        return Characters.TryGetValue(key, out character!) ? character : null;
    }
}
