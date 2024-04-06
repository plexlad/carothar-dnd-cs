namespace Logic;

public class SessionManager
{
    public static Dictionary<string, Session> Sessions = new();

    // Returns reference to the newly created session
    public static Session AddSession()
    {
        // Creates a unique ID
        Session s = new();
        // Adds the new session using the id as the key
        Sessions.Add(s.Key, s);
        return s;
    }

    // Returns a session from the ID
    // This can be used for players to connect to a session
    public static Session? GetInstanceFromString(string id)
    {
        // TODO: Set up error and case handling for out of bounds cases
        return Sessions[id];
    }
}
