namespace Logic;
// This includes the definition for Ability base and the standard D&D classes

// AbilityBase is a set of utilities for any abilities
// Already includes a private base _value (1-20) and _modifier bonus (-5 to 5)
// with setters taht handle things
public abstract class AbilityBase {
    // Value stuff
    private int _v { get; set; } // The private version of value
    protected int Value {
        get { return _v; }
        set {
            // Cannot be over 30 (for stats reasons)
            if (value > 30) _v = 30;
            else if (value < 1) _v = 1;
            else _v = value;
            
            _modifier = PlayerStats.returnModifier(_v);
        }
    }

    protected int _modifier { private set; get; }
    public int Modifier => _modifier;

    public bool SavingThrow { get; set; }

    // Returns the actual bonus based off of an ability
    public int returnStatModifier(int value, Skill skill, int proficiency) {
        return Modifier + skill.Mod + (skill.ProficiencyMultiplier * proficiency);
    }
    
}

// The individual skills (proficiencies) that are a part of the AbilityBase
// derived classes
public class Skill {
    public int Mod { get; set; } = 0;
    public int ProficiencyMultiplier { get; set; }
    private PlayerStats parent { get; set; }

    public Skill(PlayerStats parent) {
        this.parent = parent;
    }

    // Proficiency multiplier is the amount you want your proficiency to be
    // multiplied by. 1 for proficiency, 2 for mastery, etc.
    public Skill(PlayerStats parent, int profMultiplier, int mod) : this(parent) {
        Mod = mod;
        ProficiencyMultiplier = profMultiplier;
    }
}

public class STR : AbilityBase {
    // Modifier and value is already defined
    public Skill Athletics;

    public STR(
        PlayerStats parent,
        int value,
        int savingThrow,
        int athleticsMultiplier
    ) {
        Value = value;
        SavingThrow = SavingThrow;
        Athletics = new(parent, athleticsMultiplier, 0);
    }
}

public class DEX : AbilityBase {
    public Skill Acrobatics;
    public Skill SleightOfHand;
    public Skill Stealth;

    public DEX(
        PlayerStats parent,
        int value,
        bool savingThrow,
        int acrobaticsMultiplier,
        int sleightOfHandMultiplier,
        int stealthModifier
    ) {
        Value = value;
        SavingThrow = savingThrow;
        Acrobatics = new(parent, acrobaticsMultiplier, 0);
        SleightOfHand = new(parent, sleightOfHandMultiplier, 0);
        Stealth = new(parent, stealthModifier, 0);
    }
}

// Constitution only stats are managed in the AbilityBase
public class CON : AbilityBase { 
    public CON(
        int value,
        bool savingThrow
    ) {
        Value = value;
        SavingThrow = savingThrow;
    }
};

public class INT : AbilityBase {
    public Skill Arcana;
    public Skill History;
    public Skill Investigation;
    public Skill Nature;
    public Skill Religion;

    public INT(
        PlayerStats parent,
        int value,
        bool savingThrow,
        int arcanaModifier,
        int historyModifier,
        int investigationModifier,
        int natureModifier,
        int religionModifier
    ) {
        Value = value;
        SavingThrow = savingThrow;
        Arcana = new(parent, arcanaModifier, 0);
        History = new(parent, historyModifier, 0);
        Investigation = new(parent, investigationModifier, 0);
        Nature = new(parent, natureModifier, 0);
        Religion = new(parent, religionModifier, 0);
    }
}

public class WIS : AbilityBase {
    public Skill AnimalHandling;
    public Skill Insight;
    public Skill Medicine;
    public Skill Perception;
    public Skill Survival;

    public WIS(
        PlayerStats parent,
        int value,
        bool savingThrow,
        int animalHandlingModifier,
        int insightModifier,
        int medicineModifier,
        int perceptionModifier,
        int survivalModifier
    ) {
        Value = value;
        SavingThrow = savingThrow;
        AnimalHandling = new(parent, animalHandlingModifier, 0);
        Insight = new(parent, insightModifier, 0);
        Medicine = new(parent, medicineModifier, 0);
        Perception = new(parent, perceptionModifier, 0);
        Survival = new(parent, survivalModifier, 0);
    }
}

public class CHA : AbilityBase {
    public Skill Deception;
    public Skill Intimidation;
    public Skill Performance;
    public Skill Persuasion;

    public CHA(
        PlayerStats parent,
        int value,
        bool savingThrow,
        int deceptionModifier,
        int intimidationModifier,
        int performanceModifier,
        int persuasionModifier
    ) {
        Value = value;
        SavingThrow = savingThrow;
        Deception = new(parent, deceptionModifier, 0);
        Intimidation = new(parent, intimidationModifier, 0);
        Performance = new(parent, performanceModifier, 0);
        Persuasion = new(parent, persuasionModifier, 0);
    }
}
