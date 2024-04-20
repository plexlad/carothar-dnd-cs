namespace Tests;

// Using the conversion system for storing data is janky, but I do like that it
// converts things to a format that is much more intuitive to use and allows
// me to use more of the features of C# that I enjoy. That being said, I totally
// would've designed this much better if not for the due date

using System.Text.Json;
using Persistence;
using Logic.Game;

public class ConversionTests
{
    [Fact]
    public void ConvertFromPlayerStatsDataToPlayerStats()
    {
        STR str = new(new PlayerStats(), 10, false, 1);
        
        // How it is formatted
        PlayerStatsData characterData = new() {
            STR = JsonSerializer.Serialize(str)
        };
    
        // Tests what the attribute should be
        PlayerStats convertedCharacter = Conversion.ConvertCharacter(characterData);
        convertedCharacter.STR.Athletics.ProficiencyMultiplier.Should().Be(1);
    }

    [Fact]
    public void ConvertFromPlayerStatsToPlayerStatsData()
    {
        STR str = new(new PlayerStats(), 10, false, 1);

        PlayerStats character = new() {
            STR = str
        };

        PlayerStatsData characterData = Conversion.ConvertCharacter(character);

        characterData.STR.Should().Be(JsonSerializer.Serialize(str));
    }
}
