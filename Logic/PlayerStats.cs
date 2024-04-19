namespace Logic.Game;

// For the event notifications
using System.Collections.ObjectModel;
using System.Text;
using SimpleCrypto; // For key generation

// Used for tuple stats for level info
/// <summary>
///     Class that displays information for the class. Does not multiclass
///     (use a list) for that!
/// </summary>
public class ClassInfoEntry
{
    public Class Class { get; set; }
    public int Level { get; set; }
    public Dice HitDice { get; set; }
    public int HitDiceTotal { get; set; }
}
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
    public string Key { get; }
    public string PlayerName { get; set; }
    public string Name { get; set; }
    public string Description { get; set; } // Anything else that is not used
    public string Alignment { get; set; }
    public string Height { get; set; }
    public List<string> Inventory { get; set; } = new();
    public string? Meta { get; private set; } // Just in case (Could be serialized JSON?)

    // Base stats
    public int Level { get; private set; }
    public Race Race { get; set; }
    public Background Background { get; set; }
    public int InitiativeBonus { get; set; }
    public int Speed { get; set; } // In feet
    // A list that has the functionality of notifying an event when it is modified
    private ObservableCollection<ClassInfoEntry> _classInfo;
    public ObservableCollection<ClassInfoEntry> ClassInfo => _classInfo;

    // Number Stats
    public int HP { get; set; } // Health points
    public int TotalHP { get; set; }
    public int AC { get; set; } // Armor class
    public int Proficiency { get; private set; } // Prof bonus

    // Main Stats
    public STR STR;
    public DEX DEX;
    public CON CON;
    public INT INT;
    public WIS WIS;
    public CHA CHA;

    public PlayerStats() {
        _classInfo = new();
        _classInfo.CollectionChanged += (_, _) => {
            // Resets the level
            Level = 0;
            foreach(ClassInfoEntry entry in ClassInfo) {
                Level += entry.Level;
            }

            // Sets the proficiency bonus
            Proficiency = Level switch {
                <= 4 => 2,
                <= 8 => 3,
                <= 12 => 4,
                <= 16 => 5,
                _ => 6
            };
        };
        
        // Generate a random key
        Key = RandomPassword.Generate(16, PasswordGroup.Lowercase, PasswordGroup.Uppercase);
    }

    public string ReturnClassList()
    {
        StringBuilder output = new();
        foreach(ClassInfoEntry info in this.ClassInfo)
        {
            output.Append($", {info.Class} {info.Level}");
        }
        // Removes the first comma and space
        return output.ToString().Remove(0, 1);
    }

    // Returns the base modifier for an ability score
    public static int returnModifier(int value) {
        return (int)Math.Floor(((decimal)value - 10)/2);
    }
}
