namespace Persistence;

using System.Text.Json;
using Logic.Game;
using Logic.Session;

// This whole conversion class is convoluted, I know
// but I do like the ability to use a format that I like.
// I'm hoping to find a
public class Conversion
{
    public static PlayerStats ConvertCharacter(PlayerStatsData characterData)
    {
        PlayerStats character = new() {
            Version = characterData.Version,
            Key = characterData.Key,
            PlayerName = characterData.PlayerName,
            Name = characterData.Name,
            Description = characterData.Description,
            Alignment = characterData.Alignment,
            Height = characterData.Height,

            Race = (Race)characterData.Race,
            Background = (Background)characterData.Background,
            InitiativeBonus = characterData.InitiativeBonus,
            Speed = characterData.Speed,
            HP = characterData.HP,
            TotalHP = characterData.TotalHP,
            AC = characterData.AC
        };

        JsonSerializerOptions jsonOptions = new JsonSerializerOptions()
        { 
            IgnoreReadOnlyProperties = true,
            IgnoreReadOnlyFields = true,
            IncludeFields = true,
        };

        // References don't serialize

        // My lovely null handling with defaults
        character.STR = JsonSerializer.Deserialize<STR>(characterData.STR, jsonOptions);
        //character.STR.Athletics.parent = character.STR;
        //character.STR.Athletics.superParent = character;

        character.DEX = JsonSerializer.Deserialize<DEX>(characterData.DEX, jsonOptions);
        //character.DEX.Acrobatics.parent = character.DEX;
        //character.DEX.Acrobatics.superParent = character;
        //character.DEX.SleightOfHand.parent = character.DEX;
        //character.DEX.SleightOfHand.superParent = character;
        //character.DEX.Stealth.parent = character.DEX;
        //character.DEX.Stealth.superParent = character;

        character.CON = JsonSerializer.Deserialize<CON>(characterData.CON, jsonOptions);

        character.INT = JsonSerializer.Deserialize<INT>(characterData.INT, jsonOptions);
        //character.INT.Arcana.parent = character.INT;
        //character.INT.Arcana.superParent = character;
        //character.INT.History.parent = character.INT;
        //character.INT.History.superParent = character;
        //character.INT.Investigation.parent = character.INT;
        //character.INT.Investigation.superParent = character;
        //character.INT.Nature.parent = character.INT;
        //character.INT.Nature.superParent = character;
        //character.INT.Religion.parent = character.INT;
        //character.INT.Religion.superParent = character;

        character.WIS = JsonSerializer.Deserialize<WIS>(characterData.WIS, jsonOptions);
        //character.WIS.AnimalHandling.parent = character.WIS;
        //character.WIS.AnimalHandling.superParent = character;
        //character.WIS.Insight.parent = character.WIS;
        //character.WIS.Insight.superParent = character;
        //character.WIS.Medicine.parent = character.WIS;
        //character.WIS.Medicine.superParent = character;
        //character.WIS.Perception.parent = character.WIS;
        //character.WIS.Perception.superParent = character;
        //character.WIS.Survival.parent = character.WIS;
        //character.WIS.Survival.superParent = character;

        character.CHA = JsonSerializer.Deserialize<CHA>(characterData.CHA, jsonOptions);
        //character.CHA.Deception.parent = character.CHA;
        //character.CHA.Deception.superParent = character;
        //character.CHA.Intimidation.parent = character.CHA;
        //character.CHA.Intimidation.superParent = character;
        //character.CHA.Persuasion.parent = character.CHA;
        //character.CHA.Persuasion.superParent = character;
        //character.CHA.Performance.parent = character.CHA;
        //character.CHA.Performance.superParent = character;
        
        return character;
    }

    // While some of the data might be incorrect when stored using the serialize
    // method below, this means that the users data will not be removed if the
    // system goes bad. Same with above method.
    public static PlayerStatsData ConvertCharacter(PlayerStats character)
    {
        PlayerStatsData characterData = new() {
            Version = character.Version,
            Key = character.Key,
            PlayerName = character.PlayerName,
            Name = character.Name,
            Description = character.Description,
            Alignment = character.Alignment,
            Height = character.Height,

            Race = (int)character.Race,
            Background = (int)character.Background,
            InitiativeBonus = character.InitiativeBonus,
            Speed = character.Speed,
            HP = character.HP,
            TotalHP = character.TotalHP,
            AC = character.AC
        };

        // My lovely null handling with defaults (not really)
        characterData.STR = JsonSerializer.Serialize<STR>(character.STR)
            ?? JsonSerializer.Serialize(new STR(character, 10, false, 0));

        characterData.DEX = JsonSerializer.Serialize<DEX>(character.DEX)
            ?? JsonSerializer.Serialize(new DEX(character, 10, false, 0, 0, 0));

        characterData.CON = JsonSerializer.Serialize<CON>(character.CON)
            ?? JsonSerializer.Serialize(new CON(10, false));

        characterData.INT = JsonSerializer.Serialize<INT>(character.INT)
            ?? JsonSerializer.Serialize(new INT(character, 10, false, 0, 0, 0, 0, 0));

        characterData.WIS = JsonSerializer.Serialize<WIS>(character.WIS)
            ?? JsonSerializer.Serialize(new WIS(character, 10, false, 0, 0, 0, 0, 0));

        characterData.CHA = JsonSerializer.Serialize<CHA>(character.CHA)
            ?? JsonSerializer.Serialize(new CHA(character, 10, false, 0, 0, 0, 0));

        return characterData;
    }

    public static Session ConvertSession(SessionData sessionData)
    {
        Session session = new() {
            Name = sessionData.Name,
            Key = sessionData.Key,
            CreatedBy = sessionData.CreatedBy,
            Users = JsonSerializer.Deserialize<List<string>>(sessionData.Users),
            Characters = JsonSerializer.Deserialize<Dictionary<string, PlayerStats>>(sessionData.Characters)
        };

        return session;
    }

    public static SessionData ConvertSession(Session session)
    {
        SessionData sessionData = new() {
            Name = session.Name,
            Key = session.Key,
            CreatedBy = session.CreatedBy,
            Users = JsonSerializer.Serialize<List<string>>(session.Users),
            Characters = JsonSerializer.Serialize<Dictionary<string, PlayerStats>>(session.Characters)
        };

        return sessionData;
    }
}
