namespace Logic;

/// <summary>
///     The stats for a standard D&D character. Documentation available on 
///     GitHub.
/// </summary
public class PlayerStats
{
    // A default fighter for players to mess with
    // TODO: Move this to a "Defaults" class located in another file?

    // All string info (just getting stuff layed out for the DB)
    public string PlayerName { get; set; }
    public string Description { get; set; } // Anything else that is not used
    public string Alignment { get; set; }
    public string Height { get; set; }

    // Base stats
    public int Level { get; private set; }

    public List<(Class Class, int Level)> ClassList;
    public Race Race { get; set; }
    public int InitiativeBonus { get; set; }
    public int Speed { get; set; } // In feet

    // Base stats
    // List of a tuple for hit dice. This allows for multiple classes
    public List<(Class Class, Dice HitDice, int Total, int Amount)> HitDice;
    public int Proficiency; // Prof bonus

    // Main Stats
    public STR STR;
    public DEX DEX;
    public CON CON;
    public INT INT;
    public WIS WIS;
    public CHA CHA;

    // Returns the base modifier for an ability score
    public static int returnModifier(int value) {
        return (int)Math.Floor(((decimal)value - 10)/2);
    }
}
