namespace Persistence;

using SQLite;
using Logic.Game;
using System.Collections.ObjectModel;

[Table("Characters")]
public class PlayerStatsData
{
    [PrimaryKey]
    public string Key { get; set; }
    public int Version { get; set; }
    public string PlayerName { get; set; }
    public string Name { get; set; }
    public string Description { get; set; } // Anything else that is not used
    public string Alignment { get; set; }
    public string Height { get; set; }
    public string Inventory { get; set; }
    public string? Meta { get; set; } // Just in case (Could be serialized JSON?)

    // Base stats
    public int Level { get;  set; }
    public int Race { get; set; }
    public int Background { get; set; }
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
    public string STR;
    public string DEX;
    public string CON;
    public string INT;
    public string WIS;
    public string CHA;
}

[Table("Sessions")]
public class SessionData
{
    [PrimaryKey]
    public string Key { get; set; } 
}
