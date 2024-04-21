namespace Tests;
using Logic.Game;
using FluentAssertions;

public class GameLogicTests
{
    [Fact]
    public void SkillConstructsProperlyWithOnlyParent()
    {
        Skill s = new(new PlayerStats(), new AbilityBase());

        s.Should().NotBeNull();
    }

    [Fact]
    public void AbilityBaseSetsValuesCorrectlyWhenAbove()
    {
        AbilityBase ab = new();

        ab.Value = 32;

        ab.Value.Should().Be(20);
        ab.Modifier.Should().Be(5);
    }

    [Fact]
    public void AbilityBaseSetsValuesCorrectlyWhenBelow()
    {
        AbilityBase ab = new();

        ab.Value = -1;
    
        ab.Value.Should().Be(1);
        ab.Modifier.Should().Be(-5);
    }

    [Fact]
    public void SkillReturnsProperModifier()
    {
        PlayerStats p = new();
        AbilityBase a = new() { Value = 16 };
        Skill s = new(p, a, 1, 3); // Simulate a skill that has a +3 bonus
        
        p.ClassInfo.Add(new ClassInfoEntry() { Level = 5 });
        
        s.Modifier.Should().Be(9);
    }

    [Fact]
    public void STRInitializesProperly()
    {
        PlayerStats p = new();
        p.ClassInfo.Add(new ClassInfoEntry() { Level = 1 });
        STR str = new(p, 16, true, 1); // Simulates proficiency in strength

        str.SavingThrow.Should().BeTrue();
        str.Athletics.Modifier.Should().Be(5);
    }

    [Fact]
    public void DEXInitializesProperly()
    {
        PlayerStats p = new();
        p.ClassInfo.Add(new ClassInfoEntry() { Level = 1 });
        DEX dex = new(p, 16, true, 1, 0, 0);

        dex.SavingThrow.Should().BeTrue();
        dex.Acrobatics.Modifier.Should().Be(5);
    }

    [Fact]
    public void CONInitializesProperly()
    {
        PlayerStats p = new();
        p.ClassInfo.Add(new ClassInfoEntry() { Level = 1 });
        CON con = new(16, true);

        con.SavingThrow.Should().BeTrue();
    }

    [Fact]
    public void INTInitializesProperly()
    {
        PlayerStats p = new();
        p.ClassInfo.Add(new ClassInfoEntry() { Level = 1 });
        INT intelligence = new(p, 16, true, 1, 0, 0, 0, 0);

        intelligence.SavingThrow.Should().BeTrue();
        intelligence.Arcana.Modifier.Should().Be(5);
    }

    [Fact]
    public void WISInitializesProperly()
    {
        PlayerStats p = new();
        p.ClassInfo.Add(new ClassInfoEntry() { Level = 1 });
        WIS wis = new(p, 16, true, 1, 0, 0, 0, 0);

        wis.SavingThrow.Should().BeTrue();
        wis.AnimalHandling.Modifier.Should().Be(5);
    }

    [Fact]
    public void CHAInitializesProperly()
    {
        PlayerStats p = new();
        p.ClassInfo.Add(new ClassInfoEntry() { Level = 1 });
        CHA cha = new(p, 16, true, 1, 0, 0, 0);

        cha.SavingThrow.Should().BeTrue();
        cha.Deception.Modifier.Should().Be(5);
    }
}
