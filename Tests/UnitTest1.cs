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
}
