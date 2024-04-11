namespace Logic;

/// <summary>
///     The stats for a standard D&D character.
/// </summary
public class PlayerStats
{
    // A default fighter for players to mess with
    // TODO: Move this to a "Defaults" class located in another file?

    // All string info (just getting stuff layed out for the DB)
    public string PlayerName { get; set; }
    public string Description { get; set; } 
    public string Alignment { get; set; }
    public string Height { get; set; }

    // Base stats
    public int Level { get; set; }
    public Class Class { get; set; }
    public Race Race { get; set; }
    public int InitiativeBonus { get; set; }
    public int Speed { get; set; } // In feet

    // Base stats
    // List of a tuple for hit dice. This allows for multiple classes
    public List<(Class Class, Dice HitDice, int Total, int Amount)> HitDice;
    public int Proficiency; // Prof bonus

    // Main Stats
    STR STR = new();
    DEX DEX = new();
    CON CON = new();
    INT INT = new();
    WIS WIS = new();
    CHA CHA = new();
    
    // Returns the applicable modifier stat
}

// AbilityBase is a set of utilities for any abilities
// Already includes a private base _value and modifier
// with setters taht handle things
public abstract class AbilityBase
{
    public static int SetStatInBounds(int value) {
        if (value > 20) return 20;
        if (value < 1) return 1;
        return value;
    }

    public static int returnModifier(int value) {
        return (int)Math.Floor(((decimal)value - 10)/2);
    }
    
    protected int _v;
    protected int _value {
        get { return _v; }
        set {
            
        }
    }
    protected int _modifier;
}

public class STR : AbilityBase
{
    // The actual STR stat
    public int Value {
        set {
            _value = SetStatInBounds(value);
            
        }
        get {
            return _value;
        }} // The normal value (1-20)

    // The actual modifier derived from
    public int Modifier { private set; get; }
    public int SavingThrow;
    public int Athletics;
}

public class DEX
{
    public int Stat;
    public int SavingThrow;
    public int Acrobatics;
    public int SleightOfHand;
    public int Stealth;

public class CON
{
    public int Stat;
    public int SavingThrow;
}

public class INT
{
    public int Stat;
    public int SavingThrow;
    public int Arcana;
    public int History;
    public int Investigation;
    public int Nature;
    public int Religion;
}

public class WIS
{

    public int Stat;
    public int SavingThrow;
    public int AnimalHandling;
    public int Insight;
    public int Medicine;
    public int Perception;
    public int Survival;
}

public class CHA
{
    public int Stat;
    public int SavingThrow;
    public int Deception;
    public int Intimidation;
    public int Performance;
    public int Persuasion;
}

public class Defaults
{
    public static PlayerStats HumanFighter = new() {
        PlayerName = "Steve",
        Description = "The COOLEST guy.",
        Alignment = "True Neutral",
        Height = "6'0\"",

        Level = 1,
        Class = Class.Fighter,
        Race = Race.Human,
        
//        HitDice = new() { () }

    };
   
}
