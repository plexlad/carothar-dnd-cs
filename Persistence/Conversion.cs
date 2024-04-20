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

        // My lovely null handling with defaults
        character.STR = JsonSerializer.Deserialize<STR>(characterData.STR, jsonOptions)
            ?? new STR(character, 10, false, 0);

        character.DEX = JsonSerializer.Deserialize<DEX>(characterData.DEX, jsonOptions)
            ?? new DEX(character, 10, false, 0, 0, 0);

        character.CON = JsonSerializer.Deserialize<CON>(characterData.CON, jsonOptions)
            ?? new CON(10, false);

        character.INT = JsonSerializer.Deserialize<INT>(characterData.INT, jsonOptions)
            ?? new INT(character, 10, false, 0, 0, 0, 0, 0);

        character.WIS = JsonSerializer.Deserialize<WIS>(characterData.WIS, jsonOptions)
            ?? new WIS(character, 10, false, 0, 0, 0, 0, 0);

        character.CHA = JsonSerializer.Deserialize<CHA>(characterData.CHA, jsonOptions)
            ?? new CHA(character, 10, false, 0, 0, 0, 0);
        
        return character;
    }

    // While some of the data might be incorrect when stored using the serialize
    // method below, this means that the users data will not be removed if the
    // system goes bad. Same with above method.
    public static PlayerStatsData ConvertCharacter(PlayerStats character)
    {
        PlayerStatsData characterData = new() {
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
        return new Session("default", "SYSTEM");
    }

    public static SessionData ConvertSession(Session session)
    {
        return new SessionData();
    }
}
