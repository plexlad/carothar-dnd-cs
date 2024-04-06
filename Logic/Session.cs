// These are the the instances of games that people can connect to
// Use the instance manager to manage sets of instances

namespace Logic;

public class Session
{
    public string Key { get; }
    
    public Session()
    {
        Guid g = Guid.NewGuid();
        Key = g.ToString().Replace("-", "");
    }
}
