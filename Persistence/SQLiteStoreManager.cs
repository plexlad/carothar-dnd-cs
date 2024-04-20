namespace Persistence;

using SQLite;
using Logic.Game;
using Logic.Session;
// For future reference if I want to write a login system
// using Logic.Login;

public class SQLiteStoreManager : IStorageManager
{
    private SQLiteConnection _connection;

    public void AddCharacter(PlayerStats character)
    {
        _connection.Insert(Conversion.ConvertCharacter(character));
    }

    public void AddSession(Session session)
    {
        _connection.Insert(Conversion.ConvertSession(session));
    }

    public PlayerStats GetCharacter(string key)
    {
        PlayerStatsData output = _connection.Table<PlayerStatsData>().FirstOrDefault(x => x.Key == key);
        return Conversion.ConvertCharacter(output);
    }

    public IEnumerable<PlayerStats> GetSessionCharacters(string sessionKey)
    {
        List<PlayerStats> characters = new();
        foreach(string key in GetSession(sessionKey).Characters.Keys.ToList())
        {
            characters.Add(GetCharacter(key));
        }
        return characters;
    }

    public Session GetSession(string key)
    {
        SessionData data = _connection.Table<SessionData>().FirstOrDefault(x => x.Key == key);
        return Conversion.ConvertSession(data);
    }

    public void UpdateCharacter(PlayerStats character)
    {
        PlayerStatsData characterData = Conversion.ConvertCharacter(character);
        _connection.Update(characterData);
    }

    public SQLiteStoreManager()
    {
        _connection = new SQLiteConnection("carothardata.db");
        _connection.CreateTable<PlayerStatsData>();
        _connection.CreateTable<SessionData>();
    }
}
