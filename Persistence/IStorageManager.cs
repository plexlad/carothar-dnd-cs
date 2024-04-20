namespace Persistence;

using Logic.Game;
using Logic.Session;
using Logic.Login;

public interface IStorageManager
{
    void AddCharacter(PlayerStatsData character);
    void AddSession(SessionData session);
    PlayerStatsData GetCharacter(string key);
    IEnumerable<PlayerStatsData> GetSessionCharacters(string sessionKey);
    SessionData GetSession(string key);
    void UpdateCharacter(PlayerStatsData character);
    public static IStorageManager Instance { get; } = new SQLiteStoreManager();
}
