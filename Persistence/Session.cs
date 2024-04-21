// These are the the instances of games that people can connect to
// Use the instance manager to manage sets of instances
namespace Persistence;

using SimpleCrypto;

// Session probably wasn't the greatest name, but it is persistantly stored
// so users can access their character data
public class Session
{
    private SQLiteStoreManager sm = new();
    public string Name { get; set; }
    public string Key { get; init; } // Used to invite and work with people
    public string CreatedBy { get; set; } // Username of person who created this session
    public List<string> Users; // Users on the session
    public Dictionary<string, PlayerStats> Characters;

    public event Action SessionUpdated;

    public Session() {
        SessionUpdated += () => sm.UpdateSession(this);
    }

    public Session(string name, string createdBy) : this()
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
        PlayerStats character;
        foreach(KeyValuePair<string, PlayerStats> entry in Characters)
        {
            character = entry.Value;
            sm.UpdateCharacter(character);
        }

        SessionUpdated?.Invoke();
    }

    public void AddCharacter(PlayerStats character)
    {
        Characters.Add(character.Key, character);
        sm.AddCharacter(character);
    }

    public PlayerStats? GetCharacter(string key)
    {
        if (key is not null) {
            PlayerStats character;
            return Characters.TryGetValue(key, out character!) ? character : null;
        }
        return null;
    }
}
