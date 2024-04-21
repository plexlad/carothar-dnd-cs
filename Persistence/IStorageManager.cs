namespace Persistence;

// TODO: Add login later
public interface IStorageManager
{
    void AddCharacter(PlayerStats character);
    void AddSession(Session session);
    PlayerStats GetCharacter(string key);
    IEnumerable<PlayerStats> GetSessionCharacters(string sessionKey);
    Session GetSession(string key);
    void UpdateCharacter(PlayerStats character);
    public static IStorageManager Instance { get; } = new SQLiteStoreManager();
}
