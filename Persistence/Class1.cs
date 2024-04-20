namespace Persistence;

using SQLite;
using Logic.Game;
using System.Collections.ObjectModel;

[Table("Characters")]
public class PlayerStatsData
{
    [PrimaryKey]
    public string Key { get; set; }
    public int Version;
    public string PlayerName;
    public string Name;
    public string Description; // Anything else that is not used
    public string Alignment;
    public string Height;
    public string Inventory;
    public string? Meta; // Just in case (Could be serialized JSON?)

    // Base stats
    public int Level;
    public int Race;
    public int Background;
    public int InitiativeBonus;
    public int Speed; // In feet
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
