namespace Persistence;

using SQLite;
using Logic.Game;
using Logic.Session;
using Logic.Login;

public class SQLiteStoreManager : IStorageManager
{
    private SQLiteConnection _connection;

    public void AddCharacter(PlayerStatsData character)
    {
        _connection.Insert(character);
    }

    public void AddSession(Session session)
    {
        _connection.Insert(session);
    }

    public PlayerStatsData GetCharacter(string key)
    {
        return _connection.Table<PlayerStatsData>().FirstOrDefault(x => x.Key == key);
    }

    public IEnumerable<PlayerStatsData> GetSessionCharacters(string sessionKey)
    {
        List<PlayerStatsData> characters = new();
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

    public void UpdateCharacter(PlayerStatsData character)
    {
        _connection.Update(character);
    }

    public SQLiteStoreManager()
    {
        _connection = new SQLiteConnection("carothardata.db");
        _connection.CreateTable<PlayerStatsData>();
        _connection.CreateTable<SessionData>();
    }
}
