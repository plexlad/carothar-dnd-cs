namespace Tests;
using Logic;

public class UnitTest1
{
    [Fact]
    public void SkillConstructsProperlyWithOnlyParent()
    {
        Skill s = new(new PlayerStats());

        Assert.NotNull(s);
    }

    [Fact]
    public void AbilityBaseSetsValuesCorrectlyWhenAbove()
    {
        AbilityBase ab = new();

        ab.Value = 32;

        Assert.True(ab.Value == 20);
        Assert.True(ab.Modifier == 5);
    }

    [Fact]
    public void AbilityBaseSetsValuesCorrectlyWhenBelow()
    {
        AbilityBase ab = new();

        ab.Value = -1;

        Assert.True(ab.Value == 1);
        Assert.True(ab.Modifier == -5);
    }

    [Fact]
    public void SkillReturnsProperModifier()
    {
        PlayerStats p = new();
        Skill s = new(p, 1, 3); // Simulate a skill that has a +3 bonus
        
        p.ClassInfo.Add(new ClassInfoEntry() { Level = 5 });
        
        Assert.True(s.Modifier == 6);
    }

    [Fact]
    public void STRInitializesProperly()
    {
        PlayerStats p = new();
        p.ClassInfo.Add(new ClassInfoEntry() { Level = 1 });
        STR str = new(p, 16, true, 1); // Simulates proficiency in strength

        Assert.True(p.Proficiency == 2);
        Assert.True(str.Modifier == 3);
        Assert.True(str.SavingThrow);
        Assert.True(str.Athletics.ProficiencyMultiplier == 1);
        Assert.True(str.Athletics.Modifier == 5);
    }
}
