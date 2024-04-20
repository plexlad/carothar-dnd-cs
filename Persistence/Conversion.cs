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

        // My lovely null handling with defaults
        character.STR = JsonSerializer.Deserialize<STR>(characterData.STR)
            ?? new STR(character, 10, false, 0);

        character.DEX = JsonSerializer.Deserialize<DEX>(characterData.DEX)
            ?? new DEX(character, 10, false, 0, 0, 0);

        character.CON = JsonSerializer.Deserialize<CON>(characterData.DEX)
            ?? new CON(10, false);

        character.INT = JsonSerializer.Deserialize<INT>(characterData.INT)
            ?? new INT(character, 10, false, 0, 0, 0, 0, 0);

        character.WIS = JsonSerializer.Deserialize<WIS>(characterData.WIS)
            ?? new WIS(character, 10, false, 0, 0, 0, 0, 0);

        character.CHA = JsonSerializer.Deserialize<CHA>(characterData.CHA)
            ?? new CHA(character, 10, false, 0, 0, 0, 0);
        
        // TODO; Class info and rest of conversions
        return character;
    }

    public static PlayerStatsData ConvertCharacter(PlayerStats character)
    {

    }

    public static Session ConvertSession(SessionData sessionData)
    {

    }

    public static SessionData ConvertSession(Session session)
    {

    }
}
