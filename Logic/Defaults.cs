namespace Logic.Game;

public class Defaults
{
    public static PlayerStats HumanFighter(string name, string playerName)
    {
        PlayerStats output = new() {
            PlayerName = playerName,
            Name = name,
            Description = "The COOLEST guy.",
            Alignment = "True Neutral",
            Height = "6'0\"",
            
            Race = Race.Human,
            InitiativeBonus = 0,
            Speed = 35,
            HP = 10,
            TotalHP = 10,
            AC = 11,
        };

        output.STR = new(output, 10, true, 1);
        output.DEX = new(output, 10, false, 0, 0, 0);
        output.CON = new(10, true);
        output.INT = new(output, 10, false, 0, 0, 0, 0, 0);
        output.WIS = new(output, 10, false, 0, 0, 0, 0, 0);
        output.CHA = new(output, 10, false, 0, 0, 0, 0);

        output.ClassInfo.Add(new ClassInfoEntry() {
            Class = Class.Fighter,
            Level = 1,
            HitDice = Dice.d10,
            HitDiceTotal = 1
        });

        return output;
    }
}
