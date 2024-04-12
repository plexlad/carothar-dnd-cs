namespace Logic;

using System.Collections.ObjectModel;

/// <summary>
///     The stats for a standard D&D character. Documentation available on 
///     GitHub.
/// </summary
public class PlayerStats
{
    // A default fighter for players to mess with
    // TODO: Move this to a "Defaults" class located in another file?

    // All string and non stat info (just getting stuff layed out for the DB)

    // The version can be used to update characters to the new version,
    // or even use the original version if updated
    public int Version { get; } = 0;
    public string PlayerName { get; set; }
    public string Description { get; set; } // Anything else that is not used
    public string Alignment { get; set; }
    public string Height { get; set; }
    public string Meta { get; private set; } // Just in case (Could be serialized JSON?)

    // Base stats
    public int Level { get; private set; }

    public ObservableCollection<(Class Class, int Level)> ClassList;
    public Race Race { get; set; }
    public int InitiativeBonus { get; set; }
    public int Speed { get; set; } // In feet

    // A list that has the functionality of notifying an event when it is modified
    public ObservableCollection<(Class Class, Dice HitDice, int Total, int Amount)> ClassInfo;
    public int Proficiency; // Prof bonus

    // Main Stats
    public STR STR;
    public DEX DEX;
    public CON CON;
    public INT INT;
    public WIS WIS;
    public CHA CHA;

    public PlayerStats() {
        ClassInfo = new();
        ClassInfo.CollectionChanged += () => {
            foreach() {

            }
        };
    }

    // Returns the base modifier for an ability score
    public static int returnModifier(int value) {
        return (int)Math.Floor(((decimal)value - 10)/2);
    }
}
