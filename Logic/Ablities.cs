namespace Logic.Game;
// This includes the definition for Ability base and the standard D&D classes

// AbilityBase is a set of utilities for any abilities
// Already includes a private base _value (1-20) and _modifier bonus (-5 to 5)
// with setters taht handle things
public class AbilityBase {
    // Value stuff
    private int _v { get; set; } // The private version of value
    public int Value {
        get { return _v; }
        set {
            // Cannot be over 30 (for stats reasons)
            if (value > 20) _v = 20;
            else if (value < 1) _v = 1;
            else _v = value;
            
            _modifier = PlayerStats.returnModifier(_v);
        }
    }

    protected int _modifier { private set; get; }
    public int Modifier => _modifier;

    public bool SavingThrow { get; set; }
}

// The individual skills (proficiencies) that are a part of the AbilityBase
// derived classes
public class Skill {
    public int Mod { get; set; } = 0;
    public int ProficiencyMultiplier { get; set; }
    private PlayerStats superParent { get; set; }
    private AbilityBase parent { get; set; }

    public int Modifier => Mod + parent.Modifier + (ProficiencyMultiplier * superParent.Proficiency);

    public Skill(PlayerStats superParent, AbilityBase parent) {
        this.parent = parent;
        this.superParent = superParent;
    }

    // Proficiency multiplier is the amount you want your proficiency to be
    // multiplied by. 1 for proficiency, 2 for mastery, etc.
    public Skill(PlayerStats superParent, AbilityBase parent, int profMultiplier, int mod) : this(superParent, parent) {
        Mod = mod;
        ProficiencyMultiplier = profMultiplier;
    }
}

public class STR : AbilityBase {
    // Modifier and value is already defined
    public Skill Athletics;

    public STR(
        PlayerStats superParent,
        int value,
        bool savingThrow,
        int athleticsMultiplier
    ) {
        Value = value;
        SavingThrow = savingThrow;
        Athletics = new(superParent, this, athleticsMultiplier, 0);
    }
}

public class DEX : AbilityBase {
    public Skill Acrobatics;
    public Skill SleightOfHand;
    public Skill Stealth;

    public DEX(
        PlayerStats superParent,
        int value,
        bool savingThrow,
        int acrobaticsMultiplier,
        int sleightOfHandMultiplier,
        int stealthModifier
    ) {
        Value = value;
        SavingThrow = savingThrow;
        Acrobatics = new(superParent, this, acrobaticsMultiplier, 0);
        SleightOfHand = new(superParent, this, sleightOfHandMultiplier, 0);
        Stealth = new(superParent, this, stealthModifier, 0);
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
        PlayerStats superParent,
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
        Arcana = new(superParent, this, arcanaModifier, 0);
        History = new(superParent, this, historyModifier, 0);
        Investigation = new(superParent, this, investigationModifier, 0);
        Nature = new(superParent, this, natureModifier, 0);
        Religion = new(superParent, this, religionModifier, 0);
    }
}

public class WIS : AbilityBase {
    public Skill AnimalHandling;
    public Skill Insight;
    public Skill Medicine;
    public Skill Perception;
    public Skill Survival;

    public WIS(
        PlayerStats superParent,
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
        AnimalHandling = new(superParent, this, animalHandlingModifier, 0);
        Insight = new(superParent, this, insightModifier, 0);
        Medicine = new(superParent, this, medicineModifier, 0);
        Perception = new(superParent, this, perceptionModifier, 0);
        Survival = new(superParent, this, survivalModifier, 0);
    }
}

public class CHA : AbilityBase {
    public Skill Deception;
    public Skill Intimidation;
    public Skill Performance;
    public Skill Persuasion;

    public CHA(
        PlayerStats superParent,
        int value,
        bool savingThrow,
        int deceptionModifier,
        int intimidationModifier,
        int performanceModifier,
        int persuasionModifier
    ) {
        Value = value;
        SavingThrow = savingThrow;
        Deception = new(superParent, this, deceptionModifier, 0);
        Intimidation = new(superParent, this, intimidationModifier, 0);
        Performance = new(superParent, this, performanceModifier, 0);
        Persuasion = new(superParent, this, persuasionModifier, 0);
    }
}
