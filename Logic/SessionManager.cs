namespace Logic.Session;

public class SessionManager
{
    public static SessionManager Instance = new();

    private static Dictionary<string, Session> Sessions = new();

    // Returns reference to the newly created session
    public Session AddSession(string name)
    {
        // Creates a unique ID
        Session s = new();
        // Adds the new session using the id as the key
        Sessions.Add(s.Key, s);
        return s;
    }

    // Returns a session from the ID
    // This can be used for players to connect to a session
    public Session? GetSessionFromId(string id)
    {
        Session? output = Sessions.TryGetValue(id, out output) ? output : null;
        return output;
    }

    public static bool SessionIdValid(string id)
    {
        return Sessions.ContainsKey(id);
    }
}
