namespace Logic.Session;

public class SessionManager
{
    public static SessionManager Instance = new();

    private static Dictionary<string, Session> Sessions = new();

    // Returns reference to the newly created session
    public Session AddSession(string name, string username)
    {
        // Creates a unique ID, generates another if id already exists
        Session s = new(name, username); // Good ol' recursion
        if (SessionIdValid(s.Key))
        {
            s = AddSession(name, username);
        }
        else
        {
            // Adds the new session using the id as the key
            Sessions.Add(s.Key, s);
        }
        return s;
    }

    // Returns a session from the ID
    // This can be used for players to connect to a session
    public Session? GetSessionFromKey(string key)
    {
        Session? output = Sessions.TryGetValue(key, out output) ? output : null;
        return output;
    }

    public static bool SessionIdValid(string id)
    {
        return Sessions.ContainsKey(id);
    }
}
